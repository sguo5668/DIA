using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DIA.Web.Controllers
{
    public class CachingController : Controller
    {
        private readonly IMemoryCache _MemoryCache;

        private readonly IRepository<ReferenceTableValue> _service;
        //1
        public CachingController(IMemoryCache memCache,
            IRepository<ReferenceTableValue> serv)
        {
            _MemoryCache = memCache;
            _service = serv;
        }

        // GET: /<controller>/
        [Route("[controller]")]
        public IActionResult Index()
        {
            var Emps = SetGetMemoryCache();
            return View(Emps);
        }

        private List<ReferenceTableValue> SetGetMemoryCache()
        {
            //2
            string key = "referencetablevalue";
            List<ReferenceTableValue> ReferenceTableValues;

            //3: We will try to get the Cache data
            //If the data is present in cache the 
            //Condition will be true else it is false 
            if (!_MemoryCache.TryGetValue(key, out ReferenceTableValues))
            {
                //4.fetch the data from the object
                ReferenceTableValues = _service.GetAll().ToList();
                //5.Save the received data in cache
                _MemoryCache.Set(key, ReferenceTableValues,
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));

                ViewBag.Status = "Data is added in Cache";

            }
            else
            {
                ReferenceTableValues = _MemoryCache.Get(key) as List<ReferenceTableValue>;
                ViewBag.Status = "Data is Retrieved from in Cache";
            }
            return ReferenceTableValues;
        }
    }
}