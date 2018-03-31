using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Transition
{
    public class OpEf //Opacity transition effect
    {
        //new OpEf(1, true, 250, true, 1000)); to dissapear previous
        //new OpEf(1, false,250, false,1000) to appear current
        //new OpEf(1, true, 100, "W..0>O.B.400.-100*W..0>Y.B.200.300")
        public static OpEf AppearCurrent(int i)
        {
            return new OpEf(i, false, 250, false, 0);
        }
        public static OpEf AppCurr(int i, string t)
        {
            return new OpEf(i, false, 0, t);
        }
        public static OpEf HidPrev(int i, string t)
        {
            return new OpEf(i, true, 100, t);
        }
        public static OpEf HidePrev(int i)
        {
            return new OpEf(i, true, 250, true, 0);
        }
        public OpEf(int l, bool p, int t, bool d, int w)
        {
            L = l;
            P = p;
            T = t;
            W = w;
            D = d;
        }
        //string CurrentTran = "W..1000>X.B.3000.100";
        public string Tran = null;
        public OpEf(int l, bool p, int o, string tran)
        {
            L = l;
            P = p;
            O = o;
            Tran = tran;
        }
        public OpEf(int l, int t)
        {
            L = l;
            T = t;
        }
        public int L = 0; // pic level            
        public bool P = false; // false - current, true - previous
        public int T = 500; //speed time, ms
        public int W = 500; //wait time, ms
        public bool D = true;//direction, true - dissapeared, false - appeared (optional, T can be used instead)

        public int O { get; set; } = 100;
    }
}
