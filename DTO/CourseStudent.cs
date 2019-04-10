using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniProject.DTO
{
    public class CourseStudent
    {
        [Key, Column(Order = 0)]
        public virtual int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Key, Column(Order = 1)]
        public virtual int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
