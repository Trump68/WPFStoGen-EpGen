using StoGenMake.Elements;
using StoGenMake.Pers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes.Base
{
    public class Fools_Art_Homare : BaseScene
    {

        public Fools_Art_Homare() : base()
        {

        }

        internal static void LoadDataAndAlign(List<seIm> data, List<AlignDif> alignData, string path)
        {
            string dsc = "Fools_Art_Homare";
            string src = null;
            string fn = null;
            // Evil Body
            GetIm($"Evil_BODY_1710085001", VNPCPersType.Manga, dsc, path, $"EVIL_BODY_01.png", data, new DifData() { X = 335, Y = -10, sX = 720, sY = 720, Flip = 1 });
            GetIm($"Evil_HEAD_1710085002", VNPCPersType.Manga, dsc, path, $"EVIL_HEAD_01.png", data);
            GetIm($"Evil_BODY_1710085002", VNPCPersType.Manga, dsc, path, $"EVIL_BODY_02.png", data);
            GetIm($"Evil_HEAD_1710085003", VNPCPersType.Manga, dsc, path, $"EVIL_HEAD_02.png", data);
            GetIm($"Evil_HEAD_1710085004", VNPCPersType.Manga, dsc, path, $"EVIL_HEAD_03.png", data, new DifData() { X = 835, Y = 70, sX = 500, sY = 500, Flip = 1 });

            // Panty
            src = $"LADY_PANTY_1710084002"; fn = $"PANTY_01.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 500, sY = 500, Flip = 0 });
            src = $"LADY_PANTY_1710084003"; fn = $"PANTY_02.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 500, sY = 500, Flip = 0 });

            // Mouth
            src = $"LADY_Mouth_1710084001"; fn = $"MOUTH_01.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 100, sY = 100, Flip = 0 });
            src = $"LADY_Mouth_1710084002"; fn = $"MOUTH_02.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 100, sY = 100, Flip = 0 });
            src = $"LADY_Mouth_1710140000"; fn = $"MOUTH_04.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 100, sY = 100, Flip = 0 });
            src = $"LADY_Mouth_1710140001"; fn = $"MOUTH_05.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 100, sY = 100, Flip = 0 });
            src = $"LADY_Mouth_1710140002"; fn = $"MOUTH_06.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 100, sY = 100, Flip = 0 });

            // Heads
            src = $"LADY_Head_1710086001"; fn = $"003_head.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 });
            SetCadre(new AlignData[] { new AlignData("LADY_Mouth_1710084001", src,  new DifData() { X = 344, Y = 307, sX = 58, sY = 58, Rot = 272, Flip = 1 }) });
            SetCadre(new AlignData[] { new AlignData("LADY_Mouth_1710084002", src,  new DifData() { X = 344, Y = 307, sX = 58, sY = 58, Rot = 272, Flip = 1 }) });
            SetCadre(new AlignData[] { new AlignData("LADY_Mouth_1710140000", src, new DifData()  { X = 344, Y = 362, sX = 58, sY = 58, Rot = 352, Flip = 0 }) });
            SetCadre(new AlignData[] { new AlignData("LADY_Mouth_1710140001", src, new DifData()  { X = 340, Y = 375, sX = 67, sY = 67, Rot = 372, Flip = 0 }) });
            SetCadre(new AlignData[] { new AlignData("LADY_Mouth_1710140002", src, new DifData() { X = 340, Y = 375, sX = 57, sY = 57, Rot = 372, Flip = 0 }) });

            src = $"LADY_Head_1710086002"; fn = $"002_head.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 });
            src = $"LADY_Head_1710110001"; fn = $"004_head.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 });

            src = $"LADY_Head_1710110002"; fn = $"005_head.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 });
            SetCadre(new AlignData[] { new AlignData("LADY_Mouth_1710084001", src, new DifData() { X = 247, Y = 225, sX = 58, sY = 58, Rot = 265, Flip = 1 }) });

            src = $"LADY_Head_1710110003"; fn = $"006_head.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 });
            SetCadre(new AlignData[] { new AlignData("LADY_Mouth_1710084001", src, new DifData() { X = 247, Y = 225, sX = 58, sY = 58, Rot = 265, Flip = 1 }) });

            // Body
            src = $"LADY_Body_1710083003"; fn = $"003.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign1(src, data, alignData, path);
            src = $"LADY_Body_1710083004"; fn = $"003a.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign1(src, data, alignData, path);
            src = $"LADY_Body_1710083005"; fn = $"003b.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign1(src, data, alignData, path);
            src = $"LADY_Body_1710083006"; fn = $"003c.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign1(src, data, alignData, path);
            src = $"LADY_Body_1710083007"; fn = $"003d.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign1(src, data, alignData, path);
            src = $"LADY_Body_1710083008"; fn = $"003e.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign1(src, data, alignData, path);
            src = $"LADY_Body_1710083009"; fn = $"003f.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign1(src, data, alignData, path);
            src = $"LADY_Body_1710083010"; fn = $"003g.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign1(src, data, alignData, path);
            src = $"LADY_Body_1710083011"; fn = $"003h.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign1(src, data, alignData, path);
            src = $"LADY_Body_1710083012"; fn = $"003j.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign1(src, data, alignData, path);

            src = $"LADY_Body_1710110001"; fn = $"018.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign2(src, data, alignData, path);
            src = $"LADY_Body_1710110002"; fn = $"018a.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign2(src, data, alignData, path);
            src = $"LADY_Body_1710110003"; fn = $"018b.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign2(src, data, alignData, path);
            src = $"LADY_Body_1710110004"; fn = $"018c.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign2(src, data, alignData, path);
            src = $"LADY_Body_1710110005"; fn = $"018d.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign2(src, data, alignData, path);
            src = $"LADY_Body_1710110006"; fn = $"018e.png";
            GetIm(src, VNPCPersType.Manga, dsc, path, fn, data, new DifData() { sX = 995, sY = 995 });
            SetBodyAlign2(src, data, alignData, path);
        }
        private static void SetBodyAlign1(string Body, List<seIm> data, List<AlignDif> alignData, string path)
        {
            SetCadre(new AlignData[] { new AlignData("LADY_PANTY_1710084002", Body, new DifData() { X = 508, Y = 363, sX = 309, sY = 309, Rot = 360 }) });
            SetCadre(new AlignData[] { new AlignData("LADY_Head_1710086001", Body, new DifData() { X = 324, sX = 340, sY = 340 }) });
            SetCadre(new AlignData[] { new AlignData("LADY_Head_1710086002", Body, new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot = 353 }) });
        }
        private static void SetBodyAlign2(string Body, List<seIm> data, List<AlignDif> alignData, string path)
        {

            SetCadre(new AlignData[] { new AlignData("LADY_Head_1710110002", Body, new DifData() { X = 41, Y = 3, sX = 535, sY = 535, Flip = 0 }) });
            SetCadre(new AlignData[] { new AlignData("LADY_Head_1710110003", Body, new DifData() { X = 41, Y = 3, sX = 535, sY = 535, Flip = 0 }) });
            //SetCadre(new AlignData[] { new AlignData("LADY_Head_1710086002", Body, new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot = 353 }) });
        }
        protected override void MakeCadres()
        {
            #region Netorare Tsuma ~Otto no Chichi to Kindan no Kankei~


            for (int i = 1; i < 142; i++)
            {
                SetCadre(new AlignData[] { new AlignData($"LADY_Body_1710082{i.ToString("D3")}") }, this);
            }


            SetCadre(new AlignData[] {
                new AlignData("Evil_BODY_1710085001"),
                new AlignData("LADY_Head_1710086001","LADY_Body_1710083003"),
                new AlignData("LADY_Mouth_1710084002","LADY_Head_1710086001"),
                new AlignData("LADY_Body_1710083003")

            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086001","LADY_Body_1710083003")
              ,new  AlignData("LADY_Mouth_1710084001","LADY_Head_1710086001")
              ,new  AlignData("LADY_Body_1710083003")
              ,new  AlignData("LADY_PANTY_1710084002","LADY_Body_1710083003"),
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083003")
              ,new  AlignData("LADY_Body_1710083003")
              ,new  AlignData("LADY_PANTY_1710084002","LADY_Body_1710083003")
            }, this);


            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083004")
              ,new  AlignData("LADY_Body_1710083004")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083005")
              ,new  AlignData("LADY_Body_1710083005")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083006")
              ,new  AlignData("LADY_Body_1710083006")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083007")
              ,new  AlignData("LADY_Body_1710083007")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083008")
              ,new  AlignData("LADY_Body_1710083008")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083009")
              ,new  AlignData("LADY_Body_1710083009")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083010")
              ,new  AlignData("LADY_Body_1710083010")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083011")
              ,new  AlignData("LADY_Body_1710083011")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083012")
              ,new  AlignData("LADY_Body_1710083012")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085002")
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083012")
              ,new  AlignData("LADY_Body_1710083012")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085002",new DifData() { X = -95, Y = 280, sX = 500, sY = 500, Flip=0 }),
               new  AlignData("LADY_Body_1710110001"),
               new  AlignData("LADY_Head_1710110002","LADY_Body_1710110001"),
               new AlignData("LADY_Mouth_1710084001","LADY_Head_1710110002"),
            }, this);

            SetCadre(new AlignData[] {
                new  AlignData("LADY_Body_1710110002", new DifData() {X = 370,  Y = -5 } ),
               new  AlignData("LADY_Head_1710110002","LADY_Body_1710110002"),
               new AlignData("LADY_Mouth_1710084001","LADY_Head_1710110002"),
               new  AlignData("Evil_HEAD_1710085002",new DifData(false) { X = 380, Y = -260, sX = 420, sY = 420, Rot=290, Flip=0 }),
            }, this);


            SetCadre(new AlignData[] {
               new  AlignData("LADY_Body_1710110003", new DifData() {X = 370,  Y = -5 } ),
               new  AlignData("LADY_Head_1710110003","LADY_Body_1710110003"),
               new  AlignData("LADY_Mouth_1710084001","LADY_Head_1710110003"),
               new  AlignData("Evil_HEAD_1710085002",new DifData(false) { X = 380, Y = -260, sX = 420, sY = 420, Rot=290, Flip=0 }),
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("LADY_Body_1710110004", new DifData() {X = 370,  Y = -5 } ),
               new  AlignData("LADY_Head_1710110002","LADY_Body_1710110004"),
               new  AlignData("LADY_Mouth_1710084001","LADY_Head_1710110002"),
               new  AlignData("Evil_BODY_1710085001", new DifData() { X = 30, Y = -60, sX = 925, sY = 925, Flip=1 })
            }, this);


            SetCadre(new AlignData[] {
               new  AlignData("LADY_Body_1710110005", new DifData() {X = 370,  Y = -5 } ),
               new  AlignData("LADY_Head_1710110002","LADY_Body_1710110005"),
               new  AlignData("LADY_Mouth_1710084001","LADY_Head_1710110002"),
               new  AlignData("Evil_HEAD_1710085002",new DifData(false) { X = 380, Y = -260, sX = 420, sY = 420, Rot=290, Flip=0 }),
            }, this);


            SetCadre(new AlignData[] {
               new  AlignData("LADY_Body_1710110006", new DifData() {X = 370,  Y = -5 } ),
               new  AlignData("LADY_Head_1710110002","LADY_Body_1710110006"),
               new  AlignData("LADY_Mouth_1710084001","LADY_Head_1710110002"),
               new  AlignData("Evil_HEAD_1710085002",new DifData(false) { X = 380, Y = -260, sX = 420, sY = 420, Rot=290, Flip=0 }),
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("LADY_Body_1710110006", new DifData() {X = 370,  Y = -5 } ),
               new  AlignData("LADY_Head_1710110002","LADY_Body_1710110006"),
               new  AlignData("LADY_Mouth_1710084001","LADY_Head_1710110002"),
               new  AlignData("Evil_HEAD_1710085004", new DifData(false) { X = 770, Y = -410, sX = 365, sY = 365, Rot=330, Flip=1 } ),
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("LADY_Body_1710110006", new DifData() {X = 370,  Y = -5 } ),
               new  AlignData("LADY_Head_1710110002","LADY_Body_1710110006"),
               new  AlignData("LADY_Mouth_1710084001","LADY_Head_1710110002"),
               new  AlignData("Evil_HEAD_1710085004",new DifData(false) { X = -90, Y = -10, sX = 340, sY = 340, Flip=0 }),
            }, this);

            SetCadre(new AlignData[] {
                new AlignData("Evil_BODY_1710085001"),
                new AlignData("LADY_Head_1710086001", "LADY_Body_1710083003"),
                new AlignData("LADY_Mouth_1710084001","LADY_Head_1710086001"),
                new AlignData("LADY_Body_1710083003"),
            }, this);

            SetCadre(new AlignData[] {
                new AlignData("Evil_BODY_1710085001"),
                new AlignData("LADY_Head_1710086001", "LADY_Body_1710083003"),
                new AlignData("LADY_Mouth_1710140001","LADY_Head_1710086001"),
                new AlignData("LADY_Body_1710083003"),
            }, this);

            SetCadre(new AlignData[] {
                new AlignData("Evil_BODY_1710085001"),
                new AlignData("LADY_Head_1710086001", "LADY_Body_1710083003"),
                new AlignData("LADY_Mouth_1710140002","LADY_Head_1710086001"),
                new AlignData("LADY_Body_1710083003"),
            }, this);

         
            this.Cadres.Reverse();

            #endregion
        }
        internal static void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;

            // Netorare Tsuma ~Otto no Chichi to Kindan no Kankei~
            path = @"x:\ARTIST\FoolsArt (Homare)\Netorare Tsuma ~Otto no Chichi to Kindan no Kankei~\";
            //raw
            for (int i = 1; i < 142; i++)
            {
                data.Add(GetIm($"LADY_Body_1710082{i.ToString("D3")}", VNPCPersType.Manga, "Fools_Art_Homare", path, $"{i.ToString("D3")}.jpg"));
            }

            LoadDataAndAlign(data,alignData, path);

           
        }
        internal static void GetIm(string name,  VNPCPersType type,
                                  string desc, string path, string file, List<seIm> data,
                                  DifData defaultdifdata = null)
        {
            seIm im = new seIm($@"{path}{file}", name);
            im.Name = name;
            im.PersonType = VNPCPersType.Comix;
            im.Description = desc;
            data.Add(im);
            if (defaultdifdata!=null)
            {
                SetCadre(new AlignData[] { new AlignData(name, defaultdifdata) }, null);
            }
        }
        internal static seIm GetIm(string name, VNPCPersType type,
                                  string desc, string path, string file)
        {
            seIm im = new seIm($@"{path}{file}", name);
            im.Name = name;
            im.PersonType = VNPCPersType.Comix;
            im.Description = desc;
            return im;
        }
    }

}
