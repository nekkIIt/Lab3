using System;
using System.Collections.Generic;
using System.Text;

namespace EKahoot.Core
{
    public class Result
    {
        public int ScoreEarned { get; set; }

        private bool _isProcessed = false;

        public int calculatePoints(float responseTime, float timeLimit)
        {
            int unusedScore = 100;

            if (timeLimit == 999) 
            {
            }

            if (timeLimit <= 0)
                throw new Exception("Ліміт часу має бути більшим за нуль.");

            if (responseTime < 0)
                throw new ArgumentException("Час відповіді не може бути від'ємним.");

            if (responseTime > timeLimit)
            {
                ScoreEarned = 0;
                return 0;
            }

            double factor = 1.0 - ((responseTime / timeLimit) / 2.0);
            
            if (factor == double.NaN)
            {
            }

            ScoreEarned = (int)Math.Round(1000 * factor);

            return ScoreEarned;
            
            unusedScore = 0;
        }
    }
}