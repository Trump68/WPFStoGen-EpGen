using System.Collections.Generic;
using System.Linq;
using StoGen.Classes;
using StoGen.ModelClasses;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections;

namespace StoGen.Classes
{
    public static class BackgroundHelper
    {
        static string MAKER_NIGHT = "MAKER_NIGHT";
        public static string MAKER_VIEWER_VIA_DOOR_01 = "MAKER_VIEWER_VIA_DOOR_01";

        public static string MAKER_PARK_EVENING_01 = "MAKER_PARK_EVENING_01";
        public static string MAKER_PARK_EVENING_02 = "MAKER_PARK_EVENING_02";
        public static string MAKER_VICTORIAN_ROOM_01_DAY = "MAKER_VICTORIAN_ROOM_01_DAY";
        public static string MAKER_VICTORIAN_ROOM_01_DAY2 = "MAKER_VICTORIAN_ROOM_01_DAY2";
        public static string MAKER_VICTORIAN_ROOM_01_EVENING = "MAKER_VICTORIAN_ROOM_01_EVENING";

        public static string MAKER_BAD_MAN_001_A = "MAKER_BAD_MAN_001_A";

        private static Dictionary<string, string> Pathlist = new Dictionary<string, string>();
        static BackgroundHelper()
        {
            Pathlist.Add(MAKER_NIGHT, @"D:\Process2\!Background\Effects\Dark002.png");
            Pathlist.Add(MAKER_VIEWER_VIA_DOOR_01, @"D:\Process2\!Background\Effects\OpenDoor002.png");

            Pathlist.Add(MAKER_PARK_EVENING_01, @"D:\Process2\!Background\Park\bg15a_0_0_1024_768.jpg");
            Pathlist.Add(MAKER_PARK_EVENING_02, @"D:\Process2\!Background\Park\bg20a_0_0_1024_768.jpg");
            Pathlist.Add(MAKER_VICTORIAN_ROOM_01_DAY, @"D:\Process2\!Background\Flat\001\bg09.jpg");
            Pathlist.Add(MAKER_VICTORIAN_ROOM_01_DAY2, @"D:\Process2\!Background\Flat\001\bg09a.jpg");
            Pathlist.Add(MAKER_VICTORIAN_ROOM_01_EVENING, @"D:\Process2\!Background\Flat\001\bg09b.jpg");

            Pathlist.Add(MAKER_BAD_MAN_001_A, @"D:\Process2\Hentai\![Soft Circle Courreges]\[Soft Circle Courreges] Tsuma Jiru ～Shibori Tsukushite A・Ge・Ru～\!Badman\__009.png");
        }


        //public static void NightChange(List<Cadre> list)
        //{
        //    foreach (Cadre cadre in list) NightChange(cadre);
        //}
        //public static void NightChange(Cadre cadre)
        //{
        //    CadreData cd = CadreData.GetByName(MAKER_NIGHT, cadre.PicFrameData);
        //    if (cd != null) NightRemove(cadre);
        //    else NightAdd(cadre);
        //}
        public static void NightAdd(List<Cadre> list)
        {
            foreach (Cadre cadre in list) NightAdd(cadre);
        }
        public static PictureSourceDataProps NightAdd(Cadre cadre)
        {
            PictureSourceDataProps psp = ItemAdd(cadre,MAKER_NIGHT);
            psp.BackColor = Color.Transparent;
            psp.Level = PicLevel.OnActor2;
            psp.SizeX = 800;
            psp.SizeY = 600;
            psp.Opacity = 90;
            return psp;
        }
        public static void NightRemove(List<Cadre> list)
        {
            foreach (Cadre cadre in list) NightRemove(cadre);
        }
        public static void NightRemove(Cadre cadre)
        {
            ItemRemove(cadre, MAKER_NIGHT);   
        }

        public static void Actor2AddRemove(List<Cadre> list, string name, params object[] args)
        {
            foreach (Cadre cadre in list) Actor2AddRemove(cadre, name, args);
        }
        public static void Actor2AddRemove(Cadre cadre, string name, params object[] args)
        {
            //PictureSourceData cadre.PicFrameData.GetByName(name);
            PictureSourceDataProps result = cadre.PicFrameData.PictureDataList.FirstOrDefault(data => data.Name == name);
            if (result != null) ItemRemove(cadre, name);
            else Actor2Add(cadre, name, args);
        }
        public static void Actor2Add(List<Cadre> list, string name, params object[] args)
        {
            foreach (Cadre cadre in list) Actor2Add(cadre, name, args);
        }
        public static PictureSourceDataProps Actor2Add(Cadre cadre, string name, params object[] args)
        {
            return ActorAdd(PicLevel.Actor2, cadre, name, args);
        }


        public static PictureSourceDataProps Actor1AddRemove(Cadre cadre, string name, params object[] args)
        {
            PictureSourceDataProps result = cadre.PicFrameData.PictureDataList.FirstOrDefault(data => data.Name == name);
            if (result != null) ItemRemove(cadre, name);
            else return Actor1Add(cadre, name, args);
            return null;
        }
        public static void Actor1Add(List<Cadre> list, string name, params object[] args)
        {
            foreach (Cadre cadre in list) Actor1Add(cadre, name, args);
        }
        public static PictureSourceDataProps Actor1Add(Cadre cadre, string name, params object[] args)
        {
            return ActorAdd(PicLevel.Actor1, cadre, name, args);
        }

        public static PictureSourceDataProps ActorAdd(PicLevel level,Cadre cadre, string name, params object[] args)
        {
            PictureSourceDataProps psp = ItemAdd(cadre, name);
            psp.BackColor = Color.Transparent;
            psp.Level = level;
            psp.SizeX = 800;
            psp.SizeY = 600;
            if (args != null) psp.Flip = (RotateFlipType)args[0];
            return psp;
        }

        public static void BackgroundChange(List<Cadre> list, string name, params object[] args)
        {
            foreach (Cadre cadre in list) BackgroundChange(cadre, name, args);
        }
        public static PictureSourceDataProps BackgroundChange(Cadre cadre, string name, params object[] args)
        {
            foreach (PictureSourceDataProps pictureSourceDataProps in cadre.PicFrameData.PictureDataList)
            {
                if (pictureSourceDataProps.Level == PicLevel.Background)
                { cadre.PicFrameData.Remove(pictureSourceDataProps); break; }
            }
               

            PictureSourceDataProps psp = ItemAdd(cadre, name);
            psp.BackColor = Color.Transparent;
            psp.Level = PicLevel.Background;
            psp.SizeX = 800;
            psp.SizeY = 600;
            if (args != null && args.Length > 0) psp.Flip = (RotateFlipType)args[0];
            return psp;
        }

        private static PictureSourceDataProps ItemAdd(Cadre cadre,string name)
        {
            PictureSourceDataProps psp = cadre.PicFrameData.GetByName(name);
            if (psp == null) psp = cadre.PicFrameData.Add(name, Pathlist[name]);
            return psp;
        }
        public static void ItemRemove(List<Cadre> list, string name)
        {
            foreach (Cadre cadre in list) ItemRemove(cadre,name);
        }
        public static void ItemRemove(Cadre cadre,string name)
        {
            PictureSourceDataProps result = cadre.PicFrameData.GetByName(name);
            if (result != null) cadre.PicFrameData.Remove(result);
        }
    }
}
