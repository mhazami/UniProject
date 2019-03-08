using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniProject.DTO
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }


        [Required]
        [MaxLength(50)]
        public string Title { get; set; }


        public string Description { get; set; }

        [Required(ErrorMessage = "لطفا عکس اسلاید را وارد کنید")]
        public Guid FileId { get; set; }
        public virtual File File { get; set; }
    }
}
