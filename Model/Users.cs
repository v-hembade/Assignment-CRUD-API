using System.ComponentModel.DataAnnotations;

namespace JwtRoleBase.Model
{
    public class Users
    {

        public string id { get; set; } 
        public string username { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public string Hobbie { get; set; }

    }
}
