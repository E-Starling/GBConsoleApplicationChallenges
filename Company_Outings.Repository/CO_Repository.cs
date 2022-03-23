using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Outings.Repository
{
    public class CO_Repository
    {
        protected readonly List<Outing> _outingDir = new List<Outing>();
        //C
        public bool AddOutingToDirectory(Outing outing)
        {
            int startingCount = _outingDir.Count();
            _outingDir.Add(outing);
            bool wasAdded = (_outingDir.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        //R
        public List<Outing> GetOutings()
        {
            return _outingDir;
        }
        public  List<Outing> GetOutingByEvent(EventType events)
        {
            return _outingDir.Where(o => o.Events == events).ToList();
        }
        
    }
}
