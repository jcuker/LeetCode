// Given a sorted array consisting of only integers where every element appears twice except for one element which appears once. Find this single element that appears only once.

// Example 1:

// Input: [1,1,2,3,3,4,4,8,8]
// Output: 2

// Example 2:

// Input: [3,3,7,7,10,11,11]
// Output: 10

// [1,1,2]
// Note: Your solution should run in O(log n) time and O(1) space.
class Solution {
    public static int singleNonDuplicate(int[] nums) {
        int leftPos = 1;
        int rightPos = 2;
        int length = nums.length - 1;

        if(nums[0] != nums[1]){
            return nums[0];
        }

        while(true) {
            if(rightPos >= length) {
                return nums[rightPos];
            }
            else if(nums[leftPos] == nums[rightPos]) {
                leftPos+=2;
                rightPos+=2;
            }
            else {
                int temp = rightPos + 1;
                if(nums[rightPos] != nums[temp]) { 
                    return nums[rightPos];
                } 
                else {
                    leftPos = temp;
                    rightPos = temp + 1;
                }
            }
        }        
    }

    public static void main(String args[]) {
        System.out.println(singleNonDuplicate(new int[] {1,1,8,9,9}));
        System.out.println(singleNonDuplicate(new int[] {1,8,8,9,9}));
        System.out.println(singleNonDuplicate(new int[] {1,1,8,8,9}));

    }
}

