namespace WebsiteExampleMain.Models
{
    public class Staff
    {
        int id;
        string title;
        string name;
        string password;
        string dob;

        public Staff()
        {

        }

        public Staff(int id, string title, string name, string password, string dob)
        {
            this.id = id;
            this.title = title;
            this.name = name;
            this.password = password;
            this.dob = dob;
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Dob { get => dob; set => dob = value; }
    }
}
