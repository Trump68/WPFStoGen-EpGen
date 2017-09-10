using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.SOUND
{

    public static class SoundStore
    {        
        static string ROOT = @"CadreSound=d:\Process2\!STOGEN\!SOUND\";
        public static string MUSIC_SAD_01 = "MUSIC_SAD_01";
        public static string MUSIC_SAD_02 = "MUSIC_SAD_02";
        public static string MUSIC_ROMANTIC_01 = "MUSIC_ROMANTIC_01";
        public static string MUSIC_DISTURBING_01 = "MUSIC_DISTURBING_01";

        public static string ASMR_BellaBrookz_Girlfriend_Roleplay_01 = "ASMR_BellaBrookz_Girlfriend_Roleplay_01";
        public static string ASMR_BellaBrookz_Girlfriend_Roleplay_02 = "ASMR_BellaBrookz_Girlfriend_Roleplay_02";
        public static string ASMR_BellaBrookz_Girlfriend_Roleplay_03 = "ASMR_BellaBrookz_Girlfriend_Roleplay_03";

        public static string ORGAZM_Hysterical_Literature12_Fette = "ORGAZM_Hysterical_Literature12_Fette";
        public static string ORGAZM_Hysterical_Literature11_Toni = "ORGAZM_Hysterical_Literature11_Toni";
        public static string ORGAZM_Hysterical_Literature10_Janet = "ORGAZM_Hysterical_Literature10_Janet";
        public static string ORGAZM_Hysterical_Literature09_Marne = "ORGAZM_Hysterical_Literature09_Marne";
        public static string ORGAZM_Hysterical_Literature06_Sole = "ORGAZM_Hysterical_Literature06_Sole";
        public static string ORGAZM_Hysterical_Literature05_Teresa = "ORGAZM_Hysterical_Literature05_Teresa";
        public static string ORGAZM_Hysterical_Literature03_Danielle = "ORGAZM_Hysterical_Literature03_Danielle";
        public static string ORGAZM_Hysterical_Literature02_Alicia = "ORGAZM_Hysterical_Literature02_Alicia";

        public static List<SoundVariable> Items = new List<SoundVariable>();
        public static string ValByName(string name)
        {
            return ROOT + Items.Where(x => x.Name == name).FirstOrDefault()?.Value;
        }
        static SoundStore()
        {
            Items.Add(new SoundVariable(MUSIC_SAD_01,                      null, @"MUSIC\SAD\Sadness-01.mp3",          null));
            Items.Add(new SoundVariable(MUSIC_SAD_02,                      null, @"MUSIC\SAD\Sadness-02.mp3",          null));
            Items.Add(new SoundVariable(MUSIC_ROMANTIC_01,                 null, @"MUSIC\ROMANTIC\Romantic-01.mp3",    null));
            Items.Add(new SoundVariable(MUSIC_DISTURBING_01,               null, @"MUSIC\DISTURBING\File0004.mp3", null));
            Items.Add(new SoundVariable(ASMR_BellaBrookz_Girlfriend_Roleplay_01, null, @"ASMR\[ASMR] BellaBrookz Girlfriend Roleplay 01.mp3", null));
            Items.Add(new SoundVariable(ASMR_BellaBrookz_Girlfriend_Roleplay_02, null, @"ASMR\[ASMR] BellaBrookz Girlfriend Roleplay 02.mp3", null));
            Items.Add(new SoundVariable(ASMR_BellaBrookz_Girlfriend_Roleplay_03, null, @"ASMR\[ASMR] BellaBrookz Girlfriend Roleplay 03.mp3", null));

            Items.Add(new SoundVariable(ORGAZM_Hysterical_Literature12_Fette, null, @"LITERATURE_ORGAZM\Hysterical Literature Session Twelve Fette 02.mp3", null));
            Items.Add(new SoundVariable(ORGAZM_Hysterical_Literature11_Toni, null, @"LITERATURE_ORGAZM\Hysterical Literature Session Eleven Toni (Official) 02.mp3", null));
            Items.Add(new SoundVariable(ORGAZM_Hysterical_Literature10_Janet, null, @"LITERATURE_ORGAZM\Hysterical Literature Session Ten Janet 02.mp3", null));
            Items.Add(new SoundVariable(ORGAZM_Hysterical_Literature09_Marne, null, @"LITERATURE_ORGAZM\Hysterical Literature Session Nine Marne 02.mp3", null));
            Items.Add(new SoundVariable(ORGAZM_Hysterical_Literature06_Sole, null, @"LITERATURE_ORGAZM\Hysterical Literature Session Six Solé 02.mp3", null));
            Items.Add(new SoundVariable(ORGAZM_Hysterical_Literature05_Teresa, null, @"LITERATURE_ORGAZM\Hysterical Literature Session Five Teresa 02.mp3", null));
            Items.Add(new SoundVariable(ORGAZM_Hysterical_Literature03_Danielle, null, @"LITERATURE_ORGAZM\Hysterical Literature Session Three Danielle (Official) 02.mp3", null));
            Items.Add(new SoundVariable(ORGAZM_Hysterical_Literature02_Alicia, null, @"LITERATURE_ORGAZM\Hysterical Literature Session Two Alicia (Official) 02.mp3", null));

        }
    }

    public class SoundVariable
    {
        public string Name;
        public string Part;
        public string Description;
        public string Value;
        public SoundVariable(string name, string part, string val, string desc)
        {
            Name = name;
            Part = part;
            Description = desc;
            Value = val;
        }
    }
}
