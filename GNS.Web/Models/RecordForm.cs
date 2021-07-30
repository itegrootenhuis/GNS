using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GNS.Web.Models
{
    public class RecordForm
    {
        [Required( ErrorMessage = "Please select a Group" )]
        [Display( Name = "Group" )]
        public Guid? SelectedGroupId { get; set; }

        [Required( ErrorMessage = "Please select a Game" )]
        [Display( Name = "Game" )]
        public Guid? SelectedGameId { get; set; }

        [Required( ErrorMessage = "Please select a Player" )]
        [Display( Name = "Player" )]
        public Guid? SelectedPlayerId { get; set; }

        public SelectList GameList { get; set; }
        public SelectList GroupList { get; set; }
        public SelectList PlayerList { get; set; }
    }
}
