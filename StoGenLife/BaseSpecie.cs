using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife
{
    public class BaseSpecie
    {
        // Public
        public int EnergyStored { set; get; }
        public int EnergyConsumption { set; get; }

        public BaseSpecie()
        {
            this.IsLive = true;
        }
        public bool Live { get { return IsLive; } }
        public bool Kill()
        {
           return this.Die();
        }
        public void Exists(int timeUnits)
        {
            this.EnergyStored = this.EnergyStored - (this.EnergyConsumption * timeUnits);
            if (this.EnergyStored <= 0)
                this.Die();
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
