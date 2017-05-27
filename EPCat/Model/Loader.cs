﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPCat.Model
{
    public class Loader
    {
        static string c_UpdateFolder = "UPDATE FOLDER ";
        static string c_LoadCatalog = "LOAD CATALOG ";
        static string c_MoveFiles = "MOVE FILES ";
        static string c_SynchFiles = "SYNCH FILES ";
        static string c_CreatePassport = "CREATE PASSPORT ";

        static string c_AddDict = "ADD DICT ";
        static string c_AddCapsDict = "ADD CAPS_DICT ";

        static string c_NameDict = "NAME DICT ";
        static string c_NameCapsDict = "NAME CAPS_DICT ";

        private List<EpItem> Source;
        public List<EpItem> ProcessScriptFile(List<EpItem> sourceList)
        {
            Source = sourceList;
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
            rootdir.AddRange(Directory.GetDirectories(fromPath, "UK *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "TWN *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "SWZ *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "KOR *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "DEN *", SearchOption.TopDirectoryOnly).ToList());
            rootdir.AddRange(Directory.GetDirectories(fromPath, "HKG *", SearchOption.TopDirectoryOnly).ToList());
            //var rootdir = Directory.GetDirectories(fromPath, "JAP *|BRA *|ITA *|FRA *|USA *|UK *|TWN *|SWZ *|KOR *", SearchOption.TopDirectoryOnly).ToList();
            foreach (var item in rootdir)
            {
                var files = Directory.GetFiles(item, "*.mkv", SearchOption.TopDirectoryOnly).ToList();
                files.AddRange(Directory.GetFiles(item, "*.avi", SearchOption.TopDirectoryOnly).ToList());
                files.AddRange(Directory.GetFiles(item, "*.mp4", SearchOption.TopDirectoryOnly).ToList());
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
            string fromPath = @"d:\Process2\!!Data\EroFilms\converted\";
            string toPath = @"d:\Process2\!!Data\EroFilms\";
            var files = Directory.GetFiles(fromPath, "*.m4v", SearchOption.TopDirectoryOnly).ToList();
            foreach (var fn in files)
            {
                string Country = "JAP";
                string fnwe = Path.GetFileName(fn);
                if (fnwe.ToUpper().StartsWith($"{Country} "))
                {
                    string nfm = fnwe.Remove(0, 4);
                    string yearstr = nfm.Substring(0, 4);
                    int Year;
                    if (int.TryParse(yearstr, out Year))
                    {
                        if (Year < 1950 || Year > 2017) continue;
                        nfm = nfm.Remove(0, 4);
                        nfm = nfm.Replace(".m4v", string.Empty);
                        string Name = nfm.Trim();

                        string newPath = Path.Combine(@"d:\Process2\!!Data\EroFilms\", Year.ToString());
                        if (Directory.Exists(newPath))
                        {
                            newPath = Path.Combine(newPath, Name);
                            if (!Directory.Exists(newPath))
                            {
                                Directory.CreateDirectory(newPath);
                                EpItem item = new EpItem(0);
                                item.Name = Name;
                                item.Country = Country;
                                item.Year = Year;
                                List<string> lines = EpItem.SetToPassport(item);
                                File.WriteAllLines(Path.Combine(newPath, EpItem.p_PassportName), lines);
                            }

                            File.Move(fn, Path.Combine(newPath, Name) + ".m4v");
                        }
                    }
                }
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
        }

        internal void ParseLine(string line)
        {
            line = line.Trim();
            if (line.StartsWith(c_UpdateFolder))
            {
                UpdateFolder(line.Replace(c_UpdateFolder, string.Empty));
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
                    string newFilePath = Path.Combine(ToPath, Path.GetFileName(item));
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
                    if (isMove)
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


        private void LoadCatalog(string parameters)
        {
            List<EpItem> list = new List<EpItem>();
            string itemPath = parameters.ToLower();
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
            List<string> passportList = Directory.GetFiles(itemPath, EpItem.p_PassportName).ToList();
            foreach (var passport in passportList)
            {
                CreateUpdateFromPassort(passport);
            }
            List<string> dirList = Directory.GetDirectories(itemPath).ToList();
            foreach (var dir in dirList)
            {
                UpdateFolder(dir);
            }
        }

        internal void UpdateItem(EpItem item)
        {
            List<string> passportData = EpItem.SetToPassport(item);
            File.WriteAllLines(item.ItemPath, passportData);
        }

        private void CreateUpdateFromPassort(string passportPath)
        {
            List<string> passport = new List<string>(File.ReadAllLines(passportPath));
            if (passport != null)
            {
                EpItem item = EpItem.GetFromPassport(passport);
                item.ItemPath = passportPath;

                var existingItem = Source.Where(x => x.GID == item.GID).FirstOrDefault();
                if (existingItem == null)
                {
                    if (string.IsNullOrEmpty(item.Name))
                    {
                        item.Name = Path.GetFileName(Path.GetDirectoryName(passportPath));
                    }
                    Source.Add(item);
                    UpdateItem(item);
                }
                else
                {
                    existingItem.UpdateFrom(item);
                }
            }
        }


    }

}
