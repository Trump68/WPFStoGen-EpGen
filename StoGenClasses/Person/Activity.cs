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
            Random rnd = new Random();
            layers.Where(x=> x != layers.First()).ToList().ForEach(x =>
            {
                int wait = rnd.Next(1000, 10000);

                //string transition1 =
                //$"F.A.0.1>{Trans.MoveH(1000, -1000)}>F.A.0.1>{Trans.MoveH(3000, 600)}>{Trans.MoveH(1000, 400)}";
                //string transition2 =
                //$"{Trans.MoveH(1000, 600)}>F.A.0.1>{Trans.MoveH(3000, -300)}>{Trans.MoveH(1000, -300)}";

                //string transition = $"{transition1}>{transition2}~";

                //string transition = $"F.A.0.1>{Trans.MoveH(1000, -300)}>F.A.0.1>{Trans.MoveH(1000, 300)}~";
                string transition = $"R.B.100.10~";
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
            Random rnd = new Random();
            return $"{Trans.Wait(rnd.Next(1000, 10000))}>";
        }
    }
}
