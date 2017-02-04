using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{
    public enum RoleRelationEnum : int
    {
        Актер = 0,
        АктерПодходит = 1,
        ГолосПодходит = 2
    }
    public enum CountryEnum : int
    {
        Unknown = 0,
        USA = 1,
        Germany = 2,
        France = 3,
        Italy = 4,
        Spain = 5,
        Hungary = 6,
        Russia = 7,
        Japan = 8,
        Denmark = 9
    }
    public enum GenreTypeEnum : int
    {
        Unknown = 0,
        Mainstream = 1,
        Erotic = 2,
        Porno = 3
    }
    public enum GenreEnum : int
    {
        Unknown = 0,
        Drama = 1,
        Comedy = 2,
        Horror = 3,
        Thriller = 4,
        Gonzo = 5,
        Show = 6,
        Loops = 7,
        Compilation = 8,
        SoundSet = 9
    }
    public enum ProductionTypeEnum : int
    {
        Unknown = 0,
        Movie = 1,
        Serial = 2,
        InternetSite = 3
    }
    public enum GenderEnum : int
    {
        Female = 0,
        Male = 1,
        Futa =2
    }
    public enum RaceEnum : int
    {
        Unknown = 0,
        Euro = 1,
        Negro = 2,
        Asian = 3,
        Latino = 4
    }
    public enum FaceTypeEnum : int
    {
        Unknown = 0,
        СмазливаяПростушка = 1, //деревенская простушка
        ХитраяКрыска = 2 //деревенская простушка
    }
    public enum BodyTypeEnum : int
    {
        Unknown = 0,
        ПухленькаяРоденовская = 1, //пухленькая, в теле, Роденовская
        МаленькаяХудышка = 2 //небольшая, миниатюрная, с грудью
    }

    public enum ActivityTypeEnum : int
    {
        Unknown = 0,
        MainstreamActor = 1,
        EroticActor = 2,
        PornoActor = 3,
        Model = 4
    }

    #region Внешность

    public enum BodyHeightEnum : int
    {
        Неизвестно = 0,
        Миниатюрная = 1,
        СреднегоРоста = 2,
        Высокая = 3
    }
    public enum BodyShouldersEnum : int
    {
        Неизвестно = 0,
        Узкие = 1,
        Средние = 2,
        Широкие = 3
    }
    public enum BodyBreastEnum : int
    {
        Неизвестно = 0,
        Маленькие = 1,
        Средние = 2,
        Крупные = 3,
        Большие = 4
    }
    public enum BodyWaistEnum : int //Талия
    {
        Неизвестно = 0,
        Невыраженная = 1,
        Выраженная = 2
    }
    public enum BodyHipsEnum : int //Талия
    {
        Неизвестно = 0,
        Узкие = 1,
        Средние = 2,
        Широкие = 3
    }

    #endregion
}
