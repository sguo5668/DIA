using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web
{
    public class ReferenceTableValueRepository : Repository<ReferenceTableValue>, IReferenceTableValueRepository
    {
        public ReferenceTableValueRepository(DIAContext context)
            : base(context)
        {
        }

        public DIAContext DIAContext
        {
            get { return Context as DIAContext; }
        }

    }
}
