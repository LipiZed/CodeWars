namespace CodeWars.Tasks.LeetCode;

public class Median
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
    {
        return (double)(nums1.Sum() + nums2.Sum()) / (nums1.Count() + nums2.Count());
    }
}