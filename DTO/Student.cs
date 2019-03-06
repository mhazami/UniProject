using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniProject.DTO
{
   public class Student
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10),]
        [Required(ErrorMessage = "لطفا کد ملی خود را وارد کنید")]
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }

        [MaxLength(10),]
        [Required(ErrorMessage = "لطفا تاریخ تولد خود را وارد کنید")]
        [Display(Name = "تاریخ تولد")]
        public string BirthDate { get; set; }

        [MaxLength(9)]
        [Required(ErrorMessage = "لطفا شماره دانشجویی خود را وارد کنید")]
        [Display(Name = "شماره دانشجویی")]
        public string StudentNumber { get; set; }

        [MaxLength(50),]
        [Required(ErrorMessage = "لطفا نام خود را وارد کنید")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }


        [MaxLength(50),]
        [Required(ErrorMessage = "لطفا نام خانوادگی خود را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
      

        [MaxLength(11),]
        [Required(ErrorMessage = "لطفا شماره موبایل خود را وارد کنید")]
        [Display(Name = "موبایل")]
        public string CellPhone { get; set; }
    }
}
