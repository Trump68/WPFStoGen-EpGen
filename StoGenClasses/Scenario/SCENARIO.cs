﻿using StoGen.Classes.SceneCadres;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace StoGen.Classes.Scene
{
    public class SCENARIO
    {
        public SCENARIO()
        {
            RawParameters = GetParameters();
            AssignRawParameters();
        }
        public string CatalogPath;
        protected virtual string GetParameters()
        {
            return
@"//Text
//DefTextAlignH: 0-Left, 1-Right, 2-Center, 3-Justify
//DefTextAlignV: 0-Top, 1-Center, 2-Bottom
//DefTextBck: $$WHITE$$
DefTextSize=200;DefTextShift=30;DefTextWidth=1800;DefFontSize=40;DefFontColor=Cyan;DefTextAlignH=2;DefTextAlignV=1;DefTextBck=Cyan;DefTextBck=$$WHITE$$
//Visual
//DefVisLM: 0-next cadre, 1-loop, 2-stop, 3- backward?
DefVisX=700; DefVisY=0; DefVisSize=900;DefVisSpeed=100;DefVisLM=0;DefVisLC=1;DefClipPause1=1000
//DefVisX=0;DefVisY=0;DefVisSize=-3;DefVisSpeed=100;DefVisLM=1;DefVisLC=1
DefVisFile =
//Other
PackStory = 1; PackImage = 1; PackSound = 1; PackVideo = 0";
        }
        private string _Id;
        public string Id
        {
            set
            {
                _Id = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_Id))
                {
                    _Id = Guid.NewGuid().ToString();
                };
                return _Id;
            }
        }
        public string Name { set; get; }
        private string _FileName;
        public string FileName
        {
            set { _FileName = value; }
            get
            {
                return _FileName;
            }
        }
        public string FullFileName { set; get; }
        public string Description { set; get; }
        public string Story { set; get; }
        public string StopWords { set; get; }
        public string Kind { set; get; }
        public string Category { set; get; }
        public string Variant { set; get; }
        public string RawParameters { set; get; }
        public bool IsGenerationAllowed { get; set; } = false;
        private ObservableCollection<INFO_SceneGroup> _GroupList = null;
        public ObservableCollection<INFO_SceneGroup> GroupList
        {
            get
            {
                if (_GroupList == null)
                {
                    _GroupList = new ObservableCollection<INFO_SceneGroup>();

                }
                return _GroupList;
            }
        }

        public string DefTextSize;
        public string DefTextShift;
        public string DefTextWidth;
        public string DefFontSize;
        public string DefFontColor;
        public string DefTextAlignH;
        public string DefFontStyle;
        public string DefFontName;

        public string DefTextAlignV;
        public string DefTextBck;
        //visual
        public string DefVisX;
        public string DefVisY;
        public string DefVisSize;
        public string DefVisSpeed;
        public string DefVisLM;
        public string DefVisLC;
        public string DefVisFile;
        //movie
        public string DefClipPause1;
        //Other
        public string GamePath;
        private bool packStory = true;
        private bool packImage = true;
        private bool packSound = true;
        private bool packVideo = false;

        public void AssignRawParameters()
        {
            List<string> paramlist = new List<string>();
            string rdata = RawParameters.Replace(Environment.NewLine, "~");
            var lines = rdata.Split('~');
            foreach (var line in lines)
            {
                if (!line.StartsWith("//"))
                {
                    var items = line.Split(';');
                    foreach (var item in items)
                    {
                        var s = item.Trim();
                        paramlist.Add(item.Trim());
                    }
                }
            }
            foreach (var item in paramlist)
            {
                //text
                if (item.StartsWith("DefTextSize="))
                {
                    DefTextSize = item.Replace("DefTextSize=", string.Empty);
                }
                else if (item.StartsWith("DefTextShift="))
                {
                    DefTextShift = item.Replace("DefTextShift=", string.Empty);
                }
                else if (item.StartsWith("DefTextWidth="))
                {
                    DefTextWidth = item.Replace("DefTextWidth=", string.Empty);
                }
                else if (item.StartsWith("DefFontSize="))
                {
                    DefFontSize = item.Replace("DefFontSize=", string.Empty);
                }
                else if (item.StartsWith("DefFontName="))
                {
                    DefFontName = item.Replace("DefFontName=", string.Empty);
                }
                else if (item.StartsWith("DefFontColor="))
                {
                    DefFontColor = item.Replace("DefFontColor=", string.Empty);
                }
                else if (item.StartsWith("DefTextAlignH="))
                {
                    DefTextAlignH = item.Replace("DefTextAlignH=", string.Empty);
                }
                else if (item.StartsWith("DefTextAlignV="))
                {
                    DefTextAlignV = item.Replace("DefTextAlignV=", string.Empty);
                }
                else if (item.StartsWith("DefTextBck="))
                {
                    DefTextBck = item.Replace("DefTextBck=", string.Empty);
                }
                else if (item.StartsWith("DefFontStyle="))
                {
                    DefFontStyle = item.Replace("DefFontStyle=", string.Empty);
                }
                //visual
                else if (item.StartsWith("DefVisX="))
                {
                    DefVisX = item.Replace("DefVisX=", string.Empty);
                }
                else if (item.StartsWith("DefVisY="))
                {
                    DefVisY = item.Replace("DefVisY=", string.Empty);
                }
                else if (item.StartsWith("DefVisSize="))
                {
                    DefVisSize = item.Replace("DefVisSize=", string.Empty);
                }
                else if (item.StartsWith("DefVisSpeed="))
                {
                    DefVisSpeed = item.Replace("DefVisSpeed=", string.Empty);
                }
                else if (item.StartsWith("DefVisLM="))
                {
                    DefVisLM = item.Replace("DefVisLM=", string.Empty);
                }
                else if (item.StartsWith("DefVisLC="))
                {
                    DefVisLC = item.Replace("DefVisLC=", string.Empty);
                }
                else if (item.StartsWith("DefVisFile="))
                {
                    DefVisFile = item.Replace("DefVisFile=", string.Empty);
                }
                // Other
                else if (item.StartsWith("PackStory="))
                {
                    packStory = (item.Replace("PackStory=", string.Empty) == "1");
                }
                else if (item.StartsWith("PackImage="))
                {
                    packImage = (item.Replace("PackImage=", string.Empty) == "1");
                }
                else if (item.StartsWith("PackSound="))
                {
                    packSound = (item.Replace("PackSound=", string.Empty) == "1");
                }
                else if (item.StartsWith("PackVideo="))
                {
                    packVideo = (item.Replace("PackVideo=", string.Empty) == "1");
                }
                else if (item.StartsWith("DefClipPause1="))
                {
                    DefClipPause1 = item.Replace("DefClipPause1=", string.Empty);
                }
            }
        }
        public List<string> IncludeFiles(List<string> clipsinstr)
        {
            List<string> result = new List<string>();
            foreach (var str in clipsinstr)
            {
                if (str.Trim().StartsWith(@"//"))
                    continue;
                if (str.Trim().StartsWith(@"include ")) 
                {
                    string file = str.Trim().Replace("include ",string.Empty);
                    string fullpath = Path.Combine(this.CatalogPath, file);
                    try
                    {
                        var inner = File.ReadLines(fullpath);                        
                        result.AddRange(inner);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"{fullpath} not found");
                    }                    
                }
                if (str.Trim().StartsWith(@"next "))
                {
                    string file = str.Trim().Replace("next ", string.Empty);
                    string fullpath = Path.Combine(this.CatalogPath, file);
                    try
                    {
                        var cleanlines = File.ReadLines(fullpath).Where(x => !x.Trim().StartsWith("include ")).ToList();
                        var inner = IncludeFiles(cleanlines);
                        result.AddRange(inner);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"{fullpath} not found");
                    }
                }
                else
                {
                    result.Add(str);
                }
            }
            return result;
        }
        public void LoadFrom(List<string> clipsinstr)
        {
            clipsinstr = IncludeFiles(clipsinstr);

            bool isMetadata = false;
            bool isDescription = false;
            bool isRawData = false;
            bool isStory = false;
            bool isVariables = false;
            List<string> lines = new List<string>();
            List<string> description_lines = new List<string>();
            List<string> story_lines = new List<string>();
            Dictionary<string,string> variables = new Dictionary<string, string>();
            List<string> rawdata_lines = new List<string>();
            foreach (var str in clipsinstr)
            {
                string line = str.Trim();
                if (string.IsNullOrEmpty(line))  continue;
                if (line.StartsWith(@"//")) continue;                
                if (line.StartsWith("****METADATA START****"))
                {
                    isMetadata = true;
                    continue;
                }
                else if (line.StartsWith("****METADATA END****"))
                {
                    isMetadata = false;
                    continue;
                }

                if (line.StartsWith("NAME:"))
                {
                    this.Name = line.Replace("NAME:", string.Empty);
                }
                else if (line.StartsWith("ID:"))
                {
                    this.Id = line.Replace("ID:", string.Empty).Trim();
                    if (string.IsNullOrEmpty(this.Id) || this.Id.Contains("ID")) this.Id = Guid.NewGuid().ToString();
                }
                else if (line.StartsWith("FILENAME:"))
                {
                    this.FileName = line.Replace("FILENAME:", string.Empty);
                }
                else if (line.StartsWith("KIND:"))
                {
                    this.Kind = line.Replace("KIND:", string.Empty);
                }
                else if (line.StartsWith("CATEGORY:"))
                {
                    this.Category = line.Replace("CATEGORY:", string.Empty);
                }
                else if (line.StartsWith("VARIANT:"))
                {
                    this.Variant = line.Replace("VARIANT:", string.Empty);
                }
                else if (line.StartsWith("STOPWORDS:"))
                {
                    this.StopWords = line.Replace("STOPWORDS:", string.Empty);
                }
                else if (line.StartsWith("ISGENERATIONALLOWED:"))
                {
                    string boolVal = line.Replace("ISGENERATIONALLOWED:", string.Empty);
                    this.IsGenerationAllowed = bool.Parse(boolVal);
                }
                else if (line.StartsWith("DESCRIPTION:"))
                {
                    isDescription = true;
                    isRawData = false;
                    isStory = false;
                    isVariables = false;
                }
                else if (line.StartsWith("STORY:"))
                {
                    isDescription = false;
                    isRawData = false;
                    isStory = true;
                    isVariables = false;
                }
                else if (line.StartsWith("VARIABLES:"))
                {
                    isDescription = false;
                    isRawData = false;
                    isStory = false;
                    isVariables = true;
                }
                else if (line.StartsWith("RAWPARAMETERS:"))
                {
                    isDescription = false;
                    isRawData = true;
                    isStory = false;
                    isVariables = false;
                }
                else
                {
                    if (isMetadata)
                    {
                        if (isDescription)
                        {
                            description_lines.Add(line);
                        }
                        else if (isRawData)
                        {
                            rawdata_lines.Add(line);
                        }
                        else if (isStory)
                        {
                            string rez = string.Empty;
                            bool isvar = false;
                            string curkey = string.Empty;
                            foreach (var item in line)
                            {
                                if (item == '#') 
                                {                                                                        
                                    isvar = !isvar;
                                    if (!isvar)                                     
                                    {
                                        if (variables.ContainsKey(curkey)) 
                                        {
                                            rez = rez + variables[curkey];
                                        }
                                        curkey = string.Empty;
                                    }
                                }
                                else 
                                {
                                    if (isvar) 
                                    {                                        
                                        curkey = curkey + item;
                                    }
                                    else 
                                    {
                                        rez = rez + item;
                                    }
                                }
                            }

                            story_lines.Add(rez);
                        }
                        else if (isVariables)
                        {                            
                            string v = line.Trim();
                            if (!string.IsNullOrEmpty(v) && !v.StartsWith("//")) 
                            {
                                var keyval = v.Split('=');
                                if (!variables.ContainsKey(keyval[0])) 
                                {
                                    variables.Add(keyval[0], keyval[1]);
                                }                                
                            }
                            
                        }
                    }
                    else
                    {
                        lines.Add(str);
                    }
                }
            }


            this.Description = string.Join(Environment.NewLine, description_lines.ToArray());
            this.RawParameters = string.Join(Environment.NewLine, rawdata_lines.ToArray());
            this.Story = string.Join(Environment.NewLine, story_lines.ToArray());
            this.GroupList.Clear();
            string currentGroupID = null;
            string currentID = null;
            foreach (var str in lines)
            {
                string line = str;
                if (line.StartsWith(" ")) 
                {
                    int spacecount = 0;
                    while (line.StartsWith(" "))
                    {
                        spacecount++;
                        line = line.Substring(1);
                    }
                    if (spacecount == 2)
                    {
                        var newgroupid =  addGroup($"GroupId={line}");
                        currentGroupID = newgroupid;
                        continue;
                    }
                    else if (spacecount == 4)
                    {                        
                        line = $"Id={line.Trim()};GR={currentGroupID}";
                        string id = addGroupId(line);
                        currentID = id;
                        continue;
                    }
                    else if (spacecount == 6)
                    {
                        line = $"GROUP={currentID};{line.Trim()}";                        
                    }
                }

                if (line.StartsWith("GroupId="))
                {
                    addGroup(line);
                }
                else if (line.StartsWith("Id="))
                {
                    addGroupId(line);
                }
                else if (line.StartsWith("include "))
                {
                    
                }
                else
                {
                    Info_Scene info = Info_Scene.GenerateFromString(line);
                    INFO_SceneCadre cadre = null;
                    foreach (var group in GroupList)
                    {
                        cadre = group.Cadres.FirstOrDefault(x => x.Id == info.Group);
                        if (cadre != null) break;
                    }

                    if (cadre == null)
                    {
                        cadre = new INFO_SceneCadre(info.Group, this.GroupList);
                        cadre.Group = info.Description;
                        if (this.GroupList.Any())
                        {
                            this.GroupList.First().Cadres.Add(cadre);
                            cadre.Order = this.GroupList.First().Cadres.Count;
                        }
                    }
                    if (info.Order < 0)
                        info.Order = cadre.Infos.Count;
                    cadre.Infos.Add(info);

                }
            }
            AssignRawParameters();
        }
        private string addGroup(string line)
        {
            INFO_SceneGroup group = INFO_SceneGroup.GenerateFromString(line);
            string check = group.Id;
            int increment = 0;
            while (this.GroupList.FirstOrDefault(x => x.Id == check) != null)
            {
                increment++;
                check = $"{group.Id}.{increment}";                
            }
            group.Id = check;
            if (string.IsNullOrEmpty(group.Description))
            {
                group.Description = group.Id;
            }
            this.GroupList.Add(group);
            return group.Id;
        }
        private string addGroupId(string line)
        {
            INFO_SceneCadre cadre = INFO_SceneCadre.GenerateFromString(line, this.GroupList);
            string check = cadre.Id;
            int increment = 0;
            while (this.GroupList.Any(x => x.Cadres.Any(y => y.Id == check)))
            {
                increment++;
                check = $"{cadre.Id}.{increment}";
            }
            cadre.Id = check;

            var group = this.GroupList.FirstOrDefault(x => x.Id == cadre.Group);
            if (group == null)
            {
                group = new INFO_SceneGroup(cadre.Group);
                group.Description = cadre.Group;
                this.GroupList.Add(group);
                group.Order = this.GroupList.Count;
            }
            cadre.Owner = this.GroupList;
            group.Cadres.Add(cadre);
            return cadre.Id;
        }
        public void SaveToFile(string ScenDir, string tempDir)
        {
            List<string> lines = new List<string>();
            lines.Add($"****METADATA START****");
            lines.Add($"NAME:{this.Name}");
            lines.Add($"ID:{this.Id}");
            lines.Add($"FILENAME:{this.FileName}");
            lines.Add($"KIND:{this.Kind}");
            lines.Add($"CATEGORY:{this.Category}");
            lines.Add($"VARIANT:{this.Variant}");
            lines.Add($"STOPWORDS:{this.StopWords}");
            lines.Add($"ISGENERATIONALLOWED:{this.IsGenerationAllowed}");
            lines.Add($"DESCRIPTION:");
            lines.Add($"{this.Description}");
            lines.Add($"STORY:");
            lines.Add($"{this.Story}");
            lines.Add($"RAWPARAMETERS:");
            lines.Add($"{this.RawParameters}");
            lines.Add($"****METADATA END****");

            //List<string> queues = SceneInfos.Select(x => x.Queue).Distinct().ToList();

            foreach (var group in this.GroupList)
            {
                lines.Add(group.GenerateString());
                foreach (var cadre in group.Cadres)
                {
                    lines.Add(cadre.GenerateString());
                    foreach (var info in cadre.Infos)
                    {
                        lines.Add(info.GenerateString());
                    }
                }
            }

            string fn = Path.Combine(ScenDir, $"{FileName}.epcatsi");
            if (tempDir != null)
            {
                Directory.CreateDirectory(tempDir);
                string bfn = Path.Combine(tempDir, $"{FileName}.epcatsi");
                if (File.Exists(fn))
                {
                    File.Copy(fn, bfn, true);
                    File.Delete(fn);
                }
            }
            if (!Directory.Exists(ScenDir))
                Directory.CreateDirectory(ScenDir);
            File.WriteAllLines(fn, lines);
        }
        public static void PackScenario(SCENARIO original, string ScenDir)
        {
            SCENARIO scenario = new SCENARIO();
            string origfile = Path.Combine(ScenDir, $"{original.FileName}.epcatsi");
            List<string> clipsinstr = new List<string>(File.ReadAllLines(origfile));
            scenario.LoadFrom(clipsinstr);

            string tempPath = Path.Combine(ScenDir, $"_ZIPTEMP_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}");
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }


            string scenecapsdir = Path.Combine(Path.GetDirectoryName(origfile), "StoryCaps");
            bool copycaps = Directory.Exists(scenecapsdir);
            string tempcapspath = Path.Combine(tempPath, "StoryCaps");
            if (copycaps && !Directory.Exists(tempcapspath))
            {
                Directory.CreateDirectory(tempcapspath);
            }

            HashSet<string> files = new HashSet<string>();

            foreach (var group in scenario.GroupList)
            {
                foreach (var cadre in group.Cadres)
                {
                    foreach (var scene in cadre.Infos)
                    {
                        if (!string.IsNullOrEmpty(scene.File))
                        {
                            if (copycaps)
                            {
                                string fn = $"{original.FileName}-{scene.Group}.jpg";
                                string capspath = Path.Combine(scenecapsdir, fn);
                                if (File.Exists(capspath))
                                {
                                    string newfilepath = Path.Combine(tempcapspath, fn);
                                    if (!File.Exists(newfilepath))
                                    {
                                        File.Copy(capspath, newfilepath, false);
                                    }
                                }
                            }

                            if (scene.File.Contains(Path.DirectorySeparatorChar))
                            {
                                bool add = false;
                                string subdir = string.Empty;
                                string ext = Path.GetExtension(scene.File).ToUpper();
                                if (scenario.packImage && (ext == ".JPG" || ext == ".PNG"))
                                {
                                    add = true;
                                    subdir = "IMAGE";
                                }
                                else if (scenario.packVideo && (ext == ".M4V"))
                                {
                                    add = true;
                                    subdir = "VIDEO";
                                }
                                else if (scenario.packSound && (ext == ".MP3" || ext == ".WAV" || ext == ".OGG"))
                                {
                                    if (!scene.File.StartsWith("zip:"))
                                    {
                                        add = true;
                                        subdir = "SOUND";
                                    }
                                }
                                if (add)
                                {
                                    string f = scene.File;
                                    if (!files.Contains(scene.File))
                                    {
                                        files.Add(f);
                                    }
                                    if (subdir == "SOUND")
                                    {
                                        scene.File = $@"zip:sound.zip:{Path.GetFileName(scene.File)}";
                                    }
                                    else
                                        scene.File = $@".\{subdir}\{Path.GetFileName(scene.File)}";
                                }

                            }
                        }

                        if (scenario.packStory)
                        {
                            if (!string.IsNullOrEmpty(scene.Story))
                            {
                                string v = scene.Story;
                                if (scene.Story.Contains("@"))
                                {
                                    var vals = scene.Story.Split('@');
                                    v = vals[0];
                                    if (v.Contains(Path.DirectorySeparatorChar))
                                    {
                                        string f = scene.File;

                                        if (!files.Contains(v))
                                            files.Add(v);
                                        scene.Story = $@".\{Path.GetFileName(v)}@{vals[1]}";
                                    }
                                }

                            }
                        }
                    }
                }
            }
            foreach (var file in files)
            {
                string f = file;
                if (file.StartsWith(@".\"))
                {
                    if (!string.IsNullOrEmpty(original.DefVisFile))
                    {
                        f = file.Replace(@".\", $@"{original.DefVisFile}\");
                    }
                    else
                    {
                        f = file.Replace(@".\", $@"{ScenDir}\DATA\");
                        //return path.Replace(@".\", $@"{Story.CatalogPath}\DATA\");
                    }
                }

                if (File.Exists(f))
                {
                    string newfilename = Path.GetFileName(f);
                    string ext = Path.GetExtension(newfilename).ToUpper();
                    string subdir = string.Empty;
                    if (ext == ".M4V")
                    {
                        subdir = "VIDEO";
                    }
                    else if (ext == ".JPG" || ext == ".PNG")
                    {
                        subdir = "IMAGE";
                    }
                    else if (ext == ".MP3" || ext == ".WAV" || ext == ".OGG")
                    {
                        subdir = "SOUND";
                    }
                    subdir = Path.Combine(tempPath, subdir);
                    Directory.CreateDirectory(subdir);
                    string newfilepath = Path.Combine(subdir, newfilename);
                    File.Copy(f, newfilepath, false);
                }
            }

            scenario.SaveToFile(tempPath, null);


            string sounddir = Path.Combine(tempPath, "SOUND");
            if (Directory.Exists(sounddir))
            {
                string soundzip = Path.Combine(ScenDir, "sound.zip");
                if (!File.Exists(soundzip))
                {
                    var di = Directory.GetParent(Path.GetDirectoryName(soundzip));
                    if (di != null)
                    {
                        soundzip = Path.Combine(di.FullName, "sound.zip");
                        if (!File.Exists(soundzip))
                        {
                            di = Directory.GetParent(Path.GetDirectoryName(soundzip));
                            if (di != null)
                            {
                                soundzip = Path.Combine(di.FullName, "sound.zip");
                                if (!File.Exists(soundzip))
                                {
                                    di = Directory.GetParent(Path.GetDirectoryName(soundzip));
                                    if (di != null)
                                    {
                                        soundzip = Path.Combine(di.FullName, "sound.zip");
                                        if (!File.Exists(soundzip))
                                        {
                                            di = Directory.GetParent(Path.GetDirectoryName(soundzip));
                                            if (di != null)
                                            {
                                                soundzip = Path.Combine(ScenDir, "sound.zip");
                                            }

                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                if (!File.Exists(soundzip))
                {
                    soundzip = Path.Combine(ScenDir, "sound.zip");
                    ZipFile.CreateFromDirectory(sounddir, soundzip, CompressionLevel.Optimal, false);
                }

                if (File.Exists(soundzip))
                {
                    var za = ZipFile.Open(soundzip, ZipArchiveMode.Update);
                    var soundfiles = Directory.GetFiles(sounddir);
                    foreach (var item in soundfiles)
                    {
                        var ze = za.GetEntry(Path.GetFileName(item));
                        if (ze == null)
                        {
                            za.CreateEntryFromFile(item, Path.GetFileName(item));
                        }
                    }
                    za.Dispose();
                }
                Directory.EnumerateFiles(sounddir).ToList().ForEach(x => File.Delete(x));
                Directory.Delete(sounddir, true);
            }

            string zipPath = Path.Combine(ScenDir, Path.ChangeExtension(scenario.FileName, ".epcatsz"));
            if (File.Exists(zipPath))
                File.Delete(zipPath);
            ZipFile.CreateFromDirectory(tempPath, zipPath, CompressionLevel.Optimal, false);
            try
            {
                Directory.Delete(tempPath, true);
            }
            catch (Exception)
            {
                Thread.Sleep(3000);
                try
                {
                    Directory.Delete(tempPath, true);
                }
                catch (Exception)
                {
                }
            }

        }
        public void LoadFromZip(string file)
        {
            string rootpath = Path.GetDirectoryName(file);
            string zipname = Path.GetFileName(file);
            GamePath = Path.Combine(rootpath, Path.GetFileNameWithoutExtension(zipname));
            if (Directory.Exists(GamePath))
            {
                Directory.Delete(GamePath, true);
                Directory.CreateDirectory(GamePath);
            }
            Directory.CreateDirectory(GamePath);
            ZipFile.ExtractToDirectory(file, GamePath);
            var f = Directory.GetFiles(GamePath, "*.epcatsi");
            if (f.Any())
            {
                List<string> clipsinstr = new List<string>(File.ReadAllLines(f[0]));
                this.LoadFrom(clipsinstr);
            }

        }
        public static string GetNameFromData(List<string> clipsinstr)
        {
            foreach (var line in clipsinstr)
            {

                if (line.StartsWith("NAME:"))
                {
                    return line.Replace("NAME:", string.Empty);
                }
            }
            return null;
        }
    }
}

