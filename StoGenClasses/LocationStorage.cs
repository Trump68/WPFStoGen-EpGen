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
            var.Files.Add(new ItemData("system", "$$WHITE$$",null,null, var.Name));
            //комната в общаге/кондоминиуме
            Add_StudentRoom001("Student Room 001", "Student Room");
            Add_StudentRoom002("Student Room 002", "Student Room");
            Add_StudentRoom003("Student Room 003", "Student Room");
            Add_StudentRoom004("Student Room 004", "Student Room");
            Add_StudentFemaleRoom005("Student Room 005", "Student Room");
            Add_StudentRoom006("Student Room 006", "Student Room");
            //Коридор общий
            Add_Hallway001("Hallway 001", "Hallway");
            //вход в подьезд
            Add_Hallway002("Hallway 002", "Hallway");
            //спальня
            Add_Bedroom001("Bedroom 001", "Bedroom");
            Add_Bedroom002("Bedroom 002", "Bedroom");
            //дверь
            Add_DoorBathroom001();
            Add_Door002("Door 002","Door");
            Add_Door003("Door 003", "Door");
            //ванная
            Add_Bathroom001("Bathroom 001", "Bathroom", $@"{ImagePath}APARTMENT\BATHROOM\001\372.jpg");
            Add_Bathroom001("Bathroom 002", "Bathroom", $@"{ImagePath}APARTMENT\BATHROOM\002\001.jpg");
            //кухня
            Add_Kitchen001("Kitchen 001", "Kitchen");
            //гостиная
            Add_Livingroom001("Livingroom 001", "Livingroom");
            Add_Livingroom002("Livingroom 002", "Livingroom");
            Add_Livingroom003("Livingroom 003", "Livingroom");
            //квартирка дворника
            Add_PoorePeopleRoom001("JanitorRoom 001", "Janitor Room");

            //класс
            Add_Classroom001("Classroom 001", "Classroom");
            Add_Classroom002("Classroom 002", "Classroom");
            //учительская 
            Add_Teacheroom001("Teachroom 001", "Teachroom");
            Add_Teacheroom002("Teachroom 002", "Teachroom");
            //лаба 
            Add_Lab001("Lab 001", "Lab");
            //бассейн
            Add_SwimmingPool001("Swimming Pool 001", "Swimming Pool");
            //здание школы
            Add_BuildingSchool001();
            //холл
            Add_SchoolHoll001("School Holl 001", "School Holl");
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
            Add_MunicipalBuilding001("Municipal Building 001", "Municipal Building");
            Add_MunicipalBuilding002("Municipal Building 002", "Municipal Building");
            //купальня
            Add_HotSPA001();
            //office
            Add_Office001("Office 001", "Office");
            Add_Office002("Office 002", "Office");
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
            var.Files.Add(new ItemData("day,night,evening", $@"{ImagePath}APARTMENT\UNDERGROUND\001\072.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_SchoolHoll001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day,crowded", $@"{ImagePath}SCHOOL\HOLL\001\079.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("day,empty", $@"{ImagePath}SCHOOL\HOLL\001\079.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}SCHOOL\HOLL\001\083.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}SCHOOL\HOLL\001\084.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StreetPrivateDisctrict001()
        {
            LocationStorage var = new LocationStorage("Street Private Disctrict 001", "Street Private Disctrict");
            var.Files.Add(new ItemData("day", $@"{ImagePath}STREET\PRIVATE\001\63.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}STREET\PRIVATE\001\65.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}STREET\PRIVATE\001\66.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Office001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}OFFICE\001\060.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}OFFICE\001\061.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}OFFICE\001\062.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Office002(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}OFFICE\002\073.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_HotSPA001()
        {
            LocationStorage var = new LocationStorage("Hot SPA 001", "SPA");
            var.Files.Add(new ItemData("day, clean", $@"{ImagePath}SPA\001\124.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("day", $@"{ImagePath}SPA\001\127.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("evening, clean", $@"{ImagePath}SPA\001\126.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}SPA\001\129.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night, clean", $@"{ImagePath}SPA\001\125.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}SPA\001\128.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Sky001()
        {
            LocationStorage var = new LocationStorage("Sky 001", "Sky");
            var.Files.Add(new ItemData("day", $@"{ImagePath}SIMPLE\SKY\089.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("explode", $@"{ImagePath}SIMPLE\SKY\090.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}SIMPLE\SKY\091.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("day", $@"{ImagePath}SIMPLE\SKY\092.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("stars", $@"{ImagePath}SIMPLE\SKY\093.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Romantic001()
        {
            LocationStorage var = new LocationStorage("Romantic 001", "Romantic");
            var.Files.Add(new ItemData("Pink Striped with Bow", $@"{ImagePath}SIMPLE\ROMANTIC\Pink_Striped_with_Bow.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("Cream Satin with Bow", $@"{ImagePath}SIMPLE\ROMANTIC\Cream_Satin_with_Bow.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("White Satin", $@"{ImagePath}SIMPLE\ROMANTIC\White_Satin.jpg", null, null, var.Name));

            Storage.Add(var);
        }
        private static void Add_OldPaper001()
        {
            LocationStorage var = new LocationStorage("Old Paper 001", "Old Paper");
            var.Files.Add(new ItemData("Old Paper 1", $@"{ImagePath}SIMPLE\OLD\001.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Bedroom001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}APARTMENT\BEDROOM\001\102.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}APARTMENT\BEDROOM\001\104.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}APARTMENT\BEDROOM\001\105.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Bedroom002(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day,night,evening", $@"{ImagePath}APARTMENT\BEDROOM\002\001.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Hallway001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);//("Hallway 001", "Hallway");
            var.Files.Add(new ItemData("day", $@"{ImagePath}APARTMENT\HALLWAY\001\132.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}APARTMENT\HALLWAY\001\133.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}APARTMENT\EVENING\001\134.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Hallway002(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day,night,evening", $@"{ImagePath}APARTMENT\HALLWAY\002\001.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_MunicipalBuilding001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}MUNICIPAL\BUILDING\001\057.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}MUNICIPAL\BUILDING\001\058.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}MUNICIPAL\BUILDING\001\059.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_MunicipalBuilding002(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}MUNICIPAL\BUILDING\002\001.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}MUNICIPAL\BUILDING\002\002.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}MUNICIPAL\BUILDING\002\003.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_BuildingSchool001()
        {
            LocationStorage var = new LocationStorage("Building School 001", "Building School");
            var.Files.Add(new ItemData("day", $@"{ImagePath}SCHOOL\BUILDING\001\043.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}SCHOOL\BUILDING\001\045.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_ForestPark001()
        {
            LocationStorage var = new LocationStorage("Forest Park 001", "Forest Park");
            var.Files.Add(new ItemData("day", $@"{ImagePath}STREET\PARK\001\076.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night,smoke", $@"{ImagePath}STREET\PARK\001\075.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}STREET\PARK\001\078.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_ForestPark002()
        {
            LocationStorage var = new LocationStorage("Forest Park 002", "Forest Park");
            var.Files.Add(new ItemData("day", $@"{ImagePath}STREET\PARK\002\068.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}STREET\PARK\002\069.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_SquarePark001()
        {
            LocationStorage var = new LocationStorage("Square Park 001", "Square Park");
            var.Files.Add(new ItemData("day", $@"{ImagePath}STREET\SQUAREPARK\001\025.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StudentRoom001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day",              $@"{ImagePath}APARTMENT\ROOM\001\001.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening",          $@"{ImagePath}APARTMENT\ROOM\001\003.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night",            $@"{ImagePath}APARTMENT\ROOM\001\002.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StudentRoom002(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day",              $@"{ImagePath}APARTMENT\ROOM\002\001.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening,night",    $@"{ImagePath}APARTMENT\ROOM\002\002.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StudentRoom003(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}APARTMENT\ROOM\003\135.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}APARTMENT\ROOM\003\137.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}APARTMENT\ROOM\003\138.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StudentRoom004(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}APARTMENT\ROOM\004\121.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}APARTMENT\ROOM\004\122.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}APARTMENT\ROOM\004\123.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StudentFemaleRoom005(string name, string type)
        {
            LocationStorage var = new LocationStorage(name,  type);
            var.Files.Add(new ItemData("day,female", $@"{ImagePath}APARTMENT\ROOM\005\096.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night,female", $@"{ImagePath}APARTMENT\ROOM\005\097.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening,female", $@"{ImagePath}APARTMENT\ROOM\005\098.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening,female", $@"{ImagePath}APARTMENT\ROOM\005\094.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening,female,watching tv", $@"{ImagePath}APARTMENT\ROOM\005\095.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StudentRoom006(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}APARTMENT\ROOM\006\111.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}APARTMENT\ROOM\006\113.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}APARTMENT\ROOM\006\114.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_PoorePeopleRoom001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day,clean", $@"{ImagePath}APARTMENT\ROOM\007\004.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("day,dirty", $@"{ImagePath}APARTMENT\ROOM\007\001.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("evening,dirty", $@"{ImagePath}APARTMENT\ROOM\007\002.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night,dirty", $@"{ImagePath}APARTMENT\ROOM\007\003.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night,clean,empty", $@"{ImagePath}APARTMENT\ROOM\007\005.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Lab001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}SCHOOL\LAB\001\054.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}SCHOOL\LAB\001\055.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}SCHOOL\LAB\001\056.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Classroom001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day",              $@"{ImagePath}SCHOOL\CLASSROOM\001\001.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Classroom002(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day,crowd", $@"{ImagePath}SCHOOL\CLASSROOM\002\049.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("day,crowd,lession", $@"{ImagePath}SCHOOL\CLASSROOM\002\050.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("day", $@"{ImagePath}SCHOOL\CLASSROOM\002\051.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Teacheroom001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day,evening", $@"{ImagePath}SCHOOL\TEACHEROOM\001\006.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Teacheroom002(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}SCHOOL\TEACHEROOM\002\046.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}SCHOOL\TEACHEROOM\002\048.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Warehouse001()
        {
            LocationStorage var = new LocationStorage("Warehouse Hagnar 001", "Warehouse Hagnar");
            var.Files.Add(new ItemData("night",            $@"{ImagePath}WAREHOUSE\HANGAR\001\004.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("day,evening",      $@"{ImagePath}WAREHOUSE\HANGAR\001\005.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StreetShopping001()
        {
            LocationStorage var = new LocationStorage("Street Shopping 001", "Street Shopping");
            var.Files.Add(new ItemData("day,crowd",              $@"{ImagePath}STREET\SHOPPING\001\007.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("day",              $@"{ImagePath}STREET\SHOPPING\001\008.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night",            $@"{ImagePath}STREET\SHOPPING\001\009.jpg",null,null, var.Name));
            Storage.Add(var);
        }

        private static void Add_StreetShopping002()
        {
            LocationStorage var = new LocationStorage("Street Shopping 002", "Street Shopping");
            var.Files.Add(new ItemData("day,crowd", $@"{ImagePath}STREET\SHOPPING\002\010.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("day", $@"{ImagePath}STREET\SHOPPING\002\012.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StreetShopping003()
        {
            LocationStorage var = new LocationStorage("Street Shopping 003", "Street Shopping");
            var.Files.Add(new ItemData("day,crowd", $@"{ImagePath}STREET\SHOPPING\003\014.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("day", $@"{ImagePath}STREET\SHOPPING\003\015.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StreetRailwayStation001()
        {
            LocationStorage var = new LocationStorage("Street Railway Station 003", "Railway Station");
            var.Files.Add(new ItemData("day,crowd", $@"{ImagePath}STREET\RAILWAY\001\016.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("day", $@"{ImagePath}STREET\RAILWAY\001\018.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening,crowd", $@"{ImagePath}STREET\RAILWAY\001\017.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}STREET\RAILWAY\001\019.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_StreetCity001()
        {
            LocationStorage var = new LocationStorage("Street City 001", "Street City");
            var.Files.Add(new ItemData("day,crowd", $@"{ImagePath}STREET\CITY\001\020.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("day", $@"{ImagePath}STREET\CITY\001\022.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}STREET\CITY\001\024.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_SwimmingPool001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}SCHOOL\SWIMMING\001\026.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}SCHOOL\SWIMMING\001\041.jpg",null,null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}SCHOOL\SWIMMING\001\029.jpg",null,null, var.Name));
            Storage.Add(var);
        }
        private static void Add_DoorBathroom001()
        {
            LocationStorage var = new LocationStorage("Door 001", "Door");
            var.Files.Add(new ItemData("day", $@"{ImagePath}APARTMENT\DOOR\001\509.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}APARTMENT\DOOR\001\512.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}APARTMENT\DOOR\001\511.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Door002(string name, string type)
        {
            LocationStorage var = new LocationStorage(name,  type);
            var.Files.Add(new ItemData("day,night,evening", $@"{ImagePath}APARTMENT\DOOR\002\001.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Door003(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day,night,evening,closed", $@"{ImagePath}APARTMENT\DOOR\003\001.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("day,night,evening,opened", $@"{ImagePath}APARTMENT\DOOR\003\002.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Bathroom001(string name, string type, string file)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day,night,evening", file, null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Kitchen001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}APARTMENT\KITCHEN\001\001.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night,evening", $@"{ImagePath}APARTMENT\KITCHEN\001\002.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Livingroom001(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}APARTMENT\LIVINGROOM\001\001.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}APARTMENT\LIVINGROOM\001\002.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}APARTMENT\LIVINGROOM\001\003.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Livingroom002(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}APARTMENT\LIVINGROOM\002\001.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("evening", $@"{ImagePath}APARTMENT\LIVINGROOM\002\003.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night", $@"{ImagePath}APARTMENT\LIVINGROOM\002\002.jpg", null, null, var.Name));
            Storage.Add(var);
        }
        private static void Add_Livingroom003(string name, string type)
        {
            LocationStorage var = new LocationStorage(name, type);
            var.Files.Add(new ItemData("day", $@"{ImagePath}APARTMENT\LIVINGROOM\003\001.jpg", null, null, var.Name));
            var.Files.Add(new ItemData("night,evening", $@"{ImagePath}APARTMENT\LIVINGROOM\003\002.jpg", null, null, var.Name));
            Storage.Add(var);
        }
    }
}
