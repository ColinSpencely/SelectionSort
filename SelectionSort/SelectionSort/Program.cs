using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> numbers = new List<int>();

            Console.WriteLine("Welcome to Selection Sort!\nTime Complexity = O(n^2)\nSpace Complexity = O(1)\n");
            numbers = FillList(numbers, rand);
            Console.WriteLine("\nUnsorted List: ");
            PrintPrettyList(numbers);
            numbers = SelectionSort(numbers);
            Console.WriteLine("\nInsertion Sort: ");
            PrintPrettyList(numbers);
        }

        static List<int> SelectionSort(List<int> nums)
        {
            int lowestIndex = 0;
            int temp = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                lowestIndex = i;
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[j] < nums[lowestIndex])
                    {
                        lowestIndex = j;
                    }
                }
                temp = nums[i];
                nums[i] = nums[lowestIndex];
                nums[lowestIndex] = temp;
            }

            return nums;
        }

        // Function prints a list of ints with 10 ints per row.
        // Function takes a list of int as an argument.
        // Function returns void.
        static void PrintPrettyList(List<int> nums)
        {
            // Loop through each number in the list.
            for (int i = 0, j = 0; i < nums.Count; i++)
            {
                string numString = nums[i].ToString();
                numString = numString.PadLeft(5); // Adds 5 leading spaces to each number to even out the column width.

                j++; // Counts the number of ints in a single row.

                // Puts 10 numbers in a row.
                if (j < 10)
                {
                    Console.Write(numString + " ");
                }
                // At the end of a row, reset the counter.
                else
                {
                    j = 0;
                    Console.WriteLine(numString);
                }
            }
        }

        // Function fills list with random numbers.
        // Function takes a Random seed and a list of int as arguments.
        // Function returns unsorted list of ints to calling function.
        static List<int> FillList(List<int> nums, Random rand)
        {
            int randomInt = 0;
            int listSize = 0;
            bool check = false;

            while (!check)
            {
                Console.Write("How big is your list of numbers? ");
                check = int.TryParse(Console.ReadLine(), out listSize);
                if (!check)
                {
                    Console.WriteLine("That was not a number, compadre!");
                }
                if (check && listSize < 10)
                {
                    Console.WriteLine("List size must be greater than or equal to 10!");
                    check = false;
                }
            }

            while (nums.Count < listSize)
            {
                randomInt = rand.Next(1, listSize + 1);
                // If number is not already in list, add number.
                if (!nums.Contains(randomInt))
                    nums.Add(randomInt);
            }
            return nums;
        }
    }
}
