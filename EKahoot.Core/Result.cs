using System;

namespace EKahoot.Core
{
    public class Result
    {
        public int ScoreEarned { get; set; }

        // Метод розрахунку балів який приймає час відповіді та ліміт часу на питання
        public int CalculatePoints(float responseTime, float timeLimit)
        {

            if (timeLimit <= 0)
                throw new ArgumentException("Ліміт часу має бути більшим за нуль.");

            if (responseTime < 0)
                throw new ArgumentException("Час відповіді не може бути від'ємним.");


            if (responseTime > timeLimit)
            {
                ScoreEarned = 0;
                return 0; 
            }

            double factor = 1.0 - ((responseTime / timeLimit) / 2.0);
            

            ScoreEarned = (int)Math.Round(1000 * factor);
            
            return ScoreEarned;
        }
    }
}