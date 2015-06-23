using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.Math;

namespace TryingOut.Tests.Math
{
    class ClockAngleTests
    {
        private readonly ClockAngle _clockAngle = new ClockAngle();

        [Test]
        public void ShouldGetHourAngle()
        {
            foreach (var hour in Enumerable.Range(1, 12))
            {
                Console.WriteLine(_clockAngle.ForHour(hour) + " " + hour);
                var angle = hour * 30;
                _clockAngle.ForHour(hour).Should().Be(angle > 180 ? 360 - angle : angle);
            }
        }

        [Test]
        public void ShouldGetMinuteAngle()
        {
            foreach (var minute in Enumerable.Range(1, 60))
            {
                Console.WriteLine(_clockAngle.ForMinute(minute) + " " + minute);
                var angle = minute * 6;
                _clockAngle.ForMinute(minute).Should().Be(angle > 180 ? 360 - angle : angle);
            }
        }

        [TestCase(3, 0, 90)]
        [TestCase(6, 0, 180)]
        [TestCase(9, 0, 90)]
        [TestCase(12, 0, 0)]
        [TestCase(1, 0, 30)]
        [TestCase(11, 0, 30)]
        [TestCase(7, 0, 150)]
        [TestCase(7, 24, 78)]
        [TestCase(2, 20, 50)]
        public void ShouldGetAngleBetweenHourAndMinuteHandForTime(int hour, int minute, decimal expectedAngle)
        {
            _clockAngle.GetAngleBetweenHourAndMinuteHand(hour, minute).Should().Be(expectedAngle);
        }

        [TestCase(0, 1)]
        [TestCase(30, 2)]
        [TestCase(90, 2)]
        [TestCase(180, 1)]
        public void ShouldFindTimesWhenHourAndMinuteMakesGivenAngle(int angle, int total)
        {
            var times = _clockAngle.GetTimesForAngle(angle);
         
            Console.WriteLine("Angle: " + angle);
            times.ForEach(x => Console.WriteLine(x.Hour + ":" + x.Minute));
            
            times.Count.Should().Be(total);
        }

        //TODO: Need to add test for finding hours when hour and minute are super imposed

        //[Test]
        //public void ShouldFindTimesWhenHourAndMinuteMakesGivenAngle1()
        //{
        //    foreach (var angle in Enumerable.Range(0, 181))
        //    {
        //        var times = _clockAngle.GetTimesForAngle(angle);

        //        Console.WriteLine("Angle: " + angle);
        //        times.ForEach(x => Console.WriteLine(x.Hour + ":" + x.Minute));

        //        //times.Count.Should().Be(total);
        //    }
        //}
    }
}
