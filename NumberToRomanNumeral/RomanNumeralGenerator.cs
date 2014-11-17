using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NumberToRomanNumeral
{
    /// <summary>
    /// An alternate Roman Numeral generator, that doesn't use recursion and instead leverages features of the .Net 4.0 framework
    /// </summary>
    class RomanNumeralGenerator_Alternate : IRomanNumeralGenerator
    {
        public string generate(int number)
        {
            // Validate number
            if (number < 0 || number > 3999)
                throw new ArgumentException("Input numbers must lie in the range 0 - 3999");

            if (number < 1)
                return string.Empty;

            // Setup variables
            StringBuilder numeralString = new StringBuilder();
            int remainingValueToConvert = number;
            Tuple<string, int> numeralValue;

            // Iterate over M as many times as required
            numeralValue = GenerateNumeral("M", 1000, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            // and repeat for the other unique numerals
            numeralValue = GenerateNumeral("CM", 900, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("D", 500, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("CD", 400, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("C", 100, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("XC", 90, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("L", 50, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("XL", 40, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("X", 10, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("IX", 9, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("V", 5, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("IV", 4, remainingValueToConvert);
            remainingValueToConvert = numeralValue.Item2;
            numeralString.Append(numeralValue.Item1);

            numeralValue = GenerateNumeral("I", 1, remainingValueToConvert);
            numeralString.Append(numeralValue.Item1);

            return numeralString.ToString();
        }

        private static Tuple<string, int> GenerateNumeral(string numeral, int numeralValue, int number)
        {
            // Return the numeral repeated as many times as possibly (via modding) and return the current value of the number (after division)
            if (number >= numeralValue)
            {
                Debug.WriteLine(numeral + ", worth " + numeralValue + " repeated " + number / numeralValue + " times for value " + number);
                return Tuple.Create(string.Concat(Enumerable.Repeat(numeral, number / numeralValue)), number % numeralValue);
            }
            return Tuple.Create(string.Empty, number);
        }
    }
}