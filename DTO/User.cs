using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniProject.DTO
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50),]
        [Required(ErrorMessage = "لطفا نام خود را وارد کنید")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }


        [MaxLength(50),]
        [Required(ErrorMessage = "لطفا نام خانوادگی خود را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [MaxLength(10),]
        [Required(ErrorMessage = "لطفا تاریخ تولد خود را وارد کنید")]
        [Display(Name = "تاریخ تولد")]
        public string BirthDate { get; set; }


        [MaxLength(10),]
        [Required(ErrorMessage = "لطفا کد ملی خود را وارد کنید")]
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }


        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [Display(Name = "نام کاربری")]
        [MaxLength(150)]
        public string Username { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور را وارد کنید")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        #region temp
        [NotMapped]
        public string ConfirmPassword { get; set; }
        #endregion temp




    }
}
