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
            Random rnd = new Random(DateTime.Now.TimeOfDay.Seconds);
            layers.Where(x=> x != layers.First()).ToList().ForEach(x =>
            {
                int wait = rnd.Next(1000, 10000);

                //string transition1 = 
                //$"{Wait()}{Trans.MoveH(1000, -1000)}>{Wait()}{Trans.MoveH(3000, 600)}>{Wait()}{Trans.MoveH(1000, 400)}";
                //string transition2 =
                //$"{Wait()}{Trans.MoveH(1000, 600)}>{Wait()}{Trans.MoveH(3000, -300)}>{Wait()}{Trans.MoveH(1000, -300)}";

                //string transition = $"{transition1}>{transition2}~";

                string transition = $"{Trans.Wait(0)}>R.B.10000.10";
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
        private string Wait()
        {
            Random rnd = new Random(DateTime.Now.TimeOfDay.Seconds);
            return $"{Trans.Wait(rnd.Next(1000, 10000))}>";
        }
    }
}
