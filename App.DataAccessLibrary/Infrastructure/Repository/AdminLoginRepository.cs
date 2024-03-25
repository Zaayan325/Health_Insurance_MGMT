using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using NHibernate.Linq;

namespace App.DataAccessLibrary.Infrastructure.Repository
{
    public class AdminLoginRepository : Repository<AdminLogin>, IAdminLoginRepository
    {

        private HealthInsuranceMGMT _context;

        public AdminLoginRepository(HealthInsuranceMGMT context) : base(context)
        {
            _context = context;
        }

        public void Update(AdminLogin adminLogin)
        {
            var adminfromDb = _context.AdminLogin.FirstOrDefault(er => er.Adm_ID == adminLogin.Adm_ID);
            if (adminfromDb != null)
            {
                // Update properties
                adminfromDb.AdminName = adminLogin.AdminName;
                adminfromDb.Address = adminLogin.Address;
                adminfromDb.Phone = adminLogin.Phone;
                adminfromDb.Email = adminLogin.Email;
                adminfromDb.AdminPassword = adminLogin.AdminPassword;
                adminfromDb.ConfirmPassword = adminLogin.ConfirmPassword;
                adminfromDb.AdminPhotourl = adminLogin.AdminPhotourl;

                // Now update the database context
                _context.AdminLogin.Update(adminLogin);

                // Note: You don't call _context.SaveChanges() here because that should be done by the UnitOfWork.
            }
        }

    }
}
