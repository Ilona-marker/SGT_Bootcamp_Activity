using System;

namespace CSharp.Activity.Events
{
    public class Program
    {
        private static void ArrivalHandler(object sender, ArrivalEventArgs args)
        {
            if (args.ArrivalStatus == ArrivalStatus.Arriving)
            {
                Console.WriteLine($"ARRIVING: #{args.TrainNumber} ${args.ArrivalTime}");
            }
        }

        public static void Main()
        {
            TrainStation station = new();

            station.Arrival += ArrivalHandler;

            station.Arrival += (sender, args) =>
            {
                if (args.ArrivalStatus == ArrivalStatus.Arriving)
                {
                    Console.WriteLine($"Arriving 2: #{args.TrainNumber} ${args.ArrivalTime}");
                }
            };

            station.AnnounceArrival(1001, ArrivalStatus.Arriving, DateTime.Now);
            station.AnnounceArrival(1002, ArrivalStatus.Arriving, DateTime.Now.AddMinutes(5));
            station.AnnounceArrival(1003, ArrivalStatus.Delayed, DateTime.Now.AddHours(1));
        }
    }
}