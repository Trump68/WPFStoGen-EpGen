using MVVMApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVMApp.ViewModels
{
    public static class VMBusinessLogic
    {
        internal static ICollectionView GetCadres(string ScenarioFileName, ICollectionView cadres)
        {
            if (cadres == null)
            {               
                cadres = CollectionViewSource.GetDefaultView(new ObservableCollection<ECadreViewModel>());
            }

            //List<ECadre> list = ECadreStorage.LoadFile(ScenarioFileName);
            //if (list!=null)
            //{

            //    (cadres.SourceCollection as ObservableCollection<ECadreViewModel>).Clear();
            //    list.ForEach(x => 
            //    {
            //        ECadreViewModel newmodel = new ECadreViewModel(x);
            //        (cadres.SourceCollection as ObservableCollection<ECadreViewModel>).Add(newmodel);
            //    });
                
            //}
            return cadres;
        }
        internal static void AddCadre(ICollectionView cadres,Model.ECadre cadre)
        {
            ECadreViewModel newmodel = new ECadreViewModel(cadre);  
            (cadres.SourceCollection as ObservableCollection<ECadreViewModel>).Add(newmodel);
        }
        internal static void DeleteCadre(ICollectionView cadres)
        {
            (cadres.SourceCollection as ObservableCollection<ECadreViewModel>).Remove(cadres.CurrentItem as ECadreViewModel);
          
        }
      
        internal static void SaveCadres(string scenarioFileName, ICollectionView eCadres)
        {        
            string savefilename = scenarioFileName;
            //ECadreStorage.SaveFile((eCadres.SourceCollection as ObservableCollection<ECadreViewModel>).Select(x => x.ecadre).ToList(), savefilename);
        }

        internal static void CreateFimmografy()
        {
            /*
           string[] files = Directory.GetFiles(@"d:\Process2\!!Data\! STOGEN Novelles\JAV\!COMMON\COVERS\");
           foreach (string file in files)
           {
                string fn = Path.GetFileName(file);
                string[] vals = fn.Split('-');
                if (vals.Length == 3)
                {
                    if (vals[1].Length == 2)
                    {
                        vals[1] = "0" + vals[1];
                        string newfn = string.Join("-", vals);
                        string newfile = file.Replace(fn, newfn);
                        File.Move(file, newfile);
                    }
                }
           }
           */
            List<string> resultlist = new List<string>();
            List<string> resultlist2 = new List<string>();
            string IdentMark = $"\t\t\t";
            string IdentData = $"\t\t\t\t";
            string[] files = Directory.GetFiles(@"d:\Process2\!!Data\! STOGEN Novelles\JAV\!COMMON\COVERS\");
            foreach (string file in files)
            {
                string fn = Path.GetFileNameWithoutExtension(file);
                string[] vals = fn.Split('-');
                if (vals.Length == 3)
                {
                    string s = string.Empty;
                    resultlist.Add(s);
                    s = $@"{IdentMark}PartSta#{vals[2]}-{vals[0]}-{vals[1]}";
                    resultlist.Add(s);
                    s = $@"{IdentData}MainPics={file};SizeX=-2;SizeY=-2;X=-0;Y=0;Level=1";
                    resultlist.Add(s);
                    s = $@"{IdentData}#ScenarioBG_Music#";
                    resultlist.Add(s);
                    s = $@"{IdentData}#T3#{vals[0]}-{vals[1]}-{vals[2]}";
                    resultlist.Add(s);
                    s = $@"{IdentMark}PartEnd#{vals[2]}-{vals[0]}-{vals[1]}";
                    resultlist.Add(s);

                    string s1 = $@"{IdentMark}AddNewSet(desr, '{vals[2]}-{vals[0]}-{vals[1]}', FPATH + @'AutoFilmografy.txt~{vals[2]}-{vals[0]}-{vals[1]}','{vals[2]}', '{vals[0]}', null, null);";
                    resultlist2.Add(s1.Replace(@"'",@""""));
                }
            }
            File.WriteAllText(@"d:\Process2\!!Data\! STOGEN Novelles\JAV\!ALL JAV\AutoFilmografy.txt", string.Join(Environment.NewLine, resultlist.ToArray()), Encoding.UTF8);
            File.WriteAllText(@"d:\Process2\!!Data\! STOGEN Novelles\JAV\!ALL JAV\AutoClassData.txt", string.Join(Environment.NewLine, resultlist2.ToArray()), Encoding.UTF8);
        }
    }
}
