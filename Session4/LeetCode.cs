using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1.Session4
{
    //https://leetcode.com/problems/two-sum/submissions/1921104632

    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.

    //Example 1:
    //Input: nums = [2, 7, 11, 15], target = 9
    //Output: [0, 1]
    //Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

    //Example 2:
    //Input: nums = [3, 2, 4], target = 6
    //Output: [1, 2]

    //Example 3:
    //Input: nums = [3, 3], target = 6
    //Output: [0, 1]


    //Constraints:
    //2 <= nums.length <= 104
    //-10^9 <= nums[i] <= 10^9
    //-10^9 <= target <= 10^9
    //Only one valid answer exists.

    //Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

    //https://leetcode.com/problems/two-sum/submissions/1921104632

    public class LeetCode
    {
        public LeetCode()
        {
            var result = TwoSum(new int[] { 2, 7, 11, 15 }, 13);
        }
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Count(); i++)
            {
                int selectedNum1 = nums[i];
                int expectedNum2 = target - selectedNum1;
                int indexOfExpectedNum2 = Array.IndexOf(nums, expectedNum2);
                if (indexOfExpectedNum2 != -1)
                {
                    if (indexOfExpectedNum2 != i)
                    {
                        return new int[] { i, indexOfExpectedNum2 };
                    }
                }

            }
            return new int[] { };
        }
    }
}
