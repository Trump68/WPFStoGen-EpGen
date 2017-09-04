using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenLife.Intellect
{
    public interface IBaseIntellect
    {
        List<IMotivationTarget> MotivationTargetList { get; }
        bool CheckMotivationTargetCompleted();
    }

    public class BaseDefaultIntellect: IBaseIntellect
    {


        #region Interface implementation
        public List<IMotivationTarget> MotivationTargetList { get; } = new List<IMotivationTarget>();
        public bool CheckMotivationTargetCompleted()
        {
            bool result = false;
            foreach (IMotivationTarget target in MotivationTargetList)
            {
                target.CheckIfComplete();
            }
            return result;
        }
        #endregion

    }
}
