using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentManagementModel;
using System.Collections.Generic;
using StudentManagementModel.Model.Entities;

namespace StudentManagementServices.Services.StudentManagementService
{
    public class StudentManagementService : IStudentManagementService
    {
        public static List<StudentDto> dto = new List<StudentDto>()
        {
            //new SuperHero {
            //    Id = 1,
            //    FirstName = "Tunmise",
            //    LastName = "Atanda",
            //    Department = "Computer Science"
            //},

            //new SuperHero {
            //    Id = 2,
            //    FirstName = "Temi", 
            //    LastName = "Park",
            //    Department = "English"
            //}
        };

        private readonly DataContext _context;

        public StudentManagementService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<StudentViewmodel>> GetAllStudents()
        {
            List<StudentViewmodel> studentsList = new List<StudentViewmodel>();
            var students = await _context.Students.ToListAsync();

            foreach (var student in students)
            {
                var data = new StudentViewmodel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Department = student.Department
                };

                studentsList.Add(data);
            }

            return studentsList;
        }

        public async Task<StudentViewmodel?> GetSingleStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
            {
                return null;
            }
            var s = new StudentViewmodel()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Department = student.Department
            };
            return s;
        }


        public async Task<List<StudentViewmodel>> AddNewStudent(StudentDto student)
        {
            List<StudentViewmodel> students = new List<StudentViewmodel>();
            var s = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Department = student.Department,
            };
            await _context.Students.AddAsync(s);
            await _context.SaveChangesAsync();

            students = await GetAllStudents();

            return students;
        }

        public async Task<List<StudentViewmodel>?> UpdateStudent(int id, StudentDto request)
        {
            List<StudentViewmodel> updated_student = new List<StudentViewmodel>();
            var student = await _context.Students.FindAsync(id);

            if (student is null)
            {
                return null;
            }
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Department = request.Department;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            updated_student = await GetAllStudents();

            return updated_student;
        }

        public async Task<List<StudentViewmodel>?> DeleteStudent(int id)
        {
            List<StudentViewmodel> students = new List<StudentViewmodel>();
            var student = await _context.Students.FindAsync(id);
            if (student is null)
            {
                return null;
            }
            var stud = new StudentViewmodel()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Department = student.Department
            };

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return null;
            //students = await GetAllStudents();

            //return students;
        }
    }
}
