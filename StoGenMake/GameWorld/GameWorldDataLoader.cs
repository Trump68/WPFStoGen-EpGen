using StoGenMake.Elements;
using StoGenMake.Pers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake
{
    public static class GameWorldDataLoader
    {
        public static void LoadPersList (List<VNPC> perlist)
        {
            AddGenericPers(perlist, "Lorena B", @"x:\\STOGEN\LADY\REAL\Lorena B\", VNPCPersType.Real, @"metart_milede_lorena-b_high_0001 copy.jpg");
            
        }
        private static void AddGenericPers(List<VNPC> perlist, string name, string path, VNPCPersType perstype, params string[] piclist)
        {
            VNPC pers = null;
            pers = new VNPC();
            pers.PersonType = perstype;
            if (string.IsNullOrEmpty(name))
                name = $"Generic Person {perlist.Count}";
            pers.Name = name;
            foreach (var item in piclist)
            {
                pers.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, null, $@"{path}{item}");
            }
            perlist.Add(pers);
        }

      
        internal static void LoadFemBodyList(List<VNPC> commonFemBodyList)
        {
            string path = null;
            path = @"x:\STOGEN\LADY\COMIX\LADY_041017\";
            commonFemBodyList.Add(GetFemBody("LADY_Body_1710070900", VNPCPersType.Comix, "bellas de noche 128", path, "(Aca los Maistros 04)-19 copy 3.png"));

            path = @"x:\ARTIST\Dtym\DBR\";
            commonFemBodyList.Add(GetFemBody("LADY_Body_1710070901", VNPCPersType.ArtCG, "Dtym", path, "Body_001.png"));
            commonFemBodyList.Add(GetFemBody("LADY_Body_1710070902", VNPCPersType.ArtCG, "Dtym", path, "Body_002.png"));
            commonFemBodyList.Add(GetFemBody("LADY_Body_1710070903", VNPCPersType.ArtCG, "Dtym", path, "Body_003.png"));

        }

        internal static void LoadFemHeadList(List<VNPC> commonFemHeadList, List<AlignData> HeadToBodyAlignList)
        {
            string path = @"x:\STOGEN\LADY\COMIX\LADY_Heads_Dtym\";

            commonFemHeadList.Add(GetFemHead("LADY_Head_1710070901", VNPCPersType.ArtCG, "Dtym", path, "01a.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070901", new seIm() { X = -5, sX = 290 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070900", new seIm() { X = 60, Y = 55, sX = 270, Rot = 340, Flip = 1 }));

            commonFemHeadList.Add(GetFemHead("LADY_Head_1710070902", VNPCPersType.ArtCG, "Dtym", path, "02.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070902", "LADY_Body_1710070902", new seIm() { X = 110, sX = 260 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070902", "LADY_Body_1710070901", new seIm() { X = 70, sX = 180 }));

            commonFemHeadList.Add(GetFemHead("LADY_Head_1710070903", VNPCPersType.ArtCG, "Dtym", path, "03.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070903", "LADY_Body_1710070903", new seIm() { X = 105, sX = 205 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070903", "LADY_Body_1710070900", new seIm() { X = 70, Y = 30, sX = 200, Rot=25 }));

        }

        internal static VNPC GetFemHead(string name, VNPCPersType type, string desc, string path, string file)
        {
            VNPC pers = new VNPC();
            pers.Name = name;
            pers.PersonType = VNPCPersType.Comix;
            pers.Description = desc;
            pers.Faces.Add(new VNPCFace(new seIm($@"{path}{file}", name)));          
            return pers;
        }
        internal static VNPC GetFemBody(string name, VNPCPersType type, string desc, string path, string file)
        {
            VNPC pers = new VNPC();
            pers.Name = name;
            pers.PersonType = VNPCPersType.Comix;
            pers.Description = desc;
            pers.ClothList.Add(new VNPCCloth(VNPCClothType.Undefined,new seIm($@"{path}{file}", name)));            
            return pers;
        }
    }
}
