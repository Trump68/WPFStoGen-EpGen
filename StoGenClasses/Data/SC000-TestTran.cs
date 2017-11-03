namespace StoGenMake.Scenes.Base
{
    public class SC000_TestTran : BaseScene
    {

        public SC000_TestTran() : base()
        {
            this.Name = "Transition test";
            EngineHiVer = 1;
            EngineLoVer = 0;
        }
        protected override void MakeCadres(string cadregroup)
        {
            this.DefaultSceneText.Shift = 200;
            this.DefaultSceneText.Size = 60;
            this.DefaultSceneText.FontSize = 20;
            this.DefaultSceneText.FontColor = "Yellow";
            //// real
            cadregroup = "test";

            base.MakeCadres(cadregroup);
        }
        protected override void LoadData()
        {
            string path = null;
            path = @"d:\Temp\";
            string fn = string.Empty;
            string name = string.Empty;
            //raw

            name = $"Evil_blue"; fn = $"TestBlue.png";
            AddToGlobalImage(name, fn, path, new DifData() { S = 500, F = 0 });
            name = $"Evil_red"; fn = $"TestRed.png";
            AddToGlobalImage(name, fn, path, new DifData() { S = 300, F = 0 });
            name = $"Evil_green"; fn = $"TestGreen.png";
            AddToGlobalImage(name, fn, path, new DifData() { S = 500, F = 0 });

            AddGlobal(new string[] { "" },
            new DifData[] {
                new DifData("Evil_blue") { X=100 },
                new DifData("Evil_red","Evil_blue") {X=200},
            });
            AddLocal(new string[] { "test" },
            new DifData[] {
                new DifData("Evil_blue") { X=100 },
                new DifData("Evil_red","Evil_blue") {X=200, T=Transition.Test_Opacity},
            });
            

        }
    }
}
