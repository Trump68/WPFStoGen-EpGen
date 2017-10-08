﻿using StoGenMake.Elements;
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
        internal static void LoadManHeadList(List<seIm> commonManHeadList)
        {
            string path = null;

            path = @"x:\STOGEN\EVILMAN\COMIX\Hara Shigeyuki\";
            commonManHeadList.Add(GetIm("EVILMAN_Head_1710080900", VNPCPersType.Comix, "Hara Shigeyuki", path, "001a.png"));
            commonManHeadList.Add(GetIm("EVILMAN_Head_1710080901", VNPCPersType.Comix, "Hara Shigeyuki", path, "002a.png"));
            commonManHeadList.Add(GetIm("EVILMAN_Head_1710080902", VNPCPersType.Comix, "Hara Shigeyuki", path, "003a.png"));
            commonManHeadList.Add(GetIm("EVILMAN_Head_1710080903", VNPCPersType.Comix, "Hara Shigeyuki", path, "005.png"));
        }

        internal static void LoadManBodyList(List<seIm> commonManBodyList)
        {
            string path = null;

            path = @"x:\STOGEN\EVILMAN\COMIX\Hara Shigeyuki\";
            commonManBodyList.Add(GetIm("EVILMAN_Body_1710080900", VNPCPersType.Comix, "Hara Shigeyuki", path, "001.png"));
            commonManBodyList.Add(GetIm("EVILMAN_Body_1710080901", VNPCPersType.Comix, "Hara Shigeyuki", path, "002.png"));
            commonManBodyList.Add(GetIm("EVILMAN_Body_1710080902", VNPCPersType.Comix, "Hara Shigeyuki", path, "003.png"));
            commonManBodyList.Add(GetIm("EVILMAN_Body_1710080903", VNPCPersType.Comix, "Hara Shigeyuki", path, "004.png"));
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


            //Hara Shigeyuki
            path = @"x:\DOUJIN\Hara Shigeyuki\Abunai Hitozuma - Shouko no Bouken\";
            commonFemBodyList.Add(GetIm("LADY_Body_1710080900", VNPCPersType.Manga, "Hara Shigeyuki", path, "005.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080901", VNPCPersType.Manga, "Hara Shigeyuki", path, "006.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080902", VNPCPersType.Manga, "Hara Shigeyuki", path, "007.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080903", VNPCPersType.Manga, "Hara Shigeyuki", path, "008.png"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080910", VNPCPersType.Manga, "Hara Shigeyuki", path, "009.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080911", VNPCPersType.Manga, "Hara Shigeyuki", path, "010.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080912", VNPCPersType.Manga, "Hara Shigeyuki", path, "011.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080913", VNPCPersType.Manga, "Hara Shigeyuki", path, "012.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080914", VNPCPersType.Manga, "Hara Shigeyuki", path, "013.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080915", VNPCPersType.Manga, "Hara Shigeyuki", path, "014.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080916", VNPCPersType.Manga, "Hara Shigeyuki", path, "015.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080917", VNPCPersType.Manga, "Hara Shigeyuki", path, "016.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080918", VNPCPersType.Manga, "Hara Shigeyuki", path, "017.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080919", VNPCPersType.Manga, "Hara Shigeyuki", path, "018.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080920", VNPCPersType.Manga, "Hara Shigeyuki", path, "019.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080921", VNPCPersType.Manga, "Hara Shigeyuki", path, "020.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080922", VNPCPersType.Manga, "Hara Shigeyuki", path, "021.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080923", VNPCPersType.Manga, "Hara Shigeyuki", path, "022.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080924", VNPCPersType.Manga, "Hara Shigeyuki", path, "023.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080925", VNPCPersType.Manga, "Hara Shigeyuki", path, "025.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080926", VNPCPersType.Manga, "Hara Shigeyuki", path, "026.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080927", VNPCPersType.Manga, "Hara Shigeyuki", path, "027.jpg"));
            commonFemBodyList.Add(GetIm("LADY_Body_1710080928", VNPCPersType.Manga, "Hara Shigeyuki", path, "028.jpg"));
        }

        

        internal static void LoadFemHeadList(List<seIm> commonFemHeadList, List<AlignData> HeadToBodyAlignList)
        {
            string path =null;

            path = @"x:\STOGEN\LADY\COMIX\LADY_Heads_Hara Shigeyuki\";
            commonFemHeadList.Add(GetIm("LADY_Head_1710080900", VNPCPersType.Comix, "Hara Shigeyuki", path, "001.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710080900", "LADY_Body_1710080900", new seIm() { X = 205, Y = 10, sX = 140, sY = 140 }));
            commonFemHeadList.Add(GetIm("LADY_Head_1710080901", VNPCPersType.Comix, "Hara Shigeyuki", path, "002.png"));

            path = @"x:\STOGEN\LADY\COMIX\LADY_Heads_Eriya-J\";
            commonFemHeadList.Add(GetIm("LADY_Head_1710071000", VNPCPersType.ArtCG, "Eriya-J", path, "01.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710071000", "LADY_Body_1710070908a", new seIm() { X = 145, Y = 20, sX = 200, sY = 200, Rot = 340, Flip = 0 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710071001", VNPCPersType.ArtCG, "Eriya-J", path, "02.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710071001", "LADY_Body_1710070908a", new seIm() { X = 115, Y = 20, sX = 215, sY = 215, Rot = 380, Flip = 0 }));

            path = @"x:\STOGEN\LADY\COMIX\LADY_Heads_Dtym\";

            commonFemHeadList.Add(GetIm("LADY_Head_1710070901", VNPCPersType.ArtCG, "Dtym", path, "01a.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070901", new seIm() { X = -5, sX = 290 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070900", new seIm() { X = 60, Y = 55, sX = 270, Rot = 340, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710071002", new seIm() { X = 65, Y = 0, sX = 165, sY = 165, Rot = 325, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710071003", new seIm() { X = 270, Y = 5, sX = 260, sY = 260, Rot = 50, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710071004", new seIm() { X = 25, Y = 50, sX = 225, sY = 225, Rot = 50, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710071005", new seIm() { X = 95, Y = 65, sX = 265, sY = 265, Rot = 20, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710071006", new seIm() { X = 295, Y = 125, sX = 180, sY = 180, Rot = 45, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710071007", new seIm() { X = -35, Y = 85, sX = 345, sY = 345, Rot = 30, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710071008", new seIm() { X = 65, Y = 65, sX = 245, sY = 245, Rot = 24, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710071009", new seIm() { X = 215, Y = 70, sX = 225, sY = 225, Rot = 344, Flip = 1 }));


            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908a", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908b", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908c", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908d", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908e", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908f", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908g", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908h", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908j", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908k", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908l", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908m", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908n", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908o", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908p", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070908", new seIm() { X = 65, Y = 20, sX = 280, sY = 280, Rot = 405, Flip = 0 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070907", new seIm()  { X = 45, Y = 40, sX = 380, sY = 380, Rot = 315, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070907a", new seIm() { X = 45, Y = 40, sX = 380, sY = 380, Rot = 315, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070907b", new seIm() { X = 45, Y = 40, sX = 380, sY = 380, Rot = 315, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070907c", new seIm() { X = 45, Y = 40, sX = 380, sY = 380, Rot = 315, Flip = 1 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070901", "LADY_Body_1710070907d", new seIm() { X = 45, Y = 40, sX = 380, sY = 380, Rot = 315, Flip = 1 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710070902", VNPCPersType.ArtCG, "Dtym", path, "02.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070902", "LADY_Body_1710070902", new seIm() { X = 110, sX = 260 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070902", "LADY_Body_1710070901", new seIm() { X = 70, sX = 180 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710070903", VNPCPersType.ArtCG, "Dtym", path, "03.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070903", "LADY_Body_1710070903", new seIm() { X = 105, sX = 205 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070903", "LADY_Body_1710070900", new seIm() { X = 70, Y = 30, sX = 200, Rot=25 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710070904", VNPCPersType.ArtCG, "Dtym", path, "04.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070904", "LADY_Body_1710070904", new seIm() { X = 125, Y = 110, sX = 250 , sY = 250 }));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070904", "LADY_Body_1710070900", new seIm() { X = 70, Y = 20, sX = 210, sY= 210 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710070905", VNPCPersType.ArtCG, "Dtym", path, "05.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070905", "LADY_Body_1710070905", new seIm() { X = 80, Y = 0, sX = 355, sY = 355 }));

            commonFemHeadList.Add(GetIm("LADY_Head_1710070906", VNPCPersType.ArtCG, "Dtym", path, "06.png"));
            HeadToBodyAlignList.Add(new AlignData("LADY_Head_1710070906", "LADY_Body_1710070906", new seIm() { X = -5, Y = 10, sX = 220, sY = 220 }));



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
