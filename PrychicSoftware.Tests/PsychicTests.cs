using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrychicSoftware;
using PrychicSoftware.Exceptions;
using System.Collections.Generic;

namespace PrychicSoftware.Tests
{
    [TestClass]
    public class PsychicTests
    {
        [TestMethod]
        public void Create_1Min10Max_CurrentGuess1_10()
        {
            IPsychic psychic = new Psychic(1, 10);

            Assert.IsTrue(psychic.CurrentGuess >= 1 && psychic.CurrentGuess <= 10);
        }
        [TestMethod]
        public void Higher_LowerBound_equal_CrrentGuess_plus1()
        {
            IPsychic psychic = new Psychic(1, 10);
            while(psychic.CurrentGuess == 10 || psychic.CurrentGuess == 1)
            {
                psychic = new Psychic(1, 10);
            }
            int oldCurrentGuess = psychic.CurrentGuess;
            psychic.Higher();
            Assert.IsTrue(oldCurrentGuess + 1 == psychic.LowerBound);
        }
        [TestMethod]
        public void Lower_UpperBound_equal_CrrentGuess_minus1()
        {
            IPsychic psychic = new Psychic(1, 10);
            while (psychic.CurrentGuess == 10 || psychic.CurrentGuess == 1)
            {
                psychic = new Psychic(1, 10);
            }
            int oldCurrentGuess = psychic.CurrentGuess;
            psychic.Lower();
            Assert.IsTrue(oldCurrentGuess - 1 == psychic.UpperBound);
        }
        [TestMethod]
        public void Correct_Completed_returned_true()
        {
            IPsychic psychic = new Psychic(1, 10);
            psychic.Correct();
            Assert.IsTrue(psychic.Complete);
        }
        [TestMethod]
        public void UpperBound_equal_LowerBound_Complete_returned_truee()
        {
            IPsychic psychic = new Psychic(1, 1);

            Assert.IsTrue(psychic.Complete);
        }
        [TestMethod]
        public void Complete_trowException()
        {
            IPsychic psychic = new Psychic(1, 10);
            while (psychic.CurrentGuess == 10 && psychic.CurrentGuess == 1)
            {
                psychic = new Psychic(1, 10);
            }
            psychic.Correct();
            Assert.ThrowsException<GameAlreadyFinishedException>(() => psychic.Higher());
            
        }
        [TestMethod]
        public void Lower_CurrentGuess_min_trowException()
        {
            IPsychic psychic = new Psychic(1, 2);
            while (psychic.CurrentGuess == 2)
            {
                psychic = new Psychic(1, 2);
            }
            Assert.ThrowsException<LowerNotAvailibleException>(() => psychic.Lower());

        }
        [TestMethod]
        public void Highrer_CurrentGuess_max_trowException()
        {
            IPsychic psychic = new Psychic(1,2);
            while (psychic.CurrentGuess == 1)
            {
                psychic = new Psychic(1, 2);
            }
            Assert.ThrowsException<HigherNotAvailibleException>(() => psychic.Higher());

        }
        [TestMethod]
        public void Create_Highrer_Lower_5times_guessCount_returned_5()
        {
            IPsychic psychic = new Psychic(1, 100);//1 time
            for(int i = 0; i<4;i++)//4 more time
            {
                if(psychic.UpperBound - psychic.CurrentGuess > psychic.CurrentGuess - psychic.LowerBound)//early completion excluding
                {
                    psychic.Higher();
                }
                else
                {
                    psychic.Lower();
                }
            }
            Assert.AreEqual(psychic.GuessCount, 5);

        }
        [TestMethod]
        public void Create_Highrer_Lower_5times_guessHisroty_correct()
        {
            List<int> history = new List<int>();
            IPsychic psychic = new Psychic(1, 100);//1 time   
            history.Add(psychic.CurrentGuess);
            for (int i = 0; i < 4; i++)//4 more time
            {
                if (psychic.UpperBound - psychic.CurrentGuess > psychic.CurrentGuess - psychic.LowerBound)//early completion excluding
                {
                    psychic.Higher();
                }
                else
                {
                    psychic.Lower();
                }
                history.Add(psychic.CurrentGuess);
            }
            List<int> objectHIstory = psychic.GuessHistory as List<int>;
            CollectionAssert.AreEqual(objectHIstory, history);

        }
    }
}
