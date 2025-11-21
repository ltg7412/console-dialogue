using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueSystem
{
    internal static class Utility
    {
        internal static string UserInputStr()
        {
            string? userInput;

            userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput.Trim()))
            {
                return userInput.Trim();
            }

            PrintError("Try Again:");
            return UserInputStr();
        }
        internal static bool UserInputBool()
        {
            string boolStr = UserInputStr();
            bool userInputBool;

            switch (boolStr.ToLower())
            {
                case "n" or "no" or "nope":
                    return false;
                case "y" or "yes" or "yeah":
                    return true;
                case "maybe":
                    Console.WriteLine("I'll take that as a no...");
                    return false;
            }

            PrintError("Yes or No:");

            return UserInputBool();
        }
        internal static int UserInputInt()
        {
            string intStr = UserInputStr();

            try
            {
                return int.Parse(intStr);
            }
            catch
            {
                PrintError($"{intStr} is not a number. Try again:");
                return UserInputInt();
            }
        }

        internal static int UserInputInt(int min, int max)
        {
            int userInputInt = UserInputInt();

            if (userInputInt >= min && userInputInt <= max)
            {
                return userInputInt;
            }

            PrintError($"Try again {min}-{max}:");
            return UserInputInt(min, max);
        }

        internal static int ClampInt(int value, int min, int max)
        {
            if (value > max) { return min; }
            if (value < min) { return max; }
            return value;
        }
        internal static void PrintColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        internal static void PrintError(string message)
        {
            PrintColor(message, ConsoleColor.Red);
        }
        internal static void PrintSystem(string message)
        {
            PrintColor(message, ConsoleColor.DarkYellow);
        }
        internal static void PrintInfo(string message)
        {
            PrintColor(message, ConsoleColor.Cyan);
        }
        internal static string PadMessage(string message, char with, int width)
        {
            if (message.Length >= width) { return message; }

            int halfWidth = width / 2;

            return message.PadLeft(halfWidth, with).PadRight(width-halfWidth, with);
        }
    }
}
