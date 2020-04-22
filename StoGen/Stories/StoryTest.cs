using StoGen.Classes.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Stories
{
    public class StoryTest: Story001
    {
        public override void Generate(string queue, string group)
        {
            base.Generate(queue, group);

        }
        protected override void FillData()
        {
        }
    }
}
