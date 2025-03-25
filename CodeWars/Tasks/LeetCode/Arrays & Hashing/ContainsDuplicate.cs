namespace CodeWars.Tasks.LeetCode.Arrays___Hashing;

public class ContainsDuplicate
{
    public bool Contains(int[] nums) 
    {
        if (nums.Length != nums.Distinct().Count())
        {
            return true;
        }
        return false;
    }
}