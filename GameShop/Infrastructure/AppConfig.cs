using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GameShop.Infrastructure
{
    public class AppConfig
    {
        private static string __relativeFolderCategoryIcons = ConfigurationManager.AppSettings["FolderCategoryIcons"];
        public static string __RelativeFolderCategoryIcons
        {
            get
            {
                return __relativeFolderCategoryIcons;
            }
        }

        private static string __relativeGamesFolder = ConfigurationManager.AppSettings["GamesFolder"];
        public static string __RelativeGamesFolder
        {
            get
            {
                return __relativeGamesFolder;
            }
        }

    }
}