using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DIA.Web
{
    public class ClaimantRepository : Repository<Claimant>, IClaimantRepository
    {
        public ClaimantRepository(DIAContext context)
            : base(context)
        {
        }

        public IEnumerable<Claimant> GetHistoryClaimant(int id)
        {
            return DIAContext.Claimants.Where(c => c.Id == id).ToList();

        }



        public DIAContext DIAContext
        {
            get { return Context as DIAContext; }
        }

    }
}
