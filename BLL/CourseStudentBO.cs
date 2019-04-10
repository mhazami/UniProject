using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.DTO;

namespace UniProject.BLL
{
    public class CourseStudentBO : BusinessBase<CourseStudent>
    {
        public override bool Insert(CourseStudent obj)
        {
            return base.Insert(obj);
        }

        public override void CheckConstraint(CourseStudent obj)
        {
            if (base.Any(c => c.CourseId == obj.CourseId && c.Student.StudentNumber == obj.Student.StudentNumber) ||
                base.Any(c => c.CourseId == obj.CourseId && c.Student.NationalCode == obj.Student.NationalCode))
                throw new Exception("شما قبلا در این دوره آموزشی ثبت نام کرده اید");

        }
    }
}
