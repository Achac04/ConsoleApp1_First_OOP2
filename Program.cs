using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_First_OOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Task 1: Creating Variables*/
            /*Console.WriteLine("Enter a Low Number: ");
            int Low = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a High Number: ");
            int High = Convert.ToInt32(Console.ReadLine());
            int difference = Low - High;
            Console.WriteLine("The Difference Between the Low Number and High Number is: " + Low);*/

            /* Taks 2: Looping and input Validation*/
            /*int Low_number = 0;
            while(true)
            {
                Console.WriteLine("Enter a Low Number: ");
                Low_number = Convert.ToInt32(Console.ReadLine());
                if (Low_number >= 0)
                {
                    break;
                }
            }

            int High_number = 0;
            while (true)
            {
                Console.WriteLine("Enter a High Number: ");
                High_number = Convert.ToInt32(Console.ReadLine());
                if (High_number > Low_number)
                {
                    break;
                }
            }*/

            /*Task 3: Using Arrays and File I/O*/
            /*int Low_number = 3;
            int High_number = 10;
            int[] numbersArray = Enumerable.Range(Low_number, High_number - Low_number + 1).ToArray();
            string filePath = "numbers.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int number in numbersArray.Reverse())
                {
                    writer.WriteLine(number);
                }
            }*/

            int Low = GetUserInput("Enter the Lower number: ");
            int High = GetUserInput("Enter the Higher number: ");
            int[] numbersArray = Enumerable.Range(Low, High - Low + 1).ToArray();
            double[] doubleArray = numbersArray.Select(x => (double)x).ToArray();
            WriteNumbersToFile(doubleArray, "doubleNumbers.txt");
            double sum = ReadNumbersFromFileGetSum("doubleNumbers.txt");
            Console.WriteLine($"Sum of numbers in the file: {sum}");
            Console.WriteLine($"Prime numbers between {Low} and {High}:");
            PrintPrimeNumbers(Low, High);
        }

        /* Additional Tasks*/
        /* 1.Use methods get and validate the users input.*/
        static int GetUserInput(string message)
        {
            int userInput = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out userInput) && userInput >= 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
            return userInput;
        }

        /* 2.Read the numbers back from the file and print out the sum of the numbers.*/
        static double ReadNumbersFromFileGetSum(string filePath)
        {
            double sum = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (double.TryParse(line, out double number))
                    {
                        sum += number;
                    }
                }
            }
            return sum;
        }

        /* 3.Use a List instead of an array variable to store the numbers.*/
        static void WriteNumbersToFile(double[] numbersArray, string filePath)
        {
            List<double> numbersList = numbersArray.Reverse().ToList();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (double number in numbersList)
                {
                    writer.WriteLine(number);
                }
            }
        }
        /* 5.Print out the prime numbers between low and high*/
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }
        static void PrintPrimeNumbers(int low, int high)
        {
            for (int number = low; number <= high; number++)
            {
                if (IsPrime(number))
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
