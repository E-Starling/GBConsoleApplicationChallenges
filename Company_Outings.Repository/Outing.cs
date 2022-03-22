using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Outings.Repository
{
public enum EventType { Golf=1, Bowling , Amusement_Park, Concert}
    public class Outing
    {
        public Outing() { }
        public Outing(EventType events,int numPeople, DateTime date, double personCost, double eventCost)
        {
            Events = events;
            NumPeople = numPeople;
            Date = date;
            PersonCost = personCost;
            EventCost = eventCost;
        }
        public EventType Events { get; set; }
        public int NumPeople { get; set; }
        public DateTime Date { get; set; }
        public double PersonCost { get; set; }
        public double EventCost { get; set; }
    }
}
