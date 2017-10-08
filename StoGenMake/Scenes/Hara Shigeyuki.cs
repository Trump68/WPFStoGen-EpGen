using StoGenMake.Elements;
using StoGenMake.Pers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes.Base
{
    public class Hara_Shigeyuki : BaseScene
    {

        public Hara_Shigeyuki() : base()
        {

        }
        protected override void MakeCadres()
        {


            #region Abunai Hitozuma - Shouko no Bouken

            for (int i = 100; i < 272; i++)
            {
                SetCadre($"LADY_Body_1710081{i}", true);
            }
            for (int i = 39; i < 100; i++)
            {
                SetCadre($"LADY_Body_17100810{i}", true);
            }


            SetCadre("EVILMAN_Head_1710080907", true);
            SetCadre("EVILMAN_Head_1710080906", true);
            SetCadre("EVILMAN_Head_1710080905", true);
            SetCadre("EVILMAN_Head_1710080904", true);
            SetCadre("LADY_Head_1710080905", true);
            SetCadre("LADY_Head_1710080904", true);
            SetCadre("LADY_Head_1710080903", true);
            SetCadre("LADY_Head_1710080902", true);
            SetCadre("EVILMAN_Head_1710080903", true);

            SetCadre("LADY_Body_1710080938", true);
            SetCadre("LADY_Body_1710080937", true);
            SetCadre("LADY_Body_1710080936", true);
            SetCadre("LADY_Body_1710080935", true);
            SetCadre("LADY_Body_1710080934", true);
            SetCadre("LADY_Body_1710080933", true);
            SetCadre("LADY_Body_1710080932", true);
            SetCadre("LADY_Body_1710080931", true);
            SetCadre("LADY_Body_1710080930", true);
            SetCadre("LADY_Body_1710080929", true);
            SetCadre("LADY_Body_1710080928", true);
            SetCadre("LADY_Body_1710080927", true);
            SetCadre("LADY_Body_1710080926", true);
            SetCadre("LADY_Body_1710080925", true);

            SetCadre(new Tuple<string, string, seIm>[] {
              new  Tuple<string, string, seIm>("LADY_Body_1710080919",null, new seIm() { X = 0, Y = 0, sX = 755, sY = 755, Rot = 0, Flip = 0 }),
              new  Tuple<string, string, seIm>("LADY_Body_1710080922",null, new seIm() { X = 765, Y = 0, sX = 365, sY = 365, Rot = 0, Flip = 0 }),
            }, true);

            SetCadre("LADY_Body_1710080924", true);
            SetCadre("LADY_Body_1710080923", true);
            SetCadre("LADY_Body_1710080921", true);
            SetCadre("LADY_Body_1710080920", true);
            SetCadre("LADY_Body_1710080918", true);
            SetCadre("LADY_Body_1710080917", true);
            SetCadre("LADY_Body_1710080916", true);
            SetCadre("LADY_Body_1710080915", true);
            SetCadre("LADY_Body_1710080914", true);
            SetCadre("LADY_Body_1710080913", true);
            SetCadre("LADY_Body_1710080912", true);
            SetCadre("LADY_Body_1710080911", true);
            SetCadre("LADY_Body_1710080910", true);

            SetCadre(new Tuple<string, string, seIm>[]
             {
              new  Tuple<string, string, seIm>("LADY_Body_1710080903",null, new seIm() { X = 0, Y = 0, sX = 755, sY = 755, Rot = 0, Flip = 0 }),
              new  Tuple<string, string, seIm>("EVILMAN_Body_1710080903",null, new seIm() { X = 415, Y = 280, sX = 605, sY = 605, Rot = 0, Flip = 0 }),
             }, true);

            SetCadre(new Tuple<string, string, seIm>[]
             {
              new  Tuple<string, string, seIm>("LADY_Body_1710080902",null,null)
             }, true);

            SetCadre(new Tuple<string, string, seIm>[]
             {
              new  Tuple<string, string, seIm>("LADY_Body_1710080901",null,new seIm() { X = 135, Y = 85, sX = 900, sY = 600, Rot = 0, Flip = 0 }),
              new  Tuple<string, string, seIm>("EVILMAN_Head_1710080902",null,new seIm() {  X = 460, Y = 270, sX = 305, sY = 305, Rot = 0, Flip = 0 })
             }, true);

            SetCadre(new Tuple<string, string, seIm>[]
                                {
              new  Tuple<string, string, seIm>("LADY_Body_1710080900",null,null),
              new  Tuple<string, string, seIm>("LADY_Head_1710080900","LADY_Body_1710080900",null),
              new  Tuple<string, string, seIm>("EVILMAN_Head_1710080901",null,new seIm() { X = 460, Y = 270, sX = 305, sY = 305, Rot = 0, Flip = 1 })
                                }, true);

            SetCadre(new Tuple<string, string, seIm>[] {
              new  Tuple<string, string, seIm>("LADY_Body_1710080900",null,null),
              new  Tuple<string, string, seIm>("LADY_Head_1710080900","LADY_Body_1710080900",null),
              new  Tuple<string, string, seIm>("EVILMAN_Head_1710080902",null,new seIm() { X = 460, Y = 270, sX = 305, sY = 305, Rot = 0, Flip = 0 })
            }, true);


            SetCadre(new Tuple<string, string, seIm>[]
                                 {
              new  Tuple<string, string, seIm>("LADY_Body_1710080900",null,null),
              new  Tuple<string, string, seIm>("LADY_Head_1710080900","LADY_Body_1710080900",null),
              new  Tuple<string, string, seIm>("EVILMAN_Head_1710080900",null,new seIm() { X = 460, Y = 270, sX = 305, sY = 305, Rot = 0, Flip = 0 })
                                 }, true);

            SetCadre(new Tuple<string, string, seIm>[] {
              new  Tuple<string, string, seIm>("LADY_Body_1710080900",null,null),
              new  Tuple<string, string, seIm>("LADY_Head_1710080900","LADY_Body_1710080900",null)
            }, true);

            #endregion
        }
        internal static void LoadData(List<seIm> data, List<AlignData> alignData)
        {


            string path = null;

            // faces
            path = @"x:\STOGEN\LADY\COMIX\LADY_Heads_Hara Shigeyuki\";
            data.Add(GetIm("LADY_Head_1710080900", VNPCPersType.Manga, "Hara Shigeyuki", path, "001.png"));
            alignData.Add(new AlignData("LADY_Head_1710080900", "LADY_Body_1710080900", new seIm() { X = 205, Y = 10, sX = 140, sY = 140 }));
            data.Add(GetIm("LADY_Head_1710080901", VNPCPersType.Manga, "Hara Shigeyuki", path, "002.png"));
            data.Add(GetIm("LADY_Head_1710080902", VNPCPersType.Manga, "Hara Shigeyuki", path, "003.png"));
            data.Add(GetIm("LADY_Head_1710080903", VNPCPersType.Manga, "Hara Shigeyuki", path, "004.png"));
            data.Add(GetIm("LADY_Head_1710080904", VNPCPersType.Manga, "Hara Shigeyuki", path, "005.png"));
            data.Add(GetIm("LADY_Head_1710080905", VNPCPersType.Manga, "Hara Shigeyuki", path, "006.png"));

            //Bodies and scenes
            path = @"x:\DOUJIN\Hara Shigeyuki\Abunai Hitozuma - Shouko no Bouken\";
            data.Add(GetIm("LADY_Body_1710080900", VNPCPersType.Manga, "Hara Shigeyuki", path, "005.png"));
            data.Add(GetIm("LADY_Body_1710080901", VNPCPersType.Manga, "Hara Shigeyuki", path, "006.png"));
            data.Add(GetIm("LADY_Body_1710080902", VNPCPersType.Manga, "Hara Shigeyuki", path, "007.png"));
            data.Add(GetIm("LADY_Body_1710080903", VNPCPersType.Manga, "Hara Shigeyuki", path, "008.png"));
            data.Add(GetIm("LADY_Body_1710080910", VNPCPersType.Manga, "Hara Shigeyuki", path, "009.jpg"));
            data.Add(GetIm("LADY_Body_1710080911", VNPCPersType.Manga, "Hara Shigeyuki", path, "010.jpg"));
            data.Add(GetIm("LADY_Body_1710080912", VNPCPersType.Manga, "Hara Shigeyuki", path, "011.jpg"));
            data.Add(GetIm("LADY_Body_1710080913", VNPCPersType.Manga, "Hara Shigeyuki", path, "012.jpg"));
            data.Add(GetIm("LADY_Body_1710080914", VNPCPersType.Manga, "Hara Shigeyuki", path, "013.jpg"));
            data.Add(GetIm("LADY_Body_1710080915", VNPCPersType.Manga, "Hara Shigeyuki", path, "014.jpg"));
            data.Add(GetIm("LADY_Body_1710080916", VNPCPersType.Manga, "Hara Shigeyuki", path, "015.jpg"));
            data.Add(GetIm("LADY_Body_1710080917", VNPCPersType.Manga, "Hara Shigeyuki", path, "016.jpg"));
            data.Add(GetIm("LADY_Body_1710080918", VNPCPersType.Manga, "Hara Shigeyuki", path, "017.jpg"));
            data.Add(GetIm("LADY_Body_1710080919", VNPCPersType.Manga, "Hara Shigeyuki", path, "018.jpg"));
            data.Add(GetIm("LADY_Body_1710080920", VNPCPersType.Manga, "Hara Shigeyuki", path, "019.jpg"));
            data.Add(GetIm("LADY_Body_1710080921", VNPCPersType.Manga, "Hara Shigeyuki", path, "020.jpg"));
            data.Add(GetIm("LADY_Body_1710080922", VNPCPersType.Manga, "Hara Shigeyuki", path, "021.jpg"));
            data.Add(GetIm("LADY_Body_1710080923", VNPCPersType.Manga, "Hara Shigeyuki", path, "022.jpg"));
            data.Add(GetIm("LADY_Body_1710080924", VNPCPersType.Manga, "Hara Shigeyuki", path, "023.jpg"));

     
            data.Add(GetIm("LADY_Body_1710080925", VNPCPersType.Manga, "Hara Shigeyuki", path, "025.jpg"));
            data.Add(GetIm("LADY_Body_1710080926", VNPCPersType.Manga, "Hara Shigeyuki", path, "026.jpg"));
            data.Add(GetIm("LADY_Body_1710080927", VNPCPersType.Manga, "Hara Shigeyuki", path, "027.jpg"));
            data.Add(GetIm("LADY_Body_1710080928", VNPCPersType.Manga, "Hara Shigeyuki", path, "028.jpg"));
            data.Add(GetIm("LADY_Body_1710080929", VNPCPersType.Manga, "Hara Shigeyuki", path, "029.jpg"));
            data.Add(GetIm("LADY_Body_1710080930", VNPCPersType.Manga, "Hara Shigeyuki", path, "030.jpg"));
            data.Add(GetIm("LADY_Body_1710080931", VNPCPersType.Manga, "Hara Shigeyuki", path, "031.jpg"));
            data.Add(GetIm("LADY_Body_1710080932", VNPCPersType.Manga, "Hara Shigeyuki", path, "032.jpg"));
            data.Add(GetIm("LADY_Body_1710080933", VNPCPersType.Manga, "Hara Shigeyuki", path, "033.jpg"));
            data.Add(GetIm("LADY_Body_1710080934", VNPCPersType.Manga, "Hara Shigeyuki", path, "034.jpg"));
            data.Add(GetIm("LADY_Body_1710080935", VNPCPersType.Manga, "Hara Shigeyuki", path, "035.jpg"));
            data.Add(GetIm("LADY_Body_1710080936", VNPCPersType.Manga, "Hara Shigeyuki", path, "036.jpg"));
            data.Add(GetIm("LADY_Body_1710080937", VNPCPersType.Manga, "Hara Shigeyuki", path, "037.jpg"));
            data.Add(GetIm("LADY_Body_1710080938", VNPCPersType.Manga, "Hara Shigeyuki", path, "038.jpg"));

            for (int i = 39; i < 100; i++)
            {
                data.Add(GetIm($"LADY_Body_17100810{i}", VNPCPersType.Manga, "Hara Shigeyuki", path, $"0{i}.jpg"));
            }
            for (int i = 100; i < 272; i++)
            {
                data.Add(GetIm($"LADY_Body_1710081{i}", VNPCPersType.Manga, "Hara Shigeyuki", path, $"{i}.jpg"));
            }

            // Evil man body
            path = @"x:\STOGEN\EVILMAN\COMIX\Hara Shigeyuki\";
            data.Add(GetIm("EVILMAN_Body_1710080900", VNPCPersType.Comix, "Hara Shigeyuki", path, "001.png"));
            data.Add(GetIm("EVILMAN_Body_1710080901", VNPCPersType.Comix, "Hara Shigeyuki", path, "002.png"));
            data.Add(GetIm("EVILMAN_Body_1710080902", VNPCPersType.Comix, "Hara Shigeyuki", path, "003.png"));
            data.Add(GetIm("EVILMAN_Body_1710080903", VNPCPersType.Comix, "Hara Shigeyuki", path, "004.png"));

            // Evil man face
            path = @"x:\STOGEN\EVILMAN\COMIX\Hara Shigeyuki\";
            data.Add(GetIm("EVILMAN_Head_1710080900", VNPCPersType.Comix, "Hara Shigeyuki", path, "001a.png"));
            data.Add(GetIm("EVILMAN_Head_1710080901", VNPCPersType.Comix, "Hara Shigeyuki", path, "002a.png"));
            data.Add(GetIm("EVILMAN_Head_1710080902", VNPCPersType.Comix, "Hara Shigeyuki", path, "003a.png"));
            data.Add(GetIm("EVILMAN_Head_1710080903", VNPCPersType.Comix, "Hara Shigeyuki", path, "005.png"));
            data.Add(GetIm("EVILMAN_Head_1710080904", VNPCPersType.Comix, "Hara Shigeyuki", path, "006.png"));
            data.Add(GetIm("EVILMAN_Head_1710080905", VNPCPersType.Comix, "Hara Shigeyuki", path, "007.png"));
            data.Add(GetIm("EVILMAN_Head_1710080906", VNPCPersType.Comix, "Hara Shigeyuki", path, "008.png"));
            data.Add(GetIm("EVILMAN_Head_1710080907", VNPCPersType.Comix, "Hara Shigeyuki", path, "009.png"));
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
