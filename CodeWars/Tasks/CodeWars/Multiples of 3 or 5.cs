using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.Tasks.CodeWars
{
    public class Multiples_of_3_or_5
    {
        public int Solution(int num)
        {
            if (num <= 3)
            {
                return 0;
            }
            List<int> nums = new List<int>();
            for (int i = 0; 3 * i < num; i++)
            {
                nums.Add(3 * i);
            }
            for (int i = 0; 5 * i < num; i++)
            {
                nums.Add(5 * i);
            }
            return nums.Distinct().Sum();
        }
    }
}
