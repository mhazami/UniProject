using DAL;
using DAL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.DTO;

namespace UniProject.BLL
{
    public class StudentBO : BusinessBase<Student>
    {
        public Student Loging(Student student)
        {
            student.Password = StringUtils.HashPassword(student.Password);
            return base.FirstOrDefault(c => c.Username == student.Username && c.Password == student.Password);
        }
    }
}
