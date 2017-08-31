using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.Specie
{
    public class BaseSpecieBody
    {
        // Public
       
        public int EnergyConsumption { set; get; }

        public BaseSpecieBody()
        {
            this.IsLive = true;
        }
        public bool Live { get { return IsLive; } }
        public bool Kill()
        {
           return this.Die();
        }        
        // Privates
        private bool IsLive { set; get; }
        private bool Die()
        {
            this.IsLive = false;
            return this.IsLive;
        }

    }
}
