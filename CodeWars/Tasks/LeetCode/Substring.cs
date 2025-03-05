namespace CodeWars.Tasks.LeetCode;
using System;
public class Substring
{
    public int LengthOfLongestSubstring(string s)
    {
        var chars = new Dictionary<char, int>();
        int max_count = 0;
        for (int i = 0; i < s.Length;)
        {
            if (chars.ContainsKey(s[i]))
            {
                i = chars[s[i]] + 1;
                chars.Clear();
            }
            else
            {
                chars.Add(s[i], i);
                i++;
            }
        }
        max_count = Math.Max(max_count, chars.Count());
        return max_count;
    }
}

