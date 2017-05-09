using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMemoryCaching.Models;

namespace InMemoryCaching.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> Get();
    }

    public class EmployeeService : IService<Employee>
    {
        DataAccess ds;
        public EmployeeService(DataAccess d)
        {
            ds = d;
        }
        public IEnumerable<Employee> Get()
        {
            return ds.Get();
        }
    }
}
