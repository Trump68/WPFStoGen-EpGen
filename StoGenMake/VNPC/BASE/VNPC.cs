using StoGenLife.NPC;
using StoGenMake.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Pers
{
    public class VNPC:NPC
    {
        public BaseScene Scene { set; get; }
        public virtual void PrepareScene() { }

        public NPCVisualData Visual = new NPCVisualData();
        public void SetPersVariablesData(List<string> datalist)
        {
            List<string> result = new List<string>();
            if (datalist != null)
            {
                foreach (var item in datalist)
                {
                    string[] vals = item.Split(';');
                    Visual.SetByName(vals[0].Trim(),vals[1].Trim());
                }
            }
        }
    }

    public class NPCVisualData
    {
        public static string ImageDialogMain = "PIC Main dialog";
        List<VNPCVariable> variables = new List<VNPCVariable>();        
        public IEnumerable<VNPCVariable> ByName(string name)
        {
            return variables.Where(x => x.Name == name);
        }
        public void SetByName(string name,string val)
        {
            ByName(name).ToList().ForEach(x => x.Value = val);
        }
    }

    public class VNPCVariable
    {
        public string Name;
        public string Description;
        public string Value;
        public VNPCVariable(string name, string val, string desc)
        {
            Name = name;
            Description = desc;
            Value = val;
        }
    }
}
}
