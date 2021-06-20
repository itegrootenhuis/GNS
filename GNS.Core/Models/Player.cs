using System;

namespace GNS.Core.Models
{
    public class Player
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public Guid GameGroupId { get; set; }

        public Guid Id { get; set; }

        public string LastName { get; set; }
    }
}
