using GNS.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GNS.Web.Data
{
    public class GnsEntities : DbContext
    {
        #region Fields
        private readonly IConfiguration configuration;
        #endregion

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Record> Records { get; set; }

        public GnsEntities(IConfiguration configuration)
            => this.configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
