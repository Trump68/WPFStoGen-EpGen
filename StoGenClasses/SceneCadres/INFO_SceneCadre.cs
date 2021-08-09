using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StoGen.Classes.SceneCadres
{
    public class INFO_SceneCadre
    {
        public INFO_SceneCadre(string id, ObservableCollection<INFO_SceneCadre> owner)
        {
            if (string.IsNullOrEmpty(id))
            {
                this.Id = Guid.NewGuid().ToString();
            }
            else
                this.Id = id;
            Owner = owner;
        }
        private ObservableCollection<INFO_SceneCadre> Owner = null;
        private List<Info_Scene> _Infos = new List<Info_Scene>();
        public List<Info_Scene> Infos
        {
            get
            {
                return _Infos;

            }
            set
            {
                _Infos = value;
            }
        }
        public int Order { set; get; } = 0;
        public string Id { set; get; } = null;
        public string Group { set; get; } = null;
        public string Description { set; get; } = null;
        public string Story
        {
            get
            {
                var gr = Infos.FirstOrDefault(x => x.Kind == 1);
                if (gr != null)
                    return gr.Story;
                return null;
            }
        }
        private ImageSource _Poster;

        public ImageSource Poster
        {
            get
            {
                return _Poster;
            }
            set
            {
                _Poster = value;
            }
        }

        public string KindName
        {
            get
            {
                var gr = Infos.FirstOrDefault(x => x.Tags != null && x.Tags.Contains("main"));
                if (gr == null)
                {
                    var list = Infos.Where(x => x.Template != null && !x.Template.StartsWith("~"));
                    foreach (var item in list)
                    {                        
                        foreach (var cadre in Owner)
                        {
                            gr = cadre.Infos.FirstOrDefault(x => x.Template != null && x.Template ==($"~{item.Template}") && x.Tags != null && x.Tags.Contains("main"));
                            if (gr != null) break;
                        }
                        if (gr != null) break;
                    }
                }
                if (gr == null)
                    return null;
                switch (gr.Kind)
                {

                    case 0:
                        return "Pic";
                    case 1: // 
                        return "Tit";
                    case 6: // 
                        return "Snd";
                    case 8: // 
                        return "Mov";
                    case 9: // 
                        return "Bck";
                    case 10: // 
                        return "Ctr";
                    default: return "Oth";
                }
            }
        }

        public string GenerateString()
        {
            List<string> rez = new List<string>();
            rez.Add($"Id={Id}");
            if (!string.IsNullOrEmpty(Description))
                rez.Add($"DSC={Description}");
            if (!string.IsNullOrEmpty(Group))
                rez.Add($"GR={Group}");
            rez.Add($"ORD={Order}");
            return string.Join(";", rez.ToArray());
        }

        internal static INFO_SceneCadre GenerateFromString(string line, ObservableCollection<INFO_SceneCadre> owner)
        {
            INFO_SceneCadre Rez = null; 
            List <string> data = line.Split(';').ToList();
            foreach (var str in data)
            {
                if (str.StartsWith("Id="))
                {
                    Rez = new INFO_SceneCadre(str.Replace("Id=",string.Empty),owner);
                }
                else if (str.StartsWith("DSC="))
                {
                    if (Rez != null)
                        Rez.Description = (str.Replace("DSC=", string.Empty));
                }
                else if (str.StartsWith("GR="))
                {
                    if (Rez != null)
                        Rez.Group = (str.Replace("GR=", string.Empty));
                }
                else if (str.StartsWith("ORD="))
                {
                    if (Rez != null)
                        Rez.Order = int.Parse((str.Replace("ORD=", string.Empty)));
                }
            }
            return Rez;
        }
    
    }
}
