/*
Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:
Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].
*/

using System;

namespace LeetCode
{
    public class TwoSumSolution
    {
        public static int[] TwoSum(int[] nums, int target) 
        {
            int[] returnResult = new int[2];
            int intCurrentIndex = 1, intPreviousIndex = 0;

            while(intCurrentIndex < nums.Length)
            {
                if(nums[intPreviousIndex] + nums[intCurrentIndex] == target)
                {
                    returnResult[0] = intPreviousIndex;
                    returnResult[1] = intCurrentIndex;
                    return returnResult;
                }
                intPreviousIndex = intCurrentIndex;

                intCurrentIndex++;
            }
            return returnResult;
        }

        public static void Main()
        {
            int[] nums = {2, 7, 11, 15};
            int[] result = TwoSum(nums, 9);
            Console.WriteLine("[{0}, {1}]", result[0], result[1]);
        }
    }
}

