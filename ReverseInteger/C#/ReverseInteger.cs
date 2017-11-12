/*
Given a 32-bit signed integer, reverse digits of an integer.

Example 1:

Input: 123
Output:  321
Example 2:

Input: -123
Output: -321
Example 3:

Input: 120
Output: 21
Note:
Assume we are dealing with an environment which could only hold integers within the 32-bit signed integer range. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
*/

using System;

namespace LeetCode
{
    public class ReverseIntegerSolution
    {
        public static int Reverse(int x)
        {
            string inputReversed = ReverseString(x.ToString());
            if(inputReversed[inputReversed.Length - 1] == '-')
            {
                inputReversed = inputReversed.Replace("-", "");
                inputReversed = "-" + inputReversed;
            }
            try
            {
                int parsedInt = int.Parse(inputReversed);
                return parsedInt;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static void Main()
        {
            int orig = -321;
            int reversed = Reverse(orig);
            Console.WriteLine("Reversing {0} gives {1}", orig, reversed);
        }
    }
}