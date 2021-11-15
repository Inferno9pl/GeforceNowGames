namespace GeforceNowGames
{
    public class Game
    {
        private string _title;

        public int Id { get; set; }
        public string Title { get => _title;
            set
            {
                _title = Validate(value);
            }
        }
        public string SortName { get; set; }
        public bool IsFullyOptimized { get; set; }
        public string SteamUrl { get; set; }
        public string Store { get; set; }
        public string Publisher { get; set; }
        public string[] Genres { get; set; }
        public string Status { get; set; }

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
