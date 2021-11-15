using System;
using System.Collections.Generic;
using System.IO;

namespace GeforceNowGames
{
    public class GameListTxtFile
    {
        public List<string> GamesList { set; get; }
        public GameListTxtFile(string name)
        {
            GamesList = new();
            LoadFile(name);
        }
        private void LoadFile(string file)
        {
            if (File.Exists(file))
            {
                using StreamReader sr = File.OpenText(file);
                var s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    GamesList.Add(Validate(s));
                }
            } else
            {
                Console.WriteLine($"The specified file {file} does not exist");
            }
        }
        private static string Validate(string text)
        {
            //remove trademakrs
            text = text.Replace("©", "");
            text = text.Replace("®", "");
            text = text.Replace("®", "");
            text = text.Replace("©", "");
            text = text.Replace("™", "");
            return text;
        }
    }
}
