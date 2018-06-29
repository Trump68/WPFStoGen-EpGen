using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPCat.Model
{
    public class SkyrimActorPose
    {
        public string ID;
        private string sourcePath;
        public int Position = 1;
        public int Stage = 1;
        public string Label;
        public int SOS = 0;
        public SkyrimEmotion Emotion = new SkyrimEmotion();
        public Cloth Cloth = new Cloth();
        public List<string> GetEmotionData()
        {
            return Emotion.ToStringList(Position-1);
        }
        public List<string> GetClothData()
        {
            return Cloth.Generate(Position - 1);
        }
        public SkyrimActorPose(string id)
        {
            this.ID = id;
            Init();
        }
        private bool Init()
        {
            var gid = Guid.Parse(ID);
            var p = Skyrim.Items.Where(x => x.GID.Equals(gid)).FirstOrDefault();
            if (p == null) return false;
            sourcePath = Path.GetDirectoryName((p.ItemPath));
            return true;
        }
        public void CopyToDestination()
        {           
            if (!string.IsNullOrEmpty(sourcePath))
            {
                string file = Directory.GetFiles(sourcePath, "*.hkx").FirstOrDefault();
                if (!string.IsNullOrEmpty(file))
                {
                    File.Copy(file, Path.Combine(Skyrim.destinationPath, $"AB01_Fuck_A{Position}_S{Stage}.hkx"), true);
                }
            }
        }
    }
    public class SkyrimEmotion
    {
        public bool Clear = false;
        public bool LipSynch = true;
        public EmoD Mood = new EmoD() { I = 0, V = 0 };
        public List<EmoD> Phonemes  = new List<EmoD>();
        public List<EmoD> Modifiers = new List<EmoD>();
        public List<string> ToStringList(int pos)
        {
            List<string> result = new List<string>();
            if (Clear)
            {
                result.Add($"      ActorAlias(Positions[{pos}]).AB_ClearExpression()");
            }
            foreach (var item in Phonemes)
            {
                result.Add($"      ActorAlias(Positions[{pos}]).AB_SetPhoneme({item.I},{item.V})");
            }
            foreach (var item in Modifiers)
            {
                result.Add($"      ActorAlias(Positions[{pos}]).AB_SetModifier({item.I},{item.V})");
            }
            result.Add($"      ActorAlias(Positions[{pos}]).AB_SetExpression({Mood.I},{Mood.V})");
            result.Add($"      ActorAlias(Positions[{pos}]).AB_SetUseLipSync({LipSynch})");
            return result;
        }
        private void CleanEyes()
        {
            SetModifier(8, 0);
            SetModifier(9, 0);
            SetModifier(10, 0);
            SetModifier(11, 0);
        }
        public void EyesLeft(bool clear, int vol = 100)
        {
            if (clear) CleanEyes();
            SetModifier(9,vol);
        }
        public void EyesRight(bool clear, int vol = 100)
        {
            if (clear) CleanEyes();
            SetModifier(10, vol);           
        }
        public void EyesUp(bool clear, int vol = 100)
        {
            if (clear) CleanEyes();
            SetModifier(11, vol);
        }
        public void EyesDown(bool clear, int vol = 100)
        {
            if (clear) CleanEyes();
            SetModifier(8, vol);
        }
        public void SetModifier(int i, int vol = 100)
        {
            var eo = Modifiers.Where(x => x.I == i).FirstOrDefault();
            if (eo == null)
            {
                //if (vol == 0) return;
                eo = new EmoD();
                Modifiers.Add(eo);
            }
            //if (vol == 0)
            //{
            //    Modifiers.Remove(eo);
            //    return;
            //}
            eo.I = i;
            eo.V = vol;
        }
        public void SetPhoneme(int i, int vol = 100)
        {
            var eo = Modifiers.Where(x => x.I == i).FirstOrDefault();
            if (eo == null)
            {
                if (vol == 0) return;
                eo = new EmoD();
                Modifiers.Add(eo);
            }
            if (vol == 0)
            {
                Modifiers.Remove(eo);
                return;
            }
            eo.I = i;
            eo.V = vol;
        }
        public void ClearPhoneme() { this.Phonemes.Clear(); }
        public void OpenMoutn()
        {
            ClearPhoneme();
            Mood.I = 16;
            Mood.V = 80;
            SetPhoneme(1, 60);
        }
        public void CloseMoutn()
        {
            //ClearPhoneme();
            Mood.I = 7;
            Mood.V = 50;
            SetPhoneme(1, 0);
        }

        internal void CloseEyes()
        {

        }
    }
    public class EmoD
    {
        public int I; //index,
        public int V; //value
    }
    public class ClothItem
    {
        public string Name;
        public string Id;
        public string File;
    }
    public class Cloth
    {
        public List<ClothItem> items = new List<ClothItem>();
        public bool AddCloth(string name)
        {
            bool result = false;
            string id = null;
            string file = null;
            if      (name == "Veil Solid Black") { id = "0x00003DDB"; file = "Veil Recoloring.esp"; }
            else if (name == "Veil Black")       { id = "0x00004E0A"; file = "Veil Recoloring.esp"; }
            else if (name == "Veil Solid White") { id = "0x00005E4B"; file = "Veil Recoloring.esp"; }
            else if (name == "Veil White")       { id = "0x00004E06"; file = "Veil Recoloring.esp"; }
            else if (name == "Veil Emerald")     { id = "0x000058E4"; file = "Veil Recoloring.esp"; }
            else if (name == "Veil Purple")      { id = "0x00005E50"; file = "Veil Recoloring.esp"; }
            else if (name == "Veil Lavender")    { id = "0x000063B7"; file = "Veil Recoloring.esp"; }
            else if (name == "Veil Cyan")        { id = "0x00000D63"; file = "Veil Recoloring.esp"; }
            else if (name == "Veil Royal Blue")  { id = "0x00005372"; file = "Veil Recoloring.esp"; }
            else if (name == "Veil Baby Blue")   { id = "0x00005378"; file = "Veil Recoloring.esp"; }
            else if (name == "Veil Baby Red")    { id = "0x0000058F"; file = "Veil Recoloring.esp"; }
            if (id != null)
            {
                var it = new ClothItem();
                it.Name = name;
                it.Id = id;
                it.File = file;
                items.Add(it);
                result = true;
            }
            return result;
        }
        public List<string> Generate(int pos)
        {
            List<string> result = new List<string>();
            if (items.Any()) result.Add("     Form cloth");
            foreach (var item in items)
            {
                string line1 = $@"     cloth = Game.GetFormFromFile({item.Id},""{item.File}"")";
                string line2 = $@"     ActorAlias(Positions[{pos}]).AddItem(cloth, 1, true)";
                string line3 = $@"     ActorAlias(Positions[{pos}]).EquipItem(cloth)"; 
                    
            }
            return result;
        }
    }
}
