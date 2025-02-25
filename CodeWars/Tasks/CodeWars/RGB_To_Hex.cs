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
            r = Math.Clamp(r, 0, 255);
            g = Math.Clamp(g, 0, 255);
            b = Math.Clamp(b, 0, 255);
            return Convert.ToString(r, 16).ToUpper().PadLeft(2, '0') + Convert.ToString(g, 16).ToUpper().PadLeft(2, '0') + Convert.ToString(b, 16).ToUpper().PadLeft(2, '0');
        }
    }
}
