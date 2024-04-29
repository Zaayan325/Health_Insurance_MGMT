using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models.Models;

namespace App.DataAccessLibrary.Infrastructure.IRepository
{
    public interface IHospitalRepository : IRepository<Hospital>
    {
        void Update(Hospital hospital); // Updated to return Task


    }
    
    
}
