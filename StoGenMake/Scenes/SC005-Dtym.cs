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
    public class SC005_Dtym : BaseScene
    {
        #region CADRE GROUPS
        private string GROUP01 = "Various";
        #endregion

        public SC005_Dtym() : base()
        {
            Name = "Dtym";
            this.CadreGroups.Add(GROUP01);
            //this.CadreGroups.Add(GROUP02);
     
        }


        protected override void MakeCadres(string cadregroup)
        {
            if (cadregroup == GROUP01)
            {
                for (int i = 1; i <= 21; i++)
                {
                    SetCadre(new AlignData[] { new AlignData($"LADY_Body_17100709{i.ToString("D2")}") }, this);
                }

            }


            this.Cadres.Reverse();
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;


            path = @"x:\ARTIST\Dtym\DBR\";

            string dsc = "Dtym";
            string src = null;
            string fn = null;

            for (int i = 1; i <= 6; i++)
            {
                GetIm($"LADY_Body_17100709{i.ToString("D2")}", VNPCPersType.ArtCG, dsc, path, $"Body_0{i.ToString("D2")}.png", data);               
            }
        }

    }
}
