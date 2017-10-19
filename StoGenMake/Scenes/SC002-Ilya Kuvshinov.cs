using StoGenMake.Elements;
using StoGenMake.Pers;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes
{
    public class SC002_IlyaKuvshinov : BaseScene
    {
        #region CADRE GROUPS
        private string GROUP01 = "Raw data";
        private string GROUP02 = "Face 001";
        #endregion

        public SC002_IlyaKuvshinov() : base()
        {
            Name = "Ilya Kuvshinov";
            this.CadreGroups.Add(GROUP01);
            this.CadreGroups.Add(GROUP02);

        }


        protected override void MakeCadres(string cadregroup)
        {
            //if (cadregroup == GROUP01)
            //{
            //    for (int i = 1; i <= 8; i++)
            //    {
            //        SetCadre(new AlignData[] { new AlignData($"Head_IlyaKuvshinov_{i.ToString("D3")}") }, this);
            //    }
            //}

            //if (cadregroup == GROUP02)
            //{
            //    SetCadre(new AlignData[] {
            //    new AlignData($"Head_IlyaKuvshinov_001"),
            //    new AlignData("Evil_BODY_1710085001",new DifData() {X = 460, Y = 85, sX = 980, sY = 980, Flip=0}),
            //    }, this);
            //}

            //foreach (var item in this.Aligns)
            //{
            //    this.GenerateCadre(item.AlignList.ToArray());
            //}


            foreach (var item in AlignList.Where(x => x.MarkList.Contains("TEST2")))
            //foreach (var item in AlignList)
            {
                this.CreateCadre(item);
            }

            //this.Cadres.Reverse();


        }

        private void CreateCadre(CadreImageAligns item)
        {
            var cadre = new ScenCadre();
            cadre.Name = $"Cadre {this.Cadres.Count + 1}";
            this.Cadres.Add(cadre);


            foreach (var ai in item.AlignList)
            {
                //faind main image info in storage
                var isi = ImageStorage.Where(x => x.Name == ai.Name).FirstOrDefault();
                // create image
                seIm im = new seIm();
                im.Name = isi.Name;
                im.File = isi.File;
                // there is 2 alt: assign from parent-child align or from delta align, not combined!
                if (!string.IsNullOrEmpty(ai.Parent)) //if has parent image
                {
                    // get parent-child proportion
                    var parentproportion = isi.Parents.Where(x => x.ParentName == ai.Parent).FirstOrDefault();
                    if (parentproportion != null)
                    {
                        // get real parent image from cadre
                        var realpar = cadre.VisionList.Where(x => x.Name == ai.Parent).FirstOrDefault();
                        if (realpar != null)
                        {
                            // assign to image parent-child proportion according with real parent 
                            seIm realparent = realpar as seIm;
                            parentproportion.ApplyTo(im, realparent);
                        }
                    }
                }
                else // no parent image
                {
                    // assign default align to image
                    im.AssignFrom(isi.DefaultAlign);
                    // assign delta align, if any
                    im.AssignFrom(ai);
                }

                // add image to cadre
                cadre.AddImage(im);

            }

        }

        public static List<ImageAlignVec> ImageStorage = new List<ImageAlignVec>();
        public List<CadreImageAligns> AlignList = new List<CadreImageAligns>();
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;

            path = @"x:\ARTIST\Ilya Kuvshinov\PNG\";

            string dsc = "Ilya_Kuvshinov";
            string src = null;
            string fn = null;
            VNPCPersType type = VNPCPersType.ArtCG;
            // Heads
            //for (int i = 1; i <= 8; i++)
            //{                
            //    src = $"Head_IlyaKuvshinov_{i.ToString("D3")}"; fn = $"{i.ToString("D3")}.png";
            //    AlignData[] imd1 = new AlignData[] { new AlignData(src, new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 }) };
            //    CadreAlignPack cap1 = AddIm(src, VNPCPersType.ArtCG, dsc, path, fn, data, imd1);
            //    cap1.MarkList.Add("Raw data");
            //}

            //AlignData[] imd = new AlignData[] {
            //    new AlignData($"Head_IlyaKuvshinov_001"),
            //    new AlignData("Evil_BODY_1710085001",new DifData() {X = 460, Y = 85, sX = 980, sY = 980, Flip=0})
            //};
            //CadreAlignPack cap = AddIm(src, VNPCPersType.ArtCG, dsc, path, fn, data, imd);
            //cap.MarkList.Add("Head1");

            path = @"d:\Process2+\! Comix\ilya kuvshinov\PNG\";
            ImageAlignVec newIAV = null;
            ImageRelDifVec IRDVec = null;
            CadreImageAligns CAL = new CadreImageAligns();
            DifData dd = null;

            src = $"Head_IlyaKuvshinov_016_CLEAN"; fn = $"016_CLEAN.png";
            newIAV = new ImageAlignVec() { Name = src, File = path + fn };
            newIAV.DefaultAlign = new DifData() { X = 100, Y = 100, sX = 500, sY = 500, Flip = 0 };
            ImageStorage.Add(newIAV);

            src = $"Head_IlyaKuvshinov_016_MOUTH"; fn = $"016_MOUTH.png";
            newIAV = new ImageAlignVec() { Name = src, File = path + fn };
            newIAV.DefaultAlign = new DifData() { X = 100, Y = 100, sX = 100, sY = 100, Flip = 0 };
            ImageStorage.Add(newIAV);

            AddAlign(
                new string[] { "Test Mark" },
                new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN"),
                new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN") { X = 318, Y = 514, sX = 85, sY = 85, Flip = 0  },
                }, true);

            AddAlign(
                new string[] { "TEST2" },
                new DifData[] {
                new DifData("Head_IlyaKuvshinov_016_CLEAN"){ X = 500, sX = 300, sY = 300, Rot = 20 },
                new DifData("Head_IlyaKuvshinov_016_MOUTH","Head_IlyaKuvshinov_016_CLEAN"),
                }, true);


        }

        private void AddAlign(string[] marks, DifData[] difs, bool installtoglobal = false)
        {
            CadreImageAligns CAL = new CadreImageAligns();
            CAL.MarkList.AddRange(marks);
            foreach (var dif in difs)
            {
                CAL.AlignList.Add(dif);
                if (installtoglobal && !string.IsNullOrEmpty(dif.Parent))
                {
                    AddToGlobalAlign(dif);
                }
            }
            AlignList.Add(CAL);
        }
        private void AddToGlobalAlign(DifData dd)
        {
            if (!string.IsNullOrEmpty(dd.Parent))
            {
                // get child storage items
                var storageitem = ImageStorage.Where(x => x.Name == dd.Name).FirstOrDefault();
                if (storageitem != null)
                {
                    // check if default align for that parent is not already assigned
                    var oldalign = storageitem.Parents.Where(x => x.ParentName == dd.Parent).FirstOrDefault();
                    if (oldalign == null)
                    {
                        // Get parent image align via default align and delta
                        seIm parIm = new seIm();
                        var pardefaultalgn = ImageStorage.Where(x => x.Name == dd.Parent).FirstOrDefault().DefaultAlign;
                        parIm.AssignFrom(pardefaultalgn); // only default
                        // Get child image align via default align and delta
                        seIm childIm = new seIm();
                        var childdefaultalgn = storageitem.DefaultAlign;
                        childIm.AssignFrom(childdefaultalgn); // default and delta
                        childIm.AssignFrom(dd);
                        // add align for that parent
                        ImageRelDifVec newalign = new ImageRelDifVec();
                        newalign.ParentName = dd.Parent;
                        newalign.CreateDifProportions(parIm, childIm);
                        storageitem.Parents.Add(newalign);
                    }
                }
            }

        }
    }


    public class ImageAlignVec
    {
        public string Name;
        public string File;
        public DifData DefaultAlign;
        public List<ImageRelDifVec> Parents = new List<ImageRelDifVec>();
    }

    public class ImageRelDifVec
    {
        public ImageRelDifVec() { }
        public string ParentName;
        public string AlignVariant;
        public int parY = 0;
        public int dX = 0;
        public int dY = 0;
        public int psX = 1;
        public int psY = 1;
        public float dsX = 1;
        public float dsY = 1;
        public int Rot = 0;
        public int parRot = 0;
        public int dFlip = 0;
        public int Flip = 0;

        internal void CreateDifProportions(seIm parIm, seIm childIm)
        {
            if (parIm == null) return;
            if (childIm == null) return;
            dX = childIm.X - parIm.X;
            dY = childIm.Y - parIm.Y;

            Rot = childIm.Rot;
            parRot = parIm.Rot;

            dFlip = childIm.Flip - parIm.Flip;
            Flip = childIm.Flip;
            dsX = ((float)childIm.sX / (float)parIm.sX);
            dsY = ((float)childIm.sY / (float)parIm.sY);
            psX = parIm.sX;
            psY = parIm.sY;
        }

        internal void ApplyTo(seIm target, seIm actualParent)
        {
            target.sX = Convert.ToInt32(this.dsX * actualParent.sX);
            target.sY = Convert.ToInt32(this.dsY * actualParent.sY);

            // Parent rotation
            {
                target.ParentRotations.Clear();
                if (actualParent.ParentRotations != null)
                {
                    target.ParentRotations.AddRange(actualParent.ParentRotations);
                }
                if (this.parRot != actualParent.Rot)
                {
                    target.ParentRotations.Add(new Tuple<string, int>(actualParent.Name, actualParent.Rot - parRot));
                }
            }

            { // X,Y coord
                int xDif = this.dX;
                int yDif = this.dY;

                target.X = (int)(this.dX * ((float)actualParent.sX / psX));
                target.Y = (int)(this.dY * ((float)actualParent.sY / psY));

                target.X = target.X + actualParent.X;
                target.Y = target.Y + actualParent.Y;
            }
            target.Rot = this.Rot;
            target.Flip = this.Flip;
        }
    }

    public class CadreImageAligns
    {
        public List<DifData> AlignList = new List<DifData>();
        public List<string> MarkList = new List<string>();
        public CadreImageAligns()
        {

        }
    }
}
