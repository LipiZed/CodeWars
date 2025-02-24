using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.Tasks.CodeWars
{
    public class TimeFormat
    {
        public string GetReadableTime(int seconds)
        {
            string hours = (seconds / 3600).ToString();
            if (hours.Length == 1)
            {
                hours = "0" + hours;
            }
            string minutes = ((seconds - (int.Parse(hours) * 3600)) / 60).ToString();
            if (minutes.Length == 1)
            {
                minutes = "0" + minutes;
            }
            string left_seconds = (seconds - (int.Parse(hours) * 3600) - (int.Parse(minutes) * 60)).ToString();
            if (left_seconds.Length == 1)
            {
                left_seconds = "0" + left_seconds;
            }
            return hours + ":" + minutes + ":" + left_seconds;
            //както даже стыдно за это после увиденных решений
        }
    }
}
