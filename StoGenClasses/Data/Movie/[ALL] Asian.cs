using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Movie
{
    public class _ALL__Asian: BaseScene
    {
        public override bool LoadData(string loadFilter, string moviePath)
        {
            this.MoviePath = moviePath;
            PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
            string path = this.MoviePath;
            string src = null;
            string root = @"d:\Process2+\EroFilms\";



            // KOR_2013_Norigae - Mainstream , drama, bdsm, rape of actress   
            string filter = "KOR_2013_Norigae";
            AddToGlobalImage(filter, path); KOR_2013_Norigae(filter);

            // Ero romantic
            src = $"Lie I Love Sex.m4v";        path = $@"{root}2013\Lie I Love Sex\";
            AddToGlobalImage(src, src, path);
            KOR_2013_Lie_I_Love_Sex();
            // Ero romantic
            src = $"Taste.m4v";                 path = $@"{root}2013\Taste\";
            AddToGlobalImage(src, src, path);
            KOR_2013_Taste();
            // Ero romantic
            src = $"Love Match.m4v";            path = $@"{root}2014\Love Match\";
            AddToGlobalImage(src, src, path);
            KOR_2014_Love_Match();
            // Mainstream , war drama        
            src = $"Paradise In Service.m4v";   path = $@"{root}2014\Paradise In Service\";
            AddToGlobalImage(src, src, path);
            KOR_2014_Paradise_In_Service();
            // Ero Horror
            src = $"Spell.m4v";                 path = $@"{root}2014\Spell\";
            AddToGlobalImage(src, src, path);
            THA_2014_Spell();
            // Ero comedy
            src = $"7 Princess.m4v";            path = $@"{root}2015\7 Princess\";
            AddToGlobalImage(src, src, path);
            KOR_2015_7_Princess();
            // Ero drama (PART II) GRADE-6 COOL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            src = $"Female War – Lousy Deal.m4v"; path = $@"{root}2015\Female War – Lousy Deal\";
            AddToGlobalImage(src, src, path);
            KOR_2015_Female_War_Lousy_Deal();// PART II
            //Ero drama   GRADE-4
            src = $"Female Workers Romance At Work.m4v"; path = $@"{root}2015\Female Workers Romance At Work\";
            AddToGlobalImage(src, src, path);
            KOR_2015_Female_Workers_Romance_At_Work();
            //Ero drama
            src = $"Long Ping Ha Rak.m4v"; path = $@"{root}2015\Long Ping Ha Rak\";
            AddToGlobalImage(src, src, path);
            THA_2015_Long_Ping_Ha_Rak();
            //Ero mystic
            src = $"Mae Bia.m4v"; path = $@"{root}2015\Mae Bia\";
            AddToGlobalImage(src, src, path);
            THA_2015_Mae_Bia();
            //Ero drama
            src = $"My Friend's Wife Cast.m4v"; path = $@"{root}2015\My Friend's Wife Cast\";
            AddToGlobalImage(src, src, path);
            KOR_2015_My_Friends_Wife_Cast();
            //Ero comedy
            src = $"New Folder 2.m4v"; path = $@"{root}2015\New Folder 2\";
            AddToGlobalImage(src, src, path);
            KOR_2015_New_Folder_2();
            //Ero comedy
            src = $"No - soo Ram & Others - Bad Class.m4v"; path = $@"{root}2015\No-soo Ram & Others - Bad Class\";
            AddToGlobalImage(src, src, path);
            KOR_2015_No_soo_Ram_Others_Bad_Class();
            //Ero drama
            src = $"KOR_2016_Affair.m4v"; path = $@"{root}2016\[KOR] Affair\";
            AddToGlobalImage(src, src, path);
            KOR_2016_Affair(src);
            //Ero comedy
            src = $"KOR 2016 Additional Package.m4v"; path = $@"{root}2016\[KOR] Additional Package\";
            AddToGlobalImage(src, src, path);
            KOR_2016_Additional_Package(src);
            //Ero comedy
            src = $"KOR 2016 Angel Ladies.m4v"; path = $@"{root}2016\[KOR] Angel Ladies\";
            AddToGlobalImage(src, src, path);
            KOR_2016_Angel_Ladies(src);
            //Ero comedy
            src = $"KOR 2016 Comic Stories.m4v"; path = $@"{root}2016\[KOR] Comic Stories\";
            AddToGlobalImage(src, src, path);
            KOR_2016_Comic_Stories(src);
            // Ero Nikatsu drama
            src = $"JAP 1985 Beautiful Teacher Torture Hell.m4v"; path = $@"{root}1985\[JAP] Beautiful Teacher Torture Hell\";
            AddToGlobalImage(src, src, path);
            JAP_1985_Beautiful_Teacher_Torture_Hell(src);

            return true;
        }

        private void KOR_2016_Comic_Stories(string src)
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = src;
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };
            List<List<AP>> anims;
            int speed = 100;
            int volume = 100;
            st.VOLUME_M = 0;
            this.VOLUME_M = 0;

            anims = new List<List<AP>>() {
                new List<AP>() { // shower 
                new AP(src) { APS =800.7 , APE = 886.8, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck 
                new AP(src) { APS =3349.4 , APE = 3363.5, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck 
                new AP(src) { APS =3363.8 , APE = 3375.2, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck 
                new AP(src) { APS =3391.5 , APE = 3394.2, ALM = 9, ALC = 9 , AR=speed, AV=0},
                }}; st.VideoFrame800(anims, music);


            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2016_Angel_Ladies(string src)
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = src;
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };
            List<List<AP>> anims;
            int speed = 100;
            int volume = 100;
            st.VOLUME_M = 0;
            this.VOLUME_M = 0;

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck 
                new AP(src) { APS =800.7 , APE = 1284.3, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);


            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2016_Additional_Package(string src)
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = src;
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };
            List<List<AP>> anims;
            int speed = 100;
            int volume = 100;
            st.VOLUME_M = 0;
            this.VOLUME_M = 0;

            anims = new List<List<AP>>() {
                new List<AP>() { // grouping 
                new AP(src) { APS =2339.5 , APE = 2676.5, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);


            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2016_Affair(string src)
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = src;
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };
            List<List<AP>> anims;
            int speed = 100;
            int volume = 100;
            st.VOLUME_M = 0;
            this.VOLUME_M = 0;

            anims = new List<List<AP>>()
            {
                new List<AP>() { // wife looks in phone and masturbate  
                new AP(src) { APS = 329.9, APE = 401.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // some man fucks somebody in distant window, erotic moans 
                new AP(src) { APS = 1246.8, APE = 1255.5, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // some man fucks somebody in distant window, erotic moans 
                new AP(src) { APS = 1265.6, APE = 1273.3, ALM = 1, ALC = 9 , AR=speed, AV=volume},
                new AP(src) { APS = 1279.5, APE = 1290.4, ALM = 1, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // some man fucks somebody in distant window, erotic moans 
                new AP(src) { APS = 1294.3, APE = 1301.7, ALM = 1, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // wife masturbate outdoore at noght, erotic moans 
                new AP(src) { APS = 1301.8, APE = 1315.1, ALM = 1, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // some man fucks somebody in distant window, erotic moans 
                new AP(src) { APS = 1315.3, APE = 1334.3, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // wife masturbate outdoore at noght, erotic moans 
                new AP(src) { APS = 1334.6, APE = 1346.8, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // wife masturbate outdoore at noght, erotic moans 
                new AP(src) { APS = 2525.4, APE = 2555.4, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // erotic massage whole scene !!!!!
                new AP(src) { APS = 1809.0, APE = 2172.9, ALM = 1, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // wife shower fuck 'rakom'
                new AP(src) { APS = 3215.8, APE = 3315.6, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // wife shower fuck 'standing' 
                new AP(src) { APS = 3315.9, APE = 3406.1, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // grouping
                new AP(src) { APS = 3526.2, APE = 3539.6, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck
                new AP(src) { APS = 3679.6, APE = 3690.7, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck
                new AP(src) { APS = 3738.9, APE = 3757.2, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck
                new AP(src) { APS =3757.4 , APE = 3775.3, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck !!!
                new AP(src) { APS =3775.5 , APE = 3789.4, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck !!!
                new AP(src) { APS =3789.6 , APE = 3796.2, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck !!!
                new AP(src) { APS =3796.4 , APE = 3826.6, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>() {
                new List<AP>() { // fuck 
                new AP(src) { APS =4470.1 , APE = 4553.2, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }}; st.VideoFrame800(anims, music);


            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void JAP_1985_Beautiful_Teacher_Torture_Hell(string src)
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = src;
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };
            List<List<AP>> anims;
            int speed = 100;
            int volume = 0;

            anims = new List<List<AP>>()
            {
                new List<AP>() {     // assault teacher
                new AP(src) { APS = 179.2, APE = 198.1, ALM = 3, ALC = 3 , AR=speed, AV=volume},                
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {  //assault teacher
                new AP(src) { APS =221.7, APE = 229.5, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//assault teacher
                new AP(src) { APS = 268.0, APE =280.1 , ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//assault teacher
                new AP(src) { APS = 280.4, APE = 304.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {
                new AP(src) { APS = 770.1, APE = 852.2, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 904.0, APE = 907.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 910.4, APE = 917.6, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 948.8, APE = 985.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 985.9, APE = 990.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 990.7, APE = 1000.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 1005.2, APE = 1018.5, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 1018.7, APE = 1022.6, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 1026.6, APE = 1032.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 1032.7, APE = 1041.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2307.3, APE = 2314.0, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2320.8, APE = 2323.6, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {// evil man
                new AP(src) { APS = 2344.6, APE = 2346.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                new AP(src) { APS = 2418.8, APE = 2421.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                new AP(src) { APS = 2432.2, APE = 2436.3, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                new AP(src) { APS = 2441.3, APE = 2452.4, ALM = 1, ALC = 3 , AR=speed, AV=volume},
                new AP(src) { APS = 2773.9, APE = 2780.8, ALM = 1, ALC = 3 , AR=speed, AV=volume},
                new AP(src) { APS = 3294.7, APE = 3297.3, ALM = 1, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//force bj teacher
                new AP(src) { APS = 2436.5, APE = 2441.1, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                new AP(src) { APS = 2361.3, APE = 2377.1, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                new AP(src) { APS = 2377.4, APE = 2383.5, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                new AP(src) { APS = 2383.7, APE = 2386.6, ALM = 1, ALC = 3 , AR=speed, AV=volume},//evil
                new AP(src) { APS = 2386.8, APE = 2389.6, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                new AP(src) { APS = 2389.8, APE = 2392.6, ALM = 1, ALC = 3 , AR=speed, AV=volume},//evil
                new AP(src) { APS = 2392.8, APE = 2404.5, ALM = 1, ALC = 3 , AR=speed, AV=volume},
                new AP(src) { APS = 2404.5, APE = 2418.6, ALM = 7, ALC = 3 , AR=speed, AV=volume},
                new AP(src) { APS = 2421.6, APE = 2426.1, ALM = 7, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            #region Torture
            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2462.1, APE = 2484.4, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2484.6, APE = 2527.4, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2527.6, APE = 2537.9, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2538.1, APE = 2562.0, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2562.2, APE = 2580.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2582.9, APE = 2617.8, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2618.1, APE = 2649.0, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2649.1, APE = 2687.1, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2687.3, APE = 2758.3, ALM = 1, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 2782.1, APE = 2820.2, ALM = 1, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 3076.8, APE = 3100.4, ALM = 1, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 3108.4, APE = 3151.4, ALM = 1, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 3177.8, APE = 3184.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 3198.4, APE = 3212.8, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() {//torture teacher
                new AP(src) { APS = 3198.4, APE = 3212.8, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);
            #endregion

            anims = new List<List<AP>>()
            {
                new List<AP>() {//long scene with bdsm fuck
                new AP(src) { APS = 2320.8, APE = 3933.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }

        private void KOR_2013_Norigae(string filter)
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = filter;
            int speed = 100;
            List<AP> anims = new List<AP>()
            {                
                 new AP("Norigae.m4v") { APS = 1387, APE = 1423.3, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Norigae.m4v") { APS = 1848, APE = 1862.1, ALM = 3, ALC = 6 , AR=speed}, //fuck
                 new AP("Norigae.m4v") { APS = 1966.6, APE = 1969.3, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Norigae.m4v") { APS = 1972.9, APE = 1976.7, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Norigae.m4v") { APS = 2474.1, APE = 2480.1, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Norigae.m4v") { APS = 2688.9, APE = 2701.3, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Norigae.m4v") { APS = 2719.9, APE = 2743.5, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Norigae.m4v") { APS = 3276, APE = 3289.9, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Norigae.m4v") { APS = 3309, APE = 3315.1, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Norigae.m4v") { APS = 3320.1, APE = 3415, ALM = 3, ALC = 6 , AR=speed}, //fuck
                 new AP("Norigae.m4v") { APS = 4081.7, APE = 4166.2, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Norigae.m4v") { APS = 4174.3, APE = 4224, ALM = 3, ALC = 6 , AR=speed},
                 new AP("Norigae.m4v") { APS = 4266.6, APE = 4313.6, ALM = 3, ALC = 6 , AR=speed},//fuck!!!
                 new AP("Norigae.m4v") { APS = 4567, APE = 4639, ALM = 3, ALC = 6 , AR=speed},
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2013_Lie_I_Love_Sex()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "Lie I Love Sex.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                 new AP("Lie I Love Sex.m4v") { APS = 1421.7, APE = 1462.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 2433.5, APE = 2455.4, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 2455.7, APE = 2510.3, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 2510.6, APE = 2541.5, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 2818.8, APE = 2855.6, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 3133.8, APE = 3147.4, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 3164.4, APE = 3169.4, ALM = 3, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 3186, APE = 3207, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 3207.3, APE = 3242.4, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 3242.7, APE = 3320.9, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 3583.4, APE = 3594.1, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 3594.4, APE = 3596.1, ALM = 3, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 3596.3, APE = 3609.7, ALM = 3, ALC = 6 , AR=speed, AV = volume},
                 new AP("Lie I Love Sex.m4v") { APS = 3610, APE = 3659.5, ALM = 3, ALC = 6 , AR=speed, AV = volume},
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2013_Taste()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "Taste.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP("Taste.m4v") { APS = 1.1, APE = 39.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP("Taste.m4v") { APS = 1749.3, APE = 1791.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP("Taste.m4v") { APS = 2028.8, APE = 2038.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP("Taste.m4v") { APS = 2815.1, APE = 2829.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP("Taste.m4v") { APS = 2831, APE = 2868.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP("Taste.m4v") { APS = 3191.9, APE =3111.1 , ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP("Taste.m4v") { APS = 3966.1, APE = 4048.2, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP("Taste.m4v") { APS = 4048.4, APE = 4059.6, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP("Taste.m4v") { APS = 4722.2, APE = 4736.5, ALM = 1, ALC = 6 , AR=speed, AV = volume},
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2014_Love_Match()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "Love Match.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP("Love Match.m4v") { APS = 4991.9, APE = 5073.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2014_Paradise_In_Service()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "Paradise In Service.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP("Paradise In Service.m4v") { APS = 1515.7, APE = 1528, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP("Paradise In Service.m4v") { APS = 6860.1, APE = 6879, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP("Paradise In Service.m4v") { APS = 7157.2, APE = 7170, ALM = 1, ALC = 6 , AR=speed, AV = volume},
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void THA_2014_Spell()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "Spell.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP(st.currentGr) { APS = 680.5, APE = 728, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 3340, APE = 3422, ALM = 1, ALC = 6 , AR=speed, AV = volume},
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2015_7_Princess()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "7 Princess.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP(st.currentGr) { APS = 409.4, APE = 457.1, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 2669.1, APE = 2692.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 2706.6, APE = 2718.3, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 2718.6, APE = 2780.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 2827.7, APE = 2857.4, ALM = 1, ALC = 6 , AR=speed, AV = volume},
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2015_Female_War_Lousy_Deal()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "Female War – Lousy Deal.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP(st.currentGr) { APS = 92.3, APE = 133.3, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 133.6, APE = 220.2, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 302.7, APE = 308, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 316, APE = 319.3, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 344.5, APE = 429.5, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 430, APE = 443, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 443.2, APE = 512.4, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 547.4, APE = 564.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 572.9, APE = 575.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 604.1, APE = 723, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 724.1, APE = 761.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 762, APE = 821.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},
                new AP(st.currentGr) { APS = 895, APE = 985.5, ALM = 1, ALC = 6 , AR=speed, AV = volume},// talk with raper, force to bj
                new AP(st.currentGr) { APS = 986.6, APE = 1044.6, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with husb
                new AP(st.currentGr) { APS = 1045.4, APE = 1074.1, ALM = 1, ALC = 6 , AR=speed, AV = volume},//shower with memories
                new AP(st.currentGr) { APS = 1052.4, APE = 1055.6, ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1085.1, APE = 1089.6, ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1143.4, APE = 1125.9, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with raper
                new AP(st.currentGr) { APS = 1126.2, APE = 1430.3, ALM = 1, ALC = 6 , AR=speed, AV = volume},//rapier molesting with hubby
                new AP(st.currentGr) { APS = 1433, APE = 1498, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with raper
                new AP(st.currentGr) { APS = 1499.1, APE = 1532.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},//think about rapier
                new AP(st.currentGr) { APS = 1563.8, APE = 1629.3, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with frend
                new AP(st.currentGr) { APS = 1636.3, APE = 1663.5, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with raper
                new AP(st.currentGr) { APS = 1663.8, APE =1844.8 , ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck combined
                new AP(st.currentGr) { APS = 1663.8, APE = 1670.6, ALM = 3, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1670.9, APE = 1681.9, ALM = 3, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1682.1, APE = 1688.2, ALM = 3, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1688.4, APE = 1697.2, ALM = 3, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1697.4, APE = 1726.1, ALM = 3, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1728, APE = 1733, ALM = 3, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1733.3, APE = 1745.5, ALM = 3, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1760, APE = 1844, ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1845, APE = 1933.2, ALM = 1, ALC = 6 , AR=speed, AV = volume},//cuddling rapier
                new AP(st.currentGr) { APS = 1932, APE = 1996, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with nubby
                new AP(st.currentGr) { APS = 2136.8, APE = 2157.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},//makeup
                new AP(st.currentGr) { APS = 2159.9, APE = 2195.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with nubby
                new AP(st.currentGr) { APS = 2204.5, APE = 2291.5, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with rapier
                new AP(st.currentGr) { APS = 2306.3, APE = 2419.2, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with rapier
                new AP(st.currentGr) { APS = 2431.2, APE = 2462, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with nubby
                new AP(st.currentGr) { APS = 2496.1, APE = 2683.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with rapier, undressing
                new AP(st.currentGr) { APS = 2696.8, APE = 2789.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with nubby
                new AP(st.currentGr) { APS = 2798, APE = 2832, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with nubby
                new AP(st.currentGr) { APS = 2839, APE = 2912.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with rapier
                new AP(st.currentGr) { APS = 2915 , APE = 2988.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 3077.8, APE = 3160.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},//murder
                new AP(st.currentGr) { APS = 3298.5, APE = 3308.5, ALM = 1, ALC = 6 , AR=speed, AV = volume},//talk with nubby                
          };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2015_Female_Workers_Romance_At_Work()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "Female Workers Romance At Work.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
               
                new AP(st.currentGr) { APS = 105.6, APE = 116, ALM = 3, ALC = 6 , AR=speed, AV = volume},//bj
                new AP(st.currentGr) { APS = 215.5, APE = 258.4, ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 1698.7, APE = 1726.7, ALM = 1, ALC = 6 , AR=speed, AV = volume}, //bj
                new AP(st.currentGr) { APS = 3034.1, APE = 3082, ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 3444.8, APE = 3595.4, ALM = 1, ALC = 6 , AR=speed, AV = volume},//kuni
                new AP(st.currentGr) { APS = 4035.4, APE = 4087.4, ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck
                new AP(st.currentGr) { APS = 4090.5, APE = 4122.7, ALM = 1, ALC = 6 , AR=speed, AV = volume}, //fuck
                new AP(st.currentGr) { APS = 4128.3, APE = 4151.2, ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck 
                new AP(st.currentGr) { APS = 4165.2, APE = 4269.8, ALM = 1, ALC = 6 , AR=speed, AV = volume}, //fuck
                new AP(st.currentGr) { APS = 4270.1, APE = 4353, ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck 
                new AP(st.currentGr) { APS = 4405.5, APE = 4461.6, ALM = 1, ALC = 6 , AR=speed, AV = volume}, //fuck 
                new AP(st.currentGr) { APS = 4462.2, APE = 4544.2, ALM = 1, ALC = 6 , AR=speed, AV = volume}, //fuck 
                new AP(st.currentGr) { APS = 4544.4, APE = 4566.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},//fuck  
                new AP(st.currentGr) { APS =4575.2 , APE = 4612.3, ALM = 1, ALC = 6 , AR=speed, AV = volume}, //fuck 
                new AP(st.currentGr) { APS = 5171.6, APE =5317.3 , ALM = 1, ALC = 6 , AR=speed, AV = volume}, //fuck 


          };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void THA_2015_Long_Ping_Ha_Rak()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "Long Ping Ha Rak.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP(st.currentGr) { APS = 261.6, APE = 302.6, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 1371.4, APE = 1546, ALM = 3, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 2051, APE =2261 , ALM = 3, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 3536, APE = 3661, ALM = 3, ALC = 6 , AR=speed, AV = volume},//
          };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void THA_2015_Mae_Bia()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "Mae Bia.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP(st.currentGr) { APS = 856.2, APE = 863.3, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 866.8, APE = 884.9, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS =1278.7 , APE = 1322, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 2247.4, APE = 2250.1, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 4053.6, APE = 4093, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 4573.4, APE = 4584.4, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 6365.3, APE = 6475.3, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                //new AP(st.currentGr) { APS = , APE = , ALM = 1, ALC = 6 , AR=speed, AV = volume},//
               
          };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2015_My_Friends_Wife_Cast()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "My Friend's Wife Cast.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP(st.currentGr) { APS = 2672.9, APE =2676.2 , ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 2953.2, APE = 2988, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS =3730.8 , APE = 3890.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 4315.3, APE = 4334.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},//               
                new AP(st.currentGr) { APS = 4427.2, APE = 4436.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 4486.2, APE = 4519.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},//

            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2015_New_Folder_2()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "New Folder 2.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP(st.currentGr) { APS = 254.5, APE = 275.4, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 275.5, APE = 295.1, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 309.3, APE = 565.6, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 2115, APE = 2147, ALM = 1, ALC = 6 , AR=speed, AV = volume},//shower
                new AP(st.currentGr) { APS = 2768.7, APE = 2776.7, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 2874.3, APE = 3151.3, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 3501.2, APE = 3830.0, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 4523.8, APE = 4926, ALM = 1, ALC = 6 , AR=speed, AV = volume},//

            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void KOR_2015_No_soo_Ram_Others_Bad_Class()
        {
            _Clip_Default st = new _Clip_Default();
            st.currentGr = "No-soo Ram & Others - Bad Class.m4v";
            int speed = 100;
            int volume = 1;
            List<AP> anims = new List<AP>()
            {
                new AP(st.currentGr) { APS = 185.6, APE = 232, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
                new AP(st.currentGr) { APS = 419.6, APE = 441.8, ALM = 1, ALC = 6 , AR=speed, AV = volume},//
            };
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };

            st.VideoFrame800(anims, music);
            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }

        //protected override void DoFilter(string cadregroup)
        //{
        //    string[] cd = new string[] {
        //        "KOR 2016 Comic Stories.m4v"
        //    };
        //    base.DoFilter(cd);
        //    this.AlignList.Reverse();
        //}
    }
}
