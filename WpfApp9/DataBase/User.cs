using System.ComponentModel.DataAnnotations;

namespace WpfApp9.DataBase
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


        

    }
}