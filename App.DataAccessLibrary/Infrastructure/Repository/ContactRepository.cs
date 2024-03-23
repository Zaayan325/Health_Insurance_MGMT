using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly HealthInsuranceMGMT _context;

        public ContactRepository(HealthInsuranceMGMT context) : base(context)
        {
            _context = context;
        }

        // If there are any Contact-specific methods that need to be implemented,
        // they should be done here. For example, an overridden Update method if declared in IContactRepository:
        // public void Update(Contact contact)
        // {
        //     var objFromDb = _context.Contacts.FirstOrDefault(s => s.Id == contact.Id);
        //     if (objFromDb != null)
        //     {
        //         // Update properties
        //         // objFromDb.Property = contact.Property;
        //     }
        // }
    }
}
