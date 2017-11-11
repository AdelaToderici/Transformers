using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transformers.Services;

namespace Transformers.Client.Console {
    class Program {
        static void Main(string[] args) {

            List<Transformer> trasformersList = new List<Transformer>
            {
                new Transformer()
                {
                    Type = TransformerType.Decepticon,
                    Name = "Soundwave",
                    Strength = 8,
                    Intelligence = 9,
                    Speed = 2,
                    Endurance = 6,
                    Rank = 7,
                    Courage = 5,
                    Firepower = 6,
                    Skill = 10
                },
                new Transformer()
                {
                    Type = TransformerType.Autobot,
                    Name = "Bluestreak",
                    Strength = 6,
                    Intelligence = 6,
                    Speed = 7,
                    Endurance = 9,
                    Rank = 5,
                    Courage = 2,
                    Firepower = 9,
                    Skill = 7
                },
                new Transformer()
                {
                    Type = TransformerType.Autobot,
                    Name = "Hubcap",
                    Strength = 4,
                    Intelligence = 4,
                    Speed = 4,
                    Endurance = 4,
                    Rank = 4,
                    Courage = 4,
                    Firepower = 4,
                    Skill = 4
                },
            };

            var gameScore = new GameService().ComputeScore(trasformersList);

            System.Console.WriteLine($"{gameScore.Battles} battle");
            System.Console.WriteLine($"Winning team ({gameScore.WinningTeam}): {string.Join(",", trasformersList.Where(x=>x.Type==gameScore.WinningTeam).Select(x=>x.Name))}");
            System.Console.WriteLine($"Survivors from the losing team ({gameScore.LosingTeam}):{string.Join(",", gameScore.Survivors)}");

            int[] A = new int[] {2, 6,6, 1, 4, 2, 2, 1};
            int result = Castles.Solution(A);
            System.Console.Write(result);
            System.Console.Read();
        }
    }
}
