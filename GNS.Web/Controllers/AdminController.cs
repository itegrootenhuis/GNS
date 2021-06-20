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
        public AdminController(GnsEntities gnsEntities)
        {
            this.gnsEntities = gnsEntities;
        }
        public IActionResult Index()
        {
            var viewmodel = new AdminViewModel()
            {
                GameGroups = gnsEntities.GameGroups.ToList()
            };

            return View(viewmodel);
        }

        [HttpPost]
        public void AddPerson(string firstName, string lastName, string email, Guid gameGroupId)
        {
            var player = new Player()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Id = Guid.NewGuid(),
                GameGroupId = gameGroupId
            };

            gnsEntities.Players.Add(player);
            gnsEntities.SaveChanges();
        }

        [HttpPost]
        public void AddGameGroup(string groupName)
        {
            var gameGroup = new GameGroup()
            {
                LedgerId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                Name = groupName,
                Id = Guid.NewGuid()
            };

            gnsEntities.GameGroups.Add(gameGroup);
            gnsEntities.SaveChanges();
        }
    }
}
