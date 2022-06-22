namespace GoonMixer.Data
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var item = obj as CamelotScale;
            if (item == null)
                return false;
            
            return this.Number.Equals(item.Number) && this.Letter.Equals(item.Letter);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}