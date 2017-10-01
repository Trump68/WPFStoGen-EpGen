using StoGen.Classes;
using StoGenLife.NPC;
using StoGenLife.SOUND;
using StoGenMake.Elements;
using StoGenMake.Entity;
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
        #region constants
        // sound
        public static string MUSIC_MAIN_THEME = "MUSIC_MAIN_THEME";
        public static string ASMR_01 = "ASMR_01";
        public static string ORGAZM_01 = "ORGAZM_01";
        public static string ORGAZM_02 = "ORGAZM_02";
        public static string ORGAZM_03 = "ORGAZM_03";
        public static string ORGAZM_04 = "ORGAZM_04";

        // images
        public static string MAIN_PERSON_PICTURE = "MAIN_PERSON_PICTURE";

        public static string DOCIER_PICTURE = "DOCIER_PICTURE";
        //parts
        public static string RIGHT_EYE_WINK = "RIGHT_EYE_WINK";
        public static string EYES_CLOSE_01 = "EYES_CLOSE_01"; 
        #endregion

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


        public EntityData Data = new EntityData();
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
        private string _TempFileName;
        public string TempFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_TempFileName))
                {
                    if (!string.IsNullOrEmpty(this.Name)) _TempFileName = $@"d:\temp\{this.Name}.stogen";
                    else
                        _TempFileName = $@"d:\temp\{this.GID}.stogen";
                }
                return _TempFileName;
            }
            set
            {
                _TempFileName = value;
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
        public virtual bool CreateMenuPersone(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            return false;
        }
        public virtual bool CreateMenuPersoneDocier(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            item = new ChoiceMenuItem($"Досье на {this.Name}", this);
            item.Executor = delegate (object data)
            {
                this.FillDocierScene();
                //this.SceneFigure.NextCadre("Cadre" + proc.Cadres.Count);
                this.Generate(this.TempFileName);

                StoGenParser.AddCadresToProcFromFile(proc, this.TempFileName, null, StoGenParser.DefaultPath);
                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();
            };
            itemlist.Add(item);
            ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, false);
            return true;
        }
        public virtual void FillDocierScene()
        {
            if (this.Scene == null) this.Scene = new BaseScene();
            this.Scene.Cadres.Clear();
            var items = this.Data.ByName("IMAGE", DOCIER_PICTURE, null);            
            foreach (var it in items)
            {
                ScenCadre cadre;
                cadre = this.Scene.AddCadre(null, null, 200, this.Scene);

                ScenElementImage image;
                image = new ScenElementImage();                
                image.Name = $"DOCIER_PICTURE {cadre.VisionList.Count}";
                image.File = it.Value;
                cadre.VisionList.Add(image);
            }
        }
    }

}

