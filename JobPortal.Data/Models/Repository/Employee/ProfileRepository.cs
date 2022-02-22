using JobPortal.Data.Models.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.Models.Repository.Employee
{
    public class ProfileRepository : IEmployeeRepository
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
            model.FirstName = "This is from Profile Repo";
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

            
                //if (!val.IsSucess) return val;


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

    }
}
