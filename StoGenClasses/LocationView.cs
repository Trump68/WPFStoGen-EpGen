using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public class TSectionView
    {
        public TSectionView(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Id { get; set; }
    }
    public class TSection
    {
        public string Name { get; set; }
        public List<TSectionView> Views = new List<TSectionView>();
        public void AddView(string name, string id)
        {
            this.Views.Add(new TSectionView(name, id));
        }
    }
    public class TLocation
    {
        public string Name { get; set; }
        public List<TSection> Sections = new List<TSection>();
        public TSectionView GetRandomSectionAndView()
        {            
            TSection section = Sections[Universe.Rnd.Next(Sections.Count)];
            TSectionView view = section.Views[Universe.Rnd.Next(section.Views.Count)];
            return view;             
        }
    }

    public class Village01 : TLocation
    {
        public Village01()
        {
            this.Name = "Вилла Голубая Роза";

            TSection section = new TSection();
            section.Name = "гостинная";
            section.AddView("утром", BackgroundHelper.MAKER_VICTORIAN_ROOM_01_DAY);
            section.AddView("днем", BackgroundHelper.MAKER_VICTORIAN_ROOM_01_DAY2);
            section.AddView("вечером", BackgroundHelper.MAKER_VICTORIAN_ROOM_01_EVENING);
            this.Sections.Add(section);

            section = new TSection();
            section.Name = "сосновая аллея";
            section.AddView("вечером", BackgroundHelper.MAKER_PARK_EVENING_02);
            this.Sections.Add(section);

            section = new TSection();
            section.Name = "аллея сакуры";
            section.AddView("вечером", BackgroundHelper.MAKER_PARK_EVENING_01);
            this.Sections.Add(section);
        }
    }
}
