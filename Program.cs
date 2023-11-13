using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("----------------------- First task -----------------------");
        //First();
        Console.WriteLine("----------------------- Second task -----------------------");
        Second();
        Console.WriteLine("----------------------- Third task -----------------------");
        //Third();
        Console.WriteLine("----------------------- Forth task -----------------------");
        //Forth();
        Console.WriteLine("----------------------- Fifth task -----------------------");
        //Fifth();
        Console.ReadKey();
    }
    private static void First()
    {
        string letter;
        Regex regex = new Regex("[a-zA-Z]");
        Match match;

        do
        {
            Console.WriteLine("Write a one letter:");
            letter = Console.ReadLine() ?? "";
            match = regex.Match(letter);
        }
        while (letter == null || letter.Length != 1 || !match.Success);


        string letterToLower = letter.ToLower();
        int placeInAlphabet = char.Parse(letterToLower) - 'a';
        Console.WriteLine($"{letter} is {placeInAlphabet + 1} letter in alphabet");
        if (letter == letterToLower)
        {
            Console.WriteLine($"{letter} to upper case - {letter.ToUpper()}");
        }
        else
        {
            Console.WriteLine($"{letter} to lover case - {letterToLower}");
        }
    }

    private static void Second()
    {
        Console.WriteLine("Write a string:");
        string str = Console.ReadLine() ?? "";
        Console.WriteLine("Write a delimiter:");
        string delimiter = Console.ReadLine() ?? "";
        List<string> result = new List<string>();
        int index = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i].ToString() == delimiter)
            {
                result.Add(str.Substring(index, i - index));
                index = i + 1;
            }
        }

        result.Add(str.Substring(index));

        foreach (string s in result)
        {
            Console.WriteLine(s.Trim());
        }
    }

    private static void Third()
    {
        Console.WriteLine("Write a string:");
        string str = Console.ReadLine() ?? "";
        Console.WriteLine("Write a substring:");
        string subStr = Console.ReadLine() ?? "";
        Regex regex = new Regex($"{subStr}");
        var match = regex.Matches(str);
        if (match.Count != 0)
        {
            foreach(Match m in match)
            {
                Console.WriteLine($"{subStr} on {m.Index} position");
            }
        }
        else
        {
            Console.WriteLine("Substring is not found");
        }
    }

    private static void Forth()
    {
        Console.WriteLine("Write a number (up to 9999):");
        string input = Console.ReadLine() ?? "";
        string[] toTen = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] toNineteen = { "ten", "eleven", "three", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] toHundred = { "0", "1", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        string hundred = "hundred";
        string thousand = "thousand";

        int symbols = input.Length;
        switch (symbols)
        {
            case 0:
                Console.WriteLine("No number");
                break;
            case 1:
                Console.WriteLine(toTen[input[0]]);
                break;
            case 2:
                if (input[0] == '1')
                {
                    Console.WriteLine(toNineteen[input[1] - '0']);
                    break;
                }
                else
                {
                    Console.WriteLine($"{toHundred[input[0] - '0']} {(input[1] != '0' ? toTen[input[1] - '0'] : "")}");
                    break;
                }
            case 3:
                string tensForHundred;
                if (input[1] == '1')
                {
                    tensForHundred = toNineteen[input[2] - '0'];
                }
                else
                {
                    tensForHundred = $"{toHundred[input[1] - '0']} {(input[2] != '0' ? toTen[input[2] - '0'] : "")}";
                }
                Console.WriteLine(
                    $"{(input[0] != '1' ? toTen[input[0] - '0'] : "a")} {hundred}" +
                    $" {(input[1] != '0' ? tensForHundred : input[2] != '0' ? toTen[input[2] - '0'] : "")}");
                break;
            case 4:
                string tensForThousand;
                if (input[2] == '1')
                {
                    tensForThousand = toNineteen[input[3] - '0'];
                }
                else
                {
                    tensForThousand = $"{toHundred[input[2] - '0']} {(input[3] != '0' ? toTen[input[3] - '0'] : "")}";
                }
                Console.WriteLine(
                    $"{toTen[input[0] - '0']} {thousand} " +
                    $"{(input[1] != '0' ? toTen[input[1] - '0'] + " " + hundred : "")}" +
                    $" {(input[2] != '0' ? tensForThousand : input[3] != '0' ? toTen[input[3] - '0'] : "")}");
                break;
            default:
                Console.WriteLine("Opps... Enter a number less than 10000");
                break;
        }

    }

    private static void Fifth()
    {
        Console.WriteLine("Write a first number:");
        string firsString = Console.ReadLine() ?? "";
        Regex regex = new Regex("^[0-9]+$");
        Match match = regex.Match(firsString);
        while (!match.Success) 
        {
            Console.WriteLine("Write a first number:");
            firsString = Console.ReadLine() ?? "";
        }
        Console.WriteLine("Write a second number:");
        string secondString = Console.ReadLine() ?? "";
        match = regex.Match(secondString);
        while (!match.Success)
        {
            Console.WriteLine("Write a secondNumber number:");
            secondString = Console.ReadLine() ?? "";
        }
        Console.WriteLine($"First number is {firsString}");
        Console.WriteLine($"Second number is {secondString}");
        int firstNumber = int.Parse(firsString);
        int secondNumber = int.Parse(secondString);
        firstNumber += secondNumber;
        secondNumber = firstNumber - secondNumber;
        firstNumber -= secondNumber;
        Console.WriteLine($"Now first number is {firstNumber}");
        Console.WriteLine($"Now second number is {secondNumber}");

    }
}