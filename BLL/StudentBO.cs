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

        public override void CheckConstraint(Student obj)
        {
            Student student = base.FirstOrDefault(c => c.Username == obj.Username);
            if (student != null)
                throw new Exception("این نام کاربری قبلا در سیستم ثبت شده است");
            if (base.Any(c => c.NationalCode == obj.NationalCode) || base.Any(c => c.StudentNumber == obj.StudentNumber))
                throw new Exception("شما قبلا به عضویت انجمن درآمده اید");
            if (string.IsNullOrEmpty(obj.FirstName))
                throw new Exception("لطفا نام خود را وارد کنید");
            if (string.IsNullOrEmpty(obj.LastName))
                throw new Exception("لطفا نام خانوادگی خود را وارد کنید");
            if (string.IsNullOrEmpty(obj.BirthDate))
                throw new Exception("لطفا تاریخ تولد خود را وارد کنید");
            if (string.IsNullOrEmpty(obj.StudentNumber))
                throw new Exception("لطفا شماره دانشجویی خود را وارد کنید");
            if (obj.StudentNumber.Length != 9)
                throw new Exception("شماره دانشجویی اشتباه می باشد");
            if (string.IsNullOrEmpty(obj.NationalCode))
                throw new Exception("لطفا کد ملی خود را وارد کنید");
            if (obj.NationalCode.Length < 10 || obj.NationalCode.Length > 11)
                throw new Exception("کد ملی اشتباه می باشد");
            if (string.IsNullOrEmpty(obj.CellPhone))
                throw new Exception("لطفا شماره موبایل خود را وارد کنید");
            if (!obj.CellPhone.StartsWith("09") || obj.CellPhone.Length != 11)
                throw new Exception("شماره موبایل اشتباه می باشد");
            if (string.IsNullOrEmpty(obj.Username))
                throw new Exception("لطفا نام کاربری خود را وارد کنید");
            if (string.IsNullOrEmpty(obj.Password))
                throw new Exception("لطفا رمز عبور خود را وارد کنید");
            if (obj.Password != obj.ConfirmPassword)
                throw new Exception("رمز عبور با تکرار آن مطابقت دارد");
            if (string.IsNullOrEmpty(obj.Email))
                throw new Exception("لطفا ایمیل خود را وارد کنید");

            obj.Password = StringUtils.HashPassword(obj.Password);
        }
    }
}
