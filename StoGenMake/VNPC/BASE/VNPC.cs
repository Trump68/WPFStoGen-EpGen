using StoGenLife.NPC;
using StoGenLife.SOUND;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Pers
{
    public class VNPC:NPC
    {
        // sound
        public static string MUSIC_MAIN_THEME = "MUSIC_MAIN_THEME";
        public static string ASMR_01 = "ASMR_01";
        public static string ORGAZM_01 = "ORGAZM_01";
        public static string ORGAZM_02 = "ORGAZM_02";
        public static string ORGAZM_03 = "ORGAZM_03";
        public static string ORGAZM_04 = "ORGAZM_04";

        // images
        public static string MAIN_PERSON_PICTURE = "MAIN_PERSON_PICTURE";
        //parts
        public static string RIGHT_EYE_WINK = "RIGHT_EYE_WINK";
        public static string EYES_CLOSE_01 = "EYES_CLOSE_01";

        public VNPC()
        {
            this.Data.Add("IMAGE", MAIN_PERSON_PICTURE, null, null);
            this.Data.Add("IMAGE", MAIN_PERSON_PICTURE, RIGHT_EYE_WINK, null);
            this.Data.Add("IMAGE", MAIN_PERSON_PICTURE, EYES_CLOSE_01, null);
            // sound
            this.Data.Add("SOUND", MUSIC_MAIN_THEME, null, null);
            this.Data.Add("SOUND", ASMR_01, null, null);
            this.Data.Add("SOUND", ORGAZM_01, null, null);
            this.Data.Add("SOUND", ORGAZM_02, null, null);
            this.Data.Add("SOUND", ORGAZM_03, null, null);
            this.Data.Add("SOUND", ORGAZM_04, null, null);
        }
        
        public BaseScene Scene { set; get; }


        public NPCData Data = new NPCData();
        public void SetPersVariablesData(List<string> datalist)
        {
            List<string> result = new List<string>();
            if (datalist != null)
            {
                foreach (var item in datalist)
                {
                    string[] vals = item.Split(';');
                    if (vals.Length == 3)
                    {
                        Data.SetByName(vals[0].Trim(),vals[1].Trim(), null, vals[2].Trim());
                    }
                    else if(vals.Length == 4)
                    {
                        Data.SetByName(vals[0].Trim(), vals[1].Trim(), vals[2].Trim(), vals[3].Trim());
                    }
                }
            }
        }
       
        internal string Generate(string FileToProcess)
        {
            string fnScenario = string.Empty;
            if (!string.IsNullOrEmpty(FileToProcess))
            {
                string newfnScenario = Path.GetFileNameWithoutExtension(FileToProcess) + ".stogen";
                string savepath = Path.GetDirectoryName(FileToProcess);
                fnScenario = Path.Combine(savepath, newfnScenario);
            }

            List<string> scendata = new List<string>();            
            foreach (var item in this.Scene.Cadres)
            {
                item.InitValuesFromPers(this.Data.Variables);
                int i = 0;
                if (item.IsActivated)
                {
                    var cadredata = item.GetCadreData();
                    if (!string.IsNullOrEmpty(FileToProcess))
                    {
                        string newfnCadre = i.ToString("000") + "_" + item.Name + ".stogen";
                        string savepathCadre = Path.GetDirectoryName(FileToProcess) + @"\Cadres\";
                        if (!Directory.Exists(savepathCadre)) Directory.CreateDirectory(savepathCadre);
                        string fnCadre = Path.Combine(savepathCadre, newfnCadre);
                        File.WriteAllText(fnCadre, string.Join(Environment.NewLine, cadredata.ToArray()));
                    }
                    scendata.AddRange(cadredata);
                }
            }

            File.WriteAllText(fnScenario, string.Join(Environment.NewLine, scendata.ToArray()));
            return fnScenario;
        }

        public virtual void PrepareScene()
        {
            
        }
    }

    public class NPCData
    {
        public static string ImageDialogMain = "PIC Main dialog";
        public List<VNPCVariable> Variables { get; } = new List<VNPCVariable>();        
        public IEnumerable<VNPCVariable> ByName(string type, string name, string part)
        {
            return Variables.Where(x => x.Type == type && x.Name == name && x.Part == part);
        }
        public void SetByName(string type, string name,string part, string val)
        {
            ByName(type, name, part).ToList().ForEach(x => x.Value = val);
        }
        public void Add(string type, string name, string part, string defaultVal)
        {
            if (!ByName(type, name, part).Any())
            {
                this.Variables.Add(new VNPCVariable(type, name,part, defaultVal, null));
            }
        }
    }

    public class VNPCVariable
    {
        public string Name;
        public string Part;
        public string Description;
        public string Value;
        public string Type;
        public VNPCVariable(string type, string name,string part, string val, string desc)
        {
            Name = name;
            Part = part;
            Description = desc;
            Value = val;
            Type = type;
        }
    }
}

