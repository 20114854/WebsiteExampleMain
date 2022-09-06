using System.ComponentModel.DataAnnotations;

namespace WebsiteExampleMain.Models
{
    public class StudentDetails
    {
        [Key]

        public int StudentID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; } 

        public string Address { get; set; }

        public string City { get; set; }    
    }
}
