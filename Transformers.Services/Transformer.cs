namespace Transformers.Services
{
    public class Transformer
    {
        public string Name { get; set; }
        public TransformerType Type { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Speed { get; set; }
        public int Endurance { get; set; }
        public int Rank { get; set; }
        public int Courage { get; set; }
        public int Firepower { get; set; }
        public int Skill { get; set; }

        public int GetRating(Transformer transformer) {
            return Strength +
                   Intelligence +
                   Speed +
                   Endurance +
                   Firepower;
        }
    }
}