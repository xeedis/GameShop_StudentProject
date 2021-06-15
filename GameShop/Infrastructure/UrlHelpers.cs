using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Infrastructure
{
    public static class UrlHelpers
    {
        public static string PathIconCategories(this UrlHelper helper, string categoryIconName)
        {
            var FolderCategoryIcons = AppConfig.__RelativeFolderCategoryIcons;
            var patch = Path.Combine(FolderCategoryIcons, categoryIconName);
            var absolutePath = helper.Content(patch);

            return absolutePath;
        }

        public static string PathGames(this UrlHelper helper, string gameName)
        {
            var GamesFolder = AppConfig.__RelativeGamesFolder;
            var patch = Path.Combine(GamesFolder, gameName);
            var absolutePath = helper.Content(patch);

            return absolutePath;
        }
    }
}