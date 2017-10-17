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
    public class SC006_Erotibot : BaseScene
    {
        #region CADRE GROUPS
        private string GROUP01 = "Various";
        #endregion

        public SC006_Erotibot() : base()
        {
            Name = "Erotibot";
            this.CadreGroups.Add(GROUP01);
            //this.CadreGroups.Add(GROUP02);
        }


        protected override void MakeCadres(string cadregroup)
        {
            if (cadregroup == GROUP01)
            {
                for (int i = 1; i <= 8; i++)
                {
                    SetCadre(new AlignData[] { new AlignData($"LADY_Body_1710071{i.ToString("D3")}") }, this);
                }

            }


            this.Cadres.Reverse();
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;


            path = @"x:\ARTIST\Erotibot\DBR\";

            string dsc = "Erotibot";
            string src = null;
            string fn = null;

            for (int i = 1; i <= 7; i++)
            {
                GetIm($"LADY_Body_1710071{i.ToString("D3")}", VNPCPersType.ArtCG, dsc, path, $"{i.ToString("D3")}.png", data);
            }
            GetIm("LADY_Body_1710071008", VNPCPersType.ArtCG, dsc, path, "009.png",data);

        }

    }
}
