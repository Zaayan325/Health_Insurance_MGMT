using App.DataAccessLibrary.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private HealthInsuranceMGMT _context;

        public UnitofWork(HealthInsuranceMGMT context)
        {
            _context = context;
        }
        public void save()
        {
            _context.SaveChanges();
        }
    }
}
