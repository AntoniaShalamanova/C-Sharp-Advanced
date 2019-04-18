using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _4MovieTime
{
    class MovieTime
    {
        static void Main(string[] args)
        {
            var movieList = new Dictionary<string, Dictionary<string, TimeSpan>>();

            string favGenre = Console.ReadLine();
            string favDuration = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "POPCORN!")
            {
                string[] tokens = input.Split("|", StringSplitOptions.RemoveEmptyEntries);

                string filmName = tokens[0];
                string filmGenre = tokens[1];
                TimeSpan filmDuration = TimeSpan.Parse(tokens[2], CultureInfo.InvariantCulture);

                if (!movieList.ContainsKey(filmGenre))
                {
                    movieList[filmGenre] = new Dictionary<string, TimeSpan>();
                }

                movieList[filmGenre][filmName] = filmDuration;

                input = Console.ReadLine();
            }


            if (favDuration == "Short")
            {
                movieList[favGenre] = movieList[favGenre]
                    .OrderBy(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);

            }
            else
            {
                movieList[favGenre] = movieList[favGenre]
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);
            }

            double totalPlaylistSeconds = movieList.Values.Sum(x => x.Sum(s => s.Value.TotalSeconds));

            foreach (var film in movieList[favGenre])
            {
                Console.WriteLine(film.Key);

                string answer = Console.ReadLine();

                if (answer == "Yes")
                {
                    Console.WriteLine($"We're watching {film.Key} - {film.Value}");
                    Console.WriteLine($"Total Playlist Duration: {TimeSpan.FromSeconds(totalPlaylistSeconds).ToString(@"hh\:mm\:ss")}");
                    break;
                }
            }
        }
    }
}
