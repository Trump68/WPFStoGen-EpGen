﻿using StoGenMake.Elements;
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
                new AlignData("Evil_BODY_1710085001", new DifData() { X = -188, Y = -32, sX = 595, sY = 595, Rot = 362, Flip = 1 }),
                new AlignData("Evil_BODY_1710085002", new DifData() { X = -188, Y = -42, sX = 830, sY = 830, Rot = 362, Flip = 1 }),

                new AlignData("LADY_Body_1710083003"),
                new AlignData("LADY_Body_1710083012", new DifData() { sX = 900, sY = 600, X = 0, Y = 0 }),

                //new AlignData("LADY_Head_1710086002"),

                new AlignData("LADY_PANTY_1710084002","LADY_Body_1710083003", new DifData() { X = 398, Y = 283, sX = 254, sY = 254, Rot = 360}),

                new AlignData("LADY_Head_1710086001", "LADY_Body_1710083003"),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083003", new DifData() { X = 262, Y = 13, sX = 280, sY = 280, Rot = 353}),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083004", new DifData() { X = 262, Y = 13, sX = 280, sY = 280, Rot = 353}),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083005", new DifData() { X = 262, Y = 13, sX = 280, sY = 280, Rot = 353}),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083006", new DifData() { X = 262, Y = 13, sX = 280, sY = 280, Rot = 353}),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083007", new DifData() { X = 262, Y = 13, sX = 280, sY = 280, Rot = 353}),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083008", new DifData() { X = 262, Y = 13, sX = 280, sY = 280, Rot = 353}),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083009", new DifData() { X = 262, Y = 13, sX = 280, sY = 280, Rot = 353}),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083010", new DifData() { X = 262, Y = 13, sX = 280, sY = 280, Rot = 353}),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083011", new DifData() { X = 262, Y = 13, sX = 280, sY = 280, Rot = 353}),
                new AlignData("LADY_Head_1710086002", "LADY_Body_1710083012", new DifData() { X = 262, Y = 13, sX = 280, sY = 280, Rot = 353}),

                new AlignData("LADY_Mouth_1710084001","LADY_Head_1710086001", new DifData()  { X = 372, Y = 128, sX = 60, sY = 60, Rot = 277, Flip = 1 }),
                new AlignData("LADY_Mouth_1710084002","LADY_Head_1710086001", new DifData()  { X = 382, Y = 142, sX = 30, sY = 30, Rot = 279, Flip = 1 }),
            }, null);


            for (int i = 1; i < 142; i++)
            {
                SetCadre(new AlignData[] { new AlignData($"LADY_Body_1710082{i.ToString("D3")}") }, this);
            }


            SetCadre(new AlignData[] {
                new AlignData("Evil_BODY_1710085001"),
                new AlignData("LADY_Head_1710086001","LADY_Body_1710083003"),
                new AlignData("LADY_Body_1710083003"),
                new AlignData("LADY_Mouth_1710084001","LADY_Head_1710086001")
            }, this);

            SetCadre(new AlignData[] {
                new AlignData("Evil_BODY_1710085001")
              ,new AlignData("LADY_Head_1710086001","LADY_Body_1710083003")
              ,new AlignData("LADY_Body_1710083003")
              ,new AlignData("LADY_Mouth_1710084002","LADY_Head_1710086001"),
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("Evil_BODY_1710085001")
              ,new  AlignData("LADY_Head_1710086001","LADY_Body_1710083003")
              ,new  AlignData("LADY_Body_1710083003")
              ,new  AlignData("LADY_Mouth_1710084001","LADY_Head_1710086001")
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
               new  AlignData("LADY_Head_1710086002","LADY_Body_1710083012")
              ,new  AlignData("LADY_Body_1710083012")
              //,new  AlignData("Evil_BODY_1710085002")
            }, this);

            SetCadre(new AlignData[] {
               new  AlignData("LADY_Head_1710086002","LADY_Body_1710083012")
              //,new  AlignData("LADY_Body_1710083012",new DifData() { X = 169, Y = -5, sX = 1005, sY = 1005})
              ,new  AlignData("LADY_Body_1710083012",new DifData() { sX = 1005, sY = 1005})
              //,new  AlignData("Evil_BODY_1710085002")
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
