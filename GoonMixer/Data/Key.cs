using GoonMixer.Data.Enums;

namespace GoonMixer.Data
{
    public class Key
    {
        public string Note { get; set; }
        public Scale Scale { get; set; }
        public Signature Signature { get; set; }
        public CamelotScale CamelotScale { get; set; }

        public Key(string note, Scale scale, Signature signature, CamelotScale camelotScale)
        {
            Note = note.ToUpper();
            Scale = scale;
            Signature = signature;
            CamelotScale = camelotScale;
        }

        public string GetFullKey()
        {
            return Note + Scale.ToString() + Signature.ToString();
        }
    }
}