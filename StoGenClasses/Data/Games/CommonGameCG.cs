using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Games
{
    public class CommonGameCG : BaseScene
    {
        public CommonGameCG() : base()
        {
            Name = "CommonGameCG";
            EngineHiVer = 1;
            EngineLoVer = 0;

            this.DefaultSceneText.Size = 150;
            this.DefaultSceneText.Width = 1000;
            this.DefaultSceneText.FontSize = 32;
            this.DefaultSceneText.Shift = 250;
            this.DefaultSceneText.FontColor = "White";
        }
        List<CombinedSceneInfo> InfoList = null;
        internal void SetInfo(List<CombinedSceneInfo> infoList)
        {
            InfoList = infoList;
            this.LoadData(string.Empty, string.Empty);
            this.Generate(InfoList.First().ID);
        }
        public override bool LoadData(string filter, string moviePath)
        {
            this.currentGr = InfoList.First().ID;
            var grupedlist = InfoList.GroupBy(x => x.Group);
            foreach (var group in grupedlist)
            {
                DoGroup(group);
            }
           return true;
        }

        private void DoGroup(IGrouping<string, CombinedSceneInfo> group)
        {       
            var infopictures = group.Where(x => x.Kind == 0 || x.Kind == 2);
            foreach (var item in infopictures)
            {
                if (!string.IsNullOrEmpty(item.File))
                {
                    string moviePath = Path.Combine(InfoList.First().Path, "EVENTS");
                    AddToGlobalImage(item.File, item.File, moviePath);
                }
            }

            Dictionary<string, DifData> Pictures = new Dictionary<string, DifData>();

            foreach (var item in infopictures)
            {
                Pictures.Add(item.Description, new DifData(item.File) { });
                Pictures[item.Description].X = Convert.ToInt32(item.X);
                Pictures[item.Description].Y = Convert.ToInt32(item.Y);
                if (!string.IsNullOrEmpty(item.O))
                {
                    Pictures[item.Description].O = Convert.ToInt32(item.O);
                }
                if (!string.IsNullOrEmpty(item.S))
                {
                    Pictures[item.Description].S = Convert.ToInt32(item.S);
                }
                if (!string.IsNullOrEmpty(item.F))
                {
                    Pictures[item.Description].F = Convert.ToInt32(item.F);
                }
                if (!string.IsNullOrEmpty(item.Z))
                {
                    Pictures[item.Description].Z = Convert.ToInt32(item.Z);
                }
                if (!string.IsNullOrEmpty(item.R))
                {
                    Pictures[item.Description].R = Convert.ToInt32(item.R);
                }
                if (!string.IsNullOrEmpty(item.T))
                {
                    Pictures[item.Description].T = item.T;
                }

            }

            string story = string.Empty;
            var title = InfoList.Where(x => x.Kind == 1).FirstOrDefault();
            if (title != null)
                story = title.Story;
            DoC2($"{story}", Pictures.Values.ToList());
        }
       

    }
}
