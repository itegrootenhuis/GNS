using System;
using System.Collections.Generic;

namespace GNS.Core.Models
{
    public class Game
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Player> Winners { get; set; }
    }
}
