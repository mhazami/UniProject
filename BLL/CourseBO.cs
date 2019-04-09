using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.DTO;
using static UniProject.DTO.Tools.Enums;

namespace UniProject.BLL
{
    public class CourseBO : BusinessBase<Course>
    {
        public override void CheckConstraint(Course obj)
        {
            if (string.IsNullOrEmpty(obj.Title))
                throw new Exception("لطفا عنوان دوره را وارد کنید");
            if (string.IsNullOrEmpty(obj.StartDate))
                throw new Exception("لطفا زمان شروع دوره را وارد کنید");
            if (string.IsNullOrEmpty(obj.Duration))
                throw new Exception("لطفا طول دوره را وارد کنید");
            if (string.IsNullOrEmpty(obj.ClassTime))
                throw new Exception("لطفا زمان برگزاری دوره را وارد کنید");
            if ((byte)obj.Status == 0)
                throw new Exception("لطفا وضعیت دوره را مشخص کنید");
            if (obj.TeacherId == 0)
                throw new Exception("لطفا مدرس دوره را مشخص کنید");
        }

      
    }
}
