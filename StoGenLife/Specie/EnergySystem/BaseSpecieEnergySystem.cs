using StoGenLife.Specie.EnergySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.Specie
{

    public interface IBaseSpecieEnergySystem
    {
        bool Init(object paramStorage);
        int TryGet(int energy);
        /// <summary>
        /// Feeding emulation
        /// </summary>                
        int TryFeed(int food);
        void InitDefault();
        bool IsEmpty { get; set; }
    }

    public class DefaultBaseSpecieEnergySystem: IBaseSpecieEnergySystem
    {
        public int StrategicEnergyConvertionRate = 10;
        public DefaultBaseSpecieEnergySystem(
            IBaseSpecieEnergyStorage operativeStorage,
            IBaseSpecieEnergyStorage strategicStorage,
            IBaseFoodDigestionSystem digestion)
        {
            this.StorageOperative = operativeStorage;            
            this.StorageStrategic = strategicStorage;
            this.Digestion = digestion;
        }

        #region Interface implementation
        public void InitDefault()
        {
            List<int> pramList = new List<int>();
            pramList.Add(0);
            pramList.Add(300);
            pramList.Add(0);
            pramList.Add(1000);
            pramList.Add(0);
            pramList.Add(300);
            this.Init(pramList.ToArray());
        }
        public bool Init(object paramStorage)
        {
            int[] pramList  = paramStorage as int[];
            if (pramList == null) return false;

            this.StorageOperative.Init(pramList[0], pramList[1]);
            this.StorageStrategic.Init(pramList[2], pramList[3]);

            this.Digestion.Init(pramList[4], pramList[5]);

            return true;
        }
        public int TryGet(int energy)
        {            
            int val = this.StorageOperative.TryGet(energy);
            if (val < energy)
            {
                int val2 = ProcessInternal(energy - val);
                val = val + val2;
            }
            this.IsEmpty = (val == 0);
            return val;
        }
        public int TryFeed(int food)
        {
           return this.Digestion.TryAdd(food);
        }
        public bool IsEmpty { get; set; }
        #endregion

        #region Private
        /// <summary>
        /// 1st level Energy storage (sugar)
        /// </summary>
        private IBaseSpecieEnergyStorage StorageOperative { get; }
        /// <summary>
        /// 2st level Energy storage (fat, etc)
        /// </summary>
        private IBaseSpecieEnergyStorage StorageStrategic { get; }
        /// <summary>
        /// Digestion emalation
        /// </summary>
        private IBaseFoodDigestionSystem Digestion { get; }
        private int ProcessInternal(int val)
        {                                   
            int result = this.StorageStrategic.TryGet(StrategicEnergyConvertionRate);
            if (result > 0)
            {
                this.StorageOperative.TryAdd(result);
                result = this.StorageOperative.TryGet(val);
            }
            return result;
        }
        #endregion

    }
    
}
