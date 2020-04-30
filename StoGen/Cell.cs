using StoGen.Classes;
using StoGenerator.CadreElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator
{
  
    public class Cell 
    {
        public enum Kind
        {
            Land, // земля          
            Area, //  нас. пункт
            District, // район
            Street, // улица
            House, // дом
            Aparment, // квартира
            Cell //комната, помещение
        }
       
        public Kind LocationKind { get; set; } 
        public Cell Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VisualName { get; set; }
        public List<Info_Scene> Picture(string feature)
        {
            return CE_Location.Get(VisualName, feature);
        }
        public HashSet<Cell> NearByCells = new HashSet<Cell>();
        public List<Cell> Cells = new List<Cell>();
        public Cell(string name, string visualName, Cell owner, Kind kind, params Cell[] nearBy)
        {
            Name = name; Owner = owner; LocationKind = kind; this.VisualName = visualName;
            nearBy?.ToList().ForEach(x=>this.SetNearBy(x));       
            if (Owner != null)
            {
                Owner.Cells.Add(this);
            }
        }
        // static 

        private static List<Cell> _Storage;
        public static List<Cell> Storage
        {
            get
            {
                if (_Storage == null)
                {
                    _Storage = new List<Cell>();
                    Initiate();
                }
                return _Storage;
            }
        }
        private static void Initiate()
        {
            //var land = AddLandNihon();
            var street = AddStreetJasmineGardens(null);
            _Storage.Add(street);
        }

        //private static LocationGeneric AddLandNihon()
        //{
        //    LocationGeneric item = new LocationGeneric("Земля Нихон", null, Kind.Land);
        //    var district = AddCityMorston(item);
        //    return item;
        //}
        //private static LocationGeneric AddCityMorston(LocationGeneric owner)
        //{
        //    LocationGeneric item = new LocationGeneric("Город Морстон", owner, Kind.District);
        //    var area = AddStreetJasmineGardens(item);
        //    return item;
        //}
        private static Cell AddStreetJasmineGardens(Cell owner)
        {
            Cell street = new Cell("Жасминовая улица", "Street City 001", owner, Kind.Area);
            var house = AddHouseNumber1(street, street);
            return street;
        }
        private static Cell AddHouseNumber1(Cell owner, params Cell[] nearByExternal)
        {
            Cell house = new Cell("Дом N1", "Municipal Building 001", owner, Kind.House, nearByExternal);
            Cell hall = new Cell($"Холл", "Hallway 001", house, Kind.Aparment, house);
            Cell ap1 = AddApartNumber(house, "1", hall);
            Cell ap2 = AddApartNumber(house, "2", hall);
            Cell ap3 = AddApartNumber(house, "3", hall);
            return house;
        }

        private static Cell AddApartNumber(Cell owner, string num, params Cell [] nearByExternal)
        {
            Cell apart = new Cell($"Квартира N{num}","Door 001", owner, Kind.Aparment, nearByExternal);
            Cell livingroom = new Cell("Гостиная", "Student Room 001", apart, Kind.Cell, apart);
            Cell kitchen = new Cell("Кухня", "Student Room 002", apart, Kind.Cell, livingroom);            
            return apart;
        }

        protected void SetNearBy(Cell near)
        {
            if (!this.NearByCells.Contains(near))
                this.NearByCells.Add(near);
            if (!near.NearByCells.Contains(this))
                near.NearByCells.Add(this);
        }

    }
  

}
