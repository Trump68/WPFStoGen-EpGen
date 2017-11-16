using StoGen.Classes.Scene;
using StoGenMake.Persona;
using StoGenMake.Scenes.Base;
using System.Collections.Generic;

namespace StoGenMake.Scenes
{
    public class SC000_Various : BaseScene
    {
        public class Catalogue : SceneMaker
        {
            public static string CName = "SC000_Various_Catalogue";
            public static int Variants = 11;
            #region Text          
            #endregion
            public Catalogue(BaseScene scene, string name) : base(scene, name)
            {
            }
            public static List<DifData> Get(BaseScene scene, int var, DifData delta = null)
            {
                Catalogue inst = new Catalogue(scene, CName);              
                inst.Variant = var;
                return inst.Get(delta);
            }
            public override List<DifData> Get(DifData delta = null)
            {
                List<DifData> result = base.Get(delta);

                #region Codec
                if (Variant == 1)
                {
                    result.Insert(0, new DifData("Codec_BodyScene_001") { X = 10, S = 770, F = 0 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 330, Y = 5, S = 1425, F = 0 });
                }
                else if (Variant == 2)
                {
                    result.Insert(0, new DifData("Codec_BodyScene_002") { X = 10, S = 770, F = 0 });
                    //result.Add(new DifData(Mouth.Sensual_001) { X = 286, Y = 199, S = 21, R = 35, F = 1 });
                    result.Add(new DifData(Mouth.ERECTLIP_BakunyuuOnsen_001) { X = 286, Y = 204, S = 26, R = 10, F = 0 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 330, Y = 5, S = 1425, F = 0 });
                }
                else if (Variant == 3)
                {
                    result.Insert(0, new DifData("Codec_BodyScene_003") { X = 10, S = 770, F = 0 });
                    //result.Add(new DifData(Mouth.Sensual_001) { X = 286, Y = 199, S = 21, R = 35, F = 1 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 330, Y = 5, S = 1425, F = 0 });
                }
                #endregion
                #region Eriya - J
                else if (Variant == 4)
                {
                    result.Insert(0, new DifData("Eriya-J_BodyScene_001") { X = 10, S = 770, F = 0 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 600, Y = 5, S = 1000, F = 0 });
                }
                else if (Variant == 5)
                {
                    result.Insert(0, new DifData("Eriya-J_BodyScene_002") { X = -45, S = 810, F = 0 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 600, Y = 5, S = 1000, F = 0 });
                }
                #endregion
                #region Dcwj
                else if (Variant == 6)
                {
                    result.Insert(0, new DifData("Dcwj_BodyScene_001") { X = 10, S = 770, F = 0 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 485, S = 1065, F = 0 });
                }
                else if (Variant == 7)
                {
                    result.Insert(0, new DifData("Dcwj_BodyScene_002") { X = -45, S = 810, F = 0 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 600, Y = 5, S = 1000, F = 0 });
                }
                else if (Variant == 8)
                {
                    result.Insert(0, new DifData("Dcwj_BodyScene_003") { X = -45, S = 810, F = 0 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 600, Y = 5, S = 1000, F = 0 });
                }
                else if (Variant == 9)
                {
                    result.Insert(0, new DifData("Dcwj_BodyScene_004") { X = -45, S = 810, F = 0 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 600, Y = 5, S = 1000, F = 0 });
                }
                else if (Variant == 10)
                {
                    result.Insert(0, new DifData("Dcwj_BodyScene_005") { X = -45, S = 810, F = 0 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 600, Y = 5, S = 1000, F = 0 });
                }
                else if (Variant == 11)
                {
                    result.Insert(0, new DifData("Dcwj_BodyScene_006") { X = -45, S = 810, F = 0 });
                    result.Add(new DifData(Devil.ManOld_001) { X = 600, Y = 5, S = 1000, F = 0 });
                }               
                #endregion
                return result;
            }
        }

        public SC000_Various() : base()
        {
            Name = "SC000-Various";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }
        protected override void DoFilter(string cadregroup)
        {
            base.DoFilter(cadregroup);
            this.Cadres.Reverse();
        }
        protected override void LoadData()
        {
            string path = null;
            

           
            string src = null;
            string fn = null;
            int ss = 700;
            string gr = null;

            #region artist Eriya-J
            string dsc = "artist Eriya-J";
            path = @"Z:\ARTIST\Eriya-J\DBR\";
            gr = " Eriya-J Raw data";
            for (int i = 1; i <= 2; i++)
            {
                src = $"Eriya-J_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

            #endregion
            #region artist Codec
            dsc = "artist Codec";
            path = @"Z:\ARTIST\Codec\DBR\";
            gr = "Codec Raw data";
            for (int i = 1; i <= 3; i++)
            {
                src = $"Codec_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

            #endregion
            #region artist Dako 5
            dsc = "artist Dako 5";
            path = @"Z:\ARTIST\Dako 5\DBR\";
            gr = "Dako 5 data";
            for (int i = 1; i <= 2; i++)
            {
                src = $"Dako_5_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Dcwj
            dsc = "artist Dcwj";
            path = @"Z:\ARTIST\Dcwj\DBR\";
            gr = "Dcwj data";
            for (int i = 1; i <= 6; i++)
            {
                src = $"Dcwj_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Destiny Child
            dsc = "artist Destiny Child";
            path = @"Z:\ARTIST\Destiny Child\DBR\";
            gr = "Destiny Child data";
            for (int i = 1; i <= 3; i++)
            {
                src = $"Destiny_Child_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Doxy
            dsc = "artist Doxy";
            path = @"Z:\ARTIST\Doxy\DBR\";
            gr = "Doxy data";
            for (int i = 1; i <= 7; i++)
            {
                src = $"Doxy_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Emyo
            dsc = "artist Emyo";
            path = @"Z:\ARTIST\Emyo\DBR\";
            gr = "Emyo data";
            for (int i = 1; i <= 5; i++)
            {
                src = $"Emyo_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            gr = "Emyo PNG";
            for (int i = 1; i <= 1; i++)
            {
                src = $"Emyo_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Firolian
            dsc = "artist Firolian";
            path = @"Z:\ARTIST\Firolian\DBR\";
            gr = "Firolian data";
            for (int i = 1; i <= 6; i++)
            {
                src = $"Firolian_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Frans Mensink
            dsc = "artist Frans Mensink";
            path = @"Z:\ARTIST\Frans Mensink\DBR\";
            gr = "Frans Mensink data";
            for (int i = 1; i <= 18; i++)
            {
                src = $"Frans_Mensink_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist G.m (gorgeous mushroom)
            dsc = "artist G.m (gorgeous mushroom)";
            path = @"Z:\ARTIST\G.m (gorgeous mushroom)\Pixiv\";
            gr = "G.m (gorgeous mushroom) data";
            for (int i = 1; i <= 4; i++)
            {
                src = $"G.m_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Geo Siador
            dsc = "artist Geo Siador";
            path = @"Z:\ARTIST\Geo Siador\DBR\";
            gr = "Geo Siador data";
            for (int i = 1; i <= 9; i++)
            {
                src = $"Geo_Siador_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion
            #region artist Ghettoyouth
            dsc = "artist Ghettoyouth";
            path = @"Z:\ARTIST\Ghettoyouth\DBR\";
            gr = "Ghettoyouth data";
            for (int i = 1; i <= 34; i++)
            {
                src = $"Ghettoyouth_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            for (int i = 1; i <= 1; i++)
            {
                src = $"Ghettoyouth_Head_PNG_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path);
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }
            #endregion

        }
    }

}
