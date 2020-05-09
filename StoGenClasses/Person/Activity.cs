using StoGen.Classes.Transition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Persons
{
    public class Activity
    {
        public virtual List<Info_Scene> SetActivity(Person person, List<Info_Scene> layers, Info_Scene position)
        {
            return layers;
        }
    }
    public class HangAroundHome: Activity
    {
        public override List<Info_Scene> SetActivity(Person person, List<Info_Scene> layers, Info_Scene position)
        {
            int speed = 100; // TO DO:person speed
            int waitMin = 500;
            int waitMax = 30000;

            List<string> waits = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                waits.Add(Trans.WaitR(waitMin, waitMax));
            }
            layers.Where(x=> x != layers.First()).ToList().ForEach(x =>
            {
                int d = x.Direction == 1 ? -1 : 1;
                int i = 0;
                string transition1 =
                $"{Trans.MoveHs(speed, d * -1000)}>{Trans.Turn()}>{waits[i++]}>{Trans.MoveHs(speed, d * 600)}>{waits[i++]}>{Trans.MoveHs(speed, d * 400)}>{waits[i++]}";
                string transition2 =
                $"{Trans.MoveHs(speed, d * 600)}>{Trans.Turn()}>{waits[i++]}>{Trans.MoveHs(speed, d * -300)}>{waits[i++]}>{Trans.MoveHs(speed, d * -300)}>{Trans.Turn()}>{waits[i++]}";
                string transition3 =
               $"{Trans.MoveHs(speed, d * 1000)}>{Trans.Turn()}>{waits[i++]}>{Trans.MoveHs(speed, d * -800)}>{waits[i++]}>{Trans.MoveHs(speed, d * -200)}>{waits[i++]}";

                string transition = $"{waits[i++]}>{transition1}>{transition2}>{transition3}~";
                if (!string.IsNullOrEmpty(x.T))
                {
                    x.T = $"{x.T}*{transition}";
                }
                else
                {
                    x.T = $"{transition}";
                }
            });
            return layers;
        }
    }
}
