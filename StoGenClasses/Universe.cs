
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace StoGen.Classes
{
    public enum TimeOfDay
    {
        morning,
        day,
        evening,
        night
    }
    public static class Universe
    {    
        public static Random Rnd = new Random();
        public static List<string> LoadFileToStringList(string filename)
        {
            List<string> StartData = new List<string>();
            if (!File.Exists(filename))
            {
                MessageBox.Show("Cant find " + filename);
                return null;
            }

            //using (StreamReader sr = new StreamReader(filename,Encoding.GetEncoding(1251)))
            using (StreamReader sr = new StreamReader(filename, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    StartData.Add(line.TrimStart());
                }
                sr.Close();
                if (StartData.Count == 0) MessageBox.Show("Empty " + filename);
            }
            return StartData;
        }
        public static DayTime CurrentDayTime { set; get; }
        public static WeekDay CurrentWeekDay { set; get; }
        public static void Alarm(string mess)
        {
            XtraMessageBox.Show(mess, "Alarm!", System.Windows.Forms.MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        public static string GetFullPath(string fn, string defaultpath)
        {
            if (Path.IsPathRooted(fn)) return fn;
            return Path.GetFullPath(Path.Combine(defaultpath, fn));
        }
    }
    public enum DayTime: int
    {
        None = -1,
        NightStart = 0,
        Night = 1,
        NightEnd = 2,
        MorningStart = 3,
        Morning = 4,
        MorningEnd = 5,
        DayStart = 6,
        Day = 7,
        DayEnd = 8,
        EveningStart = 9,
        Evening = 10,
        EveningEnd = 11
    }
    public enum WeekDay 
    {
        d1,
        d2,
        d3,
        d4,
        d5,
        d6,
        d7
    }
}
