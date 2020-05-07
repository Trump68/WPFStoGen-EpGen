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
            SetPersonHome(Persons[0].Name, "Квартира N1,Дом N1,Жасминовая улица");
            SetPersonHome(Persons[1].Name, "Квартира N2,Дом N1,Жасминовая улица");
            SetPersonHome(Persons[2].Name, "Квартира N3,Дом N1,Жасминовая улица");
            SetPersonHome(Persons[3].Name, "Квартира N4,Дом N1,Жасминовая улица");
            SetPersonHome(Persons[4].Name, "Квартира N5,Дом N1,Жасминовая улица");
            SetPersonHome(Persons[5].Name, "Квартира N6,Дом N1,Жасминовая улица");
        }
        public void AllocateCurrentCells()
        {
            SetPersonCurrentCell(Persons[0].Name, "Квартира N1,Дом N1,Жасминовая улица");
            SetPersonCurrentCell(Persons[1].Name, "Квартира N2,Дом N1,Жасминовая улица");
            SetPersonCurrentCell(Persons[2].Name, "Квартира N3,Дом N1,Жасминовая улица");
            SetPersonCurrentCell(Persons[3].Name, "Квартира N4,Дом N1,Жасминовая улица");
            SetPersonCurrentCell(Persons[4].Name, "Квартира N5,Дом N1,Жасминовая улица");
            SetPersonCurrentCell(Persons[5].Name, "Квартира N6,Дом N1,Жасминовая улица");
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
