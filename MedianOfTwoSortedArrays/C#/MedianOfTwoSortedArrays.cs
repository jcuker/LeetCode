/*
There are two sorted arrays nums1 and nums2 of size m and n respectively.

Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

Example 1:
nums1 = [1, 3]
nums2 = [2]

The median is 2.0

Example 2:
nums1 = [1, 2]
nums2 = [3, 4]

The median is (2 + 3)/2 = 2.5
*/

using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MedianOfTwoSortedArraysSolution
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int sizeOfBothArrays = nums1.Length + nums2.Length;

            List<int> lstBothArrays = new List<int>();
            lstBothArrays.AddRange(nums1);
            lstBothArrays.AddRange(nums2);

            int[] newArray = lstBothArrays.ToArray();

            MergeSort(newArray, 0, sizeOfBothArrays - 1);
            
            if(sizeOfBothArrays % 2 == 1)
            {
                int intPositionOfMedian = (int) Math.Ceiling((double)sizeOfBothArrays / 2.0) - 1;
                return newArray[intPositionOfMedian];
            }
            else
            {
                int intMedianPositionRight = sizeOfBothArrays / 2;
                int intMedianPositionLeft = intMedianPositionRight - 1;
                return (newArray[intMedianPositionRight] + newArray[intMedianPositionLeft]) / 2.0;
            }

        }
        
        public static void MergeSort(int[] input, int intLowBound, int intHighBound)
        {
            if (intLowBound < intHighBound)
            {
                int intMiddleBound = (intLowBound / 2) + (intHighBound / 2);
                MergeSort(input, intLowBound, intMiddleBound);
                MergeSort(input, intMiddleBound + 1, intHighBound);
                Merge(input, intLowBound, intMiddleBound, intHighBound);
            }
        }

        public static void MergeSort(int[] input)
        {
            MergeSort(input, 0, input.Length - 1);
        }

        private static void Merge(int[] input, int intLowBound, int intMiddleBound, int intHighBound)
        {

            int left = intLowBound;

            int right = intMiddleBound + 1;

            int[] arrTemp = new int[(intHighBound - intLowBound) + 1];

            int intCurrentIndexOfTempArray = 0;

            while ((left <= intMiddleBound) && (right <= intHighBound))
            {
                if (input[left] < input[right])
                {
                    arrTemp[intCurrentIndexOfTempArray] = input[left];
                    left = left + 1;
                }
                else
                {
                    arrTemp[intCurrentIndexOfTempArray] = input[right];
                    right = right + 1;
                }

                intCurrentIndexOfTempArray = intCurrentIndexOfTempArray + 1;
            }

            if (left <= intMiddleBound)
            {
                while (left <= intMiddleBound)
                {
                    arrTemp[intCurrentIndexOfTempArray] = input[left];
                    left = left + 1;
                    intCurrentIndexOfTempArray = intCurrentIndexOfTempArray + 1;
                }
            }

            if (right <= intHighBound)
            {
                while (right <= intHighBound)
                {
                    arrTemp[intCurrentIndexOfTempArray] = input[right];
                    right = right + 1;
                    intCurrentIndexOfTempArray = intCurrentIndexOfTempArray + 1;
                }
            }

            for (int i = 0; i < arrTemp.Length; i++)
            {
                input[intLowBound + i] = arrTemp[i];
            }

        }

        public static void Main()
        {
            int[] num1 = { 1, 3 };
            int[] num2 = { 2 };
            Console.WriteLine(FindMedianSortedArrays(num1, num2));
        }
    }
}