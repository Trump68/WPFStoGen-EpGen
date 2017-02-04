using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public class SelectorBase
    {
        public string Id { set; get; }
        static SelectorRandom _Random;
        public static SelectorRandom Random 
        {
            get 
            {
                if (_Random == null)
                {
                    _Random = new SelectorRandom();

                }
                return _Random;
            } 
        }
        private List<List<SelectorData>> _CriteriaList;
        // outer list - OR groups, inner list - AND groups
        public List<List<SelectorData>> CriteriaList 
        {
            get
            {
                if (_CriteriaList == null) _CriteriaList = new List<List<SelectorData>>();
                return _CriteriaList;
            }
        }
        public SelectorBase(string id) { this.Id = id; }

        public virtual int Select(List<List<SelectorData>> dataList)
        {
            return 0; // always fist
        }
    }
    public class SelectorRandom : SelectorBase
    {
        public SelectorRandom(): base("Random"){}        
        public override int Select(List<List<SelectorData>> dataList)
        {
            return Universe.Rnd.Next(dataList.Count);
        }
    }


}
