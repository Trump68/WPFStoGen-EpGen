using StoGenMake.Elements;
using StoGenMake.Pers;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class SC004_EnoshimaIki: BaseScene
    {
        
        public SC004_EnoshimaIki() : base()
        {
            Name = "Enoshima Iki";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }


        protected override void MakeCadres(string cadregroup)
        {        
            base.MakeCadres(cadregroup);
            this.Cadres.Reverse();
        }
        protected override void LoadData()
        {
            string path = null;   
            path = @"x:\DOUJIN\Enoshima Iki\[DOUJIN COLOR] Kuro Gal Bitch ga Uchi ni Kita!\"; 

            string dsc = "Enoshima Iki";
            string src = null;
            string fn = null;

            int ss = 700;
            string gr = "Raw data";
            src = $"Enoshima Iki 001 Body"; fn = $"002.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001a Body"; fn = $"002a.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001b Body"; fn = $"002b.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001c Body"; fn = $"002c.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001d Body"; fn = $"002d.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001e Body"; fn = $"002e.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001f Body"; fn = $"002f.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001g Body"; fn = $"002g.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001h Body"; fn = $"002h.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001j Body"; fn = $"002j.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001k Body"; fn = $"002k.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001l Body"; fn = $"002l.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001m Body"; fn = $"002m.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001n Body"; fn = $"002n.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001o Body"; fn = $"002o.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 001p Body"; fn = $"002p.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });

            src = $"Enoshima Iki 002 Body"; fn = $"001.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 002a Body"; fn = $"001a.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 002b Body"; fn = $"001b.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 002c Body"; fn = $"001c.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            src = $"Enoshima Iki 002d Body"; fn = $"001d.png"; AddToGlobalImage(src, fn, path, new DifData() { s = ss });
            
        }

    }
}
