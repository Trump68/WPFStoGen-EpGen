using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Data.Movie
{
    public class _ERO__Best: BaseScene
    {
        protected override void LoadData()
        {
            
            PATH_M = @"d:\JGAMES\Otto no Inu Ma ni\inumani\Data\Music\";
            string src;
            string path;
            // system images
            path = @"e:\Process2\!!Data\EroFilms\System\Mask\";
            src = $"Vertical.png";
            AddToGlobalImage("Vertical Mask", src, path);
            //films
            //Angela Nicholas
            path = @"e:\Process2\!!Data\EroFilms\1999\[USA] Hot Club California\";
            src = $"Hot Club California.m4v";
            AddToGlobalImage(src, src, path);
            USA_1999_Hot_Club_California();

            //Angela Nicholas
            path = @"e:\Process2\!!Data\EroFilms\2006\[USA] Mistress Of Unit C\";
            src = $"Mistress Of Unit C.m4v";
            AddToGlobalImage(src, src, path);
            USA_2006_Mistress_Of_Unit_C();
        }
        private void USA_1999_Hot_Club_California()
        {
            _ALL__ScenarioText st = new _ALL__ScenarioText();
            st.currentGr = "Hot Club California.m4v";
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };
            List<List<AP>> anims;
            int speed = 100;
            int volume = 0;


            //===================== Angela Nicholas =========================
            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (face)!!!!!!!!!!!!                 
                new AP("Hot Club California.m4v") { APS = 3953.9, APE = 3956.3, ALM = 1, ALC = 1 , AR=speed},
                new AP("Hot Club California.m4v") { APS = 3959.2, APE = 3962.5, ALM = 1, ALC = 1 , AR=speed},
                new AP("Hot Club California.m4v") { APS = 3965.6, APE = 3968.4, ALM = 1, ALC = 1 , AR=speed},
                new AP("Hot Club California.m4v") { APS = 3979.6, APE = 3981.9, ALM = 1, ALC = 1 , AR=speed},
                new AP("Hot Club California.m4v") { APS = 3984, APE = 3987.4, ALM = 1, ALC = 1 , AR=speed},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (restoran)                           
                new AP("Hot Club California.m4v") { APS = 3971.2, APE = 3977.2, ALM = 1, ALC = 1 , AR=speed},
                }
            }; st.VideoFrame800(anims, music, new List<DifData>() { new DifData() { Name = "Vertical Mask", S = 800 } });

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 3994.2, APE = 3999.5, ALM = 1, ALC = 1 , AR=speed},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 3999.8, APE = 4007.8, ALM = 1, ALC = 1 , AR=speed},
                }
            }; st.VideoFrame800(anims, music, new List<DifData>() { new DifData() { Name = "Vertical Mask", S = 800, F = 1 } });

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4008.1, APE = 4012.7, ALM = 1, ALC = 1 , AR=speed},
                new AP("Hot Club California.m4v") { APS = 4016.1, APE = 4022.7, ALM = 3, ALC = 3 , AR=speed },
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4023, APE = 4027, ALM = 3, ALC = 3 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music, new List<DifData>() { new DifData() { Name = "Vertical Mask", S = 800, F = 1, X=250 } });

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4027.2, APE = 4029.4, ALM = 3, ALC = 3 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4029.7, APE = 4037.0, ALM = 3, ALC = 3 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music, new List<DifData>() { new DifData() { Name = "Vertical Mask", S = 800, F = 1, X = 300 } });

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4037.3, APE = 4040.7, ALM = 3, ALC = 7, AR=speed, AV = volume},
                new AP("Hot Club California.m4v") { APS =  4040.9, APE = 4048.4, ALM = 1, ALC = 1 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4048.6, APE = 4055.7, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4057.6, APE = 4093.4, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4094.4, APE = 4098.9, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4100.0, APE = 4114.9, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4116.2, APE = 4151.8, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4153.7, APE = 4157.5, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4158.2, APE = 4162.6, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4163.5, APE = 4168.4, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bassein)                           
                new AP("Hot Club California.m4v") { APS = 4169.1, APE = 4172.9, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)                           
                new AP("Hot Club California.m4v") { APS = 4174.1, APE = 4179.1, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)                           
                new AP("Hot Club California.m4v") { APS = 4180.1, APE = 4191.9, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)                           
                new AP("Hot Club California.m4v") { APS = 4192.9, APE = 4234.6, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)                           
                new AP("Hot Club California.m4v") { APS = 4235.7, APE = 4240.5, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)                           
                new AP("Hot Club California.m4v") { APS = 4240.9, APE = 4256.4, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)                           
                new AP("Hot Club California.m4v") { APS = 4258.3, APE = 4302.8, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)                           
                new AP("Hot Club California.m4v") { APS = 4302.8, APE = 4311.8, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 4314.6, APE = 4339.7, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 4340.1, APE = 4348.3, ALM = 1, ALC = 1 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 4358.5, APE = 4367.5, ALM = 1, ALC = 1 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 4369.8, APE = 4414.3, ALM = 1, ALC = 1 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 4416.3, APE = 4420.3, ALM = 1, ALC = 1 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 4428.0, APE = 4493.7, ALM = 1, ALC = 1 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 4499.7, APE = 4639.1, ALM = 1, ALC = 1 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 4768.7, APE = 4851.7, ALM = 1, ALC = 1 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            // New fuck

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 5055.5, APE = 5122.5, ALM = 1, ALC = 1 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 5123.0, APE = 5141.9, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 5147.0, APE = 5176.5, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 5177.5, APE = 5214.3, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)                           
                new AP("Hot Club California.m4v") { APS = 5215.4, APE = 5251.2, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)                           
                new AP("Hot Club California.m4v") { APS = 5252.8, APE = 5282.9, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)                           
                new AP("Hot Club California.m4v") { APS = 5283.4, APE = 5310.4, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)                           
                new AP("Hot Club California.m4v") { APS = 5311.5, APE = 5330.7, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)                           
                new AP("Hot Club California.m4v") { APS = 5331.3, APE = 5361.7, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 6086.5, APE = 6101.9, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            //===================== unknown =========================

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 1899.2, APE = 1904.7, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 1928.0, APE = 1938.0, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 1939.2, APE = 1946.0, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas ()                           
                new AP("Hot Club California.m4v") { APS = 1951.5, APE = 1983.3, ALM = 3, ALC = 7 , AR=speed, AV = volume},
                }
            }; st.VideoFrame800(anims, music);


            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        private void USA_2006_Mistress_Of_Unit_C()
        {
            _ALL__ScenarioText st = new _ALL__ScenarioText();
            st.currentGr = "Mistress Of Unit C.m4v";
            List<string> music = new List<string>() { $"{PATH_M}music.arc_000005.wav" };
            List<List<AP>> anims;
            int speed = 100;
            int volume = 0;


            //===================== Angela Nicholas =========================
            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (face)         
                new AP("Mistress Of Unit C.m4v") { APS = 166.5, APE = 171.3, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                new AP("Mistress Of Unit C.m4v") { APS = 186.6, APE = 188.9, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                new AP("Mistress Of Unit C.m4v") { APS = 218.7, APE = 224.1, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bdsm)         
                new AP("Mistress Of Unit C.m4v") { APS = 463.9, APE = 769.9, ALM = 1, ALC = 1 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 769.9, APE = 792.8, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 801.6, APE = 817.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 844.6, APE = 951.0, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 844.6, APE = 951.0, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 951.0, APE = 1001.5, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 1001.7, APE = 1067.0, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 1078.6, APE = 1091.6, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 1092.1, APE = 1210.5, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4303.4, APE = 4431.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 4431.9, APE = 4435.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 4436.1, APE = 4442.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 4443.1, APE = 4452.0, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 4452.2, APE = 4473.5, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 4473.5, APE = 4490.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 4490.9, APE = 4523.2, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (bj)         
                new AP("Mistress Of Unit C.m4v") { APS = 4523.5, APE = 4569.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4627.0, APE = 4640.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4641.0, APE = 4654.1, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4654.4, APE = 4682.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4682.7, APE = 4728.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4728.9, APE = 4753.2, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4754.2, APE = 4773.6, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4773.9, APE = 4784.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4787.0, APE = 4822.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4823.1, APE = 4848.5, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4848.7, APE = 4862.2, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4862.5, APE = 4870.0, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4870.3, APE = 4876.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4876.9, APE = 4910.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4910.7, APE = 4922.8, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4923.5, APE = 4936.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4936.6, APE = 4954.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4936.6, APE = 4954.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4955.1, APE = 4981.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4982.1, APE = 4994.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 4994.9, APE = 5017.6, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 5017.9, APE = 5032.1, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 5032.3, APE = 5039.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 5039.7, APE = 5045.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (fuck)         
                new AP("Mistress Of Unit C.m4v") { APS = 5046.2, APE = 5063.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (lesbo) !!!!!        
                new AP("Mistress Of Unit C.m4v") { APS = 2076.4, APE = 3049.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (face)         
                new AP("Mistress Of Unit C.m4v") { APS = 1287.2, APE = 1339.8, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (face)         
                new AP("Mistress Of Unit C.m4v") { APS = 3178.7, APE = 3287.6, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (face)         
                new AP("Mistress Of Unit C.m4v") { APS = 1878.4, APE = 1941.0, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (face)         
                new AP("Mistress Of Unit C.m4v") { APS = 4126.7, APE = 4180.2, ALM = 1, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //Angela Nicholas (face)         
                new AP("Mistress Of Unit C.m4v") { APS = 4194.2, APE = 4302.4, ALM = 1, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);




            // non angela fucks - girl 1
            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1395.3, APE = 1407.3, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1408.0, APE = 1451.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1454.1, APE = 1495.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1496.2, APE = 1534.8, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1534.9, APE = 1563.2, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1563.5, APE = 1571.0, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1571.7, APE = 1603.3, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1603.5, APE = 1685.1, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1685.2, APE = 1732.1, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1734.2, APE = 1787.2, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1787.4, APE = 1801, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1801.2, APE = 1812, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 1812.3, APE = 1868.4, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            // non angela fucks - Jenna West !!!!!
            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3584.3, APE = 3620.1, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3620.1, APE = 3651.3, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3651.6, APE = 3671.9, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3672, APE = 3742.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3672, APE = 3742.7, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3749.7, APE = 3774.3, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3777.1, APE = 3781.5, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3782.4, APE = 3796.5, ALM = 3, ALC = 3 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3805.6, APE = 3815.3, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3825.6, APE = 3840.6, ALM = 1, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3840.7, APE = 3866.4, ALM = 1, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3866.5, APE = 3877.8, ALM = 1, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3892.8, APE = 3902.9, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3939.7, APE = 3952.4, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);


            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3952.5, APE = 3963.1, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3963.4, APE = 3981.3, ALM = 1, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3981.6, APE = 3988.4, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 3988.3, APE = 4016.2, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 4016.9, APE = 4044.6, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);

            anims = new List<List<AP>>()
            {
                new List<AP>() { //       
                new AP("Mistress Of Unit C.m4v") { APS = 4047.9, APE = 4106.5, ALM = 3, ALC = 9 , AR=speed, AV=volume},
                }
            }; st.VideoFrame800(anims, music);



            st.DoFilter(new string[] { st.currentGr });
            this.AlignList.AddRange(st.AlignList);
        }
        protected override void DoFilter(string cadregroup)
        {
            string[] cd = new string[] {
                "Mistress Of Unit C.m4v"
            };
            base.DoFilter(cd);
            this.AlignList.Reverse();
        }
    }
}
