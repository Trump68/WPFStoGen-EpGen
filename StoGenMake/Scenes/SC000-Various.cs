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
    public class SC000_Various : BaseScene
    {
  
        public SC000_Various() : base()
        {
            Name = "Dtym";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }
        protected override void MakeCadres(string cadregroup)
        {
            base.MakeCadres(cadregroup);
            this.Cadres.Reverse();
            //if (cadregroup == GROUP01)
            //{
            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710071008",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710071008",null)
            //}, this, false);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710071007",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710071007",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710071006",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710071006",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710071005",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710071005",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710071004",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710071004",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710071003",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710071003",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710071001",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710071001",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710071001",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710071001",null)
            //}, this);


            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072302",null,null),
            //  new AlignData("LADY_Head_1710071000","LADY_Body_1710072302",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072302",null,null),
            //  new AlignData("LADY_Head_1710071001","LADY_Body_1710072302",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072321",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072321",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072320",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072320",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072319",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072319",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072318",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072318",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072317",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072317",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072316",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072316",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072315",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072315",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072314",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072314",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072313",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072313",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072312",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072312",null)
            //}, this);


            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072311",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072311",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072310",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072310",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072309",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072309",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072308",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072308",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072307",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072307",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072306",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072306",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072305",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072305",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072304",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072304",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072303",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072303",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072302",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072302",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710072301",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710072301",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710070906",null,null),
            //  new AlignData("LADY_Head_1710070906","LADY_Body_1710070906",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710070905",null,null),
            //  new AlignData("LADY_Head_1710070905","LADY_Body_1710070905",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710070900",null,null),
            //  new AlignData("LADY_Head_1710070904","LADY_Body_1710070900",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710070904",null,null),
            //  new AlignData("LADY_Head_1710070904","LADY_Body_1710070904",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710070900",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710070900",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710070901",null,null),
            //  new AlignData("LADY_Head_1710070901","LADY_Body_1710070901",null)
            //}, this);


            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710070901",null,null),
            //  new AlignData("LADY_Head_1710070902","LADY_Body_1710070901",null)
            //}, this);


            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710070902",null,null),
            //  new AlignData("LADY_Head_1710070902","LADY_Body_1710070902",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710070903",null,null),
            //  new AlignData("LADY_Head_1710070903","LADY_Body_1710070903",null)
            //}, this);

            //    SetCadre(new AlignData[] {
            //  new AlignData("LADY_Body_1710070900",null,null),
            //  new AlignData("LADY_Head_1710070903","LADY_Body_1710070900",null)
            //}, this);
            //}
        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;
            path = @"x:\ARTIST\Eriya-J\DBR\";

            string dsc = "Eriya-J";
            string src = null;
            string fn = null;
            int ss = 700;
            string gr = null;

            gr = "Raw data";
            for (int i = 1; i <= 2; i++)
            {
                src = $"Eriya-J_BodyScene_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.jpg";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

            gr = "Face";
            for (int i = 1; i <= 2; i++)
            {
                src = $"Eriya-J_Face_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
                AddToGlobalImage(src, fn, path, new DifData() { s = ss });
                AddLocal(new string[] { gr }, new DifData[] { new DifData(src) });
            }

         
        }


    }

}
