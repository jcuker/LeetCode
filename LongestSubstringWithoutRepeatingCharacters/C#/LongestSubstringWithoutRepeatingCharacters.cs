/*
Given a string, find the length of the longest substring without repeating characters.

Examples:

Given "abcabcbb", the answer is "abc", which the length is 3.

Given "bbbbb", the answer is "b", with the length of 1.

Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.


*/
using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LongestSubstringWithoutRepeatingCharactersSolution
    {
        public static int LengthOfLongestSubstring(string s)
        {
            int intLengthOfInputString = s.Length;

            int returnResult = 0;

            // maps characters to their last known position in the string
            Dictionary<char, int> map = new Dictionary<char, int>();
            
            for (int intEndOfSlidingWindow = 0, intStartOfSlidingWindow = 0; intEndOfSlidingWindow < intLengthOfInputString; intEndOfSlidingWindow++)
            {
                if (map.ContainsKey(s[intEndOfSlidingWindow]))
                {
                    intStartOfSlidingWindow = Math.Max(map[s[intEndOfSlidingWindow]], intStartOfSlidingWindow);
                }

                returnResult = Math.Max(returnResult, intEndOfSlidingWindow - intStartOfSlidingWindow + 1);

                map[s[intEndOfSlidingWindow]] = (intEndOfSlidingWindow + 1);
                
            }
            return returnResult;
        }
        
        public static void Main()
        {
            string s = "tmmzuxt";
            int result = LengthOfLongestSubstring(s);
            Console.WriteLine(result);
        }
    }
}