﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes.Story
{
    public class Location
    {
        public Location(StoryMaker story)
        {
            Story = story;
            FillLocations();
        }
        public string Template = null;
        StoryMaker Story;
        public int Z = 0;
        public string Current;
        public string Description;
        private string LastFile = null;
        private int LastCadreIdx = -1;

        public void SmartShow(string transform)
        {
            Z = Story.NextFreeZ + 1;
            string transit = string.Empty;
            string file = GetFileLocation(Current);
            int o = 0;
            if (LastCadreIdx == Story.PrevCadreIdx) // location showed in prev cadre
            {
                if (file != LastFile) // different
                {                   
                    transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitionAppear750 : $"{StoryMaker.TransitionAppear750}>{transform}";                    
                }
                else // exact same
                {
                    transit = string.IsNullOrEmpty(transform) ? null : transform ;
                    o = 100;
                }
            } 
            else if (LastCadreIdx < Story.PrevCadreIdx) // last cadre was without location
            {
                transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitionAppear750 : $"{StoryMaker.TransitionAppear750}>{transform}";
            }                        

            Story.Scenario.Add(Story.AddImageByTemplate(Description, Z, Template, file, o, transit));

            LastFile = file;
            LastCadreIdx = Story.CurrCadreIdx;
            Story.NextFreeZ = Z + 1;
        }

        public void SmartHide(string transform)
        {
            string transit = string.Empty;
            string file = GetFileLocation(Current);
            if (LastCadreIdx == Story.PrevCadreIdx) // location showed in prev cadre
            {
                if (file != LastFile) // different
                {
                    transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitDissappear1000 : $"{StoryMaker.TransitionAppear750}>{transform}>{StoryMaker.TransitDissappear1000}";
                }
                else // exact same
                {
                    transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitDissappear1000 : $"{transform}>{StoryMaker.TransitDissappear1000}";
                }
            }
            else if (LastCadreIdx < Story.PrevCadreIdx) // last cadre was without location
            {
                transit = string.IsNullOrEmpty(transform) ? StoryMaker.TransitDissappear1000 : $"{StoryMaker.TransitionAppear750}>{transform}>{StoryMaker.TransitDissappear1000}";
            }

            Story.Scenario.Add(Story.AddImageByTemplate(Description, Z, Template, file, 100, transit));
        }

        public void SmartShow()
        {
            SmartShow(null);
        }
        public void SmartHide()
        {
            SmartHide(null);
        }
        // Location
        List<Tuple<string, string, string>> locations = new List<Tuple<string, string, string>>();
        string locationroot = @"e:\!EPCATALOG\LOCATION\";
        private void FillLocations()
        {
            string catalog = "BEDROOM";
            locations.Add(new Tuple<string, string, string>("Bedroom 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\BEDROOM -morning.png"));
            locations.Add(new Tuple<string, string, string>("Bedroom 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\BEDROOM -day.png"));
            locations.Add(new Tuple<string, string, string>("Bedroom 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\BEDROOM -evening.png"));
            catalog = "GARDEN";
            locations.Add(new Tuple<string, string, string>("Garden 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Garden-morning.png"));
            catalog = "HALL";
            locations.Add(new Tuple<string, string, string>("Hall 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Hall-morning.png"));
            locations.Add(new Tuple<string, string, string>("Hall 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Hall-day.png"));
            locations.Add(new Tuple<string, string, string>("Hall 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Hall-evening.png"));
            catalog = "KORRIDOR";
            locations.Add(new Tuple<string, string, string>("Korridor 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Korridor-morning.png"));
            locations.Add(new Tuple<string, string, string>("Korridor 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Korridor-day.png"));
            locations.Add(new Tuple<string, string, string>("Korridor 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Korridor-evening.png"));
            catalog = "BATHROOM";
            locations.Add(new Tuple<string, string, string>("Bathroom 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Bathroom-morning.png"));
            locations.Add(new Tuple<string, string, string>("Bathroom 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Bathroom-day.png"));
            locations.Add(new Tuple<string, string, string>("Bathroom 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Bathroom-evening.png"));
            catalog = "LIVINGROOM";
            locations.Add(new Tuple<string, string, string>("Livingroom 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Livingroom-morning.png"));
            locations.Add(new Tuple<string, string, string>("Livingroom 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Livingroom-day.png"));
            locations.Add(new Tuple<string, string, string>("Livingroom 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Livingroom-evening.png"));
            catalog = "MANOR";
            locations.Add(new Tuple<string, string, string>("Manor 001 morning", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Manor-morning.png"));
            locations.Add(new Tuple<string, string, string>("Manor 001 day", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Manor-day.png"));
            locations.Add(new Tuple<string, string, string>("Manor 001 evening", catalog, @"Ryoujoku Celeb Zuma _ Kutsujoku!! Niku Dorei e no Daraku\Manor-evening.png"));
            catalog = "STREET";
            locations.Add(new Tuple<string, string, string>("Street 001 morning", catalog, @"001\Street-morning.jpg"));
            locations.Add(new Tuple<string, string, string>("Street 001 day", catalog, @"001\Street-day.jpg"));
            locations.Add(new Tuple<string, string, string>("Street 001 evening", catalog, @"001\Street-evening.jpg"));
            locations.Add(new Tuple<string, string, string>("Street 002 morning", catalog, @"002\0002-morning.jpg"));
            locations.Add(new Tuple<string, string, string>("Street 002 evening", catalog, @"002\0002-evening.jpg"));
            catalog = "CLASS";
            locations.Add(new Tuple<string, string, string>("Class 001 day", catalog, @"001\Class-day.jpg"));
            locations.Add(new Tuple<string, string, string>("Class 002 day", catalog, @"002\class-day.jpg"));
            catalog = "BUILDINGS";
            locations.Add(new Tuple<string, string, string>("Building 001 day", catalog, @"001\001-day.jpg"));
            locations.Add(new Tuple<string, string, string>("Building 001 morning", catalog, @"001\001-morning.jpg"));
            locations.Add(new Tuple<string, string, string>("Building 002 evening", catalog, @"002\House-evening.jpg"));
            catalog = "CHILDROOM";
            locations.Add(new Tuple<string, string, string>("Childroom 001 morning", catalog, @"001\001-morning.jpg"));
            locations.Add(new Tuple<string, string, string>("Childroom 001 evening", catalog, @"001\001-evening.jpg"));
            locations.Add(new Tuple<string, string, string>("Childroom 002 evening", catalog, @"002\002-evening.jpg"));
            locations.Add(new Tuple<string, string, string>("Childroom 003 night", catalog, @"003\003-night.jpg"));
            catalog = "SCHOOL";
            locations.Add(new Tuple<string, string, string>("School hall 001 day", catalog, @"HOLL\She Falls to a Perverted Bastard\hall-day.jpg"));
            locations.Add(new Tuple<string, string, string>("School dresser 001 day", catalog, @"DRESSER\001\001-day.jpg"));
            catalog = "FOREST";
            locations.Add(new Tuple<string, string, string>("Forest 001 day", catalog, @"001\001-day.jpg"));
        }
        protected virtual string GetFileLocation(string name)
        {
            var val = locations.Where(x => (x.Item1 == name) || (x.Item3 == name)).FirstOrDefault();
            if (val == null) return null;
            return Path.Combine(locationroot, val.Item2, val.Item3);
        }
        public string GetLocation(string group, string dsc, string name, int size, int x, int y, int z, int ord, string tran, string template, bool istemplate)
        {
            return Story.GetImage(group, dsc, GetFileLocation(name), size, x, y, z, ord, tran, template, istemplate);
        }

        // Old ==============================================
        public string OldShow()
        {
            return OldShow(null);
        }
        public string OldShow(string transform)
        {
            string file = GetFileLocation(Current);
            return Story.AddImageByTemplate(Description, Z, Template, file, transform);
        }
        public string OldShowHidden(string transform)
        {
            string file = GetFileLocation(Current);
            return Story.AddImageByTemplate(Description, Z, Template, file, 0, transform);
        }


    }
}
