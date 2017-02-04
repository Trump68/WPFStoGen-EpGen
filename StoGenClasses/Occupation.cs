using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work;

namespace StoGen.Classes
{
    public class Occupation : IDescptible
    {
        public static string _ATT_ONT = "_ONT"; // name full
        public Occupation(Hum_View owner)
        {
            this.Owner = owner;
        }
        public Hum_View Owner { get; set;}
        public string Name { set; get; }
        public DayTime DayTimeStart { set; get; }
        public DayTime DayTimeEnd { set; get; }
        public WeekDay[] Workdays { set; get; }
        #region IDescriptible
        public string Mark 
        {
            get { return this.Owner.PersName.Mark; }
        }
        public List<string> PropMarks
        {
            get
            {
                return new List<string>() { _ATT_ONT };
            }
        }
        public string GetDescriptionByMark(string propMark)
        {
            if (propMark == _ATT_ONT)
            {
                return this.Name;
            }          
            return string.Empty;
        }        
        #endregion        
    }
    public class OccupationUnimployed : Occupation, IDescptible
    {
        public OccupationUnimployed(Hum_View owner) : base(owner) 
        {
            DayTimeStart = DayTime.None;
            DayTimeEnd = DayTime.None;            
        }
        #region IDescriptible   
        public string GetDescriptionByMark(string propMark)
        {
            if (propMark == _ATT_ONT)
            {
                if (this.Owner.PersName.Gender == PersonGender.Male) return "безработный";
                else return "безработная";
            }
            return string.Empty;
        }
        #endregion
    }
    public class OccupationTeacher : Occupation, IDescptible
    {
        public OccupationTeacher(Hum_View owner)
            : base(owner)
        {
            DayTimeStart = DayTime.Morning;
            DayTimeEnd = DayTime.Day;
            Workdays = new WeekDay[] { WeekDay.d1, WeekDay.d2, WeekDay.d3, WeekDay.d4, WeekDay.d5 };
        }
        #region IDescriptible
        public string GetDescriptionByMark(string propMark)
        {
            if (propMark == _ATT_ONT)
            {
                if (this.Owner.PersName.Gender == PersonGender.Male) return "учитель";
                else return "учительница";
            }
            return string.Empty;
        }
        #endregion
    }
    public class OccupationHousekeeper : Occupation, IDescptible
    {
        public OccupationHousekeeper(Hum_View owner)
            : base(owner)
        {
            DayTimeStart = DayTime.None;
            DayTimeEnd = DayTime.None;
        }
        #region IDescriptible
        public string GetDescriptionByMark(string propMark)
        {
            if (propMark == _ATT_ONT)
            {
                if (this.Owner.PersName.Gender == PersonGender.Male) return "домохозяин";
                else return "домохозяйка";
            }
            return string.Empty;
        }
        #endregion
    }
    public class OccupationStudent : Occupation, IDescptible
    {
        public OccupationStudent(Hum_View owner)
            : base(owner)
        {
            DayTimeStart = DayTime.Morning;
            DayTimeEnd = DayTime.Day;
            Workdays = new WeekDay[] { WeekDay.d1, WeekDay.d2, WeekDay.d3, WeekDay.d4, WeekDay.d5 };
        }
        #region IDescriptible
        public string GetDescriptionByMark(string propMark)
        {
            if (propMark == _ATT_ONT)
            {
                if (this.Owner.PersName.Gender == PersonGender.Male) return "ученик";
                else return "ученица";
            }
            return string.Empty;
        }
        #endregion
    }
    public class OccupationHightStudent : Occupation, IDescptible
    {
        public OccupationHightStudent(Hum_View owner)
            : base(owner)
        {
            DayTimeStart = DayTime.Morning;
            DayTimeEnd = DayTime.Day;
            Workdays = new WeekDay[] { WeekDay.d1, WeekDay.d2, WeekDay.d3, WeekDay.d4, WeekDay.d5 };
        }
        #region IDescriptible
        public string GetDescriptionByMark(string propMark)
        {
            if (propMark == _ATT_ONT)
            {
                if (this.Owner.PersName.Gender == PersonGender.Male) return "студент";
                else return "студентка";
            }
            return string.Empty;
        }
        #endregion
    }
    public class OccupationServant : Occupation, IDescptible
    {
        public OccupationServant(Hum_View owner)
            : base(owner)
        {
            DayTimeStart = DayTime.Morning;
            DayTimeEnd = DayTime.Evening;
            Workdays = new WeekDay[] { WeekDay.d1, WeekDay.d2, WeekDay.d3, WeekDay.d4, WeekDay.d5 };
        }
        #region IDescriptible
        public string GetDescriptionByMark(string propMark)
        {
            if (propMark == _ATT_ONT)
            {
                if (this.Owner.PersName.Gender == PersonGender.Male) return "слуга";
                else return "служанка";
            }
            return string.Empty;
        }
        #endregion
    }
}