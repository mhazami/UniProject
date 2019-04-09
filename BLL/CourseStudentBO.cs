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
    }
}
