using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DIA.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace DIA.Web.Controllers
{
    public class PersonController : Controller
    {

		IPersonRepository repoPerson;
		IPersonPhoneRepository repoPersonPhone;
		IPersonAddressRepository repoPersonAddress;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<PersonController> _localizer;
		private static VMPersonProfile x = new VMPersonProfile();
		readonly ILogger<PersonController> _log;

		public PersonController(
			IPersonRepository personRepository,
			IPersonPhoneRepository personPhoneRepository,
			IPersonAddressRepository personAddressRepository,
			IMapper mapper, 
			IStringLocalizer<PersonController> localizer,
			ILogger<PersonController> log
			)
		{
			repoPerson = personRepository;
			repoPersonPhone = personPhoneRepository;
			repoPersonAddress = personAddressRepository;
			_mapper = mapper;
			_localizer = localizer;
			_log = log;
		}


		[Route("[controller]")]
		[Route("[controller]/[action]/{id?}")]
		[Route("[controller]/{id?}")]
		public IActionResult Index(int id)
		{
			x.Person = repoPerson.Get(id);
			x.PersonAddress = repoPersonAddress.Get(id);

			x.PersonPhoneNumber = repoPersonPhone.Get(id);


			return View("PersonProfile",x);
		}



		[HttpGet] 
		[Route("[controller]/Phone/[action]/{id?}")]
		public IActionResult Edit(int id)
		{

			x.Person = repoPerson.Get(id);
			x.PersonPhoneNumber = repoPersonPhone.Get(id);


			return View("PersonPhone", x);
		}

		[HttpPost]
		[Route("[controller]/Phone/[action]/{id?}")]
		public IActionResult Edit(VMPersonProfile VMPersonProfile, int id)
		{

			_log.LogInformation("this is a test");

			x.PersonPhoneNumber = VMPersonProfile.PersonPhoneNumber;

			repoPersonPhone.Update(x.PersonPhoneNumber);



			return View("PersonPhone", x);
		}


	}
}