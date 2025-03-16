namespace CodeWars.Tasks.LeetCode;

public class ContainerWithWater
{
    public int MaxArea(int[] height)
    {
        int area = 0;
        for (int i = 0, j = height.Length - 1; i < j;)
        {
            area = Math.Max(area, Math.Min(height[i], height[j]) * (j - i));
            if (height[i] < height[j])
            {
                i++;
            }
            else
            {
                j--;
            }
        }
        return area;
    }
}