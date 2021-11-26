using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story
{
    public class CadreSound
    {
        public CadreSound(StoryMaker story)
        {
            FillBGM();
            FillSoundEffest();
            Story = story;
        }
        StoryMaker Story;
        public string CurrentBGM;
        public string CurrentSE;
        public int BGM_Volume = 100;
        public int SE_Volume = 100;


        //BGM
        List<Tuple<string, string, string>> bgmlist = new List<Tuple<string, string, string>>();
        string bgmroot = @"e:\!EPCATALOG\SOUND\BGM\";
        private void FillBGM()
        {
            string catalog = "NTRPG2";
            bgmlist.Add(new Tuple<string, string, string>("1", catalog, @"0001-ayaturi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("2", catalog, @"0002-tumugi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("3", catalog, @"0003-13_kumorizora.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("4", catalog, @"0004-18_huann.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("5", catalog, @"0005-19_zaiakukan.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("6", catalog, @"0006-komari.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("7", catalog, @"0007-fanfare.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("8", catalog, @"0007-gray.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("9", catalog, @"0007-onaji.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("10", catalog, @"0008-chinkou.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("11", catalog, @"0009-15_zawameki.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("12", catalog, @"0009-under.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("13", catalog, @"0011-akumu.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("14", catalog, @"0012-maturi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("15", catalog, @"0012-tirihana.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("16", catalog, @"0014-kanashimi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("17", catalog, @"0017-MREND_dbs_lune_pi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("18", catalog, @"0018-bukikobo.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("19", catalog, @"0021-yumeno.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("20", catalog, @"0024-skytosi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("21", catalog, @"0027-doukutu.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("22", catalog, @"0028-yamidoukutu.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("23", catalog, @"0029-lamp.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("24", catalog, @"0038-20_kagekara.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("25", catalog, @"0050-senran.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("26", catalog, @"asa_mori01.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("27", catalog, @"asa2_0007-guild.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("28", catalog, @"dark.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("29", catalog, @"debu.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("30", catalog, @"firia1_ameuta.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("31", catalog, @"hiru_boukennojunbi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("32", catalog, @"hiru2_0025-rest.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("33", catalog, @"hiru2_0025-rest.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("34", catalog, @"kaisou_0003-cpn_etd10_3_pi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("35", catalog, @"madoromi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("36", catalog, @"op_sti_gymno_01_pi.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("37", catalog, @"or_madono.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("38", catalog, @"piza_0004-wev_karyudo_ok.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("39", catalog, @"pon_tokinoodori_or.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("40", catalog, @"pon_tokinoodori_or_ENDING.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("41", catalog, @"sakaba01_rosa.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("42", catalog, @"syugosya.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("43", catalog, @"yoru_kaisou.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("44", catalog, @"yoru2_0020-yosagiri.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("45", catalog, @"yugata_slowlife.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("46", catalog, @"yugata2_0014-vil.mp3"));

            catalog = "Healing";
            bgmlist.Add(new Tuple<string, string, string>("To the earth someday", catalog, @"To_the_earth_someday.mp3"));
            bgmlist.Add(new Tuple<string, string, string>("After School 1", catalog, @"After School.ogg"));
            bgmlist.Add(new Tuple<string, string, string>("ogg00054", catalog, @"ogg00054.ogg"));
            catalog = "Active";
            bgmlist.Add(new Tuple<string, string, string>("ogg00052", catalog, @"ogg00052.ogg"));
            catalog = "Saspence";
            bgmlist.Add(new Tuple<string, string, string>("Runned into it", catalog, @"Runned into it.ogg"));
            bgmlist.Add(new Tuple<string, string, string>("In the Barn", catalog, @"in the barn.ogg"));
            

        }
        protected virtual string GetFileBGM(string name)
        {
            if (name == "STOP") return name;
            var val = bgmlist.Where(x => (x.Item1 == name) || (x.Item2 == name)).FirstOrDefault();
            if (val == null) return null;
            return Path.Combine(bgmroot, val.Item2, val.Item3);
        }
        private string GetBGM(string name, string transform, bool randomstart, bool muted, bool runAtOnce)
        {
            string cadre = Story.GetCadreNum();
            string random_start_str = randomstart ? "F=1;" : string.Empty;
            string muted_str = muted ? "Y=1;" : string.Empty;
            string transform_str = (transform is null) ? null : $"T={transform};";
            string run_str = !runAtOnce ? $"R=1;" : null;
            return $"GROUP={cadre};KIND=6;A=1;{muted_str}{random_start_str}{transform_str}{run_str}DSC={Story.Chapter};ORD=1;FILE={GetFileBGM(name)}";
        }

        //Sound Effect
        List<Tuple<string, string, string>> seffectlist = new List<Tuple<string, string, string>>();
        string seffectroot = @"e:\!EPCATALOG\SOUND\EFFECT\";
        private void FillSoundEffest()
        {
            string catalog = "Other";
            seffectlist.Add(new Tuple<string, string, string>("Wear moving 1", catalog, @"Wear moving 1.ogg"));
            seffectlist.Add(new Tuple<string, string, string>("Door ring 1", catalog, @"door ring 1.ogg"));
            seffectlist.Add(new Tuple<string, string, string>("Вжик 1", catalog, @"Вжик.ogg"));
            seffectlist.Add(new Tuple<string, string, string>("Бум 1", catalog, @"Бум 1.ogg"));
            seffectlist.Add(new Tuple<string, string, string>("Бег 1", catalog, @"Бег 1.ogg"));
            seffectlist.Add(new Tuple<string, string, string>("Бег 2", catalog, @"Бег 2.ogg"));
            seffectlist.Add(new Tuple<string, string, string>("шаги в лесу 1", catalog, @"шаги в лесу 1.ogg"));            
        }
        private string GetFileSEffect(string name)
        {
            var val = seffectlist.Where(x => (x.Item1 == name) || (x.Item2 == name)).FirstOrDefault();
            if (val == null) return null;
            return Path.Combine(seffectroot, val.Item2, val.Item3);
        }
        private string GetSoundEffect(string name, int loop, string transform, bool randomstart, bool muted, bool runAtOnce)
        {
            string cadre = Story.GetCadreNum();
            string random_start_str = randomstart ? "F=1;" : string.Empty;
            string muted_str = muted ? "Y=1;" : string.Empty;
            string transform_str = (transform is null) ? null : $"T={transform};";
            string run_str = !runAtOnce ? $"R=1;" : null;
            return $"GROUP={cadre};KIND=6;A=1;{muted_str}{random_start_str}{transform_str}{run_str}DSC ={Story.Chapter};ORD=1;LoopMode={loop};FILE={GetFileSEffect(name)}";
        }
        protected virtual string GetMoan(string name)
        {
            string basecatalog = @"e:\!EPCATALOG\SOUND\MOAN\";
            List<Tuple<string, string>> bgmlist = new List<Tuple<string, string>>();
            bgmlist.Add(new Tuple<string, string>("1", @"2018 Silena Moor - Fuck 01.mp3"));
            bgmlist.Add(new Tuple<string, string>("2", @"2018 Silena Moor - Fuck 01 PS adjusted.mp3"));
            bgmlist.Add(new Tuple<string, string>("3", @"2018 Silena Moor - Fuck 02.mp3"));
            bgmlist.Add(new Tuple<string, string>("4", @"2018 Silena Moor - Fuck 02 PS adjusted.mp3"));
            bgmlist.Add(new Tuple<string, string>("5", @"2018 Silena Moor - Fuck 03.mp3"));
            bgmlist.Add(new Tuple<string, string>("6", @"2018 Silena Moor - Fuck 03 PS adjusted.mp3"));
            bgmlist.Add(new Tuple<string, string>("7", @"2018 Silena Moor - Fuck 04.mp3"));
            bgmlist.Add(new Tuple<string, string>("8", @"2018 Silena Moor - Fuck 04 PS adjusted.mp3"));
            bgmlist.Add(new Tuple<string, string>("9", @"2018 Silena Moor - Fuck 05.mp3"));
            bgmlist.Add(new Tuple<string, string>("10", @"2018 Silena Moor - Fuck 05 PS adjusted.mp3"));
            bgmlist.Add(new Tuple<string, string>("11", @"old-n-young.com-Pelmen-Anya_01.mp3"));
            bgmlist.Add(new Tuple<string, string>("12", @"old-n-young.com-Pelmen-Anya_02.mp3"));
            bgmlist.Add(new Tuple<string, string>("13", @"old-n-young.com-Pelmen-Anya_03.mp3"));
            bgmlist.Add(new Tuple<string, string>("14", @"old-n-young.com-Pelmen-Anya_04.mp3"));
            bgmlist.Add(new Tuple<string, string>("15", @"old-n-young.com-Pelmen-Anya_05.mp3"));
            bgmlist.Add(new Tuple<string, string>("16", @"old-n-young.com-Pelmen-Anya_06.mp3"));
            bgmlist.Add(new Tuple<string, string>("17", @"old-n-young.com-Pelmen-Anya_07_suck.mp3"));
            bgmlist.Add(new Tuple<string, string>("18", @"old-n-young.com-Pelmen-Anya_08.mp3"));
            bgmlist.Add(new Tuple<string, string>("19", @"old-n-young.com-Pelmen-Natasha_01_suck.mp3"));
            bgmlist.Add(new Tuple<string, string>("20", @"old-n-young.com-Pelmen-Natasha_02.mp3"));
            bgmlist.Add(new Tuple<string, string>("21", @"old-n-young.com-Pelmen-Natasha_03_suck.mp3"));
            bgmlist.Add(new Tuple<string, string>("22", @"old-n-young.com-Pelmen-Natasha_04.mp3"));
            bgmlist.Add(new Tuple<string, string>("23", @"old-n-young.com-Pelmen-Natasha_05.mp3"));
            bgmlist.Add(new Tuple<string, string>("24", @"old-n-young.com-Pelmen-Natasha_06.mp3"));
            bgmlist.Add(new Tuple<string, string>("25", @"old-n-young.com-Pelmen-Natasha_07.mp3"));
            bgmlist.Add(new Tuple<string, string>("26", @"old-n-young.com-Pelmen-Natasha_08.mp3"));
            bgmlist.Add(new Tuple<string, string>("27", @"old-n-young.com-Pelmen-Natasha_09_suck.mp3"));
            bgmlist.Add(new Tuple<string, string>("28", @"old-n-young.com-Pelmen-Sasha_01.mp3"));
            bgmlist.Add(new Tuple<string, string>("29", @"old-n-young.com-Pelmen-Sasha_02.mp3"));

            var val = bgmlist.Where(x => (x.Item1 == name) || (x.Item2 == name)).FirstOrDefault();
            if (val == null) return null;
            return Path.Combine(basecatalog, val.Item2);
        }


        public void BgmMuted(string transform)
        {
            Story.Scenario.Add(GetBGM(CurrentBGM, transform, false, false, false));
        }
        public void Bgm()
        {
            Story.Scenario.Add(GetBGM(CurrentBGM, null, false, false, true));
        }
        public void BgmStop()
        {
            Story.Scenario.Add(GetBGM(CurrentBGM, null, false, true, false));
        }

        public void SE()
        {
            Story.Scenario.Add(GetSoundEffect(CurrentSE, 0, null, false, false, true));
        }
        public void SELoop()
        {
            Story.Scenario.Add(GetSoundEffect(CurrentSE, 1, null, false, false, true));
        }
        public void SEMuted(string transform)
        {
            Story.Scenario.Add(GetSoundEffect(CurrentSE, 0, transform, false, false, false));
        }
        public void SEStop()
        {
            Story.Scenario.Add(GetSoundEffect(CurrentSE, 0, null, false, true, true));
        }
        // old
        public string oldSE()
        {
            return GetSoundEffect(CurrentSE, 0, null, false, false, true);
        }
        public string oldSE(int loop)
        {
            return GetSoundEffect(CurrentSE, loop, null, false, false, true);
        }
        public string oldSEStop()
        {
            return GetSoundEffect(CurrentSE, 0, null, false, true, true);
        }
        public string oldSEMuted(string transform)
        {
            return GetSoundEffect(CurrentSE, 0, transform, false, false, false);
        }
        public string oldBgmMuted(string transform)
        {
            return GetBGM(CurrentBGM, transform, false, false, false);
        }
        public string oldBgm()
        {
            return GetBGM(CurrentBGM, null, false, false, true);
        }
        public string oldBgmStop()
        {
            return GetBGM(CurrentBGM, null, false, true, false);
        }
    }
}
