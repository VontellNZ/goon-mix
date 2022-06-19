using GoonMixer.Data.Interfaces;

namespace GoonMixer.Data;

public class EnergyBoostMixingTechnique : IMixingTechnique
{
    private int _energyBoostModifier = 2;
    private int _maximumCamelotNumber = 12;

    public List<Song> GetSuggestedSongs(Song mainSong, List<Song> songs)
    {
        songs.Remove(mainSong);

        var songsToRemove = new List<Song>();
        if (mainSong.Key.CamelotScale.Number <= _maximumCamelotNumber - _energyBoostModifier)
        {
            songsToRemove = songs.Where(s => !s.Key.CamelotScale.Letter.Equals(mainSong.Key.CamelotScale.Letter) ||
                s.Key.CamelotScale.Number != mainSong.Key.CamelotScale.Number + _energyBoostModifier).ToList();
        }
        else
        {
            var matchingCamelotNumber = mainSong.Key.CamelotScale.Number - _maximumCamelotNumber + _energyBoostModifier;
            songsToRemove = songs.Where(s => s.Key.CamelotScale.Number != matchingCamelotNumber).ToList();
        }

        return songs.Except(songsToRemove).ToList();
    }
}