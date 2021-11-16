using StoGen.Classes.SceneCadres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.SceneCadres
{
    public class INFO_SceneGroup
    {
        public INFO_SceneGroup(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                this.Id = Guid.NewGuid().ToString();
            }
            else
                this.Id = id;            
        }
        public string Id { set; get; } = null;
        public string Description { set; get; } = null;
        public int Order { set; get; }
        private List<INFO_SceneCadre> _Cadres = new List<INFO_SceneCadre>();
        public List<INFO_SceneCadre> Cadres
        {
            get
            {
                return _Cadres;

            }
            set
            {
                _Cadres = value;
            }
        }
        public string GenerateString()
        {
            List<string> rez = new List<string>();
            rez.Add($"GroupId={Id}");
            if (!string.IsNullOrEmpty(Description))
                rez.Add($"DSC={Description}");
            rez.Add($"ORD={Order}");
            return string.Join(";", rez.ToArray());
        }

        public static INFO_SceneGroup GenerateFromString(string line)
        {
            INFO_SceneGroup Rez = null;
            List<string> data = line.Split(';').ToList();
            foreach (var str in data)
            {
                if (str.StartsWith("GroupId="))
                {
                    Rez = new INFO_SceneGroup(str.Replace("GroupId=", string.Empty));
                }
                else if (str.StartsWith("DSC="))
                {
                    if (Rez != null)
                        Rez.Description = (str.Replace("DSC=", string.Empty));
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
