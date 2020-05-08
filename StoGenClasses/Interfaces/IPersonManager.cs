using StoGen.Classes.Persons;
using StoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Interfaces
{
    public interface IPersonManager
    {
        void AllocateHomes(List<Person> persons, List<Cell> cells);
        void AllocateCurrentCells();
    }
}
