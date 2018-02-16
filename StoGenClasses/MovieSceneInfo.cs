using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public class MovieSceneInfo
    {
        public string Description { set; get; }
        public string File { set; get; }
        public string ID { set; get; }
        public decimal PositionStart { set; get; } = 0;
        public decimal PositionEnd { set; get; } = 0;

        public string GenerateString()
        {
            List<string> rez = new List<string>();
            rez.Add($"ID={ID}");
            rez.Add($"FILE={File}");
            rez.Add($"START={PositionStart}");
            rez.Add($"END={PositionStart}");
            rez.Add($"DSC={Description}");
            return string.Join(";", rez.ToArray());
        }

        public void LoadFromString(string item)
        {
            List<string> data = item.Split(';').ToList();
            foreach (var str in data)
            {
                if (str.StartsWith("ID="))
                {
                    this.ID = str.Replace("ID=", string.Empty);
                }
                else if (str.StartsWith("FILE="))
                {
                    this.File = str.Replace("FILE=", string.Empty);
                }
                else if (str.StartsWith("START="))
                {
                    this.PositionStart = Convert.ToDecimal(str.Replace("START=", string.Empty));
                }
                else if (str.StartsWith("END="))
                {
                    this.PositionEnd = Convert.ToDecimal(str.Replace("END=", string.Empty));
                }
                else if (str.StartsWith("DSC="))
                {
                    this.Description = str.Replace("DSC=", string.Empty);
                }
            }
        }
    }
}
