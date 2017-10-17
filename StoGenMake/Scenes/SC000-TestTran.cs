using StoGenMake.Elements;
using StoGenMake.Pers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenMake.Scenes.Base
{
    public class SC000_TestTran : BaseScene
    {

        public SC000_TestTran() : base()
        {
            this.Name = "Transition test";
            this.CadreGroups.Add("1");
            this.CadreGroups.Add("2");
        
        }
        protected override void MakeCadres(string cadregroup)
        {
            this.DefaultSceneText.Shift = 200;
            this.DefaultSceneText.Size = 60;
            this.DefaultSceneText.FontSize = 20;
            this.DefaultSceneText.FontColor = "Yellow";


            //// real
            if (cadregroup == null || cadregroup == "1")
            {
                SetCadre(new AlignData[] {
                 new AlignData("Evil_blue")
                ,new AlignData("Evil_green","Evil_blue")
                ,new AlignData("Evil_red","Evil_green")
                }, this, "TEST");
            }

            if (cadregroup == null || cadregroup == "2")
            {
                SetCadre(new AlignData[] {
                 new AlignData("Evil_blue", new DifData() {Rot = 20 })
                ,new AlignData("Evil_green","Evil_blue")
                ,new AlignData("Evil_red","Evil_green")
                }, this);
            }

            //SetCadre(new AlignData[] {
            //     new AlignData("Evil_blue", new DifData() {Rot = 20 })
            //    ,new AlignData("Evil_green","Evil_blue", new DifData() {Rot = -20 })
            //    ,new AlignData("Evil_red","Evil_green")
            //}, this);

            //SetCadre(new AlignData[] {
            //     new AlignData("Evil_blue", new DifData() {Rot = 20 })
            //    ,new AlignData("Evil_green","Evil_blue", new DifData() {Rot = -20 })
            //    ,new AlignData("Evil_red","Evil_green", new DifData() {Rot = 20 })
            //}, this);

        }
        protected override void LoadData(List<seIm> data, List<AlignDif> alignData)
        {
            string path = null;


            path = @"d:\Temp\";
            string dsc = string.Empty;
            //raw
            GetIm($"Evil_blue", VNPCPersType.Manga, dsc, path, $"TestBlue.png", data);
            GetIm($"Evil_blue2", VNPCPersType.Manga, dsc, path, $"TestBlue.png", data);
            GetIm($"Evil_red", VNPCPersType.Manga, dsc, path, $"TestRed.png", data);
            GetIm($"Evil_green", VNPCPersType.Manga, dsc, path, $"TestGreen.png", data);
        }

        #region Menu
        //internal bool CreateMenuScene(ProcedureBase proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        //{
        //    ChoiceMenuItem item = null;
        //    if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

        //    item = new ChoiceMenuItem($"Scene {this.Name}", this);
        //    item.Executor = delegate (object data)
        //    {
        //        this.Generate(null);
        //        StoGenParser.AddCadresToProcFromFile(proc, this.TempFileName, null, StoGenParser.DefaultPath);
        //        proc.MenuCreator = proc.OldMenuCreator;
        //        proc.GetNextCadre();
        //    };
        //    itemlist.Add(item);
        //    ChoiceMenuItem.FinalizeShowMenu(proc, true, itemlist, false);
        //    return true;
        //}

        #endregion
    }

}
