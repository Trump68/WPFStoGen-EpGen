using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Entity
{

    public class EntityData
    {
        public static string ImageDialogMain = "PIC Main dialog";
        public List<EntityVariable> Variables { get; } = new List<EntityVariable>();
        public IEnumerable<EntityVariable> ByName(string type, string name, string part)
        {
            return Variables.Where(x => x.Type == type && x.Name == name && x.Part == part);
        }
        public void SetByName(string type, string name, string part, string val)
        {
            ByName(type, name, part).ToList().ForEach(x => x.Value = val);
        }
        public void Add(string type, string name, string part, string defaultVal)
        {
            //if (!ByName(type, name, part).Any())
            //{
                this.Variables.Add(new EntityVariable(type, name, part, defaultVal, null));
            //}
        }
    }

    public class EntityVariable
    {
        public string Name;
        public string Part;
        public string Description;
        public string Value;
        public string Type;
        public EntityVariable(string type, string name, string part, string val, string desc)
        {
            Name = name;
            Part = part;
            Description = desc;
            Value = val;
            Type = type;
        }
    }
}
