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
                Groups = gnsEntities.Groups.ToList()
            };

            return View( viewmodel );
        }

        [HttpPost]
        public void AddPerson( string firstName, string lastName, string email, Guid groupId )
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
        }

        [HttpPost]
        public void AddGroup( string groupName )
        {
            var gameGroup = new Group()
            {
                LedgerId = Guid.Parse( User.FindFirstValue( ClaimTypes.NameIdentifier ) ),
                Name = groupName,
                GroupId = Guid.NewGuid()
            };

            gnsEntities.Groups.Add( gameGroup );
            gnsEntities.SaveChanges();
        }

        [HttpPost]
        public void AddGame( string gameName, Guid groupId )
        {
            var game = new Game()
            {
                GameId = Guid.NewGuid(),
                Group = gnsEntities.Groups.FirstOrDefault( x => x.GroupId == groupId ),
                Name = gameName
            };

            gnsEntities.Games.Add( game );
            gnsEntities.SaveChanges();
        }
    }
}
