using System;
using System.Linq;

namespace YahtzeeKata
{
    public static class YahtzeeScorer
    {
        const string diceRollsGreaterThanFiveMessage = "The number of dice are greater than five. They must equal five.";
        const string diceRollsLessThanFiveMessage = "The number of dice are less than five. They must equal five.";
        const string diceGreaterThanSixMessage = "A rolled dice was greater than six. Only six sided die are valid.";
        const string diceLessThanOneMessage = "A rolled dice was less than one. Only six sided die are valid.";

        public static int Score(Category category, int[] diceRolls)
        {
            ValidateDiceRolls(diceRolls);
            int score = 0;

            switch (category)
            {
                case Category.Ones:
                    score = Singles(diceRolls, 1);
                    break;
                case Category.Twos:
                    score = Singles(diceRolls, 2);
                    break;
                case Category.Threes:
                    score = Singles(diceRolls, 3);
                    break;
                case Category.Fours:
                    score = Singles(diceRolls, 4);
                    break;
                case Category.Fives:
                    score = Singles(diceRolls, 5);
                    break;
                case Category.Sixes:
                    score = Singles(diceRolls, 6);
                    break;
                case Category.Pair:
                    score = Pair(diceRolls);
                    break;
                case Category.TwoPair:
                    score = TwoPairs(diceRolls);
                    break;
                case Category.ThreeOfAKind:
                    score = ThreeOfAKind(diceRolls);
                    break;
                case Category.FourOfAKind:
                    score = FourOfAKind(diceRolls);
                    break;
                case Category.SmallStraight:
                    score = SmallStraight(diceRolls);
                    break;
                case Category.LargeStraight:
                    score = LargeStraight(diceRolls);
                    break;
                case Category.FullHouse:
                    score = FullHouse(diceRolls);
                    break;
                case Category.Yahtzee:
                    score = Yahtzee(diceRolls);
                    break;
                case Category.Chance:
                    score = Chance(diceRolls);
                    break;
                default:
                    throw new NotImplementedException(string.Format("The category {0} has not been implemented.", category));
            }

            return score;
        }

        static void ValidateDiceRolls(int[] diceRolls)
        {
            if (diceRolls.Length < 5)
                throw new ArgumentOutOfRangeException("diceRolls", diceRolls.Length, diceRollsLessThanFiveMessage);

            if (diceRolls.Length > 5)
                throw new ArgumentOutOfRangeException("diceRolls", diceRolls.Length, diceRollsGreaterThanFiveMessage);

            for (int i = 0; i < diceRolls.Length; i++)
            {
                if (diceRolls[i] > 6)
                    throw new ArgumentOutOfRangeException(
                        string.Format("diceRolls[{0}]", i), diceGreaterThanSixMessage);
                if (diceRolls[i] < 1)
                    throw new ArgumentOutOfRangeException(
                        string.Format("diceRolls[{0}]", i), diceLessThanOneMessage);
            }
        }

        /// <summary>
        /// The player scores the sum of the dice that reads 
        /// one, two, three, four, five or six, respectively. 
        /// </summary>
        static int Singles(int[] diceRolls, int toMatch)
        {
            if (toMatch > 6 || toMatch < 1)
                throw new ArgumentOutOfRangeException("toMatch", toMatch, "Number to match must appear on a six sided die.");

            int sum = 0;
            for (int i = 0; i < diceRolls.Length; i++)
            {
                if (diceRolls[i] == toMatch)
                    sum += diceRolls[i];
            }

            return sum;
        }

        /// <summary>
        /// The player scores the sum of the two highest matching dice.
        /// </summary>
        static int Pair(int[] diceRolls)
        {
            for (int i = 6; i >= 1; i--)
            {
                int[] matchingdiceRolls = Array.FindAll<int>(diceRolls, (x) => x == i);
                if (matchingdiceRolls.Length >= 2)
                    return 2 * i;
            }

            return 0;
        }

        /// <summary>
        /// If there are two pairs of dice with the same number, 
        /// the player scores the sum of these dice. 
        /// If not, the player scores 0. 
        /// </summary>
        static int TwoPairs(int[] diceRolls)
        {
            bool foundFirstPair = false;
            int sum = 0;

            for (int i = 1; i <= 6; i++)
            {
                int[] matchingdiceRolls = Array.FindAll<int>(diceRolls, (x) => x == i);
                if (matchingdiceRolls.Length >= 2)
                {
                    sum += 2 * i;

                    if (foundFirstPair)
                        return sum;
                    else
                        foundFirstPair = true;
                }
            }

            return 0;
        }

        /// <summary>
        /// If there are three dice with the same number, 
        /// the player scores the sum of these dice. 
        /// Otherwise, the player scores 0. 
        /// </summary>
        static int ThreeOfAKind(int[] diceRolls)
        {
            for (int i = 1; i <= 6; i++)
            {
                int[] matchingdiceRolls = Array.FindAll<int>(diceRolls, (x) => x == i);
                if (matchingdiceRolls.Length >= 3)
                    return 3 * i;
            }

            return 0;
        }

        /// <summary>
        /// If there are four dice with the same number, 
        /// the player scores the sum of these dice. 
        /// Otherwise, the player scores 0. 
        /// </summary>
        static int FourOfAKind(int[] diceRolls)
        {
            for (int i = 1; i <= 6; i++)
            {
                int[] matchingdiceRolls = Array.FindAll<int>(diceRolls, (x) => x == i);
                if (matchingdiceRolls.Length >= 4)
                    return 4 * i;
            }

            return 0;
        }

        /// <summary>
        /// If the dice read 1,2,3,4,5, 
        /// the player scores 15 (the sum of all the dice), otherwise 0.
        /// </summary>
        static int SmallStraight(int[] diceRolls)
        {
            int[] smallStraight = new int[] { 1, 2, 3, 4, 5 };
            Array.Sort(diceRolls);

            if (ArraysAreEqual(diceRolls, smallStraight))
                return 15;
            else
                return 0;
        }

        /// <summary>
        /// If the dice read 2,3,4,5,6, 
        /// the player scores 20 (the sum of all the dice), otherwise 0.
        /// </summary>
        static int LargeStraight(int[] diceRolls)
        {
            int[] largeStraight = new int[] { 2, 3, 4, 5, 6 };
            Array.Sort(diceRolls);

            if (ArraysAreEqual(diceRolls, largeStraight))
                return 20;
            else
                return 0;
        }

        /// <summary>
        /// If the dice are two of a kind and three of a kind, 
        /// the player scores the sum of all the dice. 
        /// </summary>
        static int FullHouse(int[] diceRolls)
        {
            bool foundTwo = false;
            bool foundThree = false;

            for (int i = 1; i <= 6; i++)
            {
                int[] matchingdiceRolls = Array.FindAll<int>(diceRolls, (x) => x == i);

                if (matchingdiceRolls.Length == 2)
                    foundTwo = true;
                else if (matchingdiceRolls.Length == 3)
                    foundThree = true;
            }

            if (foundTwo && foundThree)
                return diceRolls.Sum();
            else
                return 0;
        }

        /// <summary>
        /// If all dice are the have the same number, 
        /// the player scores 50 points, otherwise 0.
        /// </summary>
        static int Yahtzee(int[] diceRolls)
        {
            for (int i = 0; i < diceRolls.Length; i++)
            {
                if (diceRolls[i] != diceRolls[0])
                    return 0;
            }

            return 50;
        }

        /// <summary>
        /// The player gets the sum of all dice, no matter what they read.
        /// </summary>
        static int Chance(int[] diceRolls)
        {
            return diceRolls.Sum();
        }

        static bool ArraysAreEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i])
                    return false;

            return true;
        }
    }
}
