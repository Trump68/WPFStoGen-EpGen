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

        List<List<CombinedSceneInfo>> data = new List<List<CombinedSceneInfo>>();
        public override bool LoadData(string filter, string moviePath)
        {
            data.Clear();
            this.currentGr = InfoList.First().ID;
            var grupedlist = InfoList.GroupBy(x => x.Group).ToList();

            for (int i = 0; i < grupedlist.Count; i++)
            {
                var nl = grupedlist[i].ToList();
                data.Add(nl);
            }

            for (int i = 0; i < data.Count; i++)
            {
                if (i > 0)
                {
                    var prevgroup = data[i - 1];
                    var curgroup = data[i];
                    CalculateGroup(prevgroup, ref curgroup);
                }

            }

            foreach (var group in data)
            {
                DoGroup(group);
            }
           return true;
        }

        private void CalculateGroup(List<CombinedSceneInfo> prevgroup, ref List<CombinedSceneInfo> curgroup)
        {
            if (curgroup.Where(x=>x.Kind == 3).Any())
            {
                curgroup.Where(x => x.Kind == 3).First().Kind = 1;
                foreach (var pg in prevgroup)
                {
                    if (!curgroup.Where(z=>z.Description == pg.Description).Any())
                    {
                        string ngs = pg.GenerateString();
                        CombinedSceneInfo ng = new CombinedSceneInfo();
                        ng.LoadFromString(ngs);
                        ng.Group = curgroup.First().Group;
                        curgroup.Add(ng);
                    }
                }
            }
        }

        private void DoGroup(List<CombinedSceneInfo> group)
        {       
            var infopictures = group.Where(x => x.Kind == 0 || x.Kind == 2);
            Dictionary<string, DifData> Pictures = new Dictionary<string, DifData>();

            string story = string.Empty;
            var title = InfoList.Where(x => x.Kind == 1).FirstOrDefault();
            if (title != null)
            {
                story = title.Story;
                if (title.File == "$$WHITE$$") // white background
                {
                    AddToGlobalImage("$$WHITE$$", "$$WHITE$$",string.Empty);
                    Pictures.Add("$$WHITE$$", new DifData("$$WHITE$$") { });
                }
                if (!string.IsNullOrEmpty(title.Y))
                    this.DefaultSceneText.Size = Convert.ToInt32(title.Y);
                if (!string.IsNullOrEmpty(title.X))
                    this.DefaultSceneText.Width = Convert.ToInt32(title.X);
                if (!string.IsNullOrEmpty(title.F))
                    this.DefaultSceneText.FontSize = Convert.ToInt32(title.F);
                if (!string.IsNullOrEmpty(title.S))
                    this.DefaultSceneText.Shift = Convert.ToInt32(title.S);
                if (!string.IsNullOrEmpty(title.Z))
                    this.DefaultSceneText.FontColor = title.Z;
            }

            foreach (var item in infopictures)
            {
                if (!string.IsNullOrEmpty(item.File))
                {
                    string moviePath = Path.Combine(item.Path, "EVENTS");
                    AddToGlobalImage(item.File, item.File, moviePath);
                }
            }


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

            
            DoC2($"{story}", Pictures.Values.ToList());
        }
       

    }
}
