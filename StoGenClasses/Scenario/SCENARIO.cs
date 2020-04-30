using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
DefVisX = 700; DefVisY = 0; DefVisSize = 900; DefVisSpeed = 100; DefVisLM = 1; DefVisLC = 1
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
        public string Description { set; get; }
        public string Location { set; get; }
        public string Female { set; get; }
        public string Fgarment { set; get; }
        public string Male { set; get; }
        public string Mgarment { set; get; }
        public string StopWords { set; get; }
        public string Action { set; get; }
        public string Kind { set; get; }
        public string Category { set; get; }
        public string Variant { set; get; }
        public string RawParameters { set; get; }
        private ObservableCollection<Info_Scene> _ObservableSceneInfoList = null;
        public ObservableCollection<Info_Scene> SceneInfos
        {
            get
            {
                if (_ObservableSceneInfoList == null)
                {
                    _ObservableSceneInfoList = new ObservableCollection<Info_Scene>();

                }
                return _ObservableSceneInfoList;
            }
        }


        public List<IGrouping<string,Info_Scene>> GetGroupedList()
        {
            return SceneInfos.GroupBy(x => x.Group).OrderBy(x=>x.Key).ToList();
        }
        //text
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
            }
        }
        public void LoadFrom(List<string> clipsinstr)
        {
            bool isMetadata = false;
            bool isDescription = false;
            bool isRawData = false;
            List<string> lines = new List<string>();
            List<string> description_lines = new List<string>();
            List<string> rawdata_lines = new List<string>();
            foreach (var line in clipsinstr)
            {
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
                else if (line.StartsWith("LOCATION:"))
                {
                    this.Location = line.Replace("LOCATION:", string.Empty);
                }
                else if (line.StartsWith("FEMALE:"))
                {
                    this.Female = line.Replace("FEMALE:", string.Empty);
                }
                else if (line.StartsWith("FGARMENT:"))
                {
                    this.Fgarment = line.Replace("FGARMENT:", string.Empty);
                }
                else if (line.StartsWith("MALE:"))
                {
                    this.Male = line.Replace("MALE:", string.Empty);
                }
                else if (line.StartsWith("MGARMENT:"))
                {
                    this.Mgarment = line.Replace("MGARMENT:", string.Empty);
                }
                else if (line.StartsWith("ACTION:"))
                {
                    this.Action = line.Replace("ACTION:", string.Empty);
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
                else if (line.StartsWith("DESCRIPTION:"))
                {
                    isDescription = true;
                    isRawData = false;
                }
                else if (line.StartsWith("RAWPARAMETERS:"))
                {
                    isDescription = false;
                    isRawData = true;
                }
                else
                {
                    if (isMetadata)
                    {
                        if (isDescription)
                        {
                            description_lines.Add(line);
                            //this.Description = $"{this.Description}{Environment.NewLine}{line}";
                        }
                        else if (isRawData)
                        {
                            rawdata_lines.Add(line);
                            //this.RawParameters = $"{this.RawParameters}{Environment.NewLine}{line}";
                        }
                    }
                    else
                    {
                        lines.Add(line);
                    }
                }
            }
            this.Description = string.Join(Environment.NewLine, description_lines.ToArray());
            this.RawParameters = string.Join(Environment.NewLine, rawdata_lines.ToArray());
            this.SceneInfos.Clear();
            foreach (var line in lines)
            {
                this.SceneInfos.Add(Info_Scene.GenerateFromString(line));
            }
            AssignRawParameters();
        }
        public void SaveToFile(string ScenDir, string tempDir)
        {
            List<string> lines = new List<string>();
            lines.Add($"****METADATA START****");
            lines.Add($"NAME:{this.Name}");
            lines.Add($"ID:{this.Id}");
            lines.Add($"FILENAME:{this.FileName}");
            lines.Add($"LOCATION:{this.Location}");
            lines.Add($"FEMALE:{this.Female}");
            lines.Add($"FGARMENT:{this.Fgarment}");
            lines.Add($"MALE:{this.Male}");
            lines.Add($"MGARMENT:{this.Mgarment}");
            lines.Add($"ACTION:{this.Action}");
            lines.Add($"KIND:{this.Kind}");
            lines.Add($"CATEGORY:{this.Category}");
            lines.Add($"VARIANT:{this.Variant}");
            lines.Add($"STOPWORDS:{this.StopWords}");
            lines.Add($"DESCRIPTION:");
            lines.Add($"{this.Description}");
            lines.Add($"RAWPARAMETERS:");
            lines.Add($"{this.RawParameters}");
            lines.Add($"****METADATA END****");

            List<string> queues = SceneInfos.Select(x => x.Queue).Distinct().ToList();

            foreach (var item in queues)
            {

                var selectedQueue = SceneInfos.Where(x => x.Queue == item).OrderBy(x => x.Group).ToList();
                foreach (var queue in selectedQueue)
                {
                    lines.Add(queue.GenerateString());
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
            File.WriteAllLines(fn, lines);
        }
        public static void PackScenario(SCENARIO original, string ScenDir)
        {
            SCENARIO scenario = new SCENARIO();
            string origfile = Path.Combine(ScenDir, $"{original.FileName}.epcatsi");
            List<string> clipsinstr = new List<string>(File.ReadAllLines(origfile));
            scenario.LoadFrom(clipsinstr);

            string tempPath = Path.Combine(ScenDir, "_ZIPTEMP");
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }



            HashSet<string> files = new HashSet<string>();


            foreach (var scene in scenario.SceneInfos)
            {
                if (!string.IsNullOrEmpty(scene.File))
                {
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
                            add = true;
                            subdir = "SOUND";
                        }
                        if (add)
                        {
                            string f = scene.File;
                            if (!files.Contains(scene.File))
                            {
                                files.Add(f);
                            }                          
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

            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    string newfilename = Path.GetFileName(file);
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
                    File.Copy(file, newfilepath, false);
                }
            }

            scenario.SaveToFile(tempPath,null);


            string zipPath = Path.Combine(ScenDir, Path.ChangeExtension(scenario.FileName, ".epcatsz"));
            if (File.Exists(zipPath))
                File.Delete(zipPath);
            ZipFile.CreateFromDirectory(tempPath, zipPath, CompressionLevel.Optimal, false);
            Directory.Delete(tempPath, true);
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
