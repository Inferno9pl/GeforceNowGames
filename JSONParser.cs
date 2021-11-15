using System;
using System.Net;
using System.IO;
using System.Text.Json;

namespace GeforceNowGames
{
    public class JSONParser
    {
        public Game[] Games { set; get; }
        public JSONParser(string URL)
        {
            var response = GetJSON(URL);
            var json = ParseJSONtoString(response);
            Games = ParseStringtoGamesArray(json);
        }

        private static HttpWebResponse GetJSON(string URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return response;
            } catch (WebException)
            {
                Console.WriteLine($"Incorrect URL address - {URL}");
                throw;
            }
        }
        private static string ParseJSONtoString(HttpWebResponse response) {
            try
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader readerStream = new(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                var json = readerStream.ReadToEnd();
                return json;
            } catch (NullReferenceException)
            {
                Console.WriteLine("Response is null");
                throw;
            }
        }
        private static Game[] ParseStringtoGamesArray(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                var games = JsonSerializer.Deserialize<Game[]>(json, options);
                return games;
            } catch (JsonException)
            {
                Console.WriteLine("The class does not conform to the JSON structure");
                throw;
            }
        }
    }
}
