using StoGen.Classes;
using StoGenLife.SOUND;
using StoGenMake.Elements;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static StoGenMake.Pers.VNPC;

namespace StoGenMake.Pers
{
    public class LADY_041017 : VNPC
    {
        public LADY_041017() : base()
        {
            this.Name = "LADY_041017";
            this.GID = Guid.Parse("{F9A65242-67AA-4745-9A50-AA69EEE82BA3}");
            this.PersonType = VNPCPersType.HCG;

            this.Description = "bellas de noche 128";
            this.Face = new VNPCFace("Face 01", @"D:\Temp\FACE (bellas de noche 128)-06 copy 2.jpg");

            FillDataImage();
        }
        private void FillDataImage()
        {
            this.Data.Add("IMAGE", VNPC.DOCIER_PICTURE, null, $@"D:\Temp\(Aca los Maistros 04)-19 copy 3.png");
        }
    }
}
