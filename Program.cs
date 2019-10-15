// 獲取UTC時間，以及UTC和DateTime互相轉換
using System;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========Now========");
            DateTime utcNow = DateTime.Now.ToUniversalTime();  // 0時區
            Console.WriteLine(utcNow);

            double utc = convert2double(utcNow);  // 東8時區
            Console.WriteLine("UTC: " + utc);
            DateTime dtime = convert2datetime(utc);
            Console.WriteLine("Time: " + dtime);
        }

        public static double convert2double(System.DateTime time)
        {
            double result = 0;
            // System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(2010, 1, 1));  // 舊版本
            System.DateTime startTime = TimeZoneInfo.ConvertTime(new System.DateTime(2010, 1, 1), TimeZoneInfo.Local);
            result = (time - startTime).TotalMilliseconds;
            return result;
        }

        public static DateTime convert2datetime(double utc)
        {
            // System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(2010, 1, 1));  // 舊版本
            System.DateTime startTime = TimeZoneInfo.ConvertTime(new System.DateTime(2010, 1, 1), TimeZoneInfo.Local);
            startTime = startTime.AddMilliseconds(utc);
            startTime = startTime.AddHours(8);
            return startTime;
        }
    }
}
