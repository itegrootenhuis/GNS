using System;
using System.Linq;
using System.Security.Claims;
using GNS.Core.Models;
using GNS.Web.Data;
using GNS.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
            var viewmodel = new AdminViewModel()
            {
                Groups = gnsEntities.Groups.ToList(),
                Records = gnsEntities.Records.ToList()
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
        public IActionResult AddRecord( Guid gameId, Guid winnerId )
        {
            var record = new Record()
            {
                CreatedOn = DateTime.Now,
                Game = gnsEntities.Games.FirstOrDefault( game => game.GameId == gameId ),
                RecordId = Guid.NewGuid(),
                Winner = gnsEntities.Players.FirstOrDefault( x => x.PlayerId == winnerId )
            };

            gnsEntities.Records.Add( record );
            gnsEntities.SaveChanges();

            return Redirect( nameof( AdminController.Index ) );
        }
    }
}
