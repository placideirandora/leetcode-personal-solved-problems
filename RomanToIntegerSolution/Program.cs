using System;
using System.Collections.Generic;

// CONVERSION FROM ROMAN NUMERAL TO INTEGER
// SOURCE: https://leetcode.com/problems/roman-to-integer/submissions/
namespace RomanToIntegerSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INPUT ROMAIN NUMERAL: CM");
            Console.WriteLine($"RETURNED INTEGER NUMBER: {RomanToInt("CM")}");
            Console.WriteLine("EXPECTED INTEGER NUMBER: 900");
        }

        public static int RomanToInt(string romanNumeral)
        {
            int integerNumber = 0;
            var skippedIndecesList = new List<int>();
            char[] romanNumeralArr = romanNumeral.ToCharArray();

            if (IsRomanNumeralValid(romanNumeralArr) == false)
            {
                return integerNumber;
            }

            if (romanNumeralArr.Length == 1)
            {
                integerNumber = ReturnCorrespondingSingleNumber(romanNumeralArr[0]);
            }

            else if (romanNumeralArr.Length == 2)
            {

                if (ReturnCorrespondingDoubleNumber(romanNumeralArr) > 0)
                {
                    integerNumber = ReturnCorrespondingDoubleNumber(romanNumeralArr);
                }
                else
                {
                    integerNumber = ReturnCorrespondingGeneralNumber(romanNumeralArr);
                }
            }

            else
            {
                for (int charIndex = 0; charIndex < romanNumeralArr.Length; charIndex++)
                {
                    bool IsCaseIV = romanNumeralArr[charIndex].Equals('I') && romanNumeralArr[NextValidIndex(charIndex, romanNumeralArr.Length)].Equals('V');
                    bool IsCaseIX = romanNumeralArr[charIndex].Equals('I') && romanNumeralArr[NextValidIndex(charIndex, romanNumeralArr.Length)].Equals('X');
                    bool IsCaseXL = romanNumeralArr[charIndex].Equals('X') && romanNumeralArr[NextValidIndex(charIndex, romanNumeralArr.Length)].Equals('L');
                    bool IsCaseXC = romanNumeralArr[charIndex].Equals('X') && romanNumeralArr[NextValidIndex(charIndex, romanNumeralArr.Length)].Equals('C');
                    bool IsCaseCD = romanNumeralArr[charIndex].Equals('C') && romanNumeralArr[NextValidIndex(charIndex, romanNumeralArr.Length)].Equals('D');
                    bool IsCaseCM = romanNumeralArr[charIndex].Equals('C') && romanNumeralArr[NextValidIndex(charIndex, romanNumeralArr.Length)].Equals('M');

                    if (IsCaseIV)
                    {
                        skippedIndecesList.Add(charIndex);
                        skippedIndecesList.Add(NextValidIndex(charIndex, romanNumeralArr.Length));

                        integerNumber += 4;
                    }

                    else if (IsCaseIX)
                    {
                        skippedIndecesList.Add(charIndex);
                        skippedIndecesList.Add(NextValidIndex(charIndex, romanNumeralArr.Length));

                        integerNumber += 9;
                    }

                    else if (IsCaseXL)
                    {
                        skippedIndecesList.Add(charIndex);
                        skippedIndecesList.Add(NextValidIndex(charIndex, romanNumeralArr.Length));

                        integerNumber += 40;
                    }

                    else if (IsCaseXC)
                    {
                        skippedIndecesList.Add(charIndex);
                        skippedIndecesList.Add(NextValidIndex(charIndex, romanNumeralArr.Length));

                        integerNumber += 90;
                    }

                    else if (IsCaseCD)
                    {
                        skippedIndecesList.Add(charIndex);
                        skippedIndecesList.Add(NextValidIndex(charIndex, romanNumeralArr.Length));

                        integerNumber += 400;
                    }

                    else if (IsCaseCM)
                    {
                        skippedIndecesList.Add(charIndex);
                        skippedIndecesList.Add(NextValidIndex(charIndex, romanNumeralArr.Length));

                        integerNumber += 900;
                    }

                    else
                    {
                        if (skippedIndecesList.Count > 0 && skippedIndecesList.Contains(charIndex))
                        {

                            continue;
                        }
                        else
                        {
                            integerNumber += ReturnCorrespondingSingleNumber(romanNumeralArr[charIndex]);
                        }

                    }

                }
            }

            if (IsRomanNumeralRangeValid(integerNumber))
            {
                return integerNumber;

            }
            else
            {
                return 0;
            }


        }


        private static int NextValidIndex(int number, int max)
        {
            number = number + 1;

            if (number >= 0 && number < max)
            {
                return number;
            }
            else
            {
                return max - 1;
            }
        }

        private static int ReturnCorrespondingGeneralNumber(char[] romanNumeralArr)
        {
            int number = 0;

            foreach (char romanNumeralCharacter in romanNumeralArr)
            {
                number += ReturnCorrespondingSingleNumber(romanNumeralCharacter);
            }

            return number;
        }

        private static int ReturnCorrespondingDoubleNumber(char[] romanNumeralArr)
        {
            int number = 0;
            bool IsRomanFour = romanNumeralArr[0].Equals('I') && romanNumeralArr[1].Equals('V');
            bool IsRomanNine = romanNumeralArr[0].Equals('I') && romanNumeralArr[1].Equals('X');
            bool IsRomanForty = romanNumeralArr[0].Equals('X') && romanNumeralArr[1].Equals('L');
            bool IsRomanNinety = romanNumeralArr[0].Equals('X') && romanNumeralArr[1].Equals('C');
            bool IsRomanFourHundred = romanNumeralArr[0].Equals('C') && romanNumeralArr[1].Equals('D');
            bool IsRomanNineHundred = romanNumeralArr[0].Equals('C') && romanNumeralArr[1].Equals('M');

            if (IsRomanFour)
            {
                number = 4;
            }

            if (IsRomanNine)
            {
                number = 9;
            }

            if (IsRomanForty)
            {
                number = 40;
            }

            if (IsRomanNinety)
            {
                number = 90;
            }

            if (IsRomanFourHundred)
            {
                number = 400;
            }

            if (IsRomanNineHundred)
            {
                number = 900;
            }

            return number;
        }

        private static int ReturnCorrespondingSingleNumber(char romanCharacter)
        {
            int number = 0;

            switch (romanCharacter)
            {
                case 'I':
                    number = 1;
                    break;
                case 'V':
                    number = 5;
                    break;
                case 'X':
                    number = 10;
                    break;
                case 'L':
                    number = 50;
                    break;
                case 'C':
                    number = 100;
                    break;
                case 'D':
                    number = 500;
                    break;
                case 'M':
                    number = 1000;
                    break;
                default:
                    number = 0;
                    break;
            }

            return number;
        }

        private static bool IsRomanNumeralValid(char[] romainNumeralArr)
        {
            var validCharacters = new List<char> { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

            if (romainNumeralArr.Length >= 1 && romainNumeralArr.Length <= 15)
            {


                foreach (char character in romainNumeralArr)
                {
                    if (validCharacters.Contains(character))
                    {
                        continue;
                    }

                    return false;
                }

                return true;
            }

            return false;
        }

        private static bool IsRomanNumeralRangeValid(int finalNumber)
        {
            if (finalNumber >= 0 && finalNumber <= 3999)
            {
                return true;
            }

            return false;
        }
    }
}
