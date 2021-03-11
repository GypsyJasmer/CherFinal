using CherFanPage.Models;
using System;
using Xunit;

namespace Tests
{
    public class QuizTest
    {

        [Fact]
        //Test when user gives correct answers
        public void RightAnswerTest()
        {
            //Arrange
            var quiz = new QuizVM()
            {
                UserAnswer1 = "26",
                UserAnswer2 = "Mask",
                UserAnswer3 = "1 year",
                UserAnswer4 = "Moonstruck"
            };

            //Act
            quiz.CheckAnswers();

            //Assert
            Assert.True("Right" == quiz.RightOrWrong1 && "Right" == quiz.RightOrWrong2 && "Right" == quiz.RightOrWrong3 && "Right" == quiz.RightOrWrong4);
        }

        [Fact]
        //Test when user gives wrong answers 
        public void WrongAnswerTest()
        {
            //Arrange
            var quiz = new QuizVM()
            {
                UserAnswer1 = "53",
                UserAnswer2 = "Mermaids",
                UserAnswer3 = "2 years",
                UserAnswer4 = "Mask"
            };

            //Act
            quiz.CheckAnswers();

            //Assert
            Assert.True("Wrong" == quiz.RightOrWrong1 && "Wrong" == quiz.RightOrWrong2 && "Wrong" == quiz.RightOrWrong3 && "Wrong" == quiz.RightOrWrong4);
        }

    }
}

