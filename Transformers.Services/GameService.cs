using System;
using System.Collections.Generic;
using System.Linq;

namespace Transformers.Services
{
    public class GameService : IGameService
    {
        public const string OPTIMUS = "OPTIMUS Prime";
        public const string PREDAKING = "PREDAKING";
         
        public GameScore ComputeScore(List<Transformer> transformers)
        {
            if(!transformers.All(Validate))
                throw new ArgumentException("Transformers were not correctly specified");

            var autobots = transformers.Where(x => x.Type == TransformerType.Autobot).OrderByDescending(x=>x.Rank).ToList();
            var decepticons = transformers.Where(x => x.Type == TransformerType.Decepticon).OrderByDescending(x => x.Rank).ToList();
            var autobotWins = 0;
            var decepticonWins = 0;
            var battleCount = 0;
            var gameScore = new GameScore();

            for (int i = 0; i < Math.Min(autobots.Count, decepticons.Count); i++)
            {
                if (autobots[i].Name == OPTIMUS && decepticons[i].Name == PREDAKING)
                    break;
                if (autobots[i].Name == PREDAKING && decepticons[i].Name == OPTIMUS)
                    break;

                var fightResult = CompareTransformers(autobots[i], decepticons[i]);

                if (fightResult < 0)
                {
                    decepticonWins++;
                }
                if (fightResult > 0)
                {
                    autobotWins++;
                }

                battleCount++;
            }

            gameScore.Battles = battleCount;

            if (autobotWins > decepticonWins)
            {
                gameScore.WinningTeam = TransformerType.Autobot;
            } 
            else if (autobotWins < decepticonWins) {
                gameScore.WinningTeam = TransformerType.Decepticon;
            }

            if (autobots.Count > decepticons.Count)
            {
                gameScore.Survivors = autobots.Skip(battleCount).Select(x => x.Name).ToList();
            }
            else if(autobots.Count < decepticons.Count)
            {
                gameScore.Survivors = decepticons.Skip(battleCount).Select(x => x.Name).ToList();
            }

            return gameScore;
        }

        private bool Validate(Transformer transformer)
        {
            if (transformer.Courage < 1 || transformer.Courage > 10)
                return false;

            if (transformer.Endurance < 1 || transformer.Endurance > 10)
                return false;

            if (transformer.Firepower < 1 || transformer.Firepower > 10)
                return false;

            if (transformer.Rank < 1 || transformer.Rank > 10)
                return false;

            if (transformer.Skill < 1 || transformer.Skill > 10)
                return false;

            if (transformer.Strength < 1 || transformer.Strength > 10)
                return false;

            if (transformer.Intelligence < 1 || transformer.Intelligence > 10)
                return false;

            if (transformer.Speed < 1 || transformer.Speed > 10)
                return false;

            return true;
        }

        private int CompareTransformers(Transformer first, Transformer second)
        {
            if (first.Name == OPTIMUS && second.Name != PREDAKING)
            {
                return 1;
            }
            if (first.Name != OPTIMUS && second.Name == PREDAKING) {
                return -1;
            }
            if (first.Name == PREDAKING && second.Name != OPTIMUS)
            {
                return 1;
            }
            if (first.Name != PREDAKING && second.Name == OPTIMUS) {
                return -1;
            } 

            if (first.Courage >= second.Courage + 4 && first.Strength >= second.Strength + 3)
            {
                return 1;
            }
            if (second.Courage >= first.Courage + 4 && second.Strength >= first.Strength + 3)
            {
                return -1;
            }
            if(first.Skill >= second.Skill + 3)
            {
                return 1;
            }
            if (second.Skill >= first.Skill + 3) {
                return -1;
            }

            return first.GetRating().CompareTo(second.GetRating());
        }
    }
}
