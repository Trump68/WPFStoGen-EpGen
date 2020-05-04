using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Classes
{
    public enum MenuType
    {
        Common = 0,
        Cell = 1,
        Default = 2
    }
    public delegate bool MenuCreatorDelegate(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, MenuType type, bool goNextCadre);
}
