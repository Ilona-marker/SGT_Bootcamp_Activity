using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Activity.Events
{
    public class TrainStation
    {
        // The event field declaration.
        public event EventHandler<ArrivalEventArgs> Arrival;
        // void SomeMethod(object sender, ArrivalEventArgs event)

        // This method would raise the event Arrival.
        protected void OnArrival(ArrivalEventArgs e)
        {
            Arrival?.Invoke(this, e); //events
        }

        // This method would be called by the clients.
        // From this method invoke the method OnArrival()
        // by passing a new instance of <ArrivalEventArgs>.

        public void AnnounceArrival(int train, ArrivalStatus arrivalStatus, DateTime arrivalTime)
        {
            ArrivalEventArgs eventArgs = new(train, arrivalStatus, arrivalTime);
            OnArrival(eventArgs);
        }
    }
}
