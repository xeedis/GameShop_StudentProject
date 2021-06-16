using GameShop.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GameShop.DAL
{
    public class GameContext : IdentityDbContext<ApplicationUser>
    {
        public GameContext() : base("GameContext")
        {
            
        }

        static GameContext()
        {
            Database.SetInitializer<GameContext>(new GamesInitializer());
        }
        public static GameContext Create()
        {
            return new GameContext();
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<HardwareRequirements> HardwareRequirements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}