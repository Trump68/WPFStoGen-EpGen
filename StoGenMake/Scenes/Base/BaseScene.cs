using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Elements;
using System.IO;
using StoGenLife.NPC;
using StoGenMake.Pers;
using StoGenLife.SOUND;

namespace StoGenMake.Scenes.Base
{
   
    public class BaseScene
    {
        public int SizeX = 800;
        public int SizeY = 600;
        public int X = 300;
        public int Y = 0;
        private int Version = 0;
        public BaseScene()
        {
            //InitCadres();
        }
        public ScenCadre AddCadre(ScenCadre cadre, string name, int timer, BaseScene owner)
        {
            if (cadre == null)
                cadre = new ScenCadre(owner);
            if (name == null)
            {
                name = $"Cadre { this.Cadres.Count + 1}";
            }
            if (timer < 1) timer = 60;
            cadre.Timer = timer * 1000;
            cadre.Name = name;
            this.Cadres.Add(cadre);
            return cadre;
        }
        protected ScenElementImage AddImage(ScenCadre cadre, bool invisible, string name)
        {
            ScenElementImage image = new ScenElementImage();
            image.SizeX = SizeX;
            image.SizeY = SizeY;
            image.Name = name;
            if (invisible)
                image.Opacity = 0;
            else
                image.Opacity = 100;
            cadre.VisionList.Add(image);
            return image;
        }
        protected ScenElementSound AddSound(ScenCadre cadre, string name)
        {
            ScenElementSound sound = new ScenElementSound();            
            sound.Name = name;
            sound.File = SoundStore.ValByName(name);
            cadre.SoundList.Add(sound);
            return sound;
        }
        public string Description { get; set; }
        public string Name { get; set; }
        public List<ScenCadre> Cadres { get; set; } = new List<ScenCadre>();
        

        public string FileToProcess = null;
        public virtual void InitCadres(List<VNPCVariable> vars)
        {
            this.Cadres.ForEach(x => x.InitValuesFromPers(vars));
        }

      
        private void SetSceneCommonDats(List<string> scendata)
        {
            if (scendata == null) return;
            List<string> datastr = scendata.Where(x => x.StartsWith(@"SCENDATA ")).ToList();
            if (datastr != null)
            {
                scendata.RemoveAll(x => x.StartsWith(@"SCENDATA "));
                List<string> vals = datastr.First().Split(';').ToList();
                foreach (var item in vals)
                {
                    if (item.Trim().StartsWith("Location"))
                    {
                        var vals2 = item.Split('=');
                        string[] items = vals2[1].Split(',');
                        this.X = int.Parse(items[0]);
                        this.Y = int.Parse(items[1]);
                        this.SizeX = int.Parse(items[2]);
                        this.SizeY = int.Parse(items[3]);
                    }
                }
            }

           
        }
    }
    public class SceneVariable
    {
        public string Type;
        public string Name;
        public string Description;
        public string Value;
        public SceneVariable(string type, string name, string val, string desc)
        {
            Type = type;
            Name = name;
            Description = desc;
            Value = val;
        }
    }
}
