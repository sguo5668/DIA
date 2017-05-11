using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DIA.Web
{
    public class ClaimRepository :  Repository<Claim> , IClaimRepository
	{
        public ClaimRepository(DIAContext context) 
            : base(context)
        {
        }

        public IEnumerable<Claim> GetHistoryClaim(int id)
        {
            return DIAContext.Claims.Where(c => c.Id == id).ToList();
	 
        }

 

        public DIAContext DIAContext
        {
            get { return Context as DIAContext; }
        }

    }
}
