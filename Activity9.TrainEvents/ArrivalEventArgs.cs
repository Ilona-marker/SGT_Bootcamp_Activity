using System;

namespace CSharp.Activity.Events
{
    public class ArrivalEventArgs
    {
        // Constructor for the event data class.
        // Use this constructor to initialize the member variables.
        public ArrivalEventArgs(int num, ArrivalStatus status, DateTime time)
        {
            TrainNumber = num;
            ArrivalStatus = status;
            ArrivalTime = time;
        }

        // Public property to return the train
        // number and private setter to change it.
        public int TrainNumber { get; private set; }

        // Public property to return the arrival status
        // of the train and private setter to change it.
        public ArrivalStatus ArrivalStatus { get; private set; }

        // Public property to return the new arrival time
        // and private setter to change it.
        public DateTime ArrivalTime { get; private set; }
    }
}
