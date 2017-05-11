using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DIA.Web
{
	public class PersonPhoneRepository : Repository<PersonPhoneNumber>, IPersonPhoneRepository
	{
		public PersonPhoneRepository(DIAContext context)
			: base(context)
		{
		}




		public DIAContext DIAContext
		{
			get { return Context as DIAContext; }
		}

	}
}