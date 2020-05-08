using StoGen.Classes.Interfaces;
using StoGen.Classes.Persons;
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
            List<Person> homeless = new List<Person>();
            List<Cell> availablehomes = new List<Cell>();
            availablehomes.AddRange(Cells);
            foreach (var pers in Persons)
            {
                if (string.IsNullOrEmpty(pers.CurrentHomeAddress))
                {
                    homeless.Add(pers);
                }
                else
                {
                    availablehomes.RemoveAll(x=>x.FullName == pers.CurrentHomeAddress);
                    SetPersonHome(pers.Name,pers.CurrentHomeAddress);
                }
            }

         

        }
        public void AllocateCurrentCells()
        {
            foreach (var pers in Persons)
            {
                if (!string.IsNullOrEmpty(pers.CurrentHomeAddress))
                {
                    SetPersonCurrentCell(pers.Name, pers.CurrentHomeAddress);
                }              
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
