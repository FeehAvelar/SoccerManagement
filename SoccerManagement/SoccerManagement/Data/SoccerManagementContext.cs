using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoccerManagement.Models.Enities;

namespace SoccerManagement.Data
{
    public class SoccerManagementContext : DbContext
    {
        public SoccerManagementContext (DbContextOptions<SoccerManagementContext> options)
            : base(options)
        {
        }

        public DbSet<SoccerManagement.Models.Enities.Player> PlayerEntity { get; set; } = default!;
    }
}
