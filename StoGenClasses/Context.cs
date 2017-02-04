using System;
using System.Collections.Generic;
using System.Linq;

namespace StoGen.Classes
{
    public class Context
    {
        public List<List<SelectorData>> Data { set; get; }
        public Context()
        {
            Data = new List<List<SelectorData>>();
        }
    }
}
