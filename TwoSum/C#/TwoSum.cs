/*
Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:
Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].
*/
/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4) (342 + 465) = 807
Output: 7 -> 0 -> 8
*/

using System;

namespace LeetCode
{
    public class AddTwoNumbersSolution
    {

        public static int[] TwoSum(int[] nums, int target)
        {
            int[] returnResult = new int[2];

            int intStartingIndex = 0, intCurrentIndex = 0;

            while (intStartingIndex < nums.Length)
            {
                intCurrentIndex = intStartingIndex + 1;

                while(intCurrentIndex < nums.Length)
                {

                    if (nums[intCurrentIndex] + nums[intStartingIndex] == target)
                    {
                        if(intCurrentIndex < intStartingIndex)
                        {
                            returnResult[0] = intCurrentIndex;
                            returnResult[1] = intStartingIndex;
                        }
                        else
                        {
                            returnResult[0] = intStartingIndex;
                            returnResult[1] = intCurrentIndex;
                        }
                        return returnResult;
                    }

                    intCurrentIndex++;
                }

                intStartingIndex++;
            }

            return returnResult;
        }


        public static void Main()
        {
            int[] nums = { 3, 2, 4 };
            int[] result = TwoSum(nums, 6);
            Console.WriteLine("[{0}, {1}]", result[0], result[1]);
        }
    }
}
