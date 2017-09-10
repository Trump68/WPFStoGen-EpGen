using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake
{
    public static class Transition
    {
        public static string Eyes_Blink
        {
            get
            {
                List<string> result = new List<string>() { "W..1000" };
                Random rnd = new Random();
                for (int i = 0; i < 50; i++)
                {
                    result.Add("O.B.40.100>O.B.40.-100");                   
                    int wait = rnd.Next(100, 10000);
                    result.Add($"W..{wait}");
                }
                return string.Join(">", result.ToArray()) + "~";
            }
        }
        public static string Eye_Wink { get;} = "W..1000>O.B.200.100>W..200>O.B.200.-100";
        public static string Eye_Close { get; } = "W..1000>O.B.200.100";
    }
}
