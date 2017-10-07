using StoGenMake.Elements;
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
        public IEnumerable<EntityVariable> ByName(string type, string group, string part)
        {
            return Variables.Where(x => x.Type == type && x.Group == group && x.Part == part);
        }
        public void SetByName(string type, string name, string part, seIm im)
        {
            ByName(type, name, part).ToList().ForEach(x => x.Image = im);
        }
        public void Add(string type, string group, seIm im, string part = null)
        {
            //if (!ByName(type, name, part).Any())
            //{
                this.Variables.Add(new EntityVariable(type, group, im, part));
            //}
        }
    }

    public class EntityVariable
    {
        public seIm Image;
        public string Group;
        public string Part;
        public string Type;
        public EntityVariable(string type,string group, seIm im, string part = null)
        {
            this.Image = im;
            Group = group;
            Part = part;
            Type = type;
        }
    }
}
