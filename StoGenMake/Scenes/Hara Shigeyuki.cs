using StoGenMake.Elements;
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


    }

}
