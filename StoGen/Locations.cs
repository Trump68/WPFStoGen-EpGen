using Newtonsoft.Json;
using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator
{

    public class Location :BaseGeneratorItem<Location>
    {
        public static string ImagePath = @"e:\!STOGENDB\READY\BKG\";
        public Location(string name, string type) : base(name, type) { }
        protected override Info_Scene ToSceneInfo(string spec, string queue, string group)
        {
            Info_Scene result = base.ToSceneInfo(spec, queue, group);
            result.Kind = 9;
            return result;
        }
        // static
        public static string Sys_Background_White = "Sys_White_Background";
        public static void InitDefaultLocations()
        {
            Storage.Clear();
            Location var = new Location(Sys_Background_White, "system");
            var.Files.Add(new Tuple<string, string>("system", "$$WHITE$$"));
            //комната в общаге/кондоминиуме
            Add_StudentRoom001();
            Add_StudentRoom002();
            Add_StudentRoom003();
            Add_StudentRoom004();
            Add_FemaleRoom005();
            Add_StudentRoom006();
            //Коридор в общаге-гостинице
            Add_Hallway001();
            //спальня
            Add_Bedroom001();

            //класс
            Add_Classroom001();
            Add_Classroom002();
            //учительская 
            Add_Teacheroom001();
            Add_Teacheroom002();
            //лаба 
            Add_Lab001();
            //бассейн
            Add_SwimmingPool001();
            //здание школы
            Add_BuildingSchool001();


            //склад
            Add_Warehouse001();

            Add_StreetShopping001();
            Add_StreetShopping002();
            Add_StreetShopping003();

            Add_StreetRailwayStation001();

            Add_StreetCity001();
            //сквер
            Add_SquarePark001();
            //парк
            Add_ForestPark001();
            //муниципальное здание
            Add_MunicipalBuilding001();

        }
        private static void Add_Bedroom001()
        {
            Location var = new Location("Bedroom 001", "Bedroom");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}APARTMENT\BEDROOM\001\102.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}APARTMENT\BEDROOM\001\104.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}APARTMENT\BEDROOM\001\105.jpg"));
            Storage.Add(var);
        }
        private static void Add_Hallway001()
        {
            Location var = new Location("Hallway 001", "Hallway");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}APPARTMENT\HALLWAY\001\132.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}APPARTMENT\HALLWAY\001\133.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}APPARTMENT\EVENING\001\134.jpg"));
            Storage.Add(var);
        }
        private static void Add_MunicipalBuilding001()
        {
            Location var = new Location("Municipal Building 001", "Municipal Building");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}MUNICIPAL\BUILDING\001\057.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}MUNICIPAL\BUILDING\001\058.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}MUNICIPAL\BUILDING\001\059.jpg"));
            Storage.Add(var);
        }
        private static void Add_BuildingSchool001()
        {
            Location var = new Location("Building School 001", "Building School");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}SCHOOL\BUILDING\001\043.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}SCHOOL\BUILDING\001\045.jpg"));
            Storage.Add(var);
        }
        private static void Add_ForestPark001()
        {
            Location var = new Location("Forest Park 001", "Forest Park");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}STREET\PARK\001\076.jpg"));
            var.Files.Add(new Tuple<string, string>("night,smoke", $@"{ImagePath}STREET\PARK\001\075.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}STREET\PARK\001\078.jpg"));
            Storage.Add(var);
        }
        private static void Add_SquarePark001()
        {
            Location var = new Location("Square Park 001", "Square Park");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}STREET\SQUAREPARK\001\025.jpg"));
            Storage.Add(var);
        }
        private static void Add_StudentRoom001()
        {
            Location var = new Location("Student Room 001", "Student Room");
            var.Files.Add(new Tuple<string, string>("day",              $@"{ImagePath}APARTMENT\ROOM\001\001.jpg"));
            var.Files.Add(new Tuple<string, string>("evening",          $@"{ImagePath}APARTMENT\ROOM\001\003.jpg"));
            var.Files.Add(new Tuple<string, string>("night",            $@"{ImagePath}APARTMENT\ROOM\001\002.jpg"));
            Storage.Add(var);
        }
        private static void Add_StudentRoom002()
        {
            Location var = new Location("Student Room 002", "Student Room");
            var.Files.Add(new Tuple<string, string>("day",              $@"{ImagePath}APARTMENT\ROOM\002\001.jpg"));
            var.Files.Add(new Tuple<string, string>("evening",          $@"{ImagePath}APARTMENT\ROOM\002\002.jpg"));
            Storage.Add(var);
        }
        private static void Add_StudentRoom003()
        {
            Location var = new Location("Student Room 003", "Student Room");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}APARTMENT\ROOM\003\135.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}APARTMENT\ROOM\003\137.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}APARTMENT\ROOM\003\138.jpg"));
            Storage.Add(var);
        }
        private static void Add_StudentRoom004()
        {
            Location var = new Location("Student Room 004", "Student Room");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}APARTMENT\ROOM\004\121.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}APARTMENT\ROOM\004\122.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}APARTMENT\ROOM\004\123.jpg"));
            Storage.Add(var);
        }
        private static void Add_FemaleRoom005()
        {
            Location var = new Location("Female Room 005", "Female Room");
            var.Files.Add(new Tuple<string, string>("day,female", $@"{ImagePath}APARTMENT\ROOM\005\096.jpg"));
            var.Files.Add(new Tuple<string, string>("night,female", $@"{ImagePath}APARTMENT\ROOM\005\097.jpg"));
            var.Files.Add(new Tuple<string, string>("evening,female", $@"{ImagePath}APARTMENT\ROOM\005\098.jpg"));
            var.Files.Add(new Tuple<string, string>("evening,female", $@"{ImagePath}APARTMENT\ROOM\005\094.jpg"));
            var.Files.Add(new Tuple<string, string>("evening,female,watching tv", $@"{ImagePath}APARTMENT\ROOM\005\095.jpg"));
            Storage.Add(var);
        }
        private static void Add_StudentRoom006()
        {
            Location var = new Location("Student Room 006", "Student Room");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}APARTMENT\ROOM\006\111.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}APARTMENT\ROOM\006\113.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}APARTMENT\ROOM\006\114.jpg"));
            Storage.Add(var);
        }
        private static void Add_Lab001()
        {
            Location var = new Location("Lab 001", "Lab");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}SCHOOL\LAB\001\054.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}SCHOOL\LAB\001\055.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}SCHOOL\LAB\001\056.jpg"));
            Storage.Add(var);
        }
        private static void Add_Classroom001()
        {
            Location var = new Location("Classroom 001", "Classroom");
            var.Files.Add(new Tuple<string, string>("day",              $@"{ImagePath}SCHOOL\CLASSROOM\001\001.jpg"));
            Storage.Add(var);
        }
        private static void Add_Classroom002()
        {
            Location var = new Location("Classroom 002", "Classroom");
            var.Files.Add(new Tuple<string, string>("day,crowd", $@"{ImagePath}SCHOOL\CLASSROOM\002\049.jpg"));
            var.Files.Add(new Tuple<string, string>("day,crowd,lession", $@"{ImagePath}SCHOOL\CLASSROOM\002\050.jpg"));
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}SCHOOL\CLASSROOM\002\051.jpg"));
            Storage.Add(var);
        }
        private static void Add_Teacheroom001()
        {
            Location var = new Location("Teachroom 001", "Teachroom");
            var.Files.Add(new Tuple<string, string>("day,evening", $@"{ImagePath}SCHOOL\TEACHEROOM\001\006.jpg"));
            Storage.Add(var);
        }
        private static void Add_Teacheroom002()
        {
            Location var = new Location("Teachroom 002", "Teachroom");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}SCHOOL\TEACHEROOM\002\046.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}SCHOOL\TEACHEROOM\002\048.jpg"));
            Storage.Add(var);
        }
        private static void Add_Warehouse001()
        {
            Location var = new Location("Warehouse Hagnar 001", "Warehouse Hagnar");
            var.Files.Add(new Tuple<string, string>("night",            $@"{ImagePath}WAREHOUSE\HANGAR\001\004.jpg"));
            var.Files.Add(new Tuple<string, string>("day,evening",      $@"{ImagePath}WAREHOUSE\HANGAR\001\005.jpg"));
            Storage.Add(var);
        }
        private static void Add_StreetShopping001()
        {
            Location var = new Location("Street Shopping 001", "Street Shopping");
            var.Files.Add(new Tuple<string, string>("day,crowd",              $@"{ImagePath}STREET\SHOPPING\001\007.jpg"));
            var.Files.Add(new Tuple<string, string>("day",              $@"{ImagePath}STREET\SHOPPING\001\008.jpg"));
            var.Files.Add(new Tuple<string, string>("night",            $@"{ImagePath}STREET\SHOPPING\001\009.jpg"));
            Storage.Add(var);
        }

        private static void Add_StreetShopping002()
        {
            Location var = new Location("Street Shopping 002", "Street Shopping");
            var.Files.Add(new Tuple<string, string>("day,crowd", $@"{ImagePath}STREET\SHOPPING\002\010.jpg"));
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}STREET\SHOPPING\002\012.jpg"));
            Storage.Add(var);
        }
        private static void Add_StreetShopping003()
        {
            Location var = new Location("Street Shopping 003", "Street Shopping");
            var.Files.Add(new Tuple<string, string>("day,crowd", $@"{ImagePath}STREET\SHOPPING\003\014.jpg"));
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}STREET\SHOPPING\003\015.jpg"));
            Storage.Add(var);
        }
        private static void Add_StreetRailwayStation001()
        {
            Location var = new Location("Street Railway Station 003", "Railway Station");
            var.Files.Add(new Tuple<string, string>("day,crowd", $@"{ImagePath}STREET\RAILWAY\001\016.jpg"));
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}STREET\RAILWAY\001\018.jpg"));
            var.Files.Add(new Tuple<string, string>("evening,crowd", $@"{ImagePath}STREET\RAILWAY\001\017.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}STREET\RAILWAY\001\019.jpg"));
            Storage.Add(var);
        }
        private static void Add_StreetCity001()
        {
            Location var = new Location("Street City 001", "Street City");
            var.Files.Add(new Tuple<string, string>("day,crowd", $@"{ImagePath}STREET\CITY\001\020.jpg"));
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}STREET\CITY\001\022.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}STREET\CITY\001\024.jpg"));
            Storage.Add(var);
        }
        private static void Add_SwimmingPool001()
        {
            Location var = new Location("Swimming Pool 001", "Swimming Pool");
            var.Files.Add(new Tuple<string, string>("day", $@"{ImagePath}SCHOOL\SWIMMING\001\026.jpg"));
            var.Files.Add(new Tuple<string, string>("night", $@"{ImagePath}SCHOOL\SWIMMING\001\041.jpg"));
            var.Files.Add(new Tuple<string, string>("evening", $@"{ImagePath}SCHOOL\SWIMMING\001\029.jpg"));
            Storage.Add(var);
        }
    }
}
