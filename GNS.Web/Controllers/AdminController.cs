using System;
using System.Linq;
using System.Security.Claims;
using GNS.Core.Models;
using GNS.Web.Data;
using GNS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GNS.Web.Controllers
{
    public class AdminController : Controller
    {
        #region Fields
        private readonly GnsEntities gnsEntities;
        #endregion

        public AdminController( GnsEntities gnsEntities )
        {
            this.gnsEntities = gnsEntities;
        }

        public IActionResult Index()
        {
            var loggedInLedgerId = Guid.Parse( User.FindFirstValue( ClaimTypes.NameIdentifier ) );

            var viewmodel = new AdminViewModel()
            {
                Groups = gnsEntities.Groups
                    .Where( x => x.LedgerId == loggedInLedgerId )
                    .ToList(),
                Records = gnsEntities.Records
                    .Where( x => x.Group.LedgerId == loggedInLedgerId )
                    .ToList()
            };

            viewmodel.Groups.ForEach( group =>
            {
                group.Players = gnsEntities.Players
                    .Where( player => player.GroupId == group.GroupId )
                    .Select( x => x )
                    .ToList();

                group.Games = gnsEntities.Games
                    .Where( game => game.Group.GroupId == group.GroupId )
                    .Select( y => y )
                    .ToList();
            } );

            viewmodel.Records.ForEach(
                record => record.Game = gnsEntities.Games
                    .FirstOrDefault( game => game.GameId == record.Game.GameId ) );

            viewmodel.RecordForm = new RecordForm();
            FilterSelectOptions( viewmodel.RecordForm );

            return View( viewmodel );
        }

        [HttpPost]
        public IActionResult AddPerson( string firstName, string lastName, string email, Guid groupId )
        {
            var player = new Player()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PlayerId = Guid.NewGuid(),
                Group = gnsEntities.Groups.FirstOrDefault( x => x.GroupId == groupId )
            };

            gnsEntities.Players.Add( player );
            gnsEntities.SaveChanges();

            return Redirect( nameof( AdminController.Index ) );
        }

        [HttpPost]
        public IActionResult AddGroup( string groupName )
        {
            var gameGroup = new Group()
            {
                LedgerId = Guid.Parse( User.FindFirstValue( ClaimTypes.NameIdentifier ) ),
                Name = groupName,
                GroupId = Guid.NewGuid()
            };

            gnsEntities.Groups.Add( gameGroup );
            gnsEntities.SaveChanges();

            return Redirect( nameof( AdminController.Index ) );
        }

        [HttpPost]
        public IActionResult AddGame( string gameName, Guid groupId )
        {
            var game = new Game()
            {
                GameId = Guid.NewGuid(),
                Group = gnsEntities.Groups.FirstOrDefault( x => x.GroupId == groupId ),
                Name = gameName
            };

            gnsEntities.Games.Add( game );
            gnsEntities.SaveChanges();

            return Redirect( nameof( AdminController.Index ) );
        }

        [HttpPost]
        public IActionResult AddRecord( RecordForm recordForm )
        {
            if ( !ModelState.IsValid )
            {
                FilterSelectOptions( recordForm );
                return View( nameof( AdminController.Index ), recordForm );
            }
            var record = new Record()
            {
                CreatedOn = DateTime.Now,
                Game = gnsEntities.Games.FirstOrDefault( game => game.GameId == recordForm.SelectedGroupId ),
                Group = gnsEntities.Groups.FirstOrDefault( group => group.GroupId == recordForm.SelectedGroupId ),
                RecordId = Guid.NewGuid(),
                Winner = gnsEntities.Players.FirstOrDefault( x => x.PlayerId == recordForm.SelectedPlayerId )
            };

            gnsEntities.Records.Add( record );
            gnsEntities.SaveChanges();

            return Redirect( nameof( AdminController.Index ) );
        }

        private void FilterSelectOptions( RecordForm recordForm )
        {
            recordForm.GroupList = new SelectList( gnsEntities.Groups, "GroupId", "Name" );
            if ( recordForm.SelectedGroupId.HasValue )
            {
                var games = gnsEntities.Games.Where( game => game.Group.GroupId == recordForm.SelectedGroupId.Value );
                recordForm.GameList = new SelectList( games, "ID", "Name" );

                var players = gnsEntities.Players.Where( player => player.GroupId == recordForm.SelectedGroupId.Value );
                recordForm.GameList = new SelectList( players, "ID", "Name" );
            }
            else
            {
                recordForm.GameList = new SelectList( Enumerable.Empty<SelectListItem>() );
                recordForm.PlayerList = new SelectList( Enumerable.Empty<SelectListItem>() );
            }
        }
    }
}
