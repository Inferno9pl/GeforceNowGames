using System;
using System.Collections.Generic;
using System.Linq;

namespace GeforceNowGames
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                var url = args[0];
                var store = args[1];

                var myGamesList_ = new GameListTxtFile(url).GamesList;
                var GFNgames_ = new JSONParser("https://static.nvidiagrid.net/supported-public-game-list/locales/gfnpc-en-US.json").Games;
                ShowOwnedGamesByStore(myGamesList_, store, GFNgames_);
                Console.ReadKey();
            }
            else
                ConsoleApp();
        }

        static void ConsoleApp()
        {
            var GFNgames_ = new JSONParser("https://static.nvidiagrid.net/supported-public-game-list/locales/gfnpc-en-US.json").Games;

            var nextLoop = true;
            while (nextLoop)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Show all games on GeforceNow");
                Console.WriteLine("2 - Show all games by store");
                Console.WriteLine("3 - Show owned games by store");
                Console.WriteLine("exit - close App");

                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        ShowAllGames(GFNgames_);
                        break;

                    case "2":
                        Console.WriteLine("Select store - (Epic | Steam | Ubisoft Connect | Origin | GOG) ");
                        var store_ = Console.ReadLine();
                        ShowAllGamesByStore(Correct(store_), GFNgames_);
                        break;

                    case "3":
                        Console.WriteLine("Select store - (Epic | Steam | Ubisoft Connect | Origin | GOG) ");
                        store_ = Console.ReadLine();
                        Console.WriteLine("Enter the location of the file listing your games on a specific platform");
                        Console.WriteLine("You can also drag and drop a file into this window");
                        var url_ = Console.ReadLine();
                        var myGamesList_ = new GameListTxtFile(url_).GamesList;
                        ShowOwnedGamesByStore(myGamesList_, Correct(store_), GFNgames_);
                        break;

                    case "exit":
                        nextLoop = false;
                        break;

                    default:
                        break;
                }
            }
        }


        /* Compare GeforceNow Games with user's games list */
        static void ShowOwnedGamesByStore(List<string> myGames, string store, Game[] GFNgames)
        {
            //convert titles to simpler version
            for (int i = 0; i < myGames.Count; i++)
            {
                myGames[i] = MakeTextSimple(myGames[i]);
            }

            Console.WriteLine($"\nGames from the user's list, available on GFN and from {store}: ");
            var index = 1;
            for (int i = 0; i < GFNgames.Length; i++)
            {
                if (GFNgames[i].Store.Equals(store))
                {
                    var name = MakeTextSimple(GFNgames[i].Title);

                    for (int j = 0; j < myGames.Count; j++)
                    {
                        if (name.Equals(myGames[j]))
                        {
                            Console.Write($"   {index++,+5} {GFNgames[i].Title,-42} ");
                            for (int k = 0; k < GFNgames[i].Genres.Length; k++)
                            {
                                Console.Write($"{GFNgames[i].Genres[k]}, ");
                            }
                            Console.WriteLine();
                            break;
                        }
                    }
                }
            }
        }


        /* Epic | Steam | Ubisoft Connect | Origin | GOG */
        static void ShowAllGamesByStore(string store, Game[] GFNgames)
        {
            var gamesInStore = from game in GFNgames
                               where game.Store == store
                               select game;

            Console.WriteLine($"All GFN games from {store}:");
            var index = 1;
            foreach (var game in gamesInStore)
            {
                Console.WriteLine($"   {index++,+5} {game.Title}");
            }
        }


        /* Show all supported GeforceNow Games */
        static void ShowAllGames(Game[] GFNgames)
        {
            Console.WriteLine("All available GFN games:");
            var index = 1;
            foreach (var game in GFNgames)
            {
                Console.WriteLine($"   {index++,-5} {game.Store,-15} {game.Title}");
            }
        }

        private static string Correct(string opt)
        {
            if (opt.Length > 0)
            {
                opt = opt.Substring(0, 1).ToUpper() + opt[1..];
                switch (opt)
                {
                    case "Ubisoft":
                        opt = "Ubisoft Connect";
                        break;
                    case "Gog":
                        opt = "GOG";
                        break;
                }
            }
            else
            {
                opt = "";
                Console.WriteLine("Games with an undefined store: ");
            }

            return opt;
        }
        private static string MakeTextSimple(string text)
        {
            text = text.ToLower();
            text = text.Replace(" ", "");
            text = text.Replace("'", "");
            text = text.Replace("’", "");
            text = text.Replace(",", "");
            text = text.Replace(":", "");
            text = text.Replace("!", "");
            text = text.Replace("-", "");
            text = text.Replace("–", "");

            text = text.Replace("definitiveedition", "");
            text = text.Replace("enhancededition", "");
            text = text.Replace("goldedition", "");

            return text;
        }
    }
}
