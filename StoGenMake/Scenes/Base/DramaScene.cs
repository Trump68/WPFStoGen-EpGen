using StoGenMake.Elements;
using StoGenMake.Pers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes.Base
{
    public class DramaScene : BaseScene
    {
        public List<VNPC> Actors;
        public void NextCadre(string name)
        {
            ScenCadre cadre;
            cadre = this.AddCadre(null, name, 200, this);
            this.Actors[0].SetCloth(cadre);
            this.Actors[0].SetHead(cadre);

            this.AddObzor(cadre);
        }
        public DramaScene(List<VNPC> actors) : base()
        {
            this.Actors = actors;
            foreach (var item in this.Actors)
            {
                item.Scene = this;
            }

            this.Name = "Drama scene";
            this.SizeX = 1500;
            this.SizeY = 1600;
        }
        public ViewingTransitionState StateViewingTransition = ViewingTransitionState.None;
        protected void AddObzor(ScenCadre cadre)
        {
            if (this.StateViewingTransition == ViewingTransitionState.Go)
            {
                foreach (var image in cadre.VisionList)
                {
                    if (!string.IsNullOrEmpty(image.Transition))
                    {
                        image.Transition = image.Transition + "*" + Transition.Obzor();
                    }
                    else
                        image.Transition = Transition.Obzor();
                }
            }
        }
     

    }
}
