using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.DTO;

namespace UniProject.BLL
{
    public class CategoryBO : BusinessBase<Category>
    {
        public override void CheckConstraint(Category obj)
        {
            if (string.IsNullOrEmpty(obj.Title))
                throw new Exception("لطفا عنوان را وراد کنید");
        }
    }
}
