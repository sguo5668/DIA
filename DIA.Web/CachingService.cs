using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace DIA.Web
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> Get();
    }

    public class ReferenceTableValueService : IService<ReferenceTableValue>, IRepository<ReferenceTableValue>
    {
        DIAContext ds;
        public ReferenceTableValueService(DIAContext d)
        {
            ds = d;
        }
        public IEnumerable<ReferenceTableValue> Get()
        {
            return ds.Get();
        }
    }
}
