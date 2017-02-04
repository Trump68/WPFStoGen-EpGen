using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public class ProcVariant
    {
        public ProcVariant()
        {
        }

        public ProcVariant(string name,string descr)
        {
            this.Name = name;
            this.Description = descr;
        }
        // Fields...
        private string _Description;
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }


        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
            }
        }
          
    }
}
