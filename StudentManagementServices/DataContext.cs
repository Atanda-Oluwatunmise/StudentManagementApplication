using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
//using StudentManagementModel.Model.Data_Objects;
using StudentManagementModel.Model.Entities;
using System.Reflection.Emit;

namespace StudentManagementServices
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //connection string
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //modelBuilder.Entity<Student>(entity =>
        //    //{
        //    //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
        //    //});

        //    //base.OnModelCreating(modelBuilder);
        //options.usesqlserver("server=localhost\\mssqlserver01;initial catalog=studentmanagementdb;user id=mireya;password=timilehin@31;trusted_connection=false;trustservercertificate=true");
        //    //new DbInitializer(modelBuilder).Seed();

        //}

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
