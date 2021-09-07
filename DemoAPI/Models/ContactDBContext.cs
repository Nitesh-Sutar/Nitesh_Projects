using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Model
{
    public class ContactDBContext: DbContext
    {
        public ContactDBContext(DbContextOptions<ContactDBContext> options)
                : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
