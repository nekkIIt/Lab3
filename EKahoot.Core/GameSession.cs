using System;
using System.Collections.Generic;

namespace EKahoot.Core
{
    public class GameSession
    {
        // Метод приймає список результатів і рахує загальну суму очків 
        public int CalculateFinalScore(List<Result> results)
        {

            if (results == null)
                throw new ArgumentNullException(nameof(results), "Список результатів не може бути null.");


            if (results.Count == 0)
                return 0;

            int totalScore = 0; 
            

            foreach (var result in results)
            {

                if (result.ScoreEarned < 0)
                    throw new InvalidOperationException("Знайдено некоректний (від'ємний) результат балів.");

                totalScore += result.ScoreEarned;
            }

            return totalScore;
        }
    }
}