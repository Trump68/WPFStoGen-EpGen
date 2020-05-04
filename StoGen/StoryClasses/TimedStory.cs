using StoGen.Classes;
using StoGen.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGenerator.StoryClasses
{

    public class TimedStory: StoryBase
    {
        DateTime _DateTimeStart;
        DateTime _CurrentTime;
        private static TimeSpan NightSpan = new TimeSpan(6,0,0);
        private static TimeSpan MorningSpan = new TimeSpan(3, 0, 0);
        private static TimeSpan DaySpan = new TimeSpan(9,0,0);        
        public DateTime DTime
        {
            set
            {
                _CurrentTime = value;
                if (_DateTimeStart == null)
                {
                    _DateTimeStart = _CurrentTime;
                }
            }
            get
            {
                return _CurrentTime;
            }
        }
        public TimeSpan Time
        {
            get
            {
                return _CurrentTime.TimeOfDay;
            }
        }
        public DateTime Date
        {
            get
            {
                return _CurrentTime.Date;
            }
        }
        public DateTime IncrementTime(int h, int m)
        {
            DTime = DTime.Add(new TimeSpan(h, m, 0));
            RefreshProjectorTime();
            return DTime;
        }
        private void RefreshProjectorTime()
        {
            Projector.ImageCadre.InfoDateText = $"{DTime.ToShortDateString()}, {DTime.ToShortTimeString()}, {TimeOfDay}";
        }
        public TimeOfDay TimeOfDay
        {
            get
            {
                TimeOfDay result = TimeOfDay.evening;
                if (Time < NightSpan)
                {
                    result = TimeOfDay.night;
                }
                else if (Time < NightSpan.Add(MorningSpan))
                {
                    result = TimeOfDay.morning;
                }
                else if (Time < NightSpan.Add(MorningSpan).Add(DaySpan))
                {
                    result = TimeOfDay.day;
                }
                return result;
            }
        }
        public TimedStory(DateTime datetime) :base()
        {
            DTime = datetime;
        }

        //public override List<Info_Scene> GoForwardStory(CadreController proc, int lastgrouId)
        //{
        //    RefreshProjectorTime();
        //    return base.GoForwardStory(proc, lastgrouId);
        //}
        protected override void GenerateNewStoryStep(CadreController proc)
        {
            base.GenerateNewStoryStep(proc);
            RefreshProjectorTime();
        }
    }
}
