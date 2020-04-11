using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPCat.Model
{
    public static class TicTakToe
    {
        private static string ClipScreenShot = null;
        public static List<string> CopiedCombinedScene = new List<string>();
        public static void SetClipScreenShot(string v)
        {
            ClipScreenShot = v;
        }
        public static string GetClipScreenShot()
        {
            var rez = ClipScreenShot;
            ClipScreenShot = null;
            return rez;
        }

        static Info_Clip _ClipTemplate = new Info_Clip();
        public static Info_Clip ClipTemplate
        {
            get
            {
                return _ClipTemplate;
            }
            set
            {
                _ClipTemplate = value;
            }
        }
    }
}
