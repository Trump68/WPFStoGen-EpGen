using EPCat.Model;
using StoGen.Classes.Catalog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace EPCat.Model
{

    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string stringToFormat)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            // Check if we have a string to format
            if (String.IsNullOrEmpty(stringToFormat))
            {
                // Return an empty string
                return string.Empty;
            }

            // Format the string to Proper Case
            return textInfo.ToTitleCase(stringToFormat.ToLower());
        }
    }

    public class Loader
    {
        static string c_SortToCatalog = "SORTTOCATALOG";
        static string c_PrepareFolder = "PREPARE FOLDER ";
        static string c_UpdateFolder = "UPDATE FOLDER ";


        static string c_LoadCatalog = "LOAD CATALOG ";
        //static string c_LoadCapsCatalog = "LOAD CAPS CATALOG ";

        static string c_MoveFiles = "MOVE FILES ";
        static string c_SynchFiles = "SYNCH FILES ";
        static string c_CreatePassport = "CREATE PASSPORT ";


        private List<EpItem> Source;
        internal List<string> FoldersToUpdate = new List<string>();
        public List<EpItem> ProcessScriptFile(List<EpItem> sourceList)
        {
            FoldersToUpdate.Clear();
            Source = sourceList;

            string commandf = "commandscript.txt";
            var CommandArgs = System.Environment.GetCommandLineArgs().ToList();
            if (CommandArgs.Count > 1)
            {
                commandf = CommandArgs[1];
                if (CommandArgs.Count > 2)
                {
                    string gridxml = CommandArgs[2];
                    MainWindow.Instance.RestoreLayout(gridxml);
                }

            }


            List<string> LogList = new List<string>(File.ReadAllLines(commandf));
            foreach (var item in LogList)
            {
                if (item.TrimStart().StartsWith("//")) continue;
                ParseLine(item);
            }
            return Source;
        }
        private void DoTempWork1(string line)
        {
            string fromPath = @"d:\uTorrent\! ToProcess\";
            string toPath = @"d:\!CATALOG\";
            string[] args = line.Split('|');
            if (args.Length > 0)
                fromPath = args[1];
            if (args.Length > 1)
                toPath = args[2];

            DoRenameList(fromPath);

            DoTempWork1_OneCountry("JAP", fromPath, toPath);
            //DoTempWork1_OneCountry("CHE", fromPath, toPath);
            //DoTempWork1_OneCountry("FRA", fromPath, toPath);
            //DoTempWork1_OneCountry("GBR", fromPath, toPath);
            //DoTempWork1_OneCountry("TWN", fromPath, toPath);
            //DoTempWork1_OneCountry("KOR", fromPath, toPath);
            //DoTempWork1_OneCountry("ITA", fromPath, toPath);
            //DoTempWork1_OneCountry("USA", fromPath, toPath);
            //DoTempWork1_OneCountry("HKG", fromPath, toPath);
            //DoTempWork1_OneCountry("SWZ", fromPath, toPath);
            //DoTempWork1_OneCountry("CAN", fromPath, toPath);
            //DoTempWork1_OneCountry("NLD", fromPath, toPath);
            //DoTempWork1_OneCountry("HSP", fromPath, toPath);
            //DoTempWork1_OneCountry("THA", fromPath, toPath);
            //DoTempWork1_OneCountry("GER", fromPath, toPath);
            //DoTempWork1_OneCountry("CHN", fromPath, toPath);
            //DoTempWork1_OneCountry("PHI", fromPath, toPath);
            //DoTempWork1_OneCountry("BRA", fromPath, toPath);
            //DoTempWork1_OneCountry("AUS", fromPath, toPath);
            //DoTempWork1_OneCountry("MEX", fromPath, toPath);
            //DoTempWork1_OneCountry("CHI", fromPath, toPath);
            //DoTempWork1_OneCountry("IND", fromPath, toPath);
            //DoTempWork1_OneCountry("SWE", fromPath, toPath);
            //DoTempWork1_OneCountry("SNG", fromPath, toPath);
            //DoTempWork1_OneCountry("HOL", fromPath, toPath);
            //DoTempWork1_OneCountry("PRT", fromPath, toPath);
            //DoTempWork1_OneCountry("GRE", fromPath, toPath);



            DoTempWork1_WEB(fromPath, toPath);
            DoTempWork1_OneCountry("$JAV", fromPath, toPath);
            DoFOLDER(fromPath, toPath, null);
        }

        private void DoRenameList(string path)
        {
            string fp = Path.Combine(path, "rename.txt");
            if (File.Exists(fp))
            {
                var lines = File.ReadAllLines(fp).ToList();
                if (lines.Any() && lines[0].StartsWith("*"))
                {
                    string template = lines[0].Remove(0, 1);
                    lines.RemoveAt(0);

                    List<string> l1 = new List<string>();
                    foreach (var item in lines)
                    {
                        string f = Path.GetFileNameWithoutExtension(item);
                        f = f.Replace("-", " ");
                        f = f.Replace("_", " ");
                        f = f.FirstCharToUpper();
                        f = f.Replace(" ", "_");
                        string t = template.Replace("*", f);
                        l1.Add($"{item}|{t}");
                    }
                    lines.Clear();
                    lines.AddRange(l1);
                }
                foreach (var item in lines)
                {
                    var vals = item.Split('|');
                    if (vals.Count() == 2)
                    {
                        string source = Path.Combine(path, vals[0].Trim());
                        if (!string.IsNullOrEmpty(vals[1].Trim()))
                        {
                            string dest = Path.Combine(path, vals[1].Trim());
                            if (File.Exists(source))
                            {
                                File.Move(source, dest);
                            }
                        }
                    }
                }
            }
            var dirs = Directory.GetDirectories(path).ToList();
            dirs.ForEach(x => DoRenameList(x));
        }

        private void DoFOLDER(string fromPath, string toDir, List<string> parentokens)
        {
            /* 
             * $01-Catalog
             * $02-Star 
             * $03-Kind
             * $04-Serie
             * $05-Country
             * $06-Year
             * $07-Studio
             * $08-XRated
             * $09-Type
             * $10-Director
             * $11-NOSORT
             *
             * $JAV [JUFE] JUFE-085.m4v
             * 
             * $01 JAV $02  $04  $
             * $01 JAV $04  $
             * $01 JAV $!!!JAV Movies!!!
             * 
             * * $01 WEB $03 WEBCLIP $08 P $07 $
             *  
             * $01 HEN $03 ARTIST COMIX $10 Georges Levis $Coco 
             * $01 HEN $03 ARTIST BOARD $10 Zumi $Zumi Art             
             * $01 HEN $03 ARTIST PINUP $10 Luis Royo $Luis Royo Art
             * $01 HEN $03 GameCG $07 BLACKRAINBOW $11 SORTED $!!!IMAGE SETS!!!
             * 
             * $01 R3D $03 ARTIST 3D $10 Smerinka $!!!IMAGE SETS!!!
             * 
             * $01 MGZ $03 ERO MAGAZIN $04 Cancans de Paris $!!!IMAGE SETS!!!
             * $01 MGZ $03 PRN MAGAZIN $04 Silwa - Backdoor Lovers $!!!IMAGE SETS!!!
             * 
             * $01 COM $03 COMIX PRINTED $04 Top Model $!!!IMAGE SETS!!! 
             * 
             * 
             * $01 MOD $03 ACTRESS $02 Eva Hedger $!!!IMAGE SETS!!!
             * $01 MOD $03 FASHION $02 Eva Hedger $!!!IMAGE SETS!!!
             * $01 MOD $03 SOFT $02 Eva Hedger $!!!IMAGE SETS!!!
             * $01 MOD $03 HARD $02 Eva Hedger $!!!IMAGE SETS!!!
             * 
             */


            List<string> dirs;
            if (parentokens != null)
            {
                dirs = Directory.GetDirectories(fromPath, "*", SearchOption.TopDirectoryOnly).ToList();
            }
            else
            {
                dirs = Directory.GetDirectories(fromPath, "$*", SearchOption.TopDirectoryOnly).ToList();
            }

            foreach (var dir in dirs)
            {
                string toPath = toDir;
                EpItem item = new EpItem(0);
                string dn = Path.GetFileName(dir);
                bool marked = dn.Contains("$");
                List<string> tokens = dn.Split('$').ToList();
                if (!marked)
                {
                    item.Name = dn;
                    tokens = new List<string>();
                }
                if (parentokens != null)
                {
                    tokens.AddRange(parentokens);
                }

                if (tokens.Last() == "!!!IMAGE SETS!!!")
                {
                    var files = Directory.GetFiles(dir, "*.pdf", SearchOption.TopDirectoryOnly).ToList();
                    files.AddRange(Directory.GetFiles(dir, "*.djvu", SearchOption.TopDirectoryOnly).ToList());
                    foreach (var f in files)
                    {
                        string pdfdir = Path.Combine(dir, Path.GetFileNameWithoutExtension(f));
                        Directory.CreateDirectory(pdfdir);
                        File.Move(f, Path.Combine(pdfdir, Path.GetFileName(f)));
                    }

                    tokens.Remove(tokens.Last());
                    DoFOLDER(dir, toDir, tokens);
                    Directory.Delete(dir);
                    continue;
                }
                else if (tokens.Last() == "!!!JAV Movies!!!")
                {
                    var javfiles = Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly).ToList();
                    foreach (var jf in javfiles)
                    {
                        string fn = Path.GetFileNameWithoutExtension(jf);
                        string[] vals = fn.Split('-');
                        string jserie = vals[0];
                        string fullname = $"$01 JAV $04 {jserie.ToUpper()} ${fn.ToUpper()}";
                        fullname = Path.Combine(dir, fullname);
                        Directory.CreateDirectory(fullname);
                        File.Move(jf, Path.Combine(fullname, Path.GetFileName(jf)));
                    }
                    DoFOLDER(dir, toDir, null);
                    continue;
                }
                bool alreadysorted = false;
                foreach (string tok in tokens)
                {
                    if (string.IsNullOrEmpty(tok.Trim()))
                        continue;
                    string mark = tok.Substring(0, 2);
                    string val = tok.Remove(0, 2).Trim();
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
                    else if (mark == "07")
                    {
                        item.Studio = val;
                    }
                    else if (mark == "08")
                    {
                        item.XRated = val;
                    }
                    else if (mark == "09")
                    {
                        item.Type = val;
                    }
                    else if (mark == "10")
                    {
                        item.Director = val;
                    }
                    else if (mark == "11")
                    {
                        alreadysorted = (val == "SORTED");
                    }
                    else
                    {
                        item.Name = tok.Trim();
                    }
                }
                if (!string.IsNullOrEmpty(item.Name))
                {
                    if (!string.IsNullOrEmpty(item.Catalog))
                        toPath = $@"{toPath}\{item.Catalog}";
                    if (item.Catalog == "WEB")
                    {
                        if (!string.IsNullOrEmpty(item.Studio))
                            toPath = $@"{toPath}\{item.Studio}";
                    }
                    else if (item.Catalog == "MOV")
                    {
                        toPath = $@"{toPath}\{item.Year}";
                    }
                    else if (item.Catalog == "HEN"
                        || item.Catalog == "R3D"
                        || item.Catalog == "COM"
                        || item.Catalog == "MOD"
                        || item.Catalog == "MGZ")
                    {
                        if (!string.IsNullOrEmpty(item.Kind))
                            toPath = $@"{toPath}\{item.Kind}";
                        if (!string.IsNullOrEmpty(item.Director))
                            toPath = $@"{toPath}\{item.Director}";
                        if (!string.IsNullOrEmpty(item.Serie))
                            toPath = $@"{toPath}\{item.Serie}";
                        if (item.Year > 0)
                            toPath = $@"{toPath}\{item.Year}";
                        if (!string.IsNullOrEmpty(item.Star))
                            toPath = $@"{toPath}\{item.Star}";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(item.Serie))
                            toPath = $@"{toPath}\{item.Serie}";
                    }


                    if (!Directory.Exists(toPath))
                        Directory.CreateDirectory(toPath);

                    string newname = Path.Combine(toPath, item.Name);
                    if (item.Catalog == "MOV")
                    {
                        newname = Path.Combine(toPath, $"[{item.Country}] {item.Name}");
                    }

                    if (
                        !alreadysorted &&
                        (
                           item.Catalog == "HEN"
                        || item.Catalog == "R3D"
                        || item.Catalog == "COM"
                        || item.Catalog == "MOD"
                        || item.Catalog == "MGZ"
                        )
                        && parentokens != null)
                    {
                        string eventsdir = Path.Combine(dir, "EVENTS");
                        Directory.CreateDirectory(eventsdir);
                        var files = Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly).ToList();
                        files.ForEach(x => File.Move(x, Path.Combine(eventsdir, Path.GetFileName(x))));
                    }

                    try
                    {
                        if (!File.Exists(newname))
                            Directory.Move(dir, newname);
                    }
                    catch (Exception)
                    {


                    }
                    List<string> lines = EpItem.SetToPassport(item);
                    File.WriteAllLines(Path.Combine(newname, EpItem.p_PassportName), lines);
                }
            }
        }
        private void DoTempWork1_WEB(string fromPath, string toPath)
        {
            string Catalog = "WEB";
            string Studio = string.Empty;
            string Actors = string.Empty;
            string Day = "00";
            string Month = "00";
            string Year = "0000";
            string Name = string.Empty;

            var files = Directory.GetFiles(fromPath, "*.m4v", SearchOption.TopDirectoryOnly).ToList();
            foreach (var fn in files)
            {
                string source = fn;
                string fnwe = Path.GetFileName(fn);
                if (fnwe.ToUpper().StartsWith($"$WEB "))
                {

                    string nfm = fnwe.Remove(0, 4);
                    nfm = nfm.Replace(".m4v", string.Empty);
                    nfm = nfm.Trim();
                    bool ok = false;

                    if (fnwe.ToUpper().StartsWith("$"))
                    {
                        //Country = string.Empty;
                        //Catalog = mark.Replace("$", string.Empty);
                        var items = nfm.Split(' ');

                        Studio = items[0]
                            .Replace("[", string.Empty)
                            .Replace("]", string.Empty)
                            .Replace("_", " ").Trim();

                        var time = items[1]
                           .Replace("[", string.Empty)
                           .Replace("]", string.Empty)
                           .Trim();
                        var timesplitted = time.Split('_');
                        if (timesplitted.Length > 0)
                            Year = timesplitted[0];
                        if (timesplitted.Length > 1)
                            Month = timesplitted[1];
                        if (timesplitted.Length > 2)
                            Day = timesplitted[2];

                        Actors = items[2]
                                .Replace("[", string.Empty)
                                .Replace("]", string.Empty)
                                .Replace("_", " ").Trim();

                        Name = items[3]
                                 .Replace("[", string.Empty)
                                 .Replace("]", string.Empty)
                                 .Replace("_", " ").Trim();

                        Name = $"{Year}-{Month}-{Actors}-{Name}";

                        ok = true;
                    }



                    if (ok)
                    {
                        string newPath = Path.Combine(toPath, Catalog, Studio, Year, Month);

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
                                item.Year = Convert.ToInt32(Year);
                                item.Month = Convert.ToInt32(Month);
                                item.Day = Convert.ToInt32(Day);
                                item.Studio = Studio;
                                item.Star = Actors;
                                List<string> lines = EpItem.SetToPassport(item);
                                File.WriteAllLines(Path.Combine(newPath, EpItem.p_PassportName), lines);
                            }

                            File.Move(source, Path.Combine(newPath, "video") + ".m4v");
                        }
                    }
                }
            }
            Directory.GetDirectories(fromPath).ToList().ForEach(x => DoTempWork1_WEB(x, toPath));
        }
        private void DoTempWork1_OneCountry(string mark, string fromPath, string toPath)
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
                        nfm = nfm.Replace("{" + Actors + "}", string.Empty).Trim();
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
                        if (string.IsNullOrEmpty(Serie))
                        {
                            var ser = nfm.Split('-');
                            Serie = ser[0];
                        }
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
                        else if (Catalog == "JAV")
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
                    EpItem item = EpItem.GetFromPassport(passport, passportPath);
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
        internal void SaveCatalog(ref List<EpItem> list)
        {

            list.Where(x => x.ToDelete).ToList().ForEach(x =>
            {
                if (Directory.Exists(x.ItemDirectory))
                {
                    Directory.Delete(x.ItemDirectory, true);
                }
                string dirPoster = EpItem.GetCatalogPosterDir(CurrentCatalog);
                string newPostername = Path.Combine(dirPoster, $"{x.GID}.jpg");
                if (File.Exists(newPostername))
                    File.Delete(newPostername);
            });
            list.RemoveAll(x => x.ToDelete);


            list.Where(x => x.Edited).ToList().ForEach(x =>
            {
                if (Directory.Exists(x.ItemDirectory))
                {
                    List<string> lines = EpItem.SetToPassport(x);
                    File.WriteAllLines(Path.Combine(x.ItemDirectory, EpItem.p_PassportName), lines);
                }
            });

            //JAV.ReloadCollection();
           
            //foreach (var item in FoldersToUpdate)
            //{
            //    CatalogLoader.UpdateFolder(item, ref list,true, EpCatViewModel.IsSynchPosterAllowed, CurrentCatalog, false);
            //}


            if (string.IsNullOrEmpty(CurrentCatalog)) return;
            if (File.Exists(CurrentCatalog))
                File.Copy(CurrentCatalog, Path.ChangeExtension(CurrentCatalog, "bak"), true);
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<EpItem>));
            using (var writer = new StreamWriter(CurrentCatalog))
            {

                serializer.Serialize(writer, list);
            }
        }

        
        internal void ParseLine(string line)
        {

            line = line.Trim();
            if (line.StartsWith(c_SortToCatalog))
            {

                DoTempWork1(line);
                //DoTempwork2(@"d:\!CATALOG\MOV\");
                Environment.Exit(0);
            }
            else if (line.StartsWith(c_PrepareFolder))
            {
                PrepareFolder(line.Replace(c_PrepareFolder, string.Empty), 0, 2);
            }
            else if (line.StartsWith(c_UpdateFolder))
            {
                FoldersToUpdate.Add(line.Replace(c_UpdateFolder, string.Empty).ToUpper());

            }
            else if (line.StartsWith(c_LoadCatalog))
            {
                string parameters = (line.Replace(c_LoadCatalog, string.Empty));
                CurrentCatalog = parameters.ToLower();
                Source = CatalogLoader.LoadCatalog(CurrentCatalog);
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
        }
        private void PrepareFolder(string parameters, int CurrentLevel, int ProcessLevel)
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
                PrepareFolder(dir, (CurrentLevel + 1), ProcessLevel);
            }
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
                    if (!dirnamesSource.Contains(dirnameDest)) Directory.Delete(dn, true);
                }
            }
        }




     
      




     
      

    }

}
