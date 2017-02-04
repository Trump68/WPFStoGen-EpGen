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
    public static class SoundHelper
    {
        public static string MAKER_SOUND_WISPER_MIX_01 = "MAKER_SOUND_WISPER_MIX_01";
        public static string MAKER_SOUND_SMALL_KISS_01 = "MAKER_SOUND_SMALL_KISS_01";

        public static string MAKER_MAN_TALK_UGOVOR_01 = "MAKER_MAN_TALK_UGOVOR_01";
        public static string MAKER_MAN_TALK_WHILE_GET_SUCKED_01 = "MAKER_MAN_TALK_WHILE_GET_SUCKED_01";

        public static string MAKER_NOIZE_01 = "MAKER_NOIZE_01";

        private static Dictionary<string, List<string>> Pathlist = new Dictionary<string, List<string>>();
        static SoundHelper()
        {
            Pathlist.Add(MAKER_SOUND_WISPER_MIX_01, new List<string>());
            for (int i = 1; i <= 61; i++) Pathlist[MAKER_SOUND_WISPER_MIX_01].Add(String.Format(@"d:\Process2\!Sound\Wisper\WisperEng 01\WisperEngPart{0,2:D2}.mp3", i));

            Pathlist.Add(MAKER_SOUND_SMALL_KISS_01, new List<string>());
            for (int i = 1; i <= 4; i++) Pathlist[MAKER_SOUND_SMALL_KISS_01].Add(String.Format(@"d:\Process2\!Sound\Wisper\SmallKiss 01\SmallKiss{0,2:D2}.mp3", i));

            Pathlist.Add(MAKER_MAN_TALK_UGOVOR_01, new List<string>());
            for (int i = 1; i <= 13; i++) Pathlist[MAKER_MAN_TALK_UGOVOR_01].Add(String.Format(@"d:\Process2\!Sound\ManTalk\Ugovor01\Ugovor{0,3:D3}.mp3", i));
            Pathlist.Add(MAKER_MAN_TALK_WHILE_GET_SUCKED_01, new List<string>());
            for (int i = 1; i <= 1; i++) Pathlist[MAKER_MAN_TALK_WHILE_GET_SUCKED_01].Add(String.Format(@"d:\Process2\!Sound\ManTalk\WhileSuck01\WhileSuck{0,3:D3}.mp3", i));

            Pathlist.Add(MAKER_NOIZE_01, new List<string>());
            for (int i = 1; i <= 1; i++) Pathlist[MAKER_NOIZE_01].Add(String.Format(@"d:\Process2\!Sound\Noize\Noize{0,3:D3}.mp3", i));

        }
        public static void SoundChange(List<Cadre> list, int position, string name, params object[] args)
        {
            foreach (Cadre cadre in list) SoundChange(cadre, position, name, args);
        }


        public static void SoundChange(Cadre cadre, int position, string name, params object[] args)
        {
            if (cadre.SoundFrameData == null) cadre.SoundFrameData = new List<SoundItem>();
            for (int i = 0; i < cadre.SoundFrameData.Count; i++)
            {
                SoundItem item = cadre.SoundFrameData[i];
                if (item.Position == position) { cadre.SoundFrameData.Remove(item); i--; }
            }
            SoundItem mi = new SoundItem();            
            mi.Position = position;
            List<string> content = Pathlist[name];
            if (content.Count > 1)
            {
                mi.List = new List<SoundItem>();
                foreach (string item in content)
                {
                    SoundItem si = new SoundItem();
                    si.Name = name;
                    si.FileName = item;
                    si.isLoop = false;
                    if (args != null && args.Length > 0) si.Silence = (int)args[0];
                    if (args != null && args.Length > 1) si.Volume = (int)args[1];
                    mi.List.Add(si);

                }
            }
            else 
            {
                mi.FileName = content[0];
                mi.Name = name;
                mi.isLoop = true;
                if (args != null && args.Length > 0) mi.Silence = (int)args[0];
                if (args != null && args.Length > 1) mi.Volume = (int)args[1];
            }
            cadre.SoundFrameData.Add(mi);
        }
    }
}
