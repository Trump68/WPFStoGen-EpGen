using StoGen.Classes.Interfaces;
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
        public void AllocateCells(List<Person> persons, List<Cell> cells)
        {
            Persons = persons;
            Cells = cells;
            SetPerson(JennyFord.Load(), "Квартира N1,Дом N1,Жасминовая улица");
            SetPerson(BobLulam.Load(),  "Квартира N2,Дом N1,Жасминовая улица");

        }
        private void SetPerson(Person person, string homeaddress)
        {
            Cell home = Cell.GetByAddress(Cell.Storage, homeaddress);
            person.CurrentHome = home;
            Persons.Add(person);
        }
    }
}
