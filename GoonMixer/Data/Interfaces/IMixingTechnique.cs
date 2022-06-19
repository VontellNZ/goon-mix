namespace GoonMixer.Data.Interfaces
{
    public interface IMixingTechnique
    {
        List<Song> GetSuggestedSongs(Song mainSong, List<Song> songs);
    }
}