using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahtzeeKata;

namespace YahtzeeKataTests
{
    [TestClass]
    public class SinglesTests
    {
        [TestMethod]
        public void ReturnsCorrectSumForOnes()
        {
            int[] diceRolls = new int[] { 1, 1, 2, 4, 4 };

            int score = YahtzeeScorer.Score(Category.Ones, diceRolls);

            Assert.AreEqual(2, score);
        }

        [TestMethod]
        public void ReturnsCorrectSumForTwos()
        {
            int[] diceRolls = new int[] { 2, 2, 3, 4, 4 };

            int score = YahtzeeScorer.Score(Category.Twos, diceRolls);

            Assert.AreEqual(4, score);
        }

        [TestMethod]
        public void ReturnsCorrectSumForThrees()
        {
            int[] diceRolls = new int[] { 3, 3, 2, 4, 4 };

            int score = YahtzeeScorer.Score(Category.Threes, diceRolls);

            Assert.AreEqual(6, score);
        }

        [TestMethod]
        public void ReturnsCorrectSumForFours()
        {
            int[] diceRolls = new int[] { 4, 4, 1, 2, 3 };

            int score = YahtzeeScorer.Score(Category.Fours, diceRolls);

            Assert.AreEqual(8, score);
        }

        [TestMethod]
        public void ReturnsCorrectSumForFives()
        {
            int[] diceRolls = new int[] { 5, 5, 1, 2, 3 };

            int score = YahtzeeScorer.Score(Category.Fives, diceRolls);

            Assert.AreEqual(10, score);
        }

        [TestMethod]
        public void ReturnsCorrectSumForSixes()
        {
            int[] diceRolls = new int[] { 6, 6, 1, 2, 3 };

            int score = YahtzeeScorer.Score(Category.Sixes, diceRolls);

            Assert.AreEqual(12, score);
        }

        [TestMethod]
        public void ReturnsZeroWhenNoMatchesAreFound()
        {
            int[] diceRolls = new int[] { 2, 3, 4, 5, 6 };

            int score = YahtzeeScorer.Score(Category.Ones, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenNumberToMatchIsLessThanOne_ShouldThrowArgumentOutOfRange()
        {
            int[] diceRolls = new int[5];

            YahtzeeScorer.Score(Category.Ones, diceRolls);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenNumberToMatchIsGreaterThanSix_ShouldThrowArgumentOutOfRange()
        {
            int[] diceRolls = new int[5];

            YahtzeeScorer.Score(Category.Ones, diceRolls);
        }

    }

    [TestClass]
    public class PairTests
    {
        [TestMethod]
        public void SumsHighestDice()
        {
            int[] diceRolls = new int[] { 3, 3, 3, 4, 4 };

            int score = YahtzeeScorer.Score(Category.Pair, diceRolls);

            Assert.AreEqual(8, score);
        }

        [TestMethod]
        public void WhenThereAreNoPairs_ReturnsZero()
        {
            int[] diceRolls = new int[] { 1, 2, 3, 4, 6 };

            int score = YahtzeeScorer.Score(Category.Pair, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void WhenThereAreMoreThanTwoMatching_OnlySumsPair()
        {
            int[] diceRolls = new int[] { 1, 1, 1, 1, 1 };

            int score = YahtzeeScorer.Score(Category.Pair, diceRolls);

            Assert.AreEqual(2, score);
        }
    }

    [TestClass]
    public class TwoPairsTests
    {
        [TestMethod]
        public void ReturnsCorrectSum()
        {
            int[] diceRolls = new int[] { 1, 1, 2, 3, 3 };

            int score = YahtzeeScorer.Score(Category.TwoPair, diceRolls);

            Assert.AreEqual(8, score);
        }

        [TestMethod]
        public void WhenOnlyOnePair_ReturnsZero()
        {
            int[] diceRolls = new int[] { 1, 1, 2, 3, 4 };

            int score = YahtzeeScorer.Score(Category.TwoPair, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void WhenNoPairs_ReturnsZero()
        {
            int[] diceRolls = new int[] { 1, 2, 3, 4, 5 };

            int score = YahtzeeScorer.Score(Category.TwoPair, diceRolls);

            Assert.AreEqual(0, score);
        }
    }

    [TestClass]
    public class ThreeOfAKindTests
    {
        [TestMethod]
        public void WhenNoneMatch_ReturnsZero()
        {
            int[] diceRolls = new int[] { 1, 2, 3, 4, 5 };

            int score = YahtzeeScorer.Score(Category.ThreeOfAKind, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void WhenLessThanThreeMatch_ReturnsZero()
        {
            int[] diceRolls = new int[] { 1, 1, 3, 4, 5 };

            int score = YahtzeeScorer.Score(Category.ThreeOfAKind, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void WhenMoreThanThreeMatch_OnlySumsThree()
        {
            int[] diceRolls = new int[] { 1, 1, 1, 1, 1 };

            int score = YahtzeeScorer.Score(Category.ThreeOfAKind, diceRolls);

            Assert.AreEqual(3, score);
        }

        [TestMethod]
        public void ReturnsCorrectSumForThreeofaKind()
        {
            int[] diceRolls = new int[] { 3, 3, 3, 4, 5 };

            int score = YahtzeeScorer.Score(Category.ThreeOfAKind, diceRolls);

            Assert.AreEqual(9, score);
        }
    }

    [TestClass]
    public class FourOfAKindTests
    {
        [TestMethod]
        public void ReturnsCorrectSum()
        {
            int[] diceRolls = new int[] { 2, 2, 2, 2, 5 };

            int score = YahtzeeScorer.Score(Category.FourOfAKind, diceRolls);

            Assert.AreEqual(8, score);
        }

        [TestMethod]
        public void WhenNoneMatch_ReturnsZero()
        {
            int[] diceRolls = new int[] { 1, 2, 3, 4, 5 };

            int score = YahtzeeScorer.Score(Category.FourOfAKind, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void WhenLessThanFourMatch_ReturnsZero()
        {
            int[] diceRolls = new int[] { 2, 2, 2, 3, 5 };

            int score = YahtzeeScorer.Score(Category.FourOfAKind, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void WhenMoreThanFourMatch_OnlySumsFour()
        {
            int[] diceRolls = new int[] { 2, 2, 2, 2, 2 };

            int score = YahtzeeScorer.Score(Category.FourOfAKind, diceRolls);

            Assert.AreEqual(8, score);
        }
    }

    [TestClass]
    public class SmallStraightTests
    {
        [TestMethod]
        public void ReturnsCorrectSum()
        {
            int[] diceRolls = new int[] { 1, 2, 3, 4, 5 };

            int score = YahtzeeScorer.Score(Category.SmallStraight, diceRolls);

            Assert.AreEqual(15, score);
        }

        [TestMethod]
        public void WhenRollsAreUnordered_ReturnsCorrectSum()
        {
            int[] diceRolls = new int[] { 1, 3, 2, 5, 4 };

            int score = YahtzeeScorer.Score(Category.SmallStraight, diceRolls);

            Assert.AreEqual(15, score);
        }

        [TestMethod]
        public void WhenDuplicateDiceExist_ReturnsZero()
        {
            int[] diceRolls = new int[] { 1, 2, 2, 4, 5 };

            int score = YahtzeeScorer.Score(Category.SmallStraight, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void WhenDiceMatchLargeStraight_ReturnsZero()
        {
            int[] diceRolls = new int[] { 2, 3, 4, 5, 6 };

            int score = YahtzeeScorer.Score(Category.SmallStraight, diceRolls);

            Assert.AreEqual(0, score);
        }
    }

    [TestClass]
    public class LargeStraightTests
    {
        [TestMethod]
        public void ReturnsCorrectSum()
        {
            int[] diceRolls = new int[] { 2, 3, 4, 5, 6 };

            int score = YahtzeeScorer.Score(Category.LargeStraight, diceRolls);

            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void WhenRollsAreUnordered_ReturnsCorrectSum()
        {
            int[] diceRolls = new int[] { 2, 3, 6, 5, 4 };

            int score = YahtzeeScorer.Score(Category.LargeStraight, diceRolls);

            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void WhenDuplicateDiceExist_ReturnsZero()
        {
            int[] diceRolls = new int[] { 1, 2, 2, 4, 5 };

            int score = YahtzeeScorer.Score(Category.LargeStraight, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void WhenDiceMatchSmallStraight_ReturnsZero()
        {
            int[] diceRolls = new int[] { 1, 2, 3, 4, 5 };

            int score = YahtzeeScorer.Score(Category.LargeStraight, diceRolls);

            Assert.AreEqual(0, score);
        }
    }

    [TestClass]
    public class FullHouseTests
    {
        [TestMethod]
        public void ReturnsCorrectSum()
        {
            int[] diceRolls = new int[] { 1, 1, 2, 2, 2 };

            int score = YahtzeeScorer.Score(Category.FullHouse, diceRolls);

            Assert.AreEqual(8, score);
        }

        [TestMethod]
        public void WhenAllDiceMatch_ReturnsZero()
        {
            int[] diceRolls = new int[] { 4, 4, 4, 4, 4 };

            int score = YahtzeeScorer.Score(Category.FullHouse, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void WhenOnlyTwoDiceMatch_ReturnsZero()
        {
            int[] diceRolls = new int[] { 4, 4, 1, 2, 3 };

            int score = YahtzeeScorer.Score(Category.FullHouse, diceRolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void WhenOnlyThreeDiceMatch_ReturnsZero()
        {
            int[] diceRolls = new int[] { 4, 4, 4, 1, 2 };

            int score = YahtzeeScorer.Score(Category.FullHouse, diceRolls);

            Assert.AreEqual(0, score);
        }       
    }

    [TestClass]
    public class YahtzeeTests
    {
        [TestMethod]
        public void OnMatch_ReturnsOnlyFifty()
        {
            int[] aRolls = new int[] { 1, 1, 1, 1, 1 };
            int[] bRolls = new int[] { 6, 6, 6, 6, 6 };

            int aScore = YahtzeeScorer.Score(Category.Yahtzee, aRolls);
            int bScore = YahtzeeScorer.Score(Category.Yahtzee, bRolls);

            Assert.AreEqual(50, aScore);
            Assert.AreEqual(50, bScore);
        }

        [TestMethod]
        public void WhenLessThanFiveMatch_ReturnsZero()
        {
            int[] diceRolls = new int[] { 2, 1, 1, 1, 1 };

            int score = YahtzeeScorer.Score(Category.Yahtzee, diceRolls);

            Assert.AreEqual(0, score);
        }
    }

    [TestClass]
    public class ChanceTests
    {
        [TestMethod]
        public void ReturnsSumOfAllDice()
        {
            int[] diceRolls = new int[] { 1, 1, 1, 1, 1 };

            int score = YahtzeeScorer.Score(Category.Chance, diceRolls);

            Assert.AreEqual(5, score);
        }
    }

    [TestClass]
    public class ValidateDiceRolls
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenRollsAreLessThanFive_ShouldThrowArgumentOutOfRange()
        {
            int[] diceRolls = new int[4];

            YahtzeeScorer.Score(Category.Ones, diceRolls);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenRollsAreGreaterThanFive_ShouldThrowArgumentOutOfRange()
        {
            int[] diceRolls = new int[6];

            YahtzeeScorer.Score(Category.Ones, diceRolls);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenDiceIsGreaterThanSix_ShouldThrowArgumentOutOfRange()
        {
            int[] diceRolls = new int[] { 6, 6, 6, 6, 7 };

            YahtzeeScorer.Score(Category.Ones, diceRolls);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenDiceIsLessThanOne_ShouldThrowArgumentOutOfRange()
        {
            int[] diceRolls = new int[] { 6, 6, 6, 6, 0 };

            YahtzeeScorer.Score(Category.Ones, diceRolls);
        }
    }
}
