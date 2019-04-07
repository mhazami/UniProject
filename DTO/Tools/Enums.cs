using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniProject.DTO.Tools
{
    public class Enums
    {
        public enum CourseStatus : byte
        {
            [Description("درحال ثبت نام")]
            [Display(Name ="درحال ثبت نام")]
            Free=1,
            [Description("ظرفیت تکمیل شده")]
            [Display(Name ="ظرفیت تکمیل شده")]
            Full=2,
            [Description("درحال برگزاری")]
            [Display(Name ="درحال برگزاری")]
            Flow=3,  
            [Description("پایان یافته")]
            [Display(Name = "‍‍پایان یافته‍‍‍‍")]
            Finish=4
        }
        public enum MessageType
        {
            Error,
            Success,
            Warning,
            Primary,
            Defualt,
            Info
        }
    }
}
