using System;
using System.Collections.Generic;

namespace EKahoot.Core
{
    public class Question
    {
        // Властивості класу 
        public int QuestionId { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public int CorrectOptionIndex { get; set; }
        public float TimeLimit { get; set; }

        // Метод для перевірки чи правильний індекс вибрав користувач
        public bool ValidateAnswer(int index)
        {

            if (Options == null || Options.Count == 0)
                throw new InvalidOperationException("Варіанти відповідей не задані.");

            if (index < 0 || index >= Options.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс відповіді поза межами.");


            return index == CorrectOptionIndex;
        }
    }
}