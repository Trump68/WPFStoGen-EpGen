using StoGenLife.Location;
using StoGenMake.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoGen.Classes;

namespace StoGenMake.Location
{
    public class VisualLocaton : BaseLocation
    {
        public EntityData Data = new EntityData();

        internal bool CreateMenuLocationDocier(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist)
        {
            ChoiceMenuItem item = null;
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

            item = new ChoiceMenuItem($"Досье на {this.Name}", this);
            item.Executor = delegate (object data)
            {
                this.FillDocierScene();
                
                //this.Generate(this.TempFileName);

                //StoGenParser.AddCadresToProcFromFile(proc, this.TempFileName, null, StoGenParser.DefaultPath);

                proc.MenuCreator = proc.OldMenuCreator;
                proc.GetNextCadre();
            };
            itemlist.Add(item);
            return true;
        }
        public virtual void FillDocierScene()
        {
            //this.Scene.Cadres.Clear();
            //var items = this.Data.ByName("IMAGE", DOCIER_PICTURE, null);
            //foreach (var it in items)
            //{
            //    ScenCadre cadre;
            //    cadre = this.Scene.AddCadre(null, null, 200, this.Scene);

            //    ScenElementImage image;
            //    image = new ScenElementImage();
            //    image.Name = $"DOCIER_PICTURE {cadre.VisionList.Count}";
            //    cadre.VisionList.Add(image);
            //}
        }
    }
}
