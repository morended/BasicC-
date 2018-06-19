using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using static CsharpBasics.basics.ColorFlag;

namespace CsharpBasics.basics
{

    //Flags attribute should be used when enumeration consists collection of flags

    [Flags]
    public enum ColorFlag
    {
        Red = 1,
        Blue = 2, // 1<<1
        Green = 4, // 1<<2
        Black = 8, // 1 << 3
        Orange = 16, // 1 << 4
        Yellow = 32, // 1<<5
        Indigo = 64,
        Voilet = 128
    }


    public class BitWiseOperations
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToString((byte) Black, 2).PadLeft(8, '0')); //output: 0001000
            var favColors = Red | Black | Green | Red | Orange;  // enumeration represention collection of flags
            var rainbowColors = Voilet | Indigo | Blue | Green | Yellow | Orange | Red;
            Console.WriteLine($"IS blue Favorite {favColors.HasFlag(Blue)}"); //output: IS blue Favorite False
            Console.WriteLine($"IS Green Rainbow Color  {rainbowColors.HasFlag(Green)}"); //output : IS Green Rainbow Color True

            Swap(10, 12);
            BitShiftPerformance();
            TimeOffsets.testTime();
        }

        //use XOR to swap two numbers  without using temporary variable
        private static void Swap(int a, int b)
        {
          Console.WriteLine($"Before swap a: {a} b: {b}"); // a:10 b:12
            a = a ^ b;
            b = b ^ a;
            a = a ^ b;
            Console.WriteLine($"after swap a: {a} b: {b}"); // a:12 b:10
        }

        // shift Operations are fast.
        //Left shift of k position is same as multiplying the number with 2^k.
        //Right shift of k position is same as dividing the number with 2^k.
        //Bit shift are used in Random number Generator and Hash Generation Algorithms

        private static void BitShiftPerformance()
        {
            var start = Stopwatch.GetTimestamp();
            double a = 12 << 8;
            var end = Stopwatch.GetTimestamp();
            Console.WriteLine($"Use shift left operator a:{a}"); //3072
            Console.WriteLine($"Number of ticks are less when using left shift operator: {end - start}"); // 18

            Console.WriteLine("---------------");

            start = Stopwatch.GetTimestamp();
            a = 12 * Math.Pow(2, 8);
            end = Stopwatch.GetTimestamp();
            Console.WriteLine($"Use Multiplication a:{a}"); //3072
            Console.WriteLine($"Number of ticks are more when using multiplication: {end - start}"); //185
        }

    }

    public class TimeOffsets
    {
        public static void testTime()
        {
            DateTime thisDate = new DateTime(2007, 3, 10, 0, 0, 0);
            DateTime dstDate = new DateTime(2007, 6, 10, 0, 0, 0);
            DateTimeOffset thisTime;

            thisTime = new DateTimeOffset(dstDate, new TimeSpan(-7, 0, 0));
            ShowPossibleTimeZones(thisTime);

            thisTime = new DateTimeOffset(thisDate, new TimeSpan(-6, 0, 0));
            ShowPossibleTimeZones(thisTime);

            thisTime = new DateTimeOffset(thisDate, new TimeSpan(+1, 0, 0));
            ShowPossibleTimeZones(thisTime);
        }

        private static void ShowPossibleTimeZones(DateTimeOffset offsetTime)
        {
            TimeSpan offset = offsetTime.Offset;
            ReadOnlyCollection<TimeZoneInfo> timeZones;

            Console.WriteLine("{0} could belong to the following time zones:",
                offsetTime.ToString());
            // Get all time zones defined on local system
            timeZones = TimeZoneInfo.GetSystemTimeZones();
            // Iterate time zones 
            foreach (TimeZoneInfo timeZone in timeZones)
            {
                // Compare offset with offset for that date in that time zone
                if (timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset))
                    Console.WriteLine("   {0}", timeZone.DisplayName);
            }
            Console.WriteLine();
        }
    }
}
