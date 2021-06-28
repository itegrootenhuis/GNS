using System;

namespace GNS.Core.Models
{
    public class Game
    {
        public Guid GameId { get; set; }

        public Group Group { get; set; }

        public string Name { get; set; }
    }
}
