﻿namespace StudentManagementModel.Model.Entities
{
    public class Student
    {
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string Department { get; set; } = string.Empty;
    }
}
