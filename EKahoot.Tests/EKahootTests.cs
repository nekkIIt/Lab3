using System;
using System.Collections.Generic;
using Xunit;
using EKahoot.Core;

namespace EKahoot.Tests
{
    public class EKahootTests
    {
        // ==========================================
        // Тести для Question.ValidateAnswer
        // ==========================================

        [Fact]
        public void ValidateAnswer_CorrectIndex_ReturnsTrue()
        {
            // Arrange (Техніка: EP, Позитивний)
            var question = new Question { Options = new List<string> { "A", "B", "C", "D" }, CorrectOptionIndex = 1 };
            
            // Act 
            bool result = question.ValidateAnswer(1);
            
            // Assert 
            Assert.True(result);
        }

        [Fact]
        public void ValidateAnswer_IncorrectIndex_ReturnsFalse()
        {
            // Arrange (Техніка: BVA, Позитивний - верхня межа валідних)
            var question = new Question { Options = new List<string> { "A", "B", "C", "D" }, CorrectOptionIndex = 1 };
            
            // Act 
            bool result = question.ValidateAnswer(3);
            
            // Assert 
            Assert.False(result);
        }

        [Fact]
        public void ValidateAnswer_NegativeIndex_ThrowsException()
        {
            // Arrange (Техніка: BVA, Негативний - нижче нуля)
            var question = new Question { Options = new List<string> { "A", "B", "C", "D" } };
            
            // Act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => question.ValidateAnswer(-1));
        }

        [Fact]
        public void ValidateAnswer_IndexOutOfRange_ThrowsException()
        {
            // Arrange (Техніка: BVA, Негативний - дорівнює Count)
            var question = new Question { Options = new List<string> { "A", "B", "C", "D" } };
            
            // Act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => question.ValidateAnswer(4));
        }

        [Fact]
        public void ValidateAnswer_EmptyOptions_ThrowsException()
        {
            // Arrange (Техніка: BVA, Негативний - пусті дані)
            var question = new Question { Options = new List<string>() };
            
            // Act & Assert 
            Assert.Throws<InvalidOperationException>(() => question.ValidateAnswer(1));
        }

        // ==========================================
        // Тести для Result.CalculatePoints
        // ==========================================

        [Fact]
        public void CalculatePoints_InstantResponse_ReturnsMaxPoints()
        {
            // Arrange (Техніка: BVA, Позитивний - мінімальний час)
            var result = new Result();
            
            // Act 
            int points = result.CalculatePoints(0.0f, 10.0f);
            
            // Assert 
            Assert.Equal(1000, points);
        }

        [Fact]
        public void CalculatePoints_LastSecondResponse_ReturnsHalfPoints()
        {
            // Arrange (Техніка: BVA, Позитивний - максимальний час)
            var result = new Result();
            
            // Act 
            int points = result.CalculatePoints(10.0f, 10.0f);
            
            // Assert 
            Assert.Equal(500, points);
        }

        [Fact]
        public void CalculatePoints_TimeExceeded_ReturnsZero()
        {
            // Arrange (Техніка: BVA, Позитивний - поза межами ліміту)
            var result = new Result();
            
            // Act 
            int points = result.CalculatePoints(10.1f, 10.0f);
            
            // Assert 
            Assert.Equal(0, points);
        }

        [Fact]
        public void CalculatePoints_NegativeTime_ThrowsException()
        {
            // Arrange (Техніка: BVA, Негативний - негативний час)
            var result = new Result();
            
            // Act & Assert 
            Assert.Throws<ArgumentException>(() => result.CalculatePoints(-0.1f, 10.0f));
        }

        [Fact]
        public void CalculatePoints_NegativeTimeLimit_ThrowsException()
        {
            // Arrange (Техніка: BVA, Негативний - негативний ліміт)
            var result = new Result();
            
            // Act & Assert 
            Assert.Throws<ArgumentException>(() => result.CalculatePoints(5.0f, 0.0f));
        }

        // ==========================================
        // Тести для GameSession.CalculateFinalScore
        // ==========================================

        [Fact]
        public void CalculateFinalScore_ValidResults_ReturnsSum()
        {
            // Arrange (Техніка: EP, Позитивний)
            var session = new GameSession();
            var results = new List<Result>
            {
                new Result { ScoreEarned = 1000 },
                new Result { ScoreEarned = 500 }
            };
            
            // Act 
            int total = session.CalculateFinalScore(results);
            
            // Assert 
            Assert.Equal(1500, total);
        }

        [Fact]
        public void CalculateFinalScore_EmptyList_ReturnsZero()
        {
            // Arrange (Техніка: BVA, Позитивний - мінімальна кількість)
            var session = new GameSession();
            var results = new List<Result>();
            
            // Act 
            int total = session.CalculateFinalScore(results);
            
            // Assert 
            Assert.Equal(0, total);
        }

        [Fact]
        public void CalculateFinalScore_NegativeScoreInList_ThrowsException()
        {
            // Arrange (Техніка: EP, Негативний)
            var session = new GameSession();
            var results = new List<Result>
            {
                new Result { ScoreEarned = 1000 },
                new Result { ScoreEarned = -10 } 
            };
            
            // Act & Assert 
            Assert.Throws<InvalidOperationException>(() => session.CalculateFinalScore(results));
        }

        [Fact]
        public void CalculateFinalScore_NullList_ThrowsException()
        {
            // Arrange (Техніка: BVA, Негативний - відсутність об'єкта)
            var session = new GameSession();
            
            // Act & Assert 
            Assert.Throws<ArgumentNullException>(() => session.CalculateFinalScore(null));
        }
    }
}