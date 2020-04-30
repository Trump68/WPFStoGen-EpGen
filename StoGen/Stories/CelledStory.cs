using StoGen.Classes;
using StoGenerator.CadreElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Stories
{
    public class CelledStory : StoryBase
    {
        protected Cell CurrentCell;
        public CelledStory():base()
        {
            CurrentCell = Cell.Storage.First();
        }

    }
}
