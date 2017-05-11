using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DIA.Web.ViewModels;
 

namespace DIA.Web
{
    public class DIAContext : DbContext
    {

        public DIAContext(DbContextOptions<DIAContext> options)
            : base(options)
        {
        }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<Claimant> Claimants { get; set; }
        public DbSet<Form> Forms { get; set; }

		public DbSet<Person> Persons { get; set; }

		public DbSet<PersonPhoneNumber> PersonPhoneNumbers { get; set; }

		public DbSet<PersonAddress> PersonAddresses { get; set; }
		public DbSet<FormOtherName> FormOtherNames { get; set; }
        public DbSet<DI2501AForm> DI2501AForms { get; set; }
		public DbSet<ReferenceTable> ReferenceTable { get; set; }
		public DbSet<ReferenceTableValue> ReferenceTableValue { get; set; }
		//public DbSet<DIA.Web.ViewModels.DI2501AClaimantFormW6b> DI2501AClaimantFormW6b { get; set; }
        
    }
}
