namespace GoonMixer
{
    public class CamelotScale
    {
        public int Number { get; set; }
        public string Letter { get; set; }

        public CamelotScale(int number, string letter)
        {
            Number = number;
            Letter = letter.ToUpper();
        }
    }
}