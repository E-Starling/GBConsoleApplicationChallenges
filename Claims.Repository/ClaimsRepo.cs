using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Repository
{
    public class ClaimsRepo
    {
        protected readonly List<Claim> _claimDir = new List<Claim>();
        // Create
        public bool AddClaimToDirectory(Claim claim)
        {
            int startingCount = _claimDir.Count();
            _claimDir.Add(claim);
            bool wasAdded = (_claimDir.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        // Read
        public List<Claim> GetClaims()
        {
            return _claimDir;
        }
        public Claim GetClaimById(int iD)
        {
            return _claimDir.Where(g => g.ID == iD).SingleOrDefault();
        }
        // Delete
        public bool DeleteExistingClaim(Claim existingClaim)
        {
            bool deleteResult = _claimDir.Remove(existingClaim);
            return deleteResult;
        }
    }
}
