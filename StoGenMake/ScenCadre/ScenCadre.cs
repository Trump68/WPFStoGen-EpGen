﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGenMake.Scenes.Base;
using StoGenMake.Pers;
using StoGenMake.Entity;
using StoGenLife.SOUND;

namespace StoGenMake.Elements
{
    public class ScenCadre
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public virtual bool IsActivated { get { return this.VisionList.Any(x=>x.IsActivated); } }

        public int Timer = -1;
        public List<ScenElement> VisionList = new List<ScenElement>();
        public List<ScenElement> SoundList = new List<ScenElement>();
        public List<ScenElement> TextList = new List<ScenElement>();
        

        public ScenCadre()
        {
            
        }

        public ScenElementImage AddImage(int opacity, string file, string name = null)
        {
            ScenElementImage image = new ScenElementImage();
            image.Name = name;
            image.File = file;
            image.Opacity = opacity;
            VisionList.Add(image);
            return image;
        }
        public ScenElementSound AddSound(string name= null)
        {
            ScenElementSound sound = new ScenElementSound();
            sound.Name = name;
            sound.File = SoundStore.ValByName(name);
            SoundList.Add(sound);
            return sound;
        }


        public virtual List<string> GetCadreData()
        {

            List<string> result = new List<string>();
            result.Add($"PartSta# {this.Name.PadRight(100)}");

            if (this.Timer > 0)
            {
                this.VisionList.ForEach(x => (x as ScenElementImage).Timer = this.Timer);
                //(this.VisionList.First() as ScenElementImage).Timer = this.Timer;
            }
               
            foreach (var item in this.VisionList)
            {
                if (item.IsActivated)
                result.Add(" " + item.GetElementData());
            }
            foreach (var item in this.SoundList)
            {
                if (item.IsActivated)
                    result.Add(" " + item.GetElementData());
            }
            foreach (var item in this.TextList)
            {
                if (item.IsActivated)
                    result.Add(" " + item.GetElementData());
            }
            result.Add($"PartEnd#");
            return result;

            return result;
        }
        private void ParseLine(string line)
        {
            string mark = "IMAGE ";
            if (doElementLis(line, mark, this.VisionList)) return;
            mark = "SOUND ";
            if (doElementLis(line, mark, this.VisionList)) return;
            mark = "TEXT ";
            if (doElementLis(line, mark, this.TextList)) return;
        }
        private bool doElementLis(string line, string mark, List<ScenElement> list)
        {
            if (line.StartsWith(mark))
            {
                line = line.Replace(mark, string.Empty);
                string[] vals = line.Split(';');
                ScenElement element = list.Where(x => x.Name == vals[0]).FirstOrDefault();
                element?.ApplyData(vals);
                return true;
            }
            return false;
        }
    }


}
