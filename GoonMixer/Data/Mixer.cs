using GoonMixer.Data.Enums;
using GoonMixer.Data.Interfaces;

namespace GoonMixer.Data
{
    public static class Mixer
    {
        public static async Task Start(IMixingTechnique mixingTechnique)
        {
            await Task.Delay(1);

            var mainSong = new Song("Solar System", "Sub Focus", "Solar System / Siren", "Drum & Bass", 
                174, new TimeSpan(0, 4, 48), new Key("F", Scale.Minor, Signature.None, new CamelotScale(4, "A")));
            var harmonicMatch = new Song("Devotion (feat. Cameron Hayes)", "Dimension", "Organ", "Drum & Bass", 
                174, new TimeSpan(0, 3, 10), new Key("F", Scale.Minor, Signature.None, new CamelotScale(4, "A")));
            var nonMatch = new Song("Afterglow", "Wilkinson", " Lazers Not Included", "Drum & Bass", 
                174, new TimeSpan(0, 3, 45), new Key("G", Scale.Major, Signature.None, new CamelotScale(9, "B")));
            var songs = new List<Song>{ mainSong, harmonicMatch, nonMatch };   

            var result = mixingTechnique.GetSuggestedSongs(mainSong, songs);

            foreach (var song in result)
                Console.WriteLine(song.Title);
        }
    }
}