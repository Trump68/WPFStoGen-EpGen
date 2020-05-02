using StoGen.Classes;
using StoGenerator.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoGenerator.Person;

namespace StoGenerator.StoryClasses
{
    public class PersonizedStory : CelledStory
    {
        public List<Person> VisiblePersons = new List<Person>();
        public PersonizedStory(DateTime date):base(date)
        {

        }

        public override bool CreateMenu(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, object Data)
        {
            string caption;
            int mode = (int)Data;
            int viewNum = mode;
            string cap = null;
            if (mode == 1) // moving
            {
                if (MenuIsLive)
                {
                    itemlist = FillMenu_GoToLocation_ByData(proc, null, out caption);
                    cap = caption;
                }
            }
            else // all
            {
                if (MenuIsLive)
                    itemlist = AddRootMenu(proc, null, out caption);
                itemlist = base.AddRootMenu(proc, itemlist, out caption);
            }
            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true, cap, viewNum);
            return true;
        }
        protected override List<ChoiceMenuItem> AddRootMenu(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();         
            AddMenu_PersonSelection(proc, itemlist, out caption);
            caption = "Выбрать персонаж";
            return itemlist;
        }
        protected List<ChoiceMenuItem> AddMenu_PersonSelection(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            ChoiceMenuItem item = new ChoiceMenuItem();
            item.Name = "Выбрать персонаж";
            item.Executor = data =>
            {
                string caption2;
                var itemlist1 = AddMenu_Persons(proc, null, out caption2);
                ShowSubmenu(proc, itemlist1, caption2);
            };
            itemlist.Add(item);
            caption = "Выбрать персонаж";
            return itemlist;
        }
        private List<ChoiceMenuItem> AddMenu_Persons(CadreController proc, List<ChoiceMenuItem> itemlist, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            foreach (var person in this.VisiblePersons)
            {
                ChoiceMenuItem item = new ChoiceMenuItem();
                item.Name = person.Name;
                item.itemData = person;
                item.Executor = data =>
                {
                    string caption2;
                    var itemlist1 = AddMenu_PersonActions(proc, null, data as Person, out caption2);
                    ShowSubmenu(proc, itemlist1, caption2);
                };
                itemlist.Add(item);
            }
            caption = "Выбрать персонаж";
            return itemlist;
        }
        private List<ChoiceMenuItem> AddMenu_PersonActions(CadreController proc, List<ChoiceMenuItem> itemlist, Person person, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();

                ChoiceMenuItem item = new ChoiceMenuItem();
                item.Name = "Поменять выражение лица";
                item.itemData = person;
                item.Executor = data =>
                {
                    string caption2;
                    var itemlist1 = AddMenu_ChangingFace(proc, null, data as Person, out caption2);
                    ShowSubmenu(proc, itemlist1, caption2);
                };
                itemlist.Add(item);

                item = new ChoiceMenuItem();
                item.Name = "Поменять фигуру";
                item.itemData = person;
                item.Executor = data =>
                {
                    string caption2;
                    var itemlist1 = AddMenu_ChangingFigure(proc, null, data as Person, out caption2);
                    ShowSubmenu(proc, itemlist1, caption2);
                };
                itemlist.Add(item);

            caption = "Выбрать действие";
            return itemlist;
        }
        private List<ChoiceMenuItem> AddMenu_ChangingFace(CadreController proc, List<ChoiceMenuItem> itemlist, Person person, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            var list = person.GetAllFaceCombinations();

            foreach (var face in list)
            {
                var item = new ChoiceMenuItem();
                item.Name = $"{face.Item1}-{face.Item2}";
                item.itemData = face;
                MenuDescriptopnItem mdi1 = new MenuDescriptopnItem("Mouth", face.Item1, true);
                item.Props = (new List<MenuDescriptopnItem>() { mdi1 }).ToArray();
                item.Executor = data =>
                {
                    Tuple<string, string> v = (data as Tuple<string, string>);
                    F_Posture = PullCadreFromScene(proc, proc.CadreId);
                    F_Posture = person.GetFace(F_Posture, v.Item2, v.Item1, $"{Feature.FeatureBlink}{1}");
                    AddScenes(F_Posture, 1, false);
                    proc.RefreshCurrentCadre();
                };
                itemlist.Add(item);
            }
            caption = "Поменять выражение лица";
            return itemlist;
        }     
        protected List<ChoiceMenuItem> AddMenu_ChangingFigure(CadreController proc, List<ChoiceMenuItem> itemlist,Person person, out string caption)
        {
            if (itemlist == null) itemlist = new List<ChoiceMenuItem>();
            var list = person.Files.Where(x => x.Item1.Contains(Person.Generic.FigureGeneric.ToString())).ToList();
            foreach (var figure in list)
            {
                var item = new ChoiceMenuItem();
                item.Name = $"{figure.Item3}";
                item.itemData = figure;
                MenuDescriptopnItem mdi1 = new MenuDescriptopnItem("Наряд", figure.Item4, true);
                item.Props = (new List<MenuDescriptopnItem>() { mdi1 }).ToArray();
                item.Executor = data =>
                {
                    int ms = 1000;
                    F_Posture = PullCadreFromScene(proc, proc.CadreId);
                    var feature = data as Tuple<string, string, string, string>;
                    F_Posture = person.CombinePerson(F_Posture, feature, ms);                              
                    AddScenes(F_Posture, 1, false);
                    proc.RefreshCurrentCadre();
                };
                itemlist.Add(item);
            }

            caption = "Поменять фигуру";
            return itemlist;
        }

    }
}
