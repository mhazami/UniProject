using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.DTO;

namespace UniProject.DAL.Context
{
    public class UniContext : DbContext
    {
        public UniContext() : base("name=UniProjectConnectionString") { }
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<File> File { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<CourseStudent> CourseStudents { get; set; }

        public virtual DbSet<CourseTeacher> CourseTeachers { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

    }
}
