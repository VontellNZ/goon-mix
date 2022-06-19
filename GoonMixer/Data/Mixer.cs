using GoonMixer.Data.Interfaces;

namespace GoonMixer.Data
{
    public class Mixer
    {
        private IMixingTechnique MixingTechnique { get; set; }
        private List<Song> Songs { get; set; }

        public Mixer(IMixingTechnique mixingTechnique, List<Song> songs)
        {
            MixingTechnique = mixingTechnique;
            Songs = songs;
        }

        public void Start()
        {
        }
    }
}