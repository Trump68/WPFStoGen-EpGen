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
        public void AllocateHomes(List<Person> persons, List<Cell> cells)
        {
            Persons = persons;
            Cells = cells;
            SetPersonHome(JennyFord.Name, "Квартира N1,Дом N1,Жасминовая улица");
            SetPersonHome(BobLulam.Name,  "Квартира N2,Дом N1,Жасминовая улица");
        }
        public void AllocateCurrentCells()
        {
            SetPersonCurrentCell(JennyFord.Name, "Квартира N1,Дом N1,Жасминовая улица");
            SetPersonCurrentCell(BobLulam.Name, "Квартира N2,Дом N1,Жасминовая улица");
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
                Cell home = Cell.GetByAddress(Cell.Storage, homeaddress);
                person.CurrentHome = home;
            }
        }

    }
}
