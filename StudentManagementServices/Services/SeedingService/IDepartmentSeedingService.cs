using StudentManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementServices.Services.SeedingService
{
    public interface IDepartmentSeedingService
    {
        Task<List<DepartmentViewModel>> GetAllDepartments();

    }
}
