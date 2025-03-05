namespace CodeWars.Tasks.LeetCode;

public class Median
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
    {
        int[] result_array = nums1.Concat(nums2).ToArray();
        Array.Sort(result_array);
        if (result_array.Length % 2 == 0)
        {
            return (double)(result_array[result_array.Length / 2] + result_array[result_array.Length / 2 - 1]) / 2;
        }
        else
        {
            return (double)result_array[result_array.Length / 2];
        }
    }
}