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

        public DbSet<Player> Player { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Game> Game { get; set; } = default!;    
        public DbSet<Financial> Financial { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Creator)
                .WithMany()
                .HasForeignKey(g => g.IdCreator);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Player>(p => p.IdUser);

            #region LastChange
            modelBuilder.Entity<Game>()
                .HasOne(g => g.WhoChange)
                .WithOne()
                .HasForeignKey<Game>(g => g.IdWhoChange)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.WhoChange)
                .WithOne()
                .HasForeignKey<Player>(p => p.IdWhoChange)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Financial>()
                .HasOne(f => f.WhoChange)
                .WithOne()
                .HasForeignKey<Financial>(f => f.IdWhoChange)                
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Creator
            modelBuilder.Entity<Game>()
               .HasOne(g => g.Creator)
               .WithOne()
               .HasForeignKey<Game>(g => g.IdCreator)
               .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Financial>()
               .HasOne(f => f.Creator)
               .WithOne()
               .HasForeignKey<Financial>(f => f.IdCreator)
               .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
