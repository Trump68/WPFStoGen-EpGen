using StoGen.Classes.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator
{
    public enum Teller
    {
        Female,
        Male,
        FemaleThoughts,
        MaleThoughts,
        Author,
        Others,
        OthersThoughts
    }
    public class StoryBase
    {
        public SCENARIO Scenario { set; get; }
        public string currentQueue;
        public string currentGroup;
        public string Name { set; get; }
        public void IncrementGroup()
        {
            var vals = currentGroup.Split('.');
            if (vals.Length == 0) return;
            int d;
            if (int.TryParse(vals[0], out d))
            {
                ++d;
                vals[0] = (d.ToString("D" + vals[0].Length));
            }
            currentGroup = string.Join(".", vals);
        }
    }
}
