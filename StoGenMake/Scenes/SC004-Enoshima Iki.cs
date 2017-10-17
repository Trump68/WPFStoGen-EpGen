using StoGenMake.Elements;
using StoGenMake.Pers;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class SC004_EnoshimaIki: BaseScene
    {
        #region CADRE GROUPS
        private string GROUP01 = "Various";
        #endregion

        public SC004_EnoshimaIki() : base()
        {
            Name = "Enoshima Iki";
            this.CadreGroups.Add(GROUP01);
            //this.CadreGroups.Add(GROUP02);
            
        }


        protected override void MakeCadres(string cadregroup)
        {
            if (cadregroup == GROUP01)
            {
                for (int i = 1; i <= 21; i++)
                {
                    SetCadre(new AlignData[] { new AlignData($"LADY_Body_17100723{i.ToString("D2")}") }, this);
                }
            }
            this.Cadres.Reverse();
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;

            
            path = @"x:\DOUJIN\Enoshima Iki\[DOUJIN COLOR] Kuro Gal Bitch ga Uchi ni Kita!\"; 

            string dsc = "Enoshima Iki";
            string src = null;
            string fn = null;

            GetIm("LADY_Body_1710072301", VNPCPersType.ArtCG, dsc, path, "002.png", data);
            GetIm("LADY_Body_1710072302", VNPCPersType.ArtCG, dsc, path, "002a.png", data);
            GetIm("LADY_Body_1710072303", VNPCPersType.ArtCG, dsc, path, "002b.png", data);
            GetIm("LADY_Body_1710072304", VNPCPersType.ArtCG, dsc, path, "002c.png", data);
            GetIm("LADY_Body_1710072305", VNPCPersType.ArtCG, dsc, path, "002d.png", data);
            GetIm("LADY_Body_1710072306", VNPCPersType.ArtCG, dsc, path, "002e.png", data);
            GetIm("LADY_Body_1710072307", VNPCPersType.ArtCG, dsc, path, "002f.png", data);
            GetIm("LADY_Body_1710072308", VNPCPersType.ArtCG, dsc, path, "002g.png", data);
            GetIm("LADY_Body_1710072309", VNPCPersType.ArtCG, dsc, path, "002h.png", data);
            GetIm("LADY_Body_1710072310", VNPCPersType.ArtCG, dsc, path, "002j.png", data);
            GetIm("LADY_Body_1710072311", VNPCPersType.ArtCG, dsc, path, "002k.png", data);
            GetIm("LADY_Body_1710072312", VNPCPersType.ArtCG, dsc, path, "002l.png", data);
            GetIm("LADY_Body_1710072313", VNPCPersType.ArtCG, dsc, path, "002m.png", data);
            GetIm("LADY_Body_1710072314", VNPCPersType.ArtCG, dsc, path, "002n.png", data);
            GetIm("LADY_Body_1710072315", VNPCPersType.ArtCG, dsc, path, "002o.png", data);
            GetIm("LADY_Body_1710072316", VNPCPersType.ArtCG, dsc, path, "002p.png", data);
            GetIm("LADY_Body_1710072317", VNPCPersType.ArtCG, dsc, path, "001.png", data);
            GetIm("LADY_Body_1710072318", VNPCPersType.ArtCG, dsc, path, "001a.png", data);
            GetIm("LADY_Body_1710072319", VNPCPersType.ArtCG, dsc, path, "001b.png", data);
            GetIm("LADY_Body_1710072320", VNPCPersType.ArtCG, dsc, path, "001c.png", data);
            GetIm("LADY_Body_1710072321", VNPCPersType.ArtCG, dsc, path, "001d.png", data);

        }

    }
}
