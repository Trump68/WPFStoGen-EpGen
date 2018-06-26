using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPCat.Model
{
    public class SkyrimActorPose
    {
        public string ID;
        private string sourcePath;
        public int Position = 1;
        public int Stage = 1;
        public int SOS = 0;
        public SkyrimActorPose(string id)
        {
            this.ID = id;
            Init();
        }
        private bool Init()
        {
            var p = Skyrim.Items.Where(x => x.GID.Equals(Guid.Parse(ID))).FirstOrDefault();
            if (p == null) return false;
            sourcePath = Path.GetDirectoryName((p.ItemPath));
            return true;
        }
        public void CopyToDestination()
        {           
            if (!string.IsNullOrEmpty(sourcePath))
            {
                string file = Directory.GetFiles(sourcePath, "*.hkx").FirstOrDefault();
                if (!string.IsNullOrEmpty(file))
                {
                    File.Copy(file, Path.Combine(Skyrim.destinationPath, $"AB01_Fuck_A{Position}_S{Stage}.hkx"), true);
                }
            }
        }
    }
}
