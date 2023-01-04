using System;

namespace SampleConApp
{
    enum WeekDay{Mon,Tue,Wed,Thurs,Fri};
    class EnumEx
    {
        static void Main(string[] args)
        {
            WeekDay day = WeekDay.Mon;
            Console.WriteLine("The Selected day is "+day);

            Console.WriteLine("Enter the preffered day of working from the following");

            Array PossibleDay = Enum.GetValues(typeof(WeekDay));
            for (int i = 0; i < PossibleDay.Length; i++)
            {
                Console.WriteLine(PossibleDay.GetValue(i));

            }

            object InputValue = Enum.Parse(typeof(WeekDay), Console.ReadLine(), true);  //true because to ignore case
            WeekDay SelectedDay = (WeekDay)InputValue;
            Console.WriteLine("The Selected Day is " + SelectedDay);

        }
    }
}