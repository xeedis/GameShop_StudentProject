using GameShop.Migrations;
using GameShop.Models;
using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GameShop.DAL
{
    public class GamesInitializer : MigrateDatabaseToLatestVersion<GameContext, Configuration>
    {
        

        public static void SeedGamesData(GameContext context)
        {
            var categories = new List<Category>
            {
                new Category() {CategoryId=1,CategoryName="RPG", IconFileName="pdsg.png",CategoryDescription="safasfafs"},
                new Category() {CategoryId=2,CategoryName="Shoter", IconFileName="gdssgsd.png",CategoryDescription="dgdgssdg"},
            };
            categories.ForEach(k => context.Categories.AddOrUpdate(k));
            context.SaveChanges();

            var HardwareRequirements = new List<HardwareRequirements>
            {
              new HardwareRequirements() {HardwareRequirementsId=1,System="asf"},
              new HardwareRequirements() {HardwareRequirementsId=2,System="twewte"},

            };
            HardwareRequirements.ForEach(k => context.HardwareRequirements.AddOrUpdate(k));
            context.SaveChanges();

            var games = new List<Game>
            {
              new Game() {GameId=1,HardwareRequirementsId=1,Publisher="CDprojectRed",CategoryId=1,GamePrice=64,GameTitle="Cyberpunk",DateAdded=Convert.ToDateTime("05-05-2020"),Premiere=Convert.ToDateTime("05-05-2020"),ImageFileName="cyberpunk.jpg"},
              new Game() {GameId=2,HardwareRequirementsId=2,Publisher="safsfa",CategoryId=2,GameTitle="Kingdom Come",DateAdded=Convert.ToDateTime("05-05-2020"),Premiere=Convert.ToDateTime("05-05-2020"),ImageFileName="kingdomcome.jpeg"},
              new Game() {GameId=3,HardwareRequirementsId=2,Publisher="safsfa",CategoryId=2,GameTitle="Gothic 2",DateAdded=Convert.ToDateTime("05-05-2020"),Premiere=Convert.ToDateTime("05-05-2020"),ImageFileName="gothic.jpg"},
            };
            games.ForEach(k => context.Games.AddOrUpdate(k));
            context.SaveChanges();


        }

    }
}