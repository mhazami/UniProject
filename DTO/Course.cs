using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UniProject.DTO.Tools.Enums;

namespace UniProject.DTO
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string StartDate { get; set; }

        public decimal Price { get; set; }

        public string ClassTime { get; set; }

        public string Duration { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public CourseStatus Status { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

    }
}
