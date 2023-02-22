//using StudentManagementAPI.Model;

using StudentManagementModel;

namespace StudentManagementServices.Services.StudentManagementService
{
    //defining our methods
    public interface IStudentManagementService
    {
        Task<List<StudentViewmodel>> GetAllStudents();
        Task<StudentViewmodel?> GetSingleStudent(int id);
        Task<List<StudentViewmodel>> AddNewStudent(StudentDto student);
        Task<List<StudentViewmodel>?> UpdateStudent(int id, StudentDto request);
        Task<List<StudentViewmodel>?> DeleteStudent(int id);
    }
}
