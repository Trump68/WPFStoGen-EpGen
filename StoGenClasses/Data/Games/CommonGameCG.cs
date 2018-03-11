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
            this.LoadData(string.Empty, Path.Combine(InfoList.First().Path,"EVENTS"));
            this.Generate(InfoList.First().ID);
        }
        public override bool LoadData(string filter, string moviePath)
        {
            this.currentGr = InfoList.First().ID;
            var infopictures = InfoList.Where(x => x.Kind == 0);
            foreach (var item in infopictures)
            {
                AddToGlobalImage(item.File, item.File, moviePath);
            }

            Dictionary<string, DifData> Pictures = new Dictionary<string, DifData>();

            foreach (var item in infopictures)
            {
                Pictures.Add(item.Description, new DifData(item.File) { });
                Pictures[item.Description].X = Convert.ToInt32(item.X);
                Pictures[item.Description].Y = Convert.ToInt32(item.Y);
            }

            string story = string.Empty;
            var title = InfoList.Where(x => x.Kind == 1).FirstOrDefault();
            if (title != null)
                story = title.Story;
            DoC2($"{story}",Pictures.Values.ToList());

            return true;
        }

       

    }
}
