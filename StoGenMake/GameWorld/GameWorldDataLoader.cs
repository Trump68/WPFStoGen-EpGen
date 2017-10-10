﻿using StoGenMake.Elements;
using StoGenMake.Pers;
using StoGenMake.Scenes.Base;
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
        internal static void LoadManHeadList(List<seIm> commonManHeadList)
        {
            string path = null;

           
        }

        internal static void LoadManBodyList(List<seIm> commonManBodyList)
        {
            string path = null;

            

        }

        internal static void LoadFemBodyList(List<seIm> commonFemBodyList)
        {
            string path = null;


            path = @"x:\STOGEN\LADY\COMIX\LADY_041017\";
            commonFemBodyList.Add(GetIm("LADY_Body_1710070900", VNPCPersType.Comix, "bellas de noche 128", path, "(Aca los Maistros 04)-19 copy 3.png"));

            path = @"x:\ARTIST\Dtym\DBR\";
            commonFemBodyList.Add(GetIm("LADY_Body_1710070901", VNPCPersType.ArtCG, "Dtym", path, "Body_001.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070902", VNPCPersType.ArtCG, "Dtym", path, "Body_002.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070903", VNPCPersType.ArtCG, "Dtym", path, "Body_003.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070904", VNPCPersType.ArtCG, "Dtym", path, "Body_004.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070905", VNPCPersType.ArtCG, "Dtym", path, "Body_005.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070906", VNPCPersType.ArtCG, "Dtym", path, "Body_006.png"));
            path = @"x:\DOUJIN\Enoshima Iki\[DOUJIN COLOR] Kuro Gal Bitch ga Uchi ni Kita!\";            
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908", VNPCPersType.ArtCG, "Enoshima Iki", path, "002.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908a", VNPCPersType.ArtCG, "Enoshima Iki", path, "002a.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908b", VNPCPersType.ArtCG, "Enoshima Iki", path, "002b.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908c", VNPCPersType.ArtCG, "Enoshima Iki", path, "002c.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908d", VNPCPersType.ArtCG, "Enoshima Iki", path, "002d.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908e", VNPCPersType.ArtCG, "Enoshima Iki", path, "002e.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908f", VNPCPersType.ArtCG, "Enoshima Iki", path, "002f.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908g", VNPCPersType.ArtCG, "Enoshima Iki", path, "002g.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908h", VNPCPersType.ArtCG, "Enoshima Iki", path, "002h.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908j", VNPCPersType.ArtCG, "Enoshima Iki", path, "002j.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908k", VNPCPersType.ArtCG, "Enoshima Iki", path, "002k.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908l", VNPCPersType.ArtCG, "Enoshima Iki", path, "002l.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908m", VNPCPersType.ArtCG, "Enoshima Iki", path, "002m.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908n", VNPCPersType.ArtCG, "Enoshima Iki", path, "002n.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908o", VNPCPersType.ArtCG, "Enoshima Iki", path, "002o.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070908p", VNPCPersType.ArtCG, "Enoshima Iki", path, "002p.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070907", VNPCPersType.ArtCG, "Enoshima Iki", path, "001.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070907a", VNPCPersType.ArtCG, "Enoshima Iki", path, "001a.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070907b", VNPCPersType.ArtCG, "Enoshima Iki", path, "001b.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070907c", VNPCPersType.ArtCG, "Enoshima Iki", path, "001c.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710070907d", VNPCPersType.ArtCG, "Enoshima Iki", path, "001d.png"));

            path = @"x:\ARTIST\Erotibot\DBR\";
            commonFemBodyList.Add(GetIm("LADY_Body_1710071002", VNPCPersType.ArtCG, "Erotibot", path, "001.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710071003", VNPCPersType.ArtCG, "Erotibot", path, "002.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710071004", VNPCPersType.ArtCG, "Erotibot", path, "003.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710071005", VNPCPersType.ArtCG, "Erotibot", path, "004.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710071006", VNPCPersType.ArtCG, "Erotibot", path, "005.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710071007", VNPCPersType.ArtCG, "Erotibot", path, "006.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710071008", VNPCPersType.ArtCG, "Erotibot", path, "007.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710071009", VNPCPersType.ArtCG, "Erotibot", path, "009.png"));



        }

        internal static void LoadFemHeadList(List<seIm> commonFemHeadList, List<AlignDif> HeadToBodyAlignList)
        {
            string path =null;

           

            path = @"x:\STOGEN\LADY\COMIX\LADY_Heads_Eriya-J\";
            commonFemHeadList.Add(GetIm("LADY_Head_1710071000", VNPCPersType.ArtCG, "Eriya-J", path, "01.png"));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710071000", "LADY_Body_1710070908a", new DifData() { X = 145, Y = 20, sX = 200, sY = 200, Rot = 340, Flip = 0 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710071001", VNPCPersType.ArtCG, "Eriya-J", path, "02.png"));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710071001", "LADY_Body_1710070908a", new DifData() { X = 115, Y = 20, sX = 215, sY = 215, Rot = 380, Flip = 0 }));

            path = @"x:\STOGEN\LADY\COMIX\LADY_Heads_Dtym\";

            commonFemHeadList.Add(GetIm("LADY_Head_1710070901", VNPCPersType.ArtCG, "Dtym", path, "01a.png"));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070901", new DifData() { X = -5, sX = 290 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070900", new DifData() { X = 60, Y = 55, sX = 270, Rot = 340, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710071002", new DifData() { X = 65, Y = 0, sX = 165, sY = 165, Rot = 325, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710071003", new DifData() { X = 270, Y = 5, sX = 260, sY = 260, Rot = 50, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710071004", new DifData() { X = 25, Y = 50, sX = 225, sY = 225, Rot = 50, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710071005", new DifData() { X = 95, Y = 65, sX = 265, sY = 265, Rot = 20, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710071006", new DifData() { X = 295, Y = 125, sX = 180, sY = 180, Rot = 45, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710071007", new DifData() { X = -35, Y = 85, sX = 345, sY = 345, Rot = 30, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710071008", new DifData() { X = 65, Y = 65, sX = 245, sY = 245, Rot = 24, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710071009", new DifData() { X = 215, Y = 70, sX = 225, sY = 225, Rot = 344, Flip = 1 }));


            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908a", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908b", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908c", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908d", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908e", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908f", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908g", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908h", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908j", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908k", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908l", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908m", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908n", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908o", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908p", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070908", new DifData() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070907", new DifData()  { X = 45, Y = 40, sX = 380, sY = 380, Rot = 315, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070907a", new DifData() { X = 45, Y = 40, sX = 380, sY = 380, Rot = 315, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070907b", new DifData() { X = 45, Y = 40, sX = 380, sY = 380, Rot = 315, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070907c", new DifData() { X = 45, Y = 40, sX = 380, sY = 380, Rot = 315, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070901", "LADY_Body_1710070907d", new DifData() { X = 45, Y = 40, sX = 380, sY = 380, Rot = 315, Flip = 1 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710070902", VNPCPersType.ArtCG, "Dtym", path, "02.png"));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070902", "LADY_Body_1710070902", new DifData() { X = 110, sX = 260 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070902", "LADY_Body_1710070901", new DifData() { X = 70, sX = 180 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710070903", VNPCPersType.ArtCG, "Dtym", path, "03.png"));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070903", "LADY_Body_1710070903", new DifData() { X = 105, sX = 205 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070903", "LADY_Body_1710070900", new DifData() { X = 70, Y = 30, sX = 200, Rot=25 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710070904", VNPCPersType.ArtCG, "Dtym", path, "04.png"));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070904", "LADY_Body_1710070904", new DifData() { X = 125, Y = 110, sX = 250 , sY = 250 }));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070904", "LADY_Body_1710070900", new DifData() { X = 70, Y = 20, sX = 210, sY= 210 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710070905", VNPCPersType.ArtCG, "Dtym", path, "05.png"));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070905", "LADY_Body_1710070905", new DifData() { X = 80, Y = 0, sX = 355, sY = 355 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710070906", VNPCPersType.ArtCG, "Dtym", path, "06.png"));
            HeadToBodyAlignList.Add(new AlignDif("LADY_Head_1710070906", "LADY_Body_1710070906", new DifData() { X = -5, Y = 10, sX = 220, sY = 220 }));



        }

        internal static seIm GetIm(string name, VNPCPersType type, string desc, string path, string file)
        {
            seIm im = new seIm($@"{path}{file}", name);
            im.Name = name;
            im.PersonType = VNPCPersType.Comix;
            im.Description = desc;   
            return im;
        }
       
    }
}
