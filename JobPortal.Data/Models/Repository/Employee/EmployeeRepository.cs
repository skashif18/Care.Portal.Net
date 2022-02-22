using JobPortal.Data.Models.Datamodel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.Models.Repository.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private CarePortalEntities db = new CarePortalEntities();
        private DoValidation val = new DoValidation();

        public IEnumerable<Profile> GetProfiles()
        {
            return db.Profiles;
        }


        public Profile GetProfile(int Id)
        {
            return db.Profiles.Where(m => m.Id == Id).FirstOrDefault();
        }

        public DoValidation Save(Profile model)
        {
            if (model.Id > 0)
            {
                var data = db.Profiles.Where(m => m.Id == model.Id).FirstOrDefault();
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.Email = model.Email;
                data.IsActive = model.IsActive;
                data.JobTitleId = model.JobTitleId;


            }

            else
            {

                //val = CheckDuplicate(model);
                //if(!val.IsSucess) return val;


                db.Profiles.Add(model);

            }

            try
            {
                db.SaveChanges();
                val.IsSucess = true;
                val.Message = "Saved Successfully";


            }
            catch (Exception ex)
            {

                val.IsSucess = false;
                val.Message = ex.Message;
            }

            return val;


        }

        private DoValidation CheckDuplicate(Profile m) {

            var v = db.Profiles.Where(model => model.Email == m.Email).FirstOrDefault();
            if (v.Email.Equals(m.Email))
            {
                val.IsSucess = false;
                val.Message = "Email Already Exist";
            }
            else if (v.Mobile.Equals(m.Mobile))
            {
                val.IsSucess = false;
                val.Message = "Mobile Already Exist";
            }
            return val;;
        }

    }
}
