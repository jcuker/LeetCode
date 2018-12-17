// Given an integer array, you need to find one continuous subarray that if you only sort this subarray in ascending order, then the whole array will be sorted in ascending order, too.

// You need to find the shortest such subarray and output its length.

// Example 1:

// Input: [2, 6, 4, 8, 10, 9, 15]
// Output: 5
// Explanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in ascending order.

// Note:

//     Then length of the input array is in range [1, 10,000].
//     The input array may contain duplicates, so ascending order here means <=.
class Solution {
    public static int findUnsortedSubarray(int[] nums) {
        if(nums.length == 1) {
            return 0;
        }
        int leftPos = 0;
        int rightPos = 1;
        while(nums[leftPos] <= nums[rightPos]) {
            if(rightPos >= nums.length - 1) {
                return 0;
            }            
            leftPos++;
            rightPos++;
        }
        
        int startOfUnsortedBit = leftPos;
        leftPos++;
        rightPos++;
        int endOfUnsortedBit = findLastIndex(nums, leftPos, rightPos, rightPos);
        //System.out.println(endOfUnsortedBit + " - " + startOfUnsortedBit);
        return (endOfUnsortedBit - startOfUnsortedBit);
    }

    public static int findLastIndex(int[] nums, int leftPos, int rightPos, int lastPos) {
        if(rightPos > nums.length - 1) {
            return rightPos;
        }

        while(nums[leftPos] < nums[rightPos] ) {
            //System.out.println(leftPos + " : " + rightPos + " : " + lastPos);
            if(rightPos >= nums.length - 1) {
                return lastPos;
            } 
            leftPos++;
            rightPos++;
        }
        leftPos++;
        rightPos++;
        return findLastIndex(nums, leftPos, rightPos, rightPos);
    }



    public static void main(String[] args) {
        System.out.println(findUnsortedSubarray(new int[] {1}) == 0);
        System.out.println(findUnsortedSubarray(new int[] {2,1}) == 2);
        System.out.println(findUnsortedSubarray(new int[] {2, 6, 4, 8, 10, 9, 15}) == 5);
        System.out.println(findUnsortedSubarray(new int[] {5,4,3,2,1}) == 5);
        System.out.println(findUnsortedSubarray(new int[] {1,3,2,2,2}) == 4);
        System.out.println(findUnsortedSubarray(new int[] {1,3,2,3,3}) == 2);

    }
}