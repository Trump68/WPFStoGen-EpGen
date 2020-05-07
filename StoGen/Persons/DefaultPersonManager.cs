﻿using StoGen.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.Persons
{
    public class DefaultPersonManager : IPersonManager
    {

        public List<Person> Persons;
        public List<Cell> Cells;
        public void AllocateHomes(List<Person> persons, List<Cell> cells)
        {
            Persons = persons;
            Cells = cells;
            for (int i = 0; i < 8; i++)
            {
                if (Persons.ElementAt(i) != null)
                    SetPersonHome(Persons[i].Name, $"Квартира N{i+1},Дом N1,Жасминовая улица");
            }

        }
        public void AllocateCurrentCells()
        {
            for (int i = 0; i < 8; i++)
            {
                    if (Persons.ElementAt(i) != null)
                    SetPersonCurrentCell(Persons[i].Name, $"Квартира N{i + 1},Дом N1,Жасминовая улица");
            }

        }
        private void SetPersonHome(string personName, string homeaddress)
        {
            Person person = Person.Storage.Where(x => x.Name == personName).FirstOrDefault();
            if (person != null)
            {
                Cell home = Cell.GetByAddress(Cell.Storage, homeaddress);
                person.CurrentHome = home;
            }
        }
        private void SetPersonCurrentCell(string personName, string homeaddress)
        {
            Person person = Person.Storage.Where(x => x.Name == personName).FirstOrDefault();
            if (person != null)
            {
                Cell cell = Cell.GetByAddress(Cell.Storage, homeaddress);
                var realsell =cell.Cells.Where(x => x.LocationKind == Cell.Kind.Cell).FirstOrDefault(); // get first real cell in address
                person.CurrentCell = realsell;
            }
        }

    }
}
