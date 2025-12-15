using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace Utilities.Reppository;

public class ContactRepository(ApplicationDbContext dbContext) : EfRepository<Contact>(dbContext)
{
}
