using System;
using System.Collections.Generic;
using System.Text;
 

namespace DIA.Web
{
    public interface IClaimRepository: IRepository<Claim>
    {
        IEnumerable<Claim> GetHistoryClaim(int id);
       
    }
}
