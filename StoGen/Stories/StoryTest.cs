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
        public override void Generate(SCENARIO scenario, string queue, string group)
        {
            base.Generate(scenario, queue, group);

        }
        protected override void FillData()
        {
        }
    }
}
