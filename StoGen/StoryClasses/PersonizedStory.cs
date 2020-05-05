﻿using Menu.Classes;
using StoGen.Classes;
using StoGen.Classes.Interfaces;
using StoGen.Classes.Transition;
using StoGenerator.Persons;
using StoGenerator.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoGenerator.Person;
using static StoGenerator.Persons.JennyFord;

namespace StoGenerator.StoryClasses
{
    public class PersonizedStory : CelledStory
    {
        public List<Person> VisiblePersons = new List<Person>();
        IPersonManager PersonManager;
        public PersonizedStory(DateTime date, string startAtAddress) :base(date, startAtAddress)
        {
            FillPersonStorage();
        }

        protected virtual void FillPersonStorage()
        {
            Person.Storage.Add(JennyFord.Load());
            Person.Storage.Add(BobLulam.Load());
            PersonManager = new DefaultPersonManager();
            PersonManager.AllocateHomes(Person.Storage, Cell.Storage);
            PersonManager.AllocateCurrentCells();
        }
        protected override void FillCadreContent()
        {
            base.FillCadreContent();
            foreach (var person in CurrentCell.Persons)
            {
                ProcessPerson(person);
            }
            
        }
        // Set person ===============================
        private void ProcessPerson(Person person)
        {
            SetPersonOutfit(person);
            SetPersonFace(person);
        }
        private void SetPersonOutfit(Person person)
        {
            string outfit = GetPersonOutfitName(person);
            Layers = person.GetFigure(Layers, outfit, null, Trans.Appearing(500));
        }
        private void SetPersonFace(Person person)
        {
            Layers = person.GetFace(Layers, $"{JennyFord_Eyes.Eyes1_67}", $"{JennyFord_Mouth.Mouth1_67}", $"{Feature.FeatureBlink}{1}");
        }
        private string GetPersonOutfitName(Person person)
        {
            return $"{OutfitName.CasHome_I}{1}";
        }
        // Set person ===============================

        public override bool CreateMenu(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, MenuType type, bool goNextCadre)
        {
            string caption;
            string cap = null;
            if (type == MenuType.Cell) // moving
            {
                if (MenuIsLive)
                {
                    itemlist = FillMenu_GoToLocation_ByData(proc, null, goNextCadre, out caption);
                    cap = caption;
                }
            }
            else if (type == MenuType.Default) 
            {
                if (MenuIsLive)
                    itemlist = AddRootMenu(proc, null, goNextCadre, out caption);
                itemlist = base.AddRootMenu(proc, itemlist, goNextCadre, out caption);
            }
            ChoiceMenuItem.FinalizeShowMenu(proc, doShowMenu, itemlist, true, cap, type);
            return true;
        }
        protected override List<ChoiceMenuItem> AddRootMenu(CadreController proc, List<ChoiceMenuItem> itemlist,bool goNextCadre, out string caption)
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
                    Layers = PullCadreFromScene(proc, proc.CadreId);
                    Layers = person.GetFace(Layers, v.Item2, v.Item1, $"{Feature.FeatureBlink}{1}");
                    AddScenes(Layers, 1, false);
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
                    Layers = PullCadreFromScene(proc, proc.CadreId);
                    var feature = data as Tuple<string, string, string, string>;
                    Layers = person.CombinePerson(Layers, feature, ms);                              
                    AddScenes(Layers, 1, false);
                    proc.RefreshCurrentCadre();
                };
                itemlist.Add(item);
            }

            caption = "Поменять фигуру";
            return itemlist;
        }



        protected override void GenerateNewStoryStep(CadreController proc)
        {
            base.GenerateNewStoryStep(proc);
        }
    }
}
