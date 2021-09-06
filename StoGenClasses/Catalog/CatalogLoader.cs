using EPCat.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Catalog
{
    public class CatalogLoader
    {
        static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
        public static int CreateUpdateFromPassport(string passportPath, ref List<EpItem> list, bool IsSynchPosterAllowed, string CurrentCatalog, string BackupCatalog)
        {
            int result = 0;
            List<string> passport = new List<string>(File.ReadAllLines(passportPath));
            if (passport != null)
            {

                EpItem item = EpItem.GetFromPassport(passport, passportPath);

                if (item.GID == null || Guid.Empty.Equals(item.GID))
                {
                    item.GID = Guid.NewGuid();
                    item.Edited = true;

                }

                string dirname = Path.GetDirectoryName(passportPath);
                if (string.IsNullOrEmpty(item.Name))
                {
                    if (passportPath.Contains(@"/HEN/"))
                        item.Catalog = "HEN";
                    else if (passportPath.Contains(@"/MOV/"))
                        item.Catalog = "MOV";
                    else if (passportPath.Contains(@"/AMA/"))
                        item.Catalog = "AMA";
                    else if (passportPath.Contains(@"/JAV/"))
                        item.Catalog = "JAV";
                    else if (passportPath.Contains(@"/WEB/"))
                        item.Catalog = "WEB";
                    else if (passportPath.Contains(@"/PTD/"))
                        item.Catalog = "PTD";
                    else if (passportPath.Contains(@"/PRS/"))
                        item.Catalog = "PRS";
                    else if (passportPath.Contains(@"/COM/"))
                        item.Catalog = "COM";


                    item.Name = UppercaseWords(Path.GetFileName(dirname));
                    if (string.IsNullOrEmpty(item.Director) && item.Catalog == "HEN" && item.Kind == "Hentai Artist")
                    {
                        string director = Directory.GetParent(dirname).Name;
                        item.Director = UppercaseWords(director);
                    }
                    else if (string.IsNullOrEmpty(item.Studio) && item.Catalog == "HEN" && item.Kind == "GameCG")
                    {
                        string studio = Directory.GetParent(dirname).Name;
                        item.Studio = studio.ToUpper();
                    }
                }

                // JAV person rating                
                StarRating.SetRating(item);


                item.SourceFolderExist = true;
                // size
                var filesmp3 = Directory.GetFiles(dirname, "*.m4v").ToList();
                long s = 0;
                int d = 1000000;
                bool isUncensored = false;
                bool isUncensoredByMe = false;
                foreach (string fn in filesmp3)
                {
                    string pf = fn.ToUpper();

                    if (pf.Contains("UNCENSOREDBM"))
                    {
                        isUncensoredByMe = true;
                    }
                    else if (pf.Contains("UNCENSORED"))
                    {
                        isUncensored = true;
                    }
                    try
                    {
                        FileInfo fi = new FileInfo(fn);
                        s += fi.Length;
                        item.M4V += 1;
                    }
                    catch (Exception)
                    {
                        // path too long exception
                        //throw;
                    }
                }
                if (s > 0)
                    item.Size = Convert.ToInt32((s / d));


                var existingItem = list.Where(x => x.GID == item.GID).FirstOrDefault();

                if (existingItem == null)
                {
                    if (string.IsNullOrEmpty(item.Type) || (!item.Type.ToUpper().Contains("OMNIBUS")))
                    {
                        if (string.IsNullOrEmpty(item.Kind) || (!item.Kind.ToUpper().Contains("SKIP")))
                        {
                            if (!string.IsNullOrEmpty(item.Star))
                            {
                                if (string.IsNullOrEmpty(item.Name))
                                {
                                    string name = Path.GetFileName(Path.GetDirectoryName(passportPath)).ToLower();
                                    TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                                    item.Name = cultInfo.ToTitleCase(name);
                                    item.Edited = true;
                                }
                                if (isUncensoredByMe)
                                    item.Kind = "UNCBM";
                                else if (isUncensored)
                                    item.Kind = "UNC";
                                list.Add(item);
                                Console.WriteLine($"{item.Name} - new! {AddedTotal}");
                                result = 1;
                            }
                        }
                    }
                }
                else
                {
                    if (isUncensoredByMe && (string.IsNullOrEmpty(existingItem.Kind) || existingItem.Kind != "UNCBM"))
                    {
                        item.Kind = "UNCBM";
                        item.LastEdit++;
                    }
                    else if (isUncensored && (string.IsNullOrEmpty(existingItem.Kind) || existingItem.Kind != "UNC"))
                    {
                        item.Kind = "UNC";
                        item.LastEdit++;
                    }
                    if (existingItem.LastEdit < item.LastEdit)
                    {
                        existingItem.UpdateFrom(item);
                    }
                    else
                    {
                        // always
                        existingItem.Size = item.Size;
                        existingItem.M4V = item.M4V;
                        existingItem.SetItemPath(item.ItemPath);
                        existingItem.SourceFolderExist = item.SourceFolderExist;
                        existingItem.PersonKind = item.PersonKind;
                    }

                }
                if (item.Edited)
                {
                    UpdateItem(item);
                }

                //Backup
                if (!string.IsNullOrEmpty(BackupCatalog))
                {
                    bool dod = false;
                    if (item.Kind == "UNCBM")
                    {
                        dod = true;
                    }
                    else if (item.Kind == "UNC")
                    {
                        dod = true;
                    }
                    else if (!string.IsNullOrEmpty(item.Star))
                    {
                        var vals = item.Star.Split(',');
                        if (vals.Any(x => CatalogLoader.BACKUP_ACTRESS_LIST.Contains(x)))
                        {
                            dod = true;
                        }
                    }

                    if (dod)
                    {
                        string targetPath = Path.Combine(BackupCatalog, item.Serie, item.Name);
                        List<string> existingFiles = new List<string>();
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }
                        else
                        {
                            existingFiles = Directory.GetFiles(targetPath, "*.m4v").ToList();
                            foreach (string fn in existingFiles)
                            {
                                string file = Path.GetFileName(fn);
                                string filedest = Path.Combine(dirname, file);
                                if (!File.Exists(filedest))
                                {
                                    Console.WriteLine($"Delete file:{file}");
                                    File.Delete(fn);
                                }
                            }
                        }
                        foreach (string fn in filesmp3)
                        {
                            string file = Path.GetFileName(fn);
                            string filedest = Path.Combine(targetPath, file);
                            if (!File.Exists(filedest))
                            {
                                Console.WriteLine($"Backup file:{file}");
                                File.Copy(fn, filedest, false);
                            }
                        }

                    }
                }
                if (IsSynchPosterAllowed)
                {
                    //poster
                    bool copyPoster = false;
                    bool reversecopyPoster = false;
                    string dirPoster = EpItem.GetCatalogPosterDir(CurrentCatalog);
                    string newPostername = Path.Combine(dirPoster, $"{item.GID}.jpg");

                    if (existingItem == null)
                    {
                        copyPoster = true;
                    }
                    else
                    {
                        if (existingItem.LastEdit < item.LastEdit)
                        {
                            copyPoster = true;
                        }
                        else
                        {
                            copyPoster = !File.Exists(newPostername);
                            reversecopyPoster = !copyPoster;
                        }
                    }
                    if (copyPoster)
                    {
                        bool posterExist = File.Exists(item.PosterPath);
                        if (posterExist)
                        {
                            try
                            {
                                File.Copy(item.PosterPath, newPostername, true);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    else if (reversecopyPoster)
                    {
                        bool posterExist = File.Exists(newPostername);
                        if (posterExist)
                        {
                            try
                            {
                                if (!File.Exists(item.PosterPath))
                                    File.Copy(newPostername, item.PosterPath, false);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static void UpdateItem(EpItem item)
        {
            if (!Directory.Exists(Path.GetDirectoryName(item.ItemPath))) return;
            List<string> passportData = EpItem.SetToPassport(item);
            File.WriteAllLines(item.ItemPath, passportData);
        }
        public static int AddedTotal = 0;
        public static List<string> BACKUP_ACTRESS_LIST;

        public static void UpdateFolder(string parameters, ref List<EpItem> list, bool isCheck, bool IsSynchPosterAllowed, string BackupCatalog, string CurrentCatalog, bool inner)
        {
            int result = 0;
            string itemPath = parameters.ToUpper();
            if (!JAV.FoldersToUpdate.Contains("ALL") && !JAV.FoldersToUpdate.Contains("All"))
            {
                if (isCheck && !inner)
                {
                    string dirname = Path.GetFileName(itemPath);

                    if (JAV.FoldersToUpdate.Exists(x => itemPath.Contains(x)))
                    {
                        if (JAV.FoldersToUpdate.Exists(x => dirname == x))
                        {
                            inner = true;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            isCheck = true;


            if (!Directory.Exists(itemPath)) return;
            //Console.WriteLine($"Update folder {itemPath}..");
            List<string> passportList = Directory.GetFiles(itemPath, EpItem.p_PassportName).ToList();
            foreach (var passport in passportList)
            {
                AddedTotal = AddedTotal + CatalogLoader.CreateUpdateFromPassport(passport, ref list, IsSynchPosterAllowed, CurrentCatalog, BackupCatalog);
            }
            //result = added;
            //if (added > 0)
            //    Console.WriteLine($"Added {added} !");
            List<string> dirList = Directory.GetDirectories(itemPath).ToList();
            foreach (var dir in dirList)
            {
                UpdateFolder(dir, ref list, isCheck, IsSynchPosterAllowed, BackupCatalog, CurrentCatalog, inner);
            }
        }
        public static List<EpItem> LoadCatalog(string parameters)
        {
            List<EpItem> list = new List<EpItem>();
            string itemPath = parameters.ToLower();
            string dir = EpItem.GetCatalogPosterDir(itemPath);
            EpItem.CatalogPosterDir = dir;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (File.Exists(itemPath))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<EpItem>));
                try
                {
                    using (var sr = new StreamReader(itemPath))
                    {
                        list = serializer.Deserialize(sr) as List<EpItem>;
                    }
                }
                catch { }
            }
            return list;
        }
    }
}
