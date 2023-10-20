﻿//Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

//The overall run time complexity should be O(log (m+n)).


using System;

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            int[] temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }

        int x = nums1.Length;
        int y = nums2.Length;

        int low = 0, high = x;
        while (low <= high)
        {
            int partitionX = (low + high) / 2;
            int partitionY = (x + y + 1) / 2 - partitionX;

            int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
            int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];

            int minX = (partitionX == x) ? int.MaxValue : nums1[partitionX];
            int minY = (partitionY == y) ? int.MaxValue : nums2[partitionY];

            if (maxX <= minY && maxY <= minX)
            {
                if ((x + y) % 2 == 0)
                {
                    return (Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2.0;
                }
                else
                {
                    return Math.Max(maxX, maxY);
                }
            }
            else if (maxX > minY)
            {
                high = partitionX - 1;
            }
            else
            {
                low = partitionX + 1;
            }
        }

        throw new ArgumentException("Input arrays are not sorted.");
    }

}
