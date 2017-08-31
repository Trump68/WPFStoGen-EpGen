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
    }

    public class DefaultBaseSpecieEnergySystem: IBaseSpecieEnergySystem
    {
        public int StrategicEnergyConvertionRate = 10;
        public DefaultBaseSpecieEnergySystem(IBaseSpecieEnergyStorage operativeStorage, IBaseSpecieEnergyStorage strategicStorage)
        {
            this.StorageOperative = operativeStorage;
            this.StorageStrategic = strategicStorage;
        }

        #region Interface implementation
        public bool Init(object paramStorage)
        {
            int[] pramList  = paramStorage as int[];
            if (pramList == null) return false;
            this.StorageOperative.Init(pramList[0], pramList[1]);
            this.StorageStrategic.Init(pramList[2], pramList[3]);
            return true;
        }
        public int TryGet(int energy)
        {
            RestoreOperativeFormStrategic();
            int val = this.StorageOperative.TryGet(energy);                        
            return val;
        }
        #endregion
        #region Private
        /// <summary>
        /// 1st level Energy storage (natural)
        /// </summary>
        private IBaseSpecieEnergyStorage StorageOperative { get; }
        /// <summary>
        /// 2st level Energy storage (fat, etc)
        /// </summary>
        private IBaseSpecieEnergyStorage StorageStrategic { get; }
        private void RestoreOperativeFormStrategic()
        {
            if (!this.StorageOperative.isFull)
            {
                int val = this.StorageStrategic.TryGet(StrategicEnergyConvertionRate);
                if (val>0)
                    this.StorageOperative.TryAdd(val);
            }
        }
        #endregion

    }
    
}
