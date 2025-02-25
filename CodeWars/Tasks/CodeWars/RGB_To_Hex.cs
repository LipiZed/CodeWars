using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.Tasks.CodeWars
{
    public class RGB_To_Hex
    {
        public string Rgb(int r, int g, int b)
        {
            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;

            return Convert.ToString(r, 16).ToUpper() + Convert.ToString(g, 16).ToUpper() + Convert.ToString(b, 16).ToUpper();
        }
    }
}
