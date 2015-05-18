using System;
using System.Collections.Generic;
using System.Linq;

namespace TryingOut.Math
{
    public class ClockAngle
    {
        private const int OneMinuteAngleForMinuteHand = 360 / 60;
        private const int OneHourAngleForHourHand = 360/12;
        private const decimal OneMinuteAngleForHourHand = OneHourAngleForHourHand/60m;
        private const int MaxAngle = 180;
        private const int FullAngle = 360;

        public decimal ForHour(int hour)
        {
            var angle = hour * OneHourAngleForHourHand;
            return CorrectAngleFor180(angle);
        }

        private static decimal CorrectAngleFor180(decimal angle)
        {
            return angle > MaxAngle ? FullAngle - angle : angle;
        }

        public decimal ForMinute(int minute)
        {
            var angle = minute * OneMinuteAngleForMinuteHand;
            return CorrectAngleFor180(angle);
        }

        public decimal GetAngleBetweenHourAndMinuteHand(int hour, int minute)
        {
            var minuteAngle = minute * OneMinuteAngleForMinuteHand;
            var hourAngle = hour * OneHourAngleForHourHand;
            var angleMovedByHourHandForGivenMinutes = minute*OneMinuteAngleForHourHand;
            var totalHourAngle = hourAngle + angleMovedByHourHandForGivenMinutes;

            var angle = System.Math.Abs(totalHourAngle - minuteAngle);
            return CorrectAngleFor180(angle);
        }

        public List<Time> GetTimesForAngle(int angle)
        {
            var times = new List<Time>();
            foreach (var hour in Enumerable.Range(0, 12))
            {
                foreach (var minute in Enumerable.Range(0, 60))
                {
                    //Console.WriteLine("Hour: {0} Minute: {1} Angle: {2}", hour, minute, GetAngleBetweenHourAndMinuteHand(hour, minute));
                    if (angle == GetAngleBetweenHourAndMinuteHand(hour, minute))
                    {
                        times.Add(new Time{ Hour = hour, Minute = minute});
                    }
                }
            }
            return times;
        }
    }

    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
