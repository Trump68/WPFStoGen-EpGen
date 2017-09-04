using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.Intellect
{
    public interface IMotivationTarget
    {
        string Description { set; get; }
        void CheckIfComplete();
    }
    public class MotivationTarget: IMotivationTarget
    {

        #region Interface implementation
        public string Description { set; get; } = string.Empty;
        public void CheckIfComplete() { } 
        #endregion
    }
}
