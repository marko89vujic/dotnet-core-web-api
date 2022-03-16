using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballLeagueAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueAPI.DataContext
{
    public class LeagueContext:DbContext
    {
        public LeagueContext(DbContextOptions<LeagueContext> options):base(options)
        {

        }

        public DbSet<Team> Team { get; set; }

        public DbSet<Player> Players { get; set; }
    }
}
