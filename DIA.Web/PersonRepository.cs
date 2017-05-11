using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DIA.Web
{
	public class PersonRepository : Repository<Person>, IPersonRepository
	{
		public PersonRepository(DIAContext context)
			: base(context)
		{
		}




		public DIAContext DIAContext
		{
			get { return Context as DIAContext; }
		}

	}
}