using System;

namespace NumberToRomanNumeral
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException("args");

            if (args.Length < 1)
                throw new IndexOutOfRangeException("No arguements were specified");

            int number;
            if (!int.TryParse(args[0], out number))
                throw new ArgumentException("Argument specified was not a valid 32 bit integer");

            RomanNumeralGenerator generator = new RomanNumeralGenerator();
            Console.WriteLine(generator.generate(number));
        }
    }
}
