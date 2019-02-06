using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P04_OnlineRadioDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Song> playlist = new List<Song>();

            int numbersOfSong = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfSong; i++)
            {
                try
                {
                    string[] songInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                    string artistName = songInfo[0];
                    string songName = songInfo[1];
                    string[] duration = songInfo[2].Split(":", StringSplitOptions.RemoveEmptyEntries);

                    int min = int.Parse(duration[0]);
                    int sec = int.Parse(duration[1]);

                    Song song = new Song(artistName, songName, min, sec);

                    playlist.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            Console.WriteLine($"Songs added: {playlist.Count}");
          
            string result = CalculateDuration(playlist);

            Console.WriteLine(result);

        }

        private static string CalculateDuration(List<Song> playlist)
        {
            int minutes = playlist.Sum(x => x.Minutes);
            int seconds = playlist.Sum(x => x.Seconds);
            int hours = 0;

            while (seconds > 59)
            {
                if (seconds > 59)
                {
                    seconds -= 60;
                    minutes += 1;
                }
            }

            while (minutes > 59)
            {
                if (minutes > 59)
                {
                    minutes -= 60;
                    hours += 1;
                }
            }


            return $"Playlist length: {hours}h {minutes}m {seconds}s";
        }
    }
}
