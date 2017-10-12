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
        protected override void MakeCadres()
        {


            #region Netorare Tsuma ~Otto no Chichi to Kindan no Kankei~

         

          

            // SetAlign
            SetCadre(new AlignData[] {
                new AlignData("Evil_BODY_1710085001", new DifData() { sX = 900, sY = 900, Flip = 1}),
                new AlignData("Evil_BODY_1710085002", new DifData() { sX = 900, sY = 900}),
                new AlignData("Evil_BODY_1710085001","LADY_Body_1710110001",new DifData() { X = 515, Y = -670, sX = 900, sY = 900, Rot=270, Flip=0 }),

                new AlignData("LADY_Body_1710083003", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710083004", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710083005", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710083006", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710083007", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710083008", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710083009", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710083010", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710083011", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710083012", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710110001", new DifData() { sX = 995, sY = 995}),
                new AlignData("LADY_Body_1710110002", new DifData() { sX = 995, sY = 995}),

                new AlignData("LADY_PANTY_1710084002","LADY_Body_1710083003", new DifData() { X = 508, Y = 363, sX = 309, sY = 309, Rot=360 }),

                new AlignData("LADY_Head_1710086001", "LADY_Body_1710083003", new DifData() { X = 62, Y = 33, sX = 865, sY = 865, Rot=363 }),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083003", new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot=353 }),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083004", new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot=353 }),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083005", new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot=353 }),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083006", new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot=353 }),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083007", new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot=353 }),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083008", new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot=353 }),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083009", new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot=353 }),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083010", new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot=353 }),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083011", new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot=353 }),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083012", new DifData() { X = 347, Y = 28, sX = 335, sY = 335, Rot=353 }),
                new AlignData("LADY_Head_1710110002", "LADY_Body_1710110001", new DifData() { X = 40, sX = 540, sY = 540 }),
                new AlignData("LADY_Head_1710110002", "LADY_Body_1710110002", new DifData() { X = 40, sX = 540, sY = 540 }),



                new AlignData("LADY_Mouth_1710084001","LADY_Head_1710086001", new DifData() { X = 484, Y = 178, sX = 60, sY = 60, Rot=277, Flip = 1 }),
                new AlignData("LADY_Mouth_1710084002","LADY_Head_1710086001", new DifData() { X = 494, Y = 191, sX = 31, sY = 31, Rot=274, Flip = 1 }),
                new AlignData("LADY_Mouth_1710084001","LADY_Head_1710110002", new DifData() { X = 182, Y = 162, sX = 125, sY = 125, Rot=264 , Flip = 1 }),
            }, null);


            for (int i = 1; i < 142; i++)
            {
                SetCadre(new AlignData[] { new AlignData($"LADY_Body_1710082{i.ToString("D3")}") }, this);
            }


            SetCadre(new AlignData[] {
                new AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 }),
                new AlignData("LADY_Head_1710086001","LADY_Body_1710083003"),
                new AlignData("LADY_Body_1710083003"),
                new AlignData("LADY_Mouth_1710084001","LADY_Head_1710086001")
            }, this);

            SetCadre(new AlignData[] {
                new AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new AlignData("LADY_Head_1710086001","LADY_Body_1710083003")
              ,new AlignData("LADY_Body_1710083003")
              ,new AlignData("LADY_Mouth_1710084002","LADY_Head_1710086001"),
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086001","LADY_Body_1710083003")
              ,new  AlignData("LADY_Body_1710083003")
              ,new  AlignData("LADY_Mouth_1710084001","LADY_Head_1710086001")
              ,new  AlignData("LADY_PANTY_1710084002","LADY_Body_1710083003"),
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083003")
              ,new  AlignData("LADY_Body_1710083003")
              ,new  AlignData("LADY_PANTY_1710084002","LADY_Body_1710083003")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083004")
              ,new  AlignData("LADY_Body_1710083004")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083005")
              ,new  AlignData("LADY_Body_1710083005")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083006")
              ,new  AlignData("LADY_Body_1710083006")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083007")
              ,new  AlignData("LADY_Body_1710083007")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083008")
              ,new  AlignData("LADY_Body_1710083008")
            }, this);


            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083009")
              ,new  AlignData("LADY_Body_1710083009")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083010")
              ,new  AlignData("LADY_Body_1710083010")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083011")
              ,new  AlignData("LADY_Body_1710083011")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001",new DifData() { X = -145, sX = 640, sY = 640 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083012")
              ,new  AlignData("LADY_Body_1710083012")
            }, this);


            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085002",new DifData() { X = -46, Y = 311, sX = 400, sY = 400, Rot=362 })
              ,new  AlignData("LADY_Head_1710086002","LADY_Body_1710083012")              
              ,new  AlignData("LADY_Body_1710083012")            
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085002",new DifData() { X = -46, Y = 371, sX = 400, sY = 400, Rot=362 })
               ,new  AlignData("LADY_Body_1710110001", new DifData() {X = 370,  Y = -5 })
               ,new  AlignData("LADY_Head_1710110002","LADY_Body_1710110001")
               ,new AlignData("LADY_Mouth_1710084001","LADY_Head_1710110002")
            }, this);

            SetCadre(new AlignData[] {               
                new  AlignData("LADY_Body_1710110002", new DifData() {X = 370,  Y = -5 } )
               ,new  AlignData("LADY_Head_1710110002","LADY_Body_1710110002")
               ,new AlignData("LADY_Mouth_1710084001","LADY_Head_1710110002")
               ,new  AlignData("Evil_BODY_1710085001","LADY_Body_1710110001")
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

            // evil
            data.Add(GetIm($"Evil_BODY_1710085001", VNPCPersType.Manga, "Fools_Art_Homare", path, $"EVIL_BODY_01.png"));
            data.Add(GetIm($"Evil_HEAD_1710085002", VNPCPersType.Manga, "Fools_Art_Homare", path, $"EVIL_HEAD_01.png"));
            data.Add(GetIm($"Evil_BODY_1710085002", VNPCPersType.Manga, "Fools_Art_Homare", path, $"EVIL_BODY_02.png"));
            data.Add(GetIm($"Evil_HEAD_1710085003", VNPCPersType.Manga, "Fools_Art_Homare", path, $"EVIL_HEAD_02.png"));
            // parts
            data.Add(GetIm($"LADY_Mouth_1710084001", VNPCPersType.Manga, "Fools_Art_Homare", path, $"MOUTH_01.png"));
            data.Add(GetIm($"LADY_Mouth_1710084002", VNPCPersType.Manga, "Fools_Art_Homare", path, $"MOUTH_02.png"));
            data.Add(GetIm($"LADY_PANTY_1710084002", VNPCPersType.Manga, "Fools_Art_Homare", path, $"PANTY_01.png"));
            data.Add(GetIm($"LADY_PANTY_1710084003", VNPCPersType.Manga, "Fools_Art_Homare", path, $"PANTY_02.png"));
            data.Add(GetIm($"LADY_Mouth_1710084004", VNPCPersType.Manga, "Fools_Art_Homare", path, $"MOUTH_03.png"));

            // heads
            data.Add(GetIm($"LADY_Head_1710086001", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003_head.png"));
            data.Add(GetIm($"LADY_Head_1710086002", VNPCPersType.Manga, "Fools_Art_Homare", path, $"002_head.png"));
            data.Add(GetIm($"LADY_Head_1710110001", VNPCPersType.Manga, "Fools_Art_Homare", path, $"004_head.png"));
            data.Add(GetIm($"LADY_Head_1710110002", VNPCPersType.Manga, "Fools_Art_Homare", path, $"005_head.png"));
            // png
            data.Add(GetIm($"LADY_Body_1710083002", VNPCPersType.Manga, "Fools_Art_Homare", path, $"002.png"));
            data.Add(GetIm($"LADY_Body_1710083003", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003.png"));
            data.Add(GetIm($"LADY_Body_1710083004", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003a.png"));
            data.Add(GetIm($"LADY_Body_1710083005", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003b.png"));
            data.Add(GetIm($"LADY_Body_1710083006", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003c.png"));
            data.Add(GetIm($"LADY_Body_1710083007", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003d.png"));
            data.Add(GetIm($"LADY_Body_1710083008", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003e.png"));
            data.Add(GetIm($"LADY_Body_1710083009", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003f.png"));
            data.Add(GetIm($"LADY_Body_1710083010", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003g.png"));
            data.Add(GetIm($"LADY_Body_1710083011", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003h.png"));
            data.Add(GetIm($"LADY_Body_1710083012", VNPCPersType.Manga, "Fools_Art_Homare", path, $"003j.png"));

            data.Add(GetIm($"LADY_Body_1710110001", VNPCPersType.Manga, "Fools_Art_Homare", path, $"018.png"));
            data.Add(GetIm($"LADY_Body_1710110002", VNPCPersType.Manga, "Fools_Art_Homare", path, $"018a.png"));
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
