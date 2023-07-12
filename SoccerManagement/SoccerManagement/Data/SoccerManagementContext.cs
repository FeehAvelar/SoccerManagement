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
                .HasOne(g => g.WhoChange)
                .WithMany()
                .HasForeignKey(g => g.IdWhoChange);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Creator)
                .WithMany()
                .HasForeignKey(g => g.IdCreator);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Player>(p => p.IdUser);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.WhoChange)
                .WithOne()
                .HasForeignKey<Player>(p => p.IdWhoChange)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Player>()
                .HasMany(player => player.Games)
                .WithMany(game => game.Players)
                .UsingEntity<Dictionary<string, object>>(
                    "GamePlayers",
                    gamePlayers => gamePlayers.HasOne<Game>().WithMany().HasForeignKey("FkGame"),
                    gamePlayers => gamePlayers.HasOne<Player>().WithMany().HasForeignKey("FkPlayer")                    
                );
        }
    }
}
