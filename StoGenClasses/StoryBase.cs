using StoGen.Classes;
using StoGen.Classes.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator
{

    public enum Teller
    {
        Female,
        Male,
        FemaleThoughts,
        MaleThoughts,
        Author,
        Others,
        OthersThoughts
    }
    public class StoryBase: SCENARIO
    {
        public StoryBase(): base()
        {
        }
        protected string rawparameters =
@"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
DefTextSize=200;DefTextShift=30;DefTextWidth=1800;DefFontSize=40;DefFontColor=Cyan;DefTextAlignH=2;DefTextAlignV=1;DefTextBck=Cyan;DefTextBck=$$WHITE$$
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX = 700; DefVisY = 0; DefVisSize = 900; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile =
//Other
PackStory = 1; PackImage = 1; PackSound = 1; PackVideo = 0";

        public string currentQueue;
        public string currentGroup;
        public string Name { set; get; }
        public void IncrementGroup()
        {
            var vals = currentGroup.Split('.');
            if (vals.Length == 0) return;
            int d;
            if (int.TryParse(vals[0], out d))
            {
                ++d;
                vals[0] = (d.ToString("D" + vals[0].Length));
            }
            currentGroup = string.Join(".", vals);
        }
        public virtual void GenerateNextCadre() { }
        public virtual void Generate(string queue, string group)
        {
            currentGroup = group;
            currentQueue = queue;
            RawParameters = rawparameters;
            AssignRawParameters();
        }
        protected virtual void FillData()
        {
        }
        protected virtual void MakeLocation()
        {

        }

        internal List<Info_Scene> GetNextGroups(int lastgrouId)
        {
            var grupedlist = SceneInfoList.GroupBy(x => x.Group).ToList();
            lastgrouId++;
            if (lastgrouId > grupedlist.Count() - 1)
            {

            }
            else
            {
                var last = grupedlist[lastgrouId].Select(x => x).ToList();
                if (!last.First().Active)
                {
                    last.ForEach(x => x.Active = true);
                    return last;
                }
            }
            return null; ;
        }

    }
}
