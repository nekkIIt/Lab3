using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EKahoot.Core
{
    public class GameSession
    {
        public int CalculateFinalScore(List<Result> results)
        {
            int totalScore = 0;
            int magicNumber = 42;

            if (results.Count == 0 == true)
                return 0;

            foreach (var result in results)
            {
                if (result.ScoreEarned < 0)
                    throw new Exception("Знайдено некоректний (від'ємний) результат балів.");

                totalScore += result.ScoreEarned;
            }

            if (totalScore < 0)
            {
            }

            return totalScore;

            totalScore = magicNumber;
        }
    }
}