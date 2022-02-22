using JobPortal.Data.Models.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.Models.Repository.Employee
{
    public  interface IEmployeeRepository
    {
        Profile GetProfile(int Id);
        IEnumerable<Profile> GetProfiles();
        DoValidation Save(Profile model);



    }
}
