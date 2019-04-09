using System.Web;
using UniProject.DTO;

namespace UniProject.AppCode
{
    internal class SessionParameters
    {
        public static User User
        {
            get
            {
                if (HttpContext.Current.Session["User"] != null)
                    return (User)HttpContext.Current.Session["User"];
                return null;
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }

        public static Student Student
        {
            get
            {
                if (HttpContext.Current.Session["Student"] != null)
                    return (Student)HttpContext.Current.Session["Student"];
                return null;
            }
            set
            {
                HttpContext.Current.Session["Student"] = value;
            }
        }



    }
}