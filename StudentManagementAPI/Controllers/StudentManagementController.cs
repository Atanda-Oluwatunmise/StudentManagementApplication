using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementModel;
using StudentManagementServices;
using StudentManagementServices.Services.SeedingService;
using StudentManagementServices.Services.StudentManagementService;


//forwarding the requests

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentManagementController : ControllerBase
    {

        //the controller is injecting the interface IStudentManagementService and the datacontext

        private readonly IStudentManagementService _studentManagementService;
        private readonly IDepartmentSeedingService _departmentSeedingService;
        private readonly DataContext _context;

        public StudentManagementController(DataContext context, IStudentManagementService studentManagementService, IDepartmentSeedingService departmentSeedingService)
        {
            _studentManagementService = studentManagementService;
            _departmentSeedingService = departmentSeedingService;
            _context = context;
        }


        //View all
        [Route("Students")]
        [HttpGet]
        public async Task<ActionResult<List<StudentViewmodel>>> GetAllStudents()
        {
            return await _studentManagementService.GetAllStudents();

        }


        //view all department table for the seeded data
        [Route("Departments")]
        [HttpGet]
        public async Task<ActionResult<List<DepartmentViewModel>>> GetAllDepartments()
        {
            return await _departmentSeedingService.GetAllDepartments();
        }


        //View by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetSingleStudent(int id)
        {
            var result = await _studentManagementService.GetSingleStudent(id);
            if (result is null)
                return NotFound("Student does not exist");
            return Ok(result);
        }

        //Add new
        [HttpPost]
        public async Task<ActionResult<List<StudentViewmodel>>> AddNewStudent(StudentDto student)
        {
            var result = await _studentManagementService.AddNewStudent(student);
            return Ok(result);
        }

        //find/Update
        [HttpPut("{id}")]
        public async Task<ActionResult<List<StudentViewmodel>>> UpdateStudent(int id, StudentDto request)
        {
            var result = await _studentManagementService.UpdateStudent(id, request);
            if (result is null)
                return NotFound("Student does not exist");
            return Ok(result);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StudentDto>>> DeleteStudent(int id)
        {
            var result = await _studentManagementService.DeleteStudent(id);
            if (result is null)
                return NotFound("Student does not exist");
            return Ok(result);
        }
    }
}
