using System;
using Shouldly;
using Xunit;

namespace CSharpBasicsTests
{
    public class DateTest
    {
        //TimeSpan is measured as number of ticks. Tick ~ 100 nano seconds. 
        //TimeSpan represents the length of the time. 
        // It is implemented as a immutable struct type.

        [Fact]
        public void TestTimeSpan()
        {
            TimeSpan timeSpan = new TimeSpan(2, 1, 10, 10, 10);
            timeSpan.Days.ShouldBe(2);
            timeSpan.Hours.ShouldBe(1); //Gets the hours component in the time span
            Math.Round(timeSpan.TotalHours).ShouldBe(49); // Give total hours in the time span
            var fiveDays = TimeSpan.FromDays(5); // timespan of 5 days
            fiveDays.Days.ShouldBe(5);
            fiveDays.Hours.ShouldBe(0);
            fiveDays.TotalHours.ShouldBe(120);
        }

        //DateTime is immutable struct type
        //It stores number of ticks and DateTime Kind(Utc, Local, Unspecified).
        //We cannot get the TimeZone offset from DateTime

        [Fact]
        public void TestDateTime()
        {
            DateTime.Now.Date.ShouldBe(DateTime.Today.Date);
            DateTime.Now.Kind.ShouldBe(DateTimeKind.Local);
            DateTime.Today.Kind.ShouldBe(DateTimeKind.Local);
            DateTime localDateTime = new DateTime(2018, 6, 16, 9, 27, 50, DateTimeKind.Local); //represents localtime
            DateTime unSpecifiedDateTime =
                new DateTime(2018, 6, 16, 9, 27, 50, DateTimeKind.Unspecified); // neither local nor utc
            DateTime utcDateTime = new DateTime(2018, 6, 16, 15, 27, 50, DateTimeKind.Utc); // utc time
            localDateTime.ToUniversalTime().ShouldBe(utcDateTime); // convert local time to utc
            localDateTime.ToLocalTime().ShouldBe(localDateTime); // no effect  both are same
            utcDateTime.ToLocalTime().ShouldBe(localDateTime); //convert utc to local
            utcDateTime.ToUniversalTime().ShouldBe(utcDateTime); //  no effect -both are same
            unSpecifiedDateTime.ToUniversalTime()
                .ShouldBe(utcDateTime); // considers unspecifiedtime as local and converts to utc
            unSpecifiedDateTime.ToLocalTime().ToUniversalTime()
                .ShouldBe(localDateTime); // considers unspecifiedtime as utc and converts to local
            (DateTime.Now - DateTime.UtcNow).Hours
                .ShouldBeLessThan(0); // even both instances are same, localtime is earler than utc value
        }

        //DateTimeOffSet is  a struct type
        //It store ticks and keeps track of the offset from UTC as a TimeSpan.
        //DateTimeOffset always knows it's timezone.
        //DateTimeOffset valuesa are normaluized to zero offset before comparing.
        //We can intialize a DateTimeOffset with DateTime. UTCKind has zero offset where as Local and unspecifed has local time offset

        //Drawbacks of using DateTime:
        //1) It is difficult to get timeZone for DateTime values with DateTimeKind.Unspecified 
        //2) DateTime doesn't care about UTC /Local when doing comparisons. It only cares abput number of ticks.

        [Fact]
        public void TestDateTimeOffet()
        {
            DateTimeOffset.Now.Offset.Hours.ShouldBe(DateTime.Now.Hour - DateTime.UtcNow.Hour);
            DateTimeOffset.UtcNow.Offset.ShouldBe(TimeSpan.Zero);
            (DateTimeOffset.Now - DateTimeOffset.UtcNow).Hours.ShouldBe(0); // Both instances are same
            (DateTimeOffset.Now - DateTimeOffset.UtcNow).Minutes.ShouldBe(0);

            DateTimeOffset.Now.DateTime.ShouldBe(DateTime.UtcNow + DateTimeOffset.Now.Offset); // sum of utc time and offset = the current DateTimeOffset datetime

            DateTimeOffset dateAndTime = new DateTimeOffset(DateTime.Now.Ticks, new TimeSpan(-6, 0, 0));

            foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                if (timeZone.BaseUtcOffset.Equals(dateAndTime.Offset))
                {
                    timeZone.DisplayName.ShouldContain("(UTC-06:00)");

                }

            }
        }
    }
}
