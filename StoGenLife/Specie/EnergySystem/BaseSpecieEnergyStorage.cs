using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.Specie
{
    public interface IBaseSpecieEnergyStorage
    {
        bool Init(int value, int capacityMax);
        bool isEmpty { get; }
        bool isFull { get; }
        int TryGet(int enegry);
        int TryAdd(int enegry);
    }

    public class DefaultBaseSpecieEnergyStorage: IBaseSpecieEnergyStorage
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
        public int TryGet(int enegry)
        {
            if (enegry > Value)
            {
                enegry = Value;
            }
            Value = Value - enegry;
            return enegry;
        }
        public int TryAdd(int enegry)
        {
            int deficit = this.CapacityMax - Value;
            if (deficit < enegry)
            {
                enegry = deficit;
            }
            this.Value = this.Value + enegry;
            return enegry;
        }
        #endregion

        #region Private
        /// <summary>
        /// Max capacity 
        /// </summary>
        private int CapacityMax { set; get; }

        /// <summary>
        /// Current energy stored in
        /// </summary>
        private int Value { set; get; }        
        #endregion
    }
}
