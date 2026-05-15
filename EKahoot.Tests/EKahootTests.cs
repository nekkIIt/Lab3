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
            // Arrange (Підготовка даних)
            var question = new Question { Options = new List<string> { "A", "B", "C", "D" }, CorrectOptionIndex = 1 };
            
            // Act (Виконання дії)
            bool result = question.ValidateAnswer(1);
            
            // Assert (Перевірка результату)
            Assert.True(result);
        }

        [Fact]
        public void ValidateAnswer_IncorrectIndex_ReturnsFalse()
        {
            // Arrange 
            var question = new Question { Options = new List<string> { "A", "B", "C", "D" }, CorrectOptionIndex = 1 };
            
            // Act 
            bool result = question.ValidateAnswer(3);
            
            // Assert 
            Assert.False(result);
        }

        [Fact]
        public void ValidateAnswer_NegativeIndex_ThrowsException()
        {
            // Arrange 
            var question = new Question { Options = new List<string> { "A", "B", "C", "D" } };
            
            // Act & Assert (Для винятків дія і перевірка робляться разом)
            Assert.Throws<ArgumentOutOfRangeException>(() => question.ValidateAnswer(-1));
        }

        [Fact]
        public void ValidateAnswer_IndexOutOfRange_ThrowsException()
        {
            // Arrange 
            var question = new Question { Options = new List<string> { "A", "B", "C", "D" } };
            
            // Act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => question.ValidateAnswer(4));
        }

        [Fact]
        public void ValidateAnswer_EmptyOptions_ThrowsException()
        {
            // Arrange (Перевірка на порожній список відповідей)
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
            // Arrange 
            var result = new Result();
            
            // Act 
            int points = result.CalculatePoints(0.0f, 10.0f);
            
            // Assert 
            Assert.Equal(1000, points);
        }

        [Fact]
        public void CalculatePoints_LastSecondResponse_ReturnsHalfPoints()
        {
            // Arrange 
            var result = new Result();
            
            // Act 
            int points = result.CalculatePoints(10.0f, 10.0f);
            
            // Assert 
            Assert.Equal(500, points);
        }

        [Fact]
        public void CalculatePoints_TimeExceeded_ReturnsZero()
        {
            // Arrange 
            var result = new Result();
            
            // Act 
            int points = result.CalculatePoints(10.1f, 10.0f);
            
            // Assert 
            Assert.Equal(0, points);
        }

        [Fact]
        public void CalculatePoints_NegativeTime_ThrowsException()
        {
            // Arrange 
            var result = new Result();
            
            // Act & Assert 
            Assert.Throws<ArgumentException>(() => result.CalculatePoints(-0.1f, 10.0f));
        }

        [Fact]
        public void CalculatePoints_NegativeTimeLimit_ThrowsException()
        {
            // Arrange 
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
            // Arrange 
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
            // Arrange 
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
            // Arrange 
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
            // Arrange 
            var session = new GameSession();
            
            // Act & Assert 
            Assert.Throws<ArgumentNullException>(() => session.CalculateFinalScore(null));
        }
    }
}