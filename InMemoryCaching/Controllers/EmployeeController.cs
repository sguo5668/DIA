 
using Microsoft.AspNetCore.Mvc;

using InMemoryCaching.Models;
using InMemoryCaching.Services;
 
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;


namespace InMemoryCaching.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMemoryCache _MemoryCache;

        private readonly IService<Employee> _service;
        //1
        public EmployeeController(IMemoryCache memCache,
            IService<Employee> serv)
        {
            _MemoryCache = memCache;
            _service = serv;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var Emps = SetGetMemoryCache();
            return View(Emps);
        }

        private List<Employee> SetGetMemoryCache()
        {
            //2
            string key = "MyMemoryKey-Cache";
            List<Employee> Employees;

            //3: We will try to get the Cache data
            //If the data is present in cache the 
            //Condition will be true else it is false 
            if (!_MemoryCache.TryGetValue(key, out Employees))
            {
                //4.fetch the data from the object
                Employees = _service.Get().ToList();
                //5.Save the received data in cache
                _MemoryCache.Set(key, Employees,
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));

                ViewBag.Status = "Data is added in Cache";

            }
            else
            {
                Employees = _MemoryCache.Get(key) as List<Employee>;
                ViewBag.Status = "Data is Retrieved from in Cache";
            }
            return Employees;
        }
    }
}