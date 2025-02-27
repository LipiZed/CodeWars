namespace CodeWars.Tasks.LeetCode;

public class TwoSum
{
    public int[] TwoSumSolution(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.ContainsKey(complement))
            {
                return new int[2] { map[complement], i };
            }
            if (!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], i);
            }
        }

        return null;
    }
}