using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public class SelectorData
    {
        public SelectorData()
        {
            this.SelectorId = string.Empty;
        }
        public SelectorData(string selectorId)
        {
            this.SelectorId = selectorId;
        }
        public SelectorData(string selectorId, string data):this(selectorId)
        {
            this.Data = data;
        }
        public object Data { get; set; }
        public string SelectorId { get; set; }
    }
}
