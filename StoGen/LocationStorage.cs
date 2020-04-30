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

    public class LocationStorage :BaseGeneratorItem<LocationStorage>
    {
        public static string ImagePath = @"e:\!STOGENDB\READY\BKG\";
        public LocationStorage(string name, string type) : base(name, type) { }
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
            LocationStorage var = new LocationStorage(Sys_Background_White, "system");
            var.Files.Add(new Tuple<string, string, string, string>("system", "$$WHITE$$",null,null));
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
            //дверь
            Add_Door001();

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
            //холл
            Add_SchoolHoll001();
            //подвал
            Add_ApartmentUnderground001();
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
            Add_ForestPark002();
            //муниципальное здание
            Add_MunicipalBuilding001();
            //купальня
            Add_HotSPA001();
            //office
            Add_Office001();
            Add_Office002();
            //улица в пригороде
            Add_StreetPrivateDisctrict001();

            //небеса
            Add_Sky001();

            //романтика
            Add_Romantic001();

            //old paper
            Add_OldPaper001();
        }
        private static void Add_ApartmentUnderground001()
        {
            LocationStorage var = new LocationStorage("Apartment Underground 001", "Apartment Underground");
            var.Files.Add(new Tuple<string, string, string, string>("day,night,evening", $@"{ImagePath}APARTMENT\UNDERGROUND\001\79.jpg", null, null));
            Storage.Add(var);
        }
        private static void Add_SchoolHoll001()
        {
            LocationStorage var = new LocationStorage("School Holl 001", "School Holl");
            var.Files.Add(new Tuple<string, string, string, string>("day,crowded", $@"{ImagePath}SHOOL\HOLL\001\79.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("day,empty", $@"{ImagePath}SHOOL\HOLL\001\79.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}SHOOL\HOLL\001\83.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}SHOOL\HOLL\001\84.jpg", null, null));
            Storage.Add(var);
        }
        private static void Add_StreetPrivateDisctrict001()
        {
            LocationStorage var = new LocationStorage("Street Private Disctrict 001", "Street Private Disctrict");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}STREET\PRIVATE\001\63.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}STREET\PRIVATE\001\65.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}STREET\PRIVATE\001\66.jpg", null, null));
            Storage.Add(var);
        }
        private static void Add_Office001()
        {
            LocationStorage var = new LocationStorage("Office 001", "Office");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}OFFICE\001\60.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}OFFICE\001\61.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}OFFICE\001\62.jpg", null, null));
            Storage.Add(var);
        }
        private static void Add_Office002()
        {
            LocationStorage var = new LocationStorage("Office 001", "Office");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}OFFICE\002\60.jpg", null, null));
            Storage.Add(var);
        }
        private static void Add_HotSPA001()
        {
            LocationStorage var = new LocationStorage("Hot SPA 001", "SPA");
            var.Files.Add(new Tuple<string, string, string, string>("day, clean", $@"{ImagePath}SPA\001\124.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}SPA\001\127.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("evening, clean", $@"{ImagePath}SPA\001\126.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}SPA\001\129.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("night, clean", $@"{ImagePath}SPA\001\125.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}SPA\001\128.jpg", null, null));
            Storage.Add(var);
        }
        private static void Add_Sky001()
        {
            LocationStorage var = new LocationStorage("Sky 001", "Sky");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}SIMPLE\SKY\089.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("explode", $@"{ImagePath}SIMPLE\SKY\090.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}SIMPLE\SKY\091.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}SIMPLE\SKY\092.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("stars", $@"{ImagePath}SIMPLE\SKY\093.jpg", null, null));
            Storage.Add(var);
        }
        private static void Add_Romantic001()
        {
            LocationStorage var = new LocationStorage("Romantic 001", "Romantic");
            var.Files.Add(new Tuple<string, string, string, string>("Pink Striped with Bow", $@"{ImagePath}SIMPLE\ROMANTIC\Pink_Striped_with_Bow.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("Cream Satin with Bow", $@"{ImagePath}SIMPLE\ROMANTIC\Cream_Satin_with_Bow.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("White Satin", $@"{ImagePath}SIMPLE\ROMANTIC\White_Satin.jpg", null, null));

            Storage.Add(var);
        }
        private static void Add_OldPaper001()
        {
            LocationStorage var = new LocationStorage("Old Paper 001", "Old Paper");
            var.Files.Add(new Tuple<string, string, string, string>("Old Paper 1", $@"{ImagePath}SIMPLE\OLD\001.jpg", null, null));
            Storage.Add(var);
        }
        private static void Add_Bedroom001()
        {
            LocationStorage var = new LocationStorage("Bedroom 001", "Bedroom");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}APARTMENT\BEDROOM\001\102.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}APARTMENT\BEDROOM\001\104.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}APARTMENT\BEDROOM\001\105.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_Hallway001()
        {
            LocationStorage var = new LocationStorage("Hallway 001", "Hallway");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}APARTMENT\HALLWAY\001\132.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}APARTMENT\HALLWAY\001\133.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}APARTMENT\EVENING\001\134.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_MunicipalBuilding001()
        {
            LocationStorage var = new LocationStorage("Municipal Building 001", "Municipal Building");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}MUNICIPAL\BUILDING\001\057.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}MUNICIPAL\BUILDING\001\058.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}MUNICIPAL\BUILDING\001\059.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_BuildingSchool001()
        {
            LocationStorage var = new LocationStorage("Building School 001", "Building School");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}SCHOOL\BUILDING\001\043.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}SCHOOL\BUILDING\001\045.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_ForestPark001()
        {
            LocationStorage var = new LocationStorage("Forest Park 001", "Forest Park");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}STREET\PARK\001\076.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night,smoke", $@"{ImagePath}STREET\PARK\001\075.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}STREET\PARK\001\078.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_ForestPark002()
        {
            LocationStorage var = new LocationStorage("Forest Park 002", "Forest Park");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}STREET\PARK\002\068.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}STREET\PARK\002\069.jpg", null, null));
            Storage.Add(var);
        }
        private static void Add_SquarePark001()
        {
            LocationStorage var = new LocationStorage("Square Park 001", "Square Park");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}STREET\SQUAREPARK\001\025.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_StudentRoom001()
        {
            LocationStorage var = new LocationStorage("Student Room 001", "Student Room");
            var.Files.Add(new Tuple<string, string, string, string>("day",              $@"{ImagePath}APARTMENT\ROOM\001\001.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening",          $@"{ImagePath}APARTMENT\ROOM\001\003.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night",            $@"{ImagePath}APARTMENT\ROOM\001\002.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_StudentRoom002()
        {
            LocationStorage var = new LocationStorage("Student Room 002", "Student Room");
            var.Files.Add(new Tuple<string, string, string, string>("day",              $@"{ImagePath}APARTMENT\ROOM\002\001.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening",          $@"{ImagePath}APARTMENT\ROOM\002\002.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_StudentRoom003()
        {
            LocationStorage var = new LocationStorage("Student Room 003", "Student Room");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}APARTMENT\ROOM\003\135.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}APARTMENT\ROOM\003\137.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}APARTMENT\ROOM\003\138.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_StudentRoom004()
        {
            LocationStorage var = new LocationStorage("Student Room 004", "Student Room");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}APARTMENT\ROOM\004\121.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}APARTMENT\ROOM\004\122.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}APARTMENT\ROOM\004\123.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_FemaleRoom005()
        {
            LocationStorage var = new LocationStorage("Female Room 005", "Female Room");
            var.Files.Add(new Tuple<string, string, string, string>("day,female", $@"{ImagePath}APARTMENT\ROOM\005\096.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night,female", $@"{ImagePath}APARTMENT\ROOM\005\097.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening,female", $@"{ImagePath}APARTMENT\ROOM\005\098.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening,female", $@"{ImagePath}APARTMENT\ROOM\005\094.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening,female,watching tv", $@"{ImagePath}APARTMENT\ROOM\005\095.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_StudentRoom006()
        {
            LocationStorage var = new LocationStorage("Student Room 006", "Student Room");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}APARTMENT\ROOM\006\111.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}APARTMENT\ROOM\006\113.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}APARTMENT\ROOM\006\114.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_Lab001()
        {
            LocationStorage var = new LocationStorage("Lab 001", "Lab");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}SCHOOL\LAB\001\054.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}SCHOOL\LAB\001\055.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}SCHOOL\LAB\001\056.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_Classroom001()
        {
            LocationStorage var = new LocationStorage("Classroom 001", "Classroom");
            var.Files.Add(new Tuple<string, string, string, string>("day",              $@"{ImagePath}SCHOOL\CLASSROOM\001\001.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_Classroom002()
        {
            LocationStorage var = new LocationStorage("Classroom 002", "Classroom");
            var.Files.Add(new Tuple<string, string, string, string>("day,crowd", $@"{ImagePath}SCHOOL\CLASSROOM\002\049.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("day,crowd,lession", $@"{ImagePath}SCHOOL\CLASSROOM\002\050.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}SCHOOL\CLASSROOM\002\051.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_Teacheroom001()
        {
            LocationStorage var = new LocationStorage("Teachroom 001", "Teachroom");
            var.Files.Add(new Tuple<string, string, string, string>("day,evening", $@"{ImagePath}SCHOOL\TEACHEROOM\001\006.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_Teacheroom002()
        {
            LocationStorage var = new LocationStorage("Teachroom 002", "Teachroom");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}SCHOOL\TEACHEROOM\002\046.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}SCHOOL\TEACHEROOM\002\048.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_Warehouse001()
        {
            LocationStorage var = new LocationStorage("Warehouse Hagnar 001", "Warehouse Hagnar");
            var.Files.Add(new Tuple<string, string, string, string>("night",            $@"{ImagePath}WAREHOUSE\HANGAR\001\004.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("day,evening",      $@"{ImagePath}WAREHOUSE\HANGAR\001\005.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_StreetShopping001()
        {
            LocationStorage var = new LocationStorage("Street Shopping 001", "Street Shopping");
            var.Files.Add(new Tuple<string, string, string, string>("day,crowd",              $@"{ImagePath}STREET\SHOPPING\001\007.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("day",              $@"{ImagePath}STREET\SHOPPING\001\008.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night",            $@"{ImagePath}STREET\SHOPPING\001\009.jpg",null,null));
            Storage.Add(var);
        }

        private static void Add_StreetShopping002()
        {
            LocationStorage var = new LocationStorage("Street Shopping 002", "Street Shopping");
            var.Files.Add(new Tuple<string, string, string, string>("day,crowd", $@"{ImagePath}STREET\SHOPPING\002\010.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}STREET\SHOPPING\002\012.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_StreetShopping003()
        {
            LocationStorage var = new LocationStorage("Street Shopping 003", "Street Shopping");
            var.Files.Add(new Tuple<string, string, string, string>("day,crowd", $@"{ImagePath}STREET\SHOPPING\003\014.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}STREET\SHOPPING\003\015.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_StreetRailwayStation001()
        {
            LocationStorage var = new LocationStorage("Street Railway Station 003", "Railway Station");
            var.Files.Add(new Tuple<string, string, string, string>("day,crowd", $@"{ImagePath}STREET\RAILWAY\001\016.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}STREET\RAILWAY\001\018.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening,crowd", $@"{ImagePath}STREET\RAILWAY\001\017.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}STREET\RAILWAY\001\019.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_StreetCity001()
        {
            LocationStorage var = new LocationStorage("Street City 001", "Street City");
            var.Files.Add(new Tuple<string, string, string, string>("day,crowd", $@"{ImagePath}STREET\CITY\001\020.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}STREET\CITY\001\022.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}STREET\CITY\001\024.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_SwimmingPool001()
        {
            LocationStorage var = new LocationStorage("Swimming Pool 001", "Swimming Pool");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}SCHOOL\SWIMMING\001\026.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}SCHOOL\SWIMMING\001\041.jpg",null,null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}SCHOOL\SWIMMING\001\029.jpg",null,null));
            Storage.Add(var);
        }
        private static void Add_Door001()
        {
            LocationStorage var = new LocationStorage("Door 001", "Door");
            var.Files.Add(new Tuple<string, string, string, string>("day", $@"{ImagePath}APARTMENT\DOOR\001\509.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("night", $@"{ImagePath}APARTMENT\DOOR\001\512.jpg", null, null));
            var.Files.Add(new Tuple<string, string, string, string>("evening", $@"{ImagePath}APARTMENT\DOOR\001\511.jpg", null, null));
            Storage.Add(var);
        }
    }
}
