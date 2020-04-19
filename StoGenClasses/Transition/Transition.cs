using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Transition
{
    public static class Transitions
    {
        static Random rnd = new Random();
        public static string Orgazm { get; } = "W..0>O.A.0.100>O.B.250.-100";
        public static string Eyes_Blink
        {
            get
            {
                List<string> result = new List<string>() { "W..1000" };                
                for (int i = 0; i < 50; i++)
                {
                    result.Add("O.B.20.0>O.B.20.100>O.B.20.-100>");                   
                    int wait = rnd.Next(100, 10000);
                    result.Add($"W..{wait}");
                }
                return string.Join(">", result.ToArray()) + "~";
            }
        }

        public static string Eye_Wink { get;} = "W..1000>O.B.200.100>W..200>O.B.200.-100";
        public static string Eye_Close { get; } = "W..1000>O.B.200.100";
        public static string SlowDissapearing { get; } = "W..0>O.B.1000.-100";
        public static string Dissapearing(int msec) { return $"W..0>O.B.{msec}.-100"; }

        public static string Obzor()
        {
            string result = $"W..1000>Y.B.5000.-700>W..2000>Y.B.5000.700";
            return result;
        }

        public static string Blush(int time,bool reverse, bool restore, bool permanent)
        {
            int up = 7000;
            int dn = 20000;
            int reversespeed = 7;
            string result = $"{rnd.Next(500, 2000)}>";
            if (reverse)
            {
                return $"{result}O.B.{time}.-100";
            }
            result = $"{result}O.B.{time}.100";
            if (restore)
            {
                result = $"{result}>W..{dn}>O.B.{time * reversespeed}.-100";
                if (permanent)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        result = $"{result}>W..{rnd.Next(up, dn)}>O.B.{time}.100";
                        result = $"{result}>W..{rnd.Next(up, dn)}>O.B.{time * reversespeed}.-100";
                    }
                    result = $"{result}~";
                }
            }
           return result;
        }
        public static string Mouth(int time, bool reverse, bool restore, bool permanent)
        {
            int up = 5000;
            int dn = 15000;
            int reversespeed = 2;
            string result = $"{rnd.Next(500, 2000)}>";
            if (reverse)
            {
                return $"{result}O.B.{time}.-100";
            }
            result = $"{result}O.B.{time}.100";            
            if (restore)
            {

                result = $"{result}>W..{dn}>O.B.{time * reversespeed}.-100";
                if (permanent)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        result = $"{result}>W..{rnd.Next(up, dn)}>O.B.{time}.100";
                        result = $"{result}>W..{rnd.Next(up, dn)}>O.B.{time * reversespeed}.-100";
                    }
                    result = $"{result}~";
                }                    
            }
            return result;
        }
        public static string Talk()
        {
            int speed = 200;
            string Wait1000   = $"W..1000>";            
            string Wait100    = $"W..100>";
            string Wait200    = $"W..200>";
            string Wait300 = $"W..300>";
            string Wait500    = $"W..500>";
            string open       = $"O.B.{speed}.100>";
            string close      = $"O.B.{speed}.-100>";
            List<string> rez = new List<string>();
            rez.Add($@"{Wait1000}");
            rez.Add($@"{open}{close}{open}{close}{open}{close}");
            rez.Add($@"{Wait300}");
            rez.Add($@"{open}{close}{open}{close}");
            rez.Add($@"{Wait300}");
            rez.Add($@"{open}{close}{open}{close}");
            rez.Add($@"{Wait300}");
            rez.Add($@"{open}{close}");
            rez.Add($@"{Wait500}");
            rez.Add($@"{open}{close}{open}{close}{open}{close}");
            rez.Add($@"{Wait500}");
            rez.Add($@"{open}{close}{open}{close}{open}{close}{open}{close}");
            rez.Add($@"{Wait300}");
            rez.Add($@"{open}{close}{open}{close}");
            rez.Add($@"{Wait300}");
            rez.Add($@"{open}{close}{open}{close}");
            rez.Add($@"{Wait300}");
            rez.Add($@"{open}{close}");
            rez.Add($@"{Wait1000}");
            rez.Add($@"{open}{close}");
            rez.Add($@"~");
            return string.Join(string.Empty,rez.ToArray());
        }

        internal static string MouthSqueeze(int time, bool restore, bool permanent)
        {
            string result = $"W..1000>O.B.{time}.100";
            if (restore)
            {
                result = $"{result}>W..5000>O.B.{time * 3}.-100";
                if (permanent)
                    result = $"{result}~";
            }
            return result;
        }

        internal static string MouthOpen(int time, bool restore, bool permanent)
        {
            string result = $"W..1000>O.B.{time}.100";
            if (restore)
            {
                result = $"{result}>W..5000>O.B.{time * 3}.-100";
                if (permanent)
                    result = $"{result}~";
            }
            return result;
        }

        public static string Eyes(int time, bool reverse, bool restore, bool permanent)
        {
            
            int up = 7000;
            int dn = 20000;
            int reversespeed = 2;
            string result = $"{rnd.Next(500, 2000)}>";
            if (reverse)
            {
                return $"{result}O.B.{time}.-100";
            }
            result = $"{result}O.B.{time}.100";
            if (restore)
            {

                result = $"{result}>W..{dn}>O.B.{time * reversespeed}.-100";
                if (permanent)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        result = $"{result}>W..{rnd.Next(up, dn)}>O.B.{time}.100";
                        result = $"{result}>W..{rnd.Next(up, dn)}>O.B.{time * reversespeed}.-100";
                    }
                    result = $"{result}~";
                }
            }
            return result;
        }
    }
}
