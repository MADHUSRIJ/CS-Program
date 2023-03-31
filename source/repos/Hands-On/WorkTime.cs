using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On
{
    /*Working 9 to 5
    Write a function that calculates overtime and pay associated with overtime.

    Working 9 to 5: regular hours
    After 5pm is overtime
    Your function gets an array with 4 values:

    Start of working day, in decimal format, (24 - hour day notation)
    End of working day. (Same format)
    Hourly rate
    Overtime multiplier
    Your function should spit out:

    $ + earned that day(rounded to the nearest hundreth)
    Examples
    OverTime([9, 17, 30, 1.5]) ➞ "$240.00"

    OverTime([16, 18, 30, 1.8]) ➞ "$84.00"

    OverTime([13.25, 15, 30, 1.5]) ➞ "$52.50"
    2nd example explained:

    From 16 to 17 is regular, so 1 * 30 = 30
    From 17 to 18 is overtime, so 1 * 30 * 1.8 = 54
    30 + 54 = $84.00*/

    public class WorkTime
    {
        double wages = 0;

        public double GetWages()
        {
            Console.WriteLine(wages);
            return wages;
        }
        public void OverTime(double startTime, double endTime,double hourlyRate, double overtimeMultiplier )
        {
            double regularTime = 0;
            double overTime = 0;

            if ( endTime > 17)
            {
                regularTime = 17 - startTime;
                overTime = endTime - 17;
            }

            else
            {
                regularTime = endTime - startTime;
            }
            

            double regularWages = regularTime * hourlyRate;
            double extraWages = 0;

            if ( overTime > 0 )
            {
                extraWages = overTime * hourlyRate * overtimeMultiplier;
            }

            wages = regularWages + extraWages;
            Math.Round(wages, 2);
            Console.WriteLine(wages);

        }
    }
}
