namespace GoonMixer.Data
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string? Genre { get; set; }
        public int Bpm { get; set; }
        public TimeSpan Duration { get; set; }
        public Key Key { get; set; }

        public Song(string title, string artist, string album, string genre, int bpm, TimeSpan duration, Key key)
        {
            Title = title;
            Artist = artist;
            Album = album;
            Genre = genre;
            Bpm = bpm;
            Duration = duration;
            Key = key;
        }
    }
}