using StoGenLife.Enviroment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.Specie.EnergySystem
{
    public interface IBaseFoodDigestionSystem
    {
        bool Init(int value, int capacityMax);
        /// <summary>
        /// digestion simulation
        /// </summary>
        double TryGet();
        /// <summary>
        /// feed simulation
        /// </summary>
        int TryAdd(int food);
    }
    public class DefaultBaseFoodDigestionSystem : IBaseFoodDigestionSystem
    {
        #region Interface implementation       
        public bool isEmpty { get { return this.Value <= 0; } }
        public bool isFull { get { return this.Value >= this.CapacityMax; } }
        public bool Init(int value, int capacityMax)
        {
            this.CapacityMax = capacityMax;
            this.Value = value;
            return true;
        }
        public double TryGet()
        {
            if (this.isEmpty) return 0;
            TimeSpan span = World.GameTime.Subtract(this.LastProcessTime);

            double digested = this.DigestionRate * span.TotalHours;

            if (this.Value < digested)
            {
                digested = this.Value;
            }
            this.Value = (int)(this.Value - digested);

            double energy = digested * DigestionEfficiency;
            
            this.LastProcessTime = World.GameTime;
            return energy;
        }
        public int TryAdd(int value)
        {
            if (value < 0) return value;
            int deficit = this.CapacityMax - Value;
            if (deficit < value)
            {
                value = deficit;
            }
            this.Value = this.Value + value;
            return value;
        }
        #endregion

        #region Private
        /// <summary>
        /// Digestion Efficiency (how fast food can be digested)
        /// default: all food can be digested by 2 hours
        /// </summary>
        private double DigestionRate { get { return (CapacityMax / 2); } }
        /// <summary>
        /// Digestion Efficiency (how good digested food converting to energy)
        /// </summary>
        private float DigestionEfficiency { set; get; } = 1;
        /// <summary>
        /// Last processed game time
        /// </summary>
        private DateTime LastProcessTime { set; get; }
        /// <summary>
        /// Max capacity 
        /// </summary>
        private int CapacityMax { set; get; } = 300;

        /// <summary>
        /// Current energy stored in
        /// </summary>
        private int _Value;
        private int Value
        {
            set
            {
                _Value = value;
                this.LastProcessTime = World.GameTime;
            }
            get
            {
                return _Value;
            }
        }

       
        #endregion
    }
}
