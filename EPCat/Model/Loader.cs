using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPCat.Model
{
    public class Loader
    {
        static string c_PrepareFolder = "PREPARE FOLDER ";

        static string c_UpdateFolder = "UPDATE FOLDER ";
        static string c_UpdateCapsFolder = "UPDATE CAPS FOLDER ";


        static string c_LoadCatalog = "LOAD CATALOG ";
        //static string c_LoadCapsCatalog = "LOAD CAPS CATALOG ";

        static string c_MoveFiles = "MOVE FILES ";
        static string c_SynchFiles = "SYNCH FILES ";
        static string c_CreatePassport = "CREATE PASSPORT ";

        static string c_AddDict = "ADD DICT ";
        static string c_AddCapsDict = "ADD CAPS_DICT ";

        static string c_NameDict = "NAME DICT ";
        static string c_NameCapsDict = "NAME CAPS_DICT ";

        private List<EpItem> Source;
        private List<CapsItem> CaspSource;
        public List<EpItem> ProcessScriptFile(List<EpItem> sourceList, List<CapsItem> capsList)
        {
            //DoTempWork1();
            //DoTempwork2(@"d:\!CATALOG\MOV\");
            //return null;
            EpItem.DictionaryData.Dict_Class.Clear();
            EpItem.DictionaryData.Dict_Name.Clear();
            CapsItem.DictionaryData.Dict_Class.Clear();
            CapsItem.DictionaryData.Dict_Name.Clear();
            Source = sourceList;
            CaspSource = capsList;
            CaspSource.Clear();
            string commandf = "commandscript.txt";
            string[] cla = Environment.GetCommandLineArgs();
            if (cla.Length > 1)                commandf = cla[1];

            List<string> LogList = new List<string>(File.ReadAllLines(commandf));
            foreach (var item in LogList)
            {
                if (item.TrimStart().StartsWith("//")) continue;
                ParseLine(item);
            }
            return Source;
        }
        private void DoTempWork()
        {
            string toPath = @"d:\Process2\!!Data\EroFilms\! To Convert\";
            string fromPath = @"d:\uTorrent\";
            var rootdir = Directory.GetDirectories(fromPath, "JAP *", SearchOption.TopDirectoryOnly).ToList();
            rootdir.AddRange(Directory.GetDirectories(fromPath, "BRA *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "ITA *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "FRA *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "USA *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "GBR *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "TWN *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "SWZ *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "KOR *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "DEN *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "HKG *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "NLD *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "CAN *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "HSP *", SearchOption.TopDirectoryOnly).ToList());
            //var rootdir = Directory.GetDirectories(fromPath, "JAP *|BRA *|ITA *|FRA *|USA *|UK *|TWN *|SWZ *|KOR *", SearchOption.TopDirectoryOnly).ToList();
            foreach (var item in rootdir)
            {
                var files = Directory.GetFiles(item, "*.mkv", SearchOption.TopDirectoryOnly).ToList();
                files.AddRange(Directory.GetFiles(item, "*.avi", SearchOption.TopDirectoryOnly).ToList());
                files.AddRange(Directory.GetFiles(item, "*.mp4", SearchOption.TopDirectoryOnly).ToList());
                files.AddRange(Directory.GetFiles(item, "*.wmv", SearchOption.TopDirectoryOnly).ToList());

                
                foreach (var fn in files)
                {
                    string newname = Path.GetFileName(item);
                    string newPath = Path.Combine(toPath, newname + ".avi");
                    File.Move(fn, newPath);

                }
                if (files.Any()) Directory.Delete(item);
            }
        }

        private void DoTempWork1()
        {
            string fromPath = @"d:\uTorrent\! ToProcess\";
            string toPath = @"d:\!CATALOG\";
            DoTempWork1_OneCountry("JAP", fromPath, toPath);
            DoTempWork1_OneCountry("CHE", fromPath, toPath);
            DoTempWork1_OneCountry("FRA", fromPath, toPath);
            DoTempWork1_OneCountry("GBR", fromPath, toPath);
            DoTempWork1_OneCountry("TWN", fromPath, toPath);
            DoTempWork1_OneCountry("KOR", fromPath, toPath);
            DoTempWork1_OneCountry("ITA", fromPath, toPath);
            DoTempWork1_OneCountry("USA", fromPath, toPath);
            DoTempWork1_OneCountry("HKG", fromPath, toPath);
            DoTempWork1_OneCountry("SWZ", fromPath, toPath);
            DoTempWork1_OneCountry("CAN", fromPath, toPath);
            DoTempWork1_OneCountry("NLD", fromPath, toPath);
            DoTempWork1_OneCountry("HSP", fromPath, toPath);
            DoTempWork1_OneCountry("THA", fromPath, toPath);
            DoTempWork1_OneCountry("GER", fromPath, toPath);
            DoTempWork1_OneCountry("CHN", fromPath, toPath);
            DoTempWork1_OneCountry("PHI", fromPath, toPath);
            DoTempWork1_OneCountry("BRA", fromPath, toPath);
            DoTempWork1_OneCountry("AUS", fromPath, toPath);

            DoTempWork1_OneCountry("$WEB", fromPath, toPath);
            DoTempWork1_OneCountry("$JAV", fromPath, toPath);
            DoFOLDER(fromPath, toPath);
        }
        private void DoFOLDER(string fromPath, string toDir)
        {
            /* 
             * $01-Catalog
             * $02-Star 
             * $03-Kind
             * $04-Serie
             * $05-Country
             * $06-Year
             * $01 JAV $02  $04  $ 
             */

            var dirs = Directory.GetDirectories(fromPath, "$*", SearchOption.TopDirectoryOnly).ToList();
            foreach (var dir in dirs)
            {
                string toPath = toDir;
                EpItem item = new EpItem(0);
                string dn = Path.GetFileName(dir);
                List<string> tokens = dn.Split('$').ToList();
                foreach (string tok in tokens)
                {
                    if (string.IsNullOrEmpty(tok.Trim()))
                        continue;
                    string mark = tok.Substring(0, 2);
                    string val = tok.Remove(0,2).Trim();
                    if (mark == "01")
                    {
                        item.Catalog = val;
                    }
                    else if (mark == "02")
                    {
                        item.Star = val;
                    }
                    else if (mark == "03")
                    {
                        item.Kind = val;
                    }
                    else if (mark == "04")
                    {
                        item.Serie = val;
                    }
                    else if (mark == "05")
                    {
                        item.Country = val;
                    }
                    else if (mark == "06")
                    {
                        item.Year = Convert.ToInt32(val);
                    }
                    else
                    {
                        item.Name = tok.Trim();
                    }
                }

                if (!string.IsNullOrEmpty(item.Catalog))
                    toPath = $@"{toPath}\{item.Catalog}";
                if (!string.IsNullOrEmpty(item.Serie))
                    toPath = $@"{toPath}\{item.Serie}";

                if (!Directory.Exists(toPath))
                     Directory.CreateDirectory(toPath);
                string newname = Path.Combine(toPath, item.Name);
                Directory.Move(dir, newname);
                List<string> lines = EpItem.SetToPassport(item);
                File.WriteAllLines(Path.Combine(newname, EpItem.p_PassportName), lines);
            }
        }
        private void DoTempWork1_OneCountry(string mark,string fromPath, string toPath)
        {
            string Country = mark;
            string Catalog = "MOV";
            string Studio = string.Empty;
            string Actors = string.Empty;
            string Serie = string.Empty;
            int Year = 0;
            

            var files = Directory.GetFiles(fromPath, "*.m4v", SearchOption.TopDirectoryOnly).ToList();
            foreach (var fn in files)
            {
                string source = fn;
                string fnwe = Path.GetFileName(fn);
                if (fnwe.StartsWith($"[{Country}]"))
                {
                    string newfnwe = $"{Country} {fnwe.Replace($"[{Country}]", string.Empty)}";
                    File.Move(Path.Combine(fromPath, fnwe), Path.Combine(fromPath, newfnwe));
                    fnwe = newfnwe;
                    source = newfnwe;
                }

                if (fnwe.ToUpper().StartsWith($"{mark} "))
                {

                    string nfm = fnwe.Remove(0, 4);
                    nfm = nfm.Replace(".m4v", string.Empty);
                    nfm = nfm.Trim();
                    bool ok = false;

                    if (fnwe.ToUpper().StartsWith("$"))
                    {
                        Country = string.Empty;
                        Catalog = mark.Replace("$", string.Empty);
                        var items = nfm.Split(' ');
                        if (items[0].Contains("[") && items[0].Contains("]"))
                            Studio = items[0].Replace("[", string.Empty).Replace("]", string.Empty).Trim();

                        ok = true;
                    }
                    else
                    {
                        string yearstr = nfm.Substring(0, 4);
                        if (int.TryParse(yearstr, out Year))
                        {
                            if (Year > 1949 && Year < 2025)
                            {
                                nfm = nfm.Remove(0, 4);
                                ok = true;
                            }
                        }
                    }                    

                    if (nfm.Contains("{") && nfm.Contains("}"))
                    {
                        int fi = nfm.IndexOf('{') + 1;
                        int si = nfm.IndexOf('}') - 1;
                        Actors = nfm.Substring(fi, si - fi + 1);
                        nfm = nfm.Replace("{"+Actors+"}", string.Empty).Trim();
                    }

                    if (Catalog == "MOV" && nfm.Contains("[") && nfm.Contains("]"))
                    {
                        int fi = nfm.IndexOf('[') + 1;
                        int si = nfm.IndexOf(']') - 1;
                        Studio = nfm.Substring(fi, si - fi + 1);
                    }

                    if (Catalog == "JAV" && nfm.Contains("[") && nfm.Contains("]"))
                    {
                        Studio = string.Empty;
                        int fi = nfm.IndexOf('[') + 1;
                        int si = nfm.IndexOf(']') - 1;
                        Serie = nfm.Substring(fi, si - fi + 1);
                        nfm = nfm.Replace("[" + Serie + "]", string.Empty).Trim();
                    }

                    if (ok)
                    {
                        string Name = nfm.Trim();
                        string newPath = string.Empty;
                        if (Catalog == "MOV")
                        {
                            newPath = Path.Combine(toPath, Catalog, Year.ToString());
                            if (Name.Contains("-"))
                            {
                                while (Char.IsDigit(Name.Last()))
                                {
                                    Name = Name.Remove(Name.Length - 1);
                                }
                                if (Name.Last() == '-') Name = Name.Remove(Name.Length - 1);
                                Name = Name.Trim();
                            }
                        }
                        else if(Catalog == "JAV")
                        {
                            newPath = Path.Combine(toPath, Catalog, Serie);
                        }
                        else
                        {
                            newPath = Path.Combine(toPath, Catalog, Studio);
                        }


                        if (!Directory.Exists(newPath))
                        {
                            Directory.CreateDirectory(newPath);
                        }
                        if (Directory.Exists(newPath))
                        {
                            newPath = Path.Combine(newPath, Name);
                            if (!Directory.Exists(newPath))
                            {
                                Directory.CreateDirectory(newPath);
                                EpItem item = new EpItem(0);
                                item.Name = Name;
                                item.Catalog = Catalog;
                                item.Country = Country;
                                item.Year = Year;
                                item.Studio = Studio;
                                item.Star = Actors;
                                item.Serie = Serie;
                                List<string> lines = EpItem.SetToPassport(item);
                                File.WriteAllLines(Path.Combine(newPath, EpItem.p_PassportName), lines);
                            }

                            File.Move(source, Path.Combine(newPath, Name) + ".m4v");
                        }
                    }
                }
            }
        }
        private void DoTempwork2(string passportPath)
        {            
            List<string> dirList = Directory.GetDirectories(passportPath).ToList();
            foreach (var dir in dirList)
            {
                DoTempwork2(dir);
            }

            List<string> passportList = Directory.GetFiles(passportPath, EpItem.p_PassportName).ToList();
            foreach (var pass in passportList)
            {
                List<string> passport = new List<string>(File.ReadAllLines(pass));
                if (passport != null)
                {
                    EpItem item = EpItem.GetFromPassport(passport);
                    string dirname = Path.GetDirectoryName(passportPath);
                    string name = Path.GetFileName(passportPath);
                    if (item.Catalog != "JAV")
                    {
                        if (!name.StartsWith("["))
                        {
                            string newdirname = Path.Combine(dirname, $"[{item.Country}] {name}");
                            Directory.Move(passportPath, newdirname);
                        }
                    }
                }
                return;
            }
        }
        private string CurrentCatalog;
        internal void SaveCatalog()
        {
            if (string.IsNullOrEmpty(CurrentCatalog)) return;            
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<EpItem>));
            using (var writer = new StreamWriter(CurrentCatalog))
            {
                serializer.Serialize(writer, Source);
            }
            foreach (EpItem item in Source)
            {
                if (Directory.Exists(item.ItemDirectory))
                {
                    List<string> lines = EpItem.SetToPassport(item);
                    File.WriteAllLines(Path.Combine(item.ItemDirectory, EpItem.p_PassportName), lines);
                }
            }
        }

        internal void ParseLine(string line)
        {
            line = line.Trim();
            if (line.StartsWith(c_PrepareFolder))
            {
                PrepareFolder(line.Replace(c_PrepareFolder, string.Empty),0,2);
            }
            else if (line.StartsWith(c_UpdateFolder))
            {
                UpdateFolder(line.Replace(c_UpdateFolder, string.Empty));
            }
            else if (line.StartsWith(c_UpdateCapsFolder))
            {
                UpdateCapsFolder(line.Replace(c_UpdateCapsFolder, string.Empty));
            }
            else if (line.StartsWith(c_LoadCatalog))
            {
                LoadCatalog(line.Replace(c_LoadCatalog, string.Empty));
            }
            else if (line.StartsWith(c_MoveFiles))
            {
                MoveFiles(line.Replace(c_MoveFiles, string.Empty));
            }
            else if (line.StartsWith(c_SynchFiles))
            {
                SynchFiles(line.Replace(c_SynchFiles, string.Empty));
            }
            else if (line.StartsWith(c_CreatePassport))
            {
                CreatePassport(line.Replace(c_CreatePassport, string.Empty));
            }
            else if (line.StartsWith(c_AddDict))
            {
                AddDict(line.Replace(c_AddDict, string.Empty));
            }
            else if (line.StartsWith(c_NameDict))
            {
                NameDict(line.Replace(c_NameDict, string.Empty));
            }
            else if (line.StartsWith(c_CreatePassport))
            {
                CreatePassport(line.Replace(c_CreatePassport, string.Empty));
            }
            else if (line.StartsWith(c_AddCapsDict))
            {
                AddCapsDict(line.Replace(c_AddCapsDict, string.Empty));
            }
            else if (line.StartsWith(c_NameCapsDict))
            {
                NameCapsDict(line.Replace(c_NameCapsDict, string.Empty));
            }
        }
        private void PrepareFolder(string parameters,int CurrentLevel, int ProcessLevel)
        {
            string itemPath = parameters.ToLower();
            if (CurrentLevel == ProcessLevel)
            {
                List<string> files = Directory.GetFiles(itemPath, EpItem.p_PassportName, SearchOption.TopDirectoryOnly).ToList();
                if (files.Any()) return;
                //List<string> lines = EpItem.SetToPassport(item);
                List<string> lines = new List<string>();
                File.WriteAllLines(Path.Combine(itemPath, EpItem.p_PassportName), lines);
                if (!Directory.Exists(Path.Combine(itemPath, "EVENTS")))
                {
                    Directory.CreateDirectory(Path.Combine(itemPath, "EVENTS"));
                }

                return;
            }
            List<string> dirList = Directory.GetDirectories(itemPath).ToList();
            foreach (var dir in dirList)
            {
                PrepareFolder(dir, (CurrentLevel+1), ProcessLevel);
            }
        }

        private void NameDict(string parameters)
        {
            string[] vals = parameters.Split(';');
            int dictIndex = Convert.ToInt32(vals[0].Trim());
            string dictName = vals[1];
            if (!EpItem.DictionaryData.Dict_Name.ContainsKey(dictIndex)) EpItem.DictionaryData.Dict_Name.Add(dictIndex, string.Empty);
            EpItem.DictionaryData.Dict_Name[dictIndex] = dictName;
        }
        private void AddDict(string parameters)
        {
            string[] vals = parameters.Split(';');
            int dictName = Convert.ToInt32(vals[0].Trim());
            int dictVal = Convert.ToInt32(vals[1].Trim());
            string dictDescr = vals[2];
            if (!EpItem.DictionaryData.Dict_Class.ContainsKey(dictName)) EpItem.DictionaryData.Dict_Class.Add(dictName, new List<ClassItem>());
            EpItem.DictionaryData.Dict_Class[dictName].Add(new ClassItem() { Val = dictVal, Description = dictDescr });        
        }
        private void NameCapsDict(string parameters)
        {
            string[] vals = parameters.Split(';');
            int dictIndex = Convert.ToInt32(vals[0].Trim());
            string dictName = vals[1];
            if (!CapsItem.DictionaryData.Dict_Name.ContainsKey(dictIndex)) CapsItem.DictionaryData.Dict_Name.Add(dictIndex, string.Empty);
            CapsItem.DictionaryData.Dict_Name[dictIndex] = dictName;
        }
        private void AddCapsDict(string parameters)
        {
            string[] vals = parameters.Split(';');
            int dictName = Convert.ToInt32(vals[0].Trim());
            int dictVal = Convert.ToInt32(vals[1].Trim());
            string dictDescr = vals[2];
            if (!CapsItem.DictionaryData.Dict_Class.ContainsKey(dictName)) CapsItem.DictionaryData.Dict_Class.Add(dictName, new List<ClassItem>());
            CapsItem.DictionaryData.Dict_Class[dictName].Add(new ClassItem() { Val = dictVal, Description = dictDescr });
        }

        // create passport
        private void CreatePassport(string parameters)
        {
            string pathTo = parameters.ToLower();
            if (!Directory.Exists(Path.GetPathRoot(pathTo))) return;
            CreatePassportTo(pathTo);
        }
        private void CreatePassportTo(string ToPath)
        {
            if (!Directory.Exists(ToPath)) return;
            

            List<string> files = Directory.GetFiles(ToPath, EpItem.p_PassportName, SearchOption.TopDirectoryOnly).ToList();

            if (!files.Any())
            {
                List<string> movies = Directory.GetFiles(ToPath, "*.m4v", SearchOption.TopDirectoryOnly).ToList();
                if (movies.Any())
                {
                    EpItem item = new EpItem(0);
                    item.Name = Path.GetFileName(ToPath);
                    List<string> lines = EpItem.SetToPassport(item);
                    File.WriteAllLines(Path.Combine(ToPath, EpItem.p_PassportName), lines);
                }
            }

            List<string> dirs = Directory.GetDirectories(ToPath).ToList();
            foreach (var item in dirs)
            {
                CreatePassportTo(item);
            }
        }


        // synch files
        private void SynchFiles(string parameters)
        {
            string str = parameters.ToLower();
            string[] pars = str.Split(';');
            if (pars.Length == 3)
            {
                string mask = pars[0];
                string pathFrom = pars[1];
                string pathTo = pars[2];
                if (!Directory.Exists(Path.GetPathRoot(pathTo))) return;
                if (!Directory.Exists(pathFrom)) return;
                SychFileFromTo(mask, pathFrom, pathTo, false, true);
            }
        }
        private void MoveFiles(string parameters)
        {
            string str = parameters.ToLower();
            string[] pars = str.Split(';');
            if (pars.Length == 3)
            {
                string mask = pars[0];
                string pathFrom = pars[1];
                string pathTo = pars[2];
                if (!Directory.Exists(Path.GetPathRoot(pathTo))) return;
                if (!Directory.Exists(pathFrom)) return;
                SychFileFromTo(mask, pathFrom, pathTo, true, false);
            }
        }


        private void SychFileFromTo(string mask, string fromPath, string ToPath, bool isMove, bool isSynch)
        {
            List<string> files = mask.Split('|').SelectMany(filter => Directory.GetFiles(fromPath, filter, SearchOption.TopDirectoryOnly)).ToList();

            if (files.Any())
            {
                bool existingCheck = true;
                if (!Directory.Exists(ToPath))
                {
                    Directory.CreateDirectory(ToPath);
                    existingCheck = false;
                }
                foreach (var item in files)
                {
                    string fn = Path.GetFileName(item);
                    string newFilePath = Path.Combine(ToPath, fn);
                    bool fileExists = false;
                    if (existingCheck)
                    {
                        if (File.Exists(newFilePath))
                        {
                            fileExists = true;
                            DateTime oldcreation = File.GetLastWriteTime(newFilePath);
                            DateTime newcreation = File.GetLastWriteTime(item);
                            if (oldcreation == newcreation) continue;
                        }
                    }
                    File.Copy(item, newFilePath, true);
                    if (isMove && fn != EpItem.p_PassportName)
                    {
                        File.Delete(item);
                    }
                }
            }
            if (isSynch)
            {
                if (Directory.Exists(ToPath))
                {
                    List<string> filesDest = mask.Split('|').SelectMany(filter => Directory.GetFiles(ToPath, filter, SearchOption.TopDirectoryOnly)).ToList();
                    var filenamesSource = files.Select(x => Path.GetFileName(x)).ToList();
                    foreach (var fn in filesDest)
                    {
                        string filenameDest = Path.GetFileName(fn);
                        if (!filenamesSource.Contains(filenameDest)) File.Delete(fn);
                    }

                }
            }
            List<string> dirs = Directory.GetDirectories(fromPath).ToList();
            foreach (var item in dirs)
            {
                string newPath = Path.Combine(ToPath, Path.GetFileName(item));
                SychFileFromTo(mask, item, newPath, isMove, isSynch);
            }
            if (isSynch && Directory.Exists(ToPath))
            {
                List<string> dirsDest = Directory.GetDirectories(ToPath).ToList();
                var dirnamesSource = dirs.Select(x => Path.GetFileName(x)).ToList();
                foreach (var dn in dirsDest)
                {
                        string dirnameDest = Path.GetFileName(dn);
                        if (!dirnamesSource.Contains(dirnameDest)) Directory.Delete(dn,true);
                }
            }
        }

       


        private void LoadCatalog(string parameters)
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
            Source = list;
            CurrentCatalog = itemPath;
        }
        private void UpdateFolder(string parameters)
        {
            string itemPath = parameters.ToLower();
            if (!Directory.Exists(itemPath)) return;
            List<string> passportList = Directory.GetFiles(itemPath, EpItem.p_PassportName).ToList();
            foreach (var passport in passportList)
            {
                CreateUpdateFromPassport(passport);
            }
            List<string> dirList = Directory.GetDirectories(itemPath).ToList();
            foreach (var dir in dirList)
            {
                UpdateFolder(dir);
            }
        }
        private void UpdateCapsFolder(string parameters)
        {
            string itemPath = parameters.ToLower();
            List<string> passportList = Directory.GetFiles(itemPath, EpItem.p_PassportCapsName).ToList();
            passportList.AddRange(Directory.GetFiles(itemPath, EpItem.p_PassportEventsName));
            passportList.AddRange(Directory.GetFiles(itemPath, EpItem.p_PassportFiguresName));
            passportList.AddRange(Directory.GetFiles(itemPath, EpItem.p_PassportBackgroundName));
            passportList.AddRange(Directory.GetFiles(itemPath, EpItem.p_PassportCompositionName));
            passportList.AddRange(Directory.GetFiles(itemPath, EpItem.p_PassportPartsName));
            foreach (var passport in passportList)
            {
                CreateUpdateCapsFromPassort(passport);
            }
            List<string> dirList = Directory.GetDirectories(itemPath).ToList();
            foreach (var dir in dirList)
            {
                UpdateCapsFolder(dir);
            }
        }

        internal void UpdateItem(EpItem item)
        {
            if (!Directory.Exists(Path.GetDirectoryName(item.ItemPath))) return;
            List<string> passportData = EpItem.SetToPassport(item);            
            File.WriteAllLines(item.ItemPath, passportData);
        }

        private void CreateUpdateFromPassport(string passportPath)
        {
            List<string> passport = new List<string>(File.ReadAllLines(passportPath));
            if (passport != null)
            {
                EpItem item = EpItem.GetFromPassport(passport);
                item.ItemPath = passportPath;
                bool copyPoster = false;
                var existingItem = Source.Where(x => x.GID == item.GID).FirstOrDefault();

                string dirPoster = EpItem.GetCatalogPosterDir(CurrentCatalog);
                string newname = Path.Combine(dirPoster, $"{item.GID}.jpg");

                if (existingItem == null)
                {
                    if (string.IsNullOrEmpty(item.Name))
                    {                        
                        string name = Path.GetFileName(Path.GetDirectoryName(passportPath)).ToLower();
                        TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                        item.Name = cultInfo.ToTitleCase(name);
                    }
                    Source.Add(item);
                    UpdateItem(item);
                    copyPoster = true;
                }
                else
                {
                    if (existingItem.LastEdit < item.LastEdit)
                    {
                        existingItem.UpdateFrom(item);
                        copyPoster = true;
                    }
                    else
                    {
                        existingItem.ItemPath = item.ItemPath;
                        copyPoster = !File.Exists(newname);
                    }
                }
                if (copyPoster)
                {
                    bool posterExist = File.Exists(item.PosterPath);
                    if (posterExist)
                    {
                                                
                        File.Copy(item.PosterPath, newname, true);
                    }
                }
            }
        }

        private void CreateUpdateCapsFromPassort(string passportPath)
        {
            List<string> passport = new List<string>(File.ReadAllLines(passportPath));
            if (passport != null)
            {

                List<CapsItem> result = new List<CapsItem>();
                foreach (var line in passport)
                {
                    string term = line.Trim();
                    CapsItem item = CapsItem.GetFromPassport(term);
                    if (item != null)
                    {
                        string foldername = Path.GetFileNameWithoutExtension(passportPath).Split('_')[1];
                        item.GroupName = foldername;
                        item.PassportPath = passportPath;
                        item.ItemPath = Path.Combine(Path.GetDirectoryName(passportPath), foldername, item.Id);
                        result.Add(item);
                    }
                }
                result.ForEach(x => 
                  {
                    x.Parent = result.Where(p => p.Id == x.ParentId).FirstOrDefault();
                      if (x.Parent != null)
                      {
                          x.Parent.ChildList.Add(x);
                      }
                  }  
                );
                CaspSource.AddRange(result);
            }
        }


    }

}
        