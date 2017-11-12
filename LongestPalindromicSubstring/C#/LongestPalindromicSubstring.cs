/*
Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

Example:

Input: "babad"

Output: "bab"

Note: "aba" is also a valid answer.
Example:

Input: "cbbd"

Output: "bb"
*/

using System;

namespace LeetCode
{
    public class LongestPalindromicSubstringSolution
    {
        public static string LongestPalindrome (string strInputString)
        {
            int start = 0, end = 0;

            for(int i = 0; i < strInputString.Length; i++)
            {
                int len1 = ExpandAroundCenter(strInputString, i, i);
                int len2 = ExpandAroundCenter(strInputString, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return strInputString.Substring(start, end - start + 1);

        }

        public static int ExpandAroundCenter (string strInputString, int intStartIndex, int intEndIndex)
        {
            while(intStartIndex >= 0 && intEndIndex < strInputString.Length && strInputString[intStartIndex] == strInputString[intEndIndex])
            {
                intStartIndex--;
                intEndIndex++;
            }
            return intEndIndex - intStartIndex - 1;
        }

        public static void Main()
        {
            string s = "babba";
            Console.WriteLine(LongestPalindrome(s));
        }
    }
}