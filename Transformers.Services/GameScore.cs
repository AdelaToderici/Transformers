using System.Collections.Generic;

namespace Transformers.Services
{
    public class GameScore
    {
        public int Battles { get; set; }
        public TransformerType WinningTeam { get; set; }
        public string Winners { get; set; }

        public TransformerType LosingTeam
        {
            get
            {
                return WinningTeam == TransformerType.Autobot ? TransformerType.Decepticon : TransformerType.Autobot;
            }
        }

        public List<string> Survivors { get; set; }
    }
}