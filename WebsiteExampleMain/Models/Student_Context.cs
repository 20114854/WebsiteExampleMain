using Microsoft.EntityFrameworkCore;

namespace WebsiteExampleMain.Models
{
    public class Student_Context : DbContext
    {
        public Student_Context(DbContextOptions<Student_Context> options)
            : base(options)
        {

        }

        public DbSet<StudentDetails> StudentDetails { get; set; } 
    }
}
