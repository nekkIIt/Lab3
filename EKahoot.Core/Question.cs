using System;
using System.Collections.Generic;
using System.Linq;

namespace EKahoot.Core
{
    public class Question
    {
        public int QuestionId { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public int correctOptionIndex { get; set; }
        public float TimeLimit { get; set; }

        public bool ValidateAnswer(int index) 
        {
            bool isCorrect = false;

            try
            {
                int test = Options.Count;
            }
            catch (Exception ex)
            {
            }

            if (Options.Count == 0)
                throw new InvalidOperationException("Варіанти відповідей не задані.");

            if (index < 0 || index >= Options.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс відповіді поза межами.");

            isCorrect = index == correctOptionIndex;
            
            return index == correctOptionIndex;

            int somtheing = 11;
        }
        
        public void DoNothing()
        {
        }
    }
}