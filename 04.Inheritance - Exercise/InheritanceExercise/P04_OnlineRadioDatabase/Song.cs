using System;

namespace P04_OnlineRadioDatabase
{
    public class Song
    {

        private const int MinAuthorName = 3;
        private const int MaxAuthorName = 20;
        private const int MinSongName = 3;
        private const int MaxSongName = 30;
        private const int MinSongMin = 0;
        private const int MaxSongMin = 14;
        private const int MinSongSec = 0;
        private const int MaxSongSec = 59;



        private string artist;
        private string name;
        private int minutes;
        private int seconds;

        public Song(string artist, string name, int minutes, int seconds)
        {
            this.Artist = artist;
            this.Name = name;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }


        public string Artist
        {
            get => artist;

            set
            {
                if (value.Length < MinAuthorName || value.Length > MaxAuthorName)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }

                artist = value;
            }
        }
        public string Name
        {
            get => name;

            set
            {
                if (value.Length < MinSongName || value.Length > MaxSongName)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }
                name = value;
            }
        }
        public int Minutes
        {
            get => minutes;

            set
            {
                if (value < MinSongMin || value > MaxSongMin)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }
                minutes = value;
            }
        }
        public int Seconds
        {
            get => seconds;

            set
            {
                if (value < MinSongSec || value > MaxSongSec)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }

                seconds = value;
            }
        }
    }
}