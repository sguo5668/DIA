using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DIA.Web.ViewModels;
using Microsoft.AspNetCore.Http;
 

namespace DIA.Web.Controllers
{
    public class ClaimController : Controller
    {

        IClaimRepository repo;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public ClaimController( IClaimRepository claimRepository, IMapper mapper)
        {
            repo = claimRepository;
            _mapper = mapper;
        }

        [Route("[controller]")]
        [Route("[controller]/[action]/{id?}")]
        [Route("[controller]/{id?}")]
        public IActionResult Index(int id)
        {

            //   var claim = repo.GetHistoryClaim(id);
             var claim = repo.GetAll();

            var claimHistory = _mapper.Map<IEnumerable<ClaimHistory>>(claim);

            return View(claimHistory);

 
        }

        public IActionResult Create(int id)
        {
            return View("W6Step1");
        }


        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult Get(int id)
        {
            return View("index");
        }

        private DI2501AClaimantForm GetDI2501AClaimantForm()
        {
            var formsession = HttpContext.Session.GetObject<DI2501AClaimantForm>("DI2501AClaimantForm");

            if (formsession == null)
            {

                var x = new DI2501AClaimantForm();
                HttpContext.Session.SetObject("DI2501AClaimantForm", x);

                //HttpContext.Session.SetObjectAsJson("DI2501AClaimantForm", new DI2501AClaimantForm());
            }
            return HttpContext.Session.GetObject<DI2501AClaimantForm>("DI2501AClaimantForm");
        }

        [Route("[controller]/Create/[action]")]
        [HttpGet]
        [ActionName("Step1")]
        public ActionResult Create( string BtnCancel, string BtnNext)
        {
       
                return View("W6Step1");

       
        }



        [Route("[controller]/Create/[action]")]
        [HttpPost]
        [ActionName ("Step2")]
 
 
        public IActionResult create(FormOtherName FormOtherName, string BtnPrevious, string BtnSaveDraft, string BtnNext)
        {


            if (BtnNext != null)

            {


                ////      DI2501AClaimantForm x = (DI2501AClaimantForm)GetDI2501AClaimantForm();
                //var x = (DI2501AClaimantForm)GetDI2501AClaimantForm();
                //x.FormOtherName = FormOtherName;
                //TempData["step1"] = FormOtherName;
                return View("W6Step2");

            }
            return View();

        }

        [Route("[controller]/Create/[action]")]
        [HttpPost]
        [ActionName("Step3")]
        public IActionResult create(DI2501AForm DI2501AForm, string BtnPrevious, string BtnNext)

        {
            //DI2501AClaimantForm x = (DI2501AClaimantForm)GetDI2501AClaimantForm();

            if (BtnPrevious != null)

            {

                //FormOtherName DetailsObj = new FormOtherName();

                //DetailsObj = x.FormOtherName;


                //return View("create", DetailsObj);

                //return View("create", TempData["step1"]);
                return View("W6Step2");
            }

            if (BtnNext != null)

            {
                //x.DI2501AForm = DI2501AForm;

                //TempData["step2"] = DI2501AForm;
                return View("W6Step3");
            }

            return View();
        }

    }
}