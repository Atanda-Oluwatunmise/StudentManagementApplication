using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using StudentManagementModel;
using StudentManagementModel.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementServices.Services.SeedingService
{
    public class SeedingService : IDepartmentSeedingService
    {

        private readonly DataContext _context;

        public SeedingService(DataContext context)
        {
            _context = context;
        }




        public static void AutoSeedDepartments(DataContext context)
        {
            if (context.Departments.Any())
                return; //DB has been seeded with module data            int i = 1;
            var departmentList = new Department[]
            {
                new Department() {Name = "Agriculture" },
                   new Department() {Name = "Agricultural Economics" },
                   new Department() {Name = "Agricultural Extension" },
                   new Department() {Name = "Agronomy" },
                   new Department() {Name = "Animal Science" },
                   new Department() {Name = "Crop Science" },
                   new Department() {Name = "Food Science and Technology" },
                   new Department() {Name = "Business Management" },
                   new Department() {Name = "Banking and Finance" },
                   new Department() {Name = "Marketing" },
                   new Department() {Name = "Arts Education" },
                   new Department() {Name = "Education & Mathematics" },
                   new Department() {Name = "Library and Information Science" },
                   new Department() {Name = "Civil Engineering" },
                   new Department() {Name = "Chemical Engineering" },
                   new Department() {Name = "Computer Engineering" },
                   new Department() {Name = "Electrical Engineering" },
                   new Department() {Name = "Electronic Engineering" },
                   new Department() {Name = "Mechanical Engineering" },
                   new Department() {Name = "Systems Engineering" },
                   new Department() {Name = "Architecture" },
                   new Department() {Name = "Estate Management" },
                   new Department() {Name = "Quantity Surveying" },
                   new Department() {Name = "Nursing Sciences" },
                   new Department() {Name = "Law" },
                   new Department() {Name = "Medicine" },
                   new Department() {Name = "Physiology" },
                   new Department() {Name = "Pharmaceutics" },
                   new Department() {Name = "Computer Science" },
                   new Department() {Name = "Mathematics" },
                   new Department() {Name = "Political Science" },
                   new Department() {Name = "Veterinary Anatomy" },
                   new Department() {Name = "Veterinary Medicine" },
                   new Department() {Name = "Medicine" }
            };
            context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            context.Departments.AddRange(departmentList);
            context.Database.OpenConnection();
            try
            {
                //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.t_gnsys_module ON");
                context.SaveChanges();
                //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.t_gnsys_module OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }


        public async Task<List<DepartmentViewModel>> GetAllDepartments()
        {
            List<DepartmentViewModel> studentsList = new List<DepartmentViewModel>();
            var departments = await _context.Departments.ToListAsync();

            foreach (var department in departments)
            {
                var deptData = new DepartmentViewModel
                {
                    Id = department.Id,
                    Name = department.Name
                };

                studentsList.Add(deptData);
            }

            return studentsList;
        }

    }
}
