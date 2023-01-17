using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2
{
    delegate void CallMe(string msg);
    class Clock
    {
        private static DateTime _alarmTime;
        public static event CallMe OnAlarmTime;

        public static void SetAlarm(DateTime time)
        {
            _alarmTime = time;
        }

        public static void DisplayClock()
        {
            do
            {
                if(DateTime.Now.Minute == _alarmTime.Minute)
                {
                    if (OnAlarmTime != null)
                    {
                        Console.WriteLine("Time to know about ADO .NET");
                        Console.Beep(30020, 5000);
                    }
                    
                }
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Thread.Sleep(1500);
                Console.Clear();



            } while (true);
            //Console.WriteLine(DateTime.Now.ToLongTimeString());
            //Console.Beep();
        }
       
    }
    class EventHandling
    {
        static void Main(string[] args)
        {
            Clock.OnAlarmTime += Clock_OnAlarmTime;
            Clock.SetAlarm(DateTime.Now.AddMinutes(1));
            Clock.DisplayClock();
        }

        private static void Clock_OnAlarmTime(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
