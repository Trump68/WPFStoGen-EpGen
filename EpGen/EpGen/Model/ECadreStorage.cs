using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApp.Model
{
    //internal static class ECadreStorage
    //{
        
    //    public static List<string> FileHeader = new List<string>();
    //    internal static List<ECadre> LoadFile(string scenarioFileName)
    //    {
    //        List<ECadre> list = new List<ECadre>();
    //        if (!string.IsNullOrEmpty(scenarioFileName))
    //        {
    //            if (!File.Exists(scenarioFileName))
    //            {
    //                throw new Exception($"Нет файла для загрузки: {scenarioFileName}");
    //            }
    //            List<string> header;
    //            List<StringDataContainer> lines = StoGenParser.GetProcessedFile(scenarioFileName, null, KeyVarContainer, null, out header);
    //            FileHeader = header;
    //            list = ParseLines(lines);
    //        }
    //        return list;
    //    }
    //    internal static void SaveFile(List<ECadre> data, string scenarioFileName)
    //    {
    //        string IdentMark = $"\t\t\t";
    //        string IdentData = $"\t\t\t\t";
    //        List<string> result = new List<string>();
    //        //result.Add($"\tCreated by EpGen {DateTime.Now}");
    //        result.Add(string.Join(Environment.NewLine, FileHeader.ToArray()).Trim());
            

    //        foreach (ECadre ecadre in data)
    //        {
              
    //            result.Add(string.Empty);
    //            result.Add($"{IdentMark}PartSta#{ecadre.Mark}");

    //            foreach (PictureSourceDataProps pp in ecadre.PicData)
    //            {
    //                if (string.IsNullOrEmpty(pp.FileName) || pp.FileName.Contains(".mp4") || pp.FileName.Contains(".avi") || pp.FileName.Contains(".m4v"))
    //                {
    //                    if (!string.IsNullOrEmpty(pp.RawData))
    //                    {
    //                        string s = string.Empty;
    //                        string existS = pp.RawData.Split(';').ToList().Where(x => x.Contains("StartPos=")).FirstOrDefault().Split('#').Last();
    //                        string rez = pp.RawData.Replace(existS, $"StartPos={pp.StartPos}");
    //                        existS = rez.Split(';').ToList().Where(x => x.Contains("EndPos=")).FirstOrDefault().Split('#').Last();
    //                        rez = rez.Replace(existS, $"EndPos={pp.EndPos}");
    //                        result.Add($"{IdentData}{rez}");
    //                    }
    //                    else
    //                    {
    //                        result.Add($"{IdentData}#{ecadre.PicTemplate}#StartPos={pp.StartPos};EndPos={pp.EndPos};Rate=100;IsLoop=1;NextCadre=0");
    //                    }
    //                }
    //                else
    //                {
    //                    result.Add($"{IdentData}{pp.RawData}");
    //                }

    //            }
    //            foreach (SoundItem si in ecadre.SoundData)
    //            {
    //                if (!string.IsNullOrEmpty(si.RawData))
    //                {
    //                    result.Add($"{IdentData}{si.RawData}");
    //                }
    //                else
    //                {
    //                    result.Add($"{IdentData}#{ecadre.SoundTemplate}#");
    //                }
    //            }
    //            foreach (TextData td in ecadre.TextFrameData)
    //            {
    //                if (!string.IsNullOrEmpty(td.RawData))
    //                {
    //                    if (td.RawData.StartsWith(@"#"))
    //                    {
    //                        string[] vals = td.RawData.Remove(0, 1).Split('#');
    //                        if (KeyVarContainer.Inlines.ContainsKey(vals[0]))
    //                        {
    //                            string varval = KeyVarContainer.Inlines[vals[0]];
    //                            string rez = $"{IdentData}#{vals[0]}#{string.Join("~",td.TextList.ToArray())}";
    //                            result.Add(rez);
    //                        }
    //                    }
    //                    else
    //                    {
    //                        result.Add($"{IdentData}{td.RawData}");
    //                    }
    //                }
    //                else
    //                {
    //                    result.Add($"{IdentData}#{ecadre.TextTemplate}#{td.TextList[0]}");
    //                }
    //            }
    //            result.Add($"{IdentMark}PartEnd#{ecadre.Mark}");
    //        }

          

    //        File.WriteAllText(scenarioFileName, string.Join(Environment.NewLine, result.ToArray()), Encoding.UTF8);
    //    }

    //    private static List<ECadre> ParseLines(List<StringDataContainer> lines)
    //    {
    //        List<ECadre> list = new List<ECadre>();
    //        List<StringDataContainer> cadredata = new List<StringDataContainer>();
    //        string mark = null;
    //        foreach (StringDataContainer line in lines)
    //        {
    //            if (line.Complete.Trim().StartsWith("PartSta#"))
    //            {
    //                cadredata.Clear();
    //                mark = line.Complete.Trim().Replace("PartSta#", string.Empty);
    //            }
    //            else if (line.Complete.Trim().StartsWith($"PartEnd#{mark}"))
    //            {
    //                ECadre cadre = ParseCadreData(cadredata, mark);
    //                if (cadre != null) list.Add(cadre);
    //                mark = null;
    //            }
    //            else if (!string.IsNullOrEmpty(mark))
    //            {
    //                cadredata.Add(line);
    //            }
    //        }
    //        return list;
    //    }
    //    //private static ECadre ParseCadreData(List<StringDataContainer> lines, string mark)
    //    //{
    //    //    ECadre eCadre = new ECadre();
    //    //    eCadre.Mark = mark;

    //    //    foreach (StringDataContainer line in lines)
    //    //    {
    //    //        if (line.Complete.StartsWith(@"MainPics=") || line.Complete.StartsWith(@"DetailPics="))
    //    //        {
    //    //            int order = 0;
    //    //            PictureSourceDataProps psp = StoGenParser.GetPSPFromString(line.Complete, string.Empty, ref order);
    //    //            psp.RawData = line.Original;
    //    //            eCadre.PicData.Add(psp);
    //    //        }
    //    //        else if (line.Complete.StartsWith(@"CadreText="))
    //    //        {
    //    //            StoGenParser.FillCadreText(line.Complete, eCadre.TextFrameData, null, null, string.Empty, string.Empty);
    //    //            eCadre.TextFrameData[eCadre.TextFrameData.Count - 1].RawData = line.Original;
    //    //        }
    //    //        else if (line.Complete.StartsWith(@"CadreSound="))
    //    //        {
    //    //            StoGenParser.FillCadreSound(line.Complete, eCadre.SoundData, null, string.Empty);
    //    //            eCadre.SoundData[eCadre.SoundData.Count - 1].RawData = line.Original;
    //    //        }
    //    //    }
    //    //    return eCadre;
    //    //}

    //}
}
