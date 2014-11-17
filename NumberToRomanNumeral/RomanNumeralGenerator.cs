using System;

namespace NumberToRomanNumeral
{
    /// <summary>
    /// A simple Roman Numeral generator that uses recursion and string concatenation
    /// </summary>
    class RomanNumeralGenerator: IRomanNumeralGenerator
    {
        public string generate(int number)
        {
            // Validate number
            if (number < 0 || number > 3999)
                throw new ArgumentException("Input numbers must lie in the range 0 - 3999");

            if (number < 1)
                return string.Empty;

            if (number >= 1000)
                return "M" + generate(number - 1000);
            if (number >= 900)
                return "CM" + generate(number - 900);
            if (number >= 500)
                return "D" + generate(number - 500);
            if (number >= 400)
                return "CD" + generate(number - 400);
            if (number >= 100)
                return "C" + generate(number - 100);
            if (number >= 90)
                return "XC" + generate(number - 90);
            if (number >= 50)
                return "L" + generate(number - 50);
            if (number >= 40)
                return "XL" + generate(number - 40);
            if (number >= 10)
                return "X" + generate(number - 10);
            if (number >= 9)
                return "IX" + generate(number - 9);
            if (number >= 5)
                return "V" + generate(number - 5);
            if (number >= 4)
                return "IV" + generate(number - 4);
            if (number >= 1)
                return "I" + generate(number - 1);
            // All code paths should be accounted for, and this should not be reached
            throw new ArgumentOutOfRangeException("number");
        }
    }
}
