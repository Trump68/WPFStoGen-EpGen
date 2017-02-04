using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public class SelectorStringGroup : SelectorBase
    {

        public SelectorStringGroup(string groupid)
            : base(groupid)
        {

        }
        public override int Select(List<List<SelectorData>> dataList)
        {
            int result = -1;
            List<string> datatocheck = new List<string>();
            List<int> listresults = new List<int>();
            for (int i = 0; i < dataList.Count; i++)
            {
                datatocheck.Clear();
                foreach (SelectorData selectorData in dataList[i])
                {
                    if (Id.Equals(selectorData.SelectorId))
                    {
                        datatocheck.Add((string)selectorData.Data);                        
                    }
                }
                // check if any of the data prop fit to criteria list (OR)
                if (this.CheckCriteriaGroups_Or(datatocheck)) listresults.Add(i);                
            }
            if (listresults.Count > 0) // randomize result
            {
                int resultindex = Universe.Rnd.Next(listresults.Count);
                return listresults[resultindex];
            }
            return result;
        }
        private bool CheckCriteriaGroups_Or(List<string> datatocheck)
        {
            // Outer list - OR. Get fist fit
            foreach (List<SelectorData> listSelectorData in CriteriaList)
            {
                if (CheckCriteriaGroup_And(listSelectorData, datatocheck)) return true;
            }
            return false;
        }
        private bool CheckCriteriaGroup_And(List<SelectorData> listSelectorData, List<string> datatocheck)
        {
            foreach (SelectorData selectorData in listSelectorData)
            {
                bool ok = false;
                string condition = ((string)selectorData.Data);
                foreach (string data in datatocheck) //check if any of the data prop fit to criteria (OR)
                {
                    if (condition.Equals(data)) { ok = true; break; }
                }
                if (!ok) return false;
            }
            return true;
        }
    }
}
