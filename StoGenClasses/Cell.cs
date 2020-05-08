using StoGen.Classes;
using StoGen.Classes.Persons;
using StoGen.ModelClasses;
using StoGenerator.CadreElements;
using System.Collections.Generic;
using System.Linq;


namespace StoGenerator
{
  
    public class Cell 
    {
        public enum Kind
        {
            Land = 6, // земля          
            Area = 5, //  нас. пункт
            District = 4, // район
            Street = 3, // улица
            House = 2, // дом
            Aparment = 1, // квартира
            Cell  = 0//комната, помещение 
        }
       
        public Kind LocationKind { get; set; } 
        public Cell Owner { get; set; }
        public string Name { get; set; }
        public string FullName
        {
            get
            {
                string result = string.Empty;
                var owner = this;
                List<string> rez = new List<string>();
                while (owner != null)
                {
                    rez.Add(owner.Name);
                    owner = owner.Owner;
                }
                return string.Join(",",rez.ToArray());
            }
        }
        public string Description { get; set; }
        public string VisualName { get; set; }
        public List<Info_Scene> Picture(TimeOfDay feature)
        {
            return CE_Location.Get(VisualName, $"{feature}");
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

        public List<Person> Persons { get; internal set; } = new List<Person>();
        public List<Person> HomeOf { get; internal set; } = new List<Person>();

        private static void Initiate()
        {
            LocationStorage.InitDefaultLocations();
            //var land = AddLandNihon();
            var street = AddStreetJasmineGardens(null);
            _Storage.Add(street);
        }
        public static Cell GetByAddress(List<Cell> list, string address)
        {          
            if (list == null)
            {
                list = Cell.Storage;
            }
            if (string.IsNullOrEmpty(address))
            {
                return Cell.Storage.FirstOrDefault();
            }
            foreach (var cell in list)
            {
                if (cell.FullName == address) return cell;
                var result = GetByAddress(cell.Cells, address);
                if (result != null)
                    return result;
            }
            return null;
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
            Cell building = null;
            building = Add_HousingN1(street, street);
            building = Add_SchoolN1(street, street);
            return street;
        }
        private static Cell Add_SchoolN1(Cell owner, params Cell[] nearByExternal)
        {
            Cell room = null;
            Cell house = new Cell("Школа N1", "Building School 001", owner, Kind.House, nearByExternal);
            Cell hall = new Cell($"Школьный коридор", "School Holl 001", house, Kind.Cell, house);

            Cell classroom1 = new Cell($"Классная комната №1", "Door 002", house, Kind.Aparment, hall);
            room = new Cell($"Помещение", "Classroom 001", classroom1, Kind.Cell, classroom1);

            Cell classroom2 = new Cell($"Классная комната №2", "Door 002", house, Kind.Aparment, hall);
            room = new Cell($"Помещение", "Classroom 002", classroom2, Kind.Cell, classroom2);

            Cell lab = new Cell($"Лаборатория №1", "Door 002", house, Kind.Aparment, hall);
            room = new Cell($"Помещение", "Lab 001", lab, Kind.Cell, lab);

            Cell pool = new Cell($"Бассейн", "Door 002", house, Kind.Aparment, hall);
            room = new Cell($"Помещение", "Swimming Pool 001", pool, Kind.Cell, pool);

            Cell teacherroom = new Cell($"Учительская", "Door 002", house, Kind.Aparment, hall);
            room = new Cell($"Помещение", "Teachroom 001", teacherroom, Kind.Cell, teacherroom);

            Cell auditorium = new Cell($"Переговорная", "Door 002", house, Kind.Aparment, hall);
            room = new Cell($"Помещение", "Teachroom 002", auditorium, Kind.Cell, auditorium);

            Cell director = new Cell($"Кабинет директора", "Door 002", house, Kind.Aparment, hall);
            room = new Cell($"Помещение", "Office 002", director, Kind.Cell, director);

            return house;
        }
        private static Cell Add_HousingN1(Cell owner, params Cell[] nearByExternal)
        {
            Cell house = new Cell("Дом N1", "Municipal Building 001", owner, Kind.House, nearByExternal);
            Cell entrance = new Cell($"Подьезд", "Hallway 002", house, Kind.Cell, house);
            Cell janitor = AddJanitorApart(house, "Door 003", "JanitorRoom 001", entrance);
            Cell hall = new Cell($"Общий коридор", "Hallway 001", house, Kind.Cell, entrance);
            Cell ap1 = AddApartNumber(house, "1", "Door 002", "Student Room 001", "Kitchen 001", "Bathroom 001", hall);
            Cell ap2 = AddApartNumber(house, "2", "Door 002", "Student Room 002", "Kitchen 001", "Bathroom 002", hall);
            Cell ap3 = AddApartNumber(house, "3", "Door 002", "Student Room 003", "Kitchen 001", "Bathroom 001", hall);
            Cell ap4 = AddApartNumber(house, "4", "Door 002", "Student Room 004", "Kitchen 001", "Bathroom 002", hall);
            Cell ap5 = AddApartNumber(house, "5", "Door 002", "Student Room 005", "Kitchen 001", "Bathroom 001", hall);
            Cell ap6 = AddApartNumber(house, "6", "Door 002", "Student Room 006", "Kitchen 001", "Bathroom 002", hall);
            Cell ap7 = AddComfortApartNumber(house, "7", "Door 002", "Livingroom 001", "Kitchen 001", "Bathroom 002", "Bedroom 002", hall);
            Cell ap8 = AddComfortApartNumber(house, "8", "Door 002", "Livingroom 002", "Kitchen 001", "Bathroom 001", "Bedroom 002", hall);
            return house;
        }
     

        private static Cell AddApartNumber(Cell owner, string num, string c1,string c2, string c3, string c4, params Cell [] nearByExternal)
        {
            Cell apart = new Cell($"Квартира N{num}", c1, owner, Kind.Aparment, nearByExternal);
            Cell livingroom = new Cell("Гостиная", c2, apart, Kind.Cell, apart);
            Cell kitchen = new Cell("Кухня", c3, apart, Kind.Cell, livingroom);
            Cell bath = new Cell("Ванная", c4, apart, Kind.Cell, livingroom);
            return apart;
        }
        private static Cell AddComfortApartNumber(Cell owner, string num, string c1, string c2, string c3, string c4, string c5, params Cell[] nearByExternal)
        {
            Cell apart = new Cell($"Квартира N{num}", c1, owner, Kind.Aparment, nearByExternal);
            Cell livingroom = new Cell("Гостиная", c2, apart, Kind.Cell, apart);
            Cell bedroom = new Cell("Спальня", c5, apart, Kind.Cell, livingroom);
            Cell kitchen = new Cell("Кухня", c3, apart, Kind.Cell, livingroom);
            Cell bath = new Cell("Ванная", c4, apart, Kind.Cell, livingroom);
            return apart;
        }
        private static Cell AddJanitorApart(Cell owner, string c1, string c2,params Cell[] nearByExternal)
        {
            Cell apart = new Cell($"Квартирка дворника", c1, owner, Kind.Aparment, nearByExternal);
            Cell livingroom = new Cell("Гостиная", c2, apart, Kind.Cell, apart);
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
