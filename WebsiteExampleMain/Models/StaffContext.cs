using System.Collections.Generic;

namespace WebsiteExampleMain.Models
{
    public class StaffContext
    {
        public static List<Staff> Staffobject = new List<Staff>();

        public StaffContext()
        {
            if(Staffobject.Count == 0)
            {
                Staffobject.Add(new Staff(1, "Josh", "Baby staff member", "1234", "2009"));
                Staffobject.Add(new Staff(2, "Jessica", "staff member", "4321", "2000"));
                Staffobject.Add(new Staff(3, "Jebidiya", "dead staff member", "3456", "1879"));
            }

        } 
    }
}
