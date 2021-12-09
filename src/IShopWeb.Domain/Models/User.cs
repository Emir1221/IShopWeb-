using System.Collections.Generic;

namespace IShopWeb.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Role> Role { get; set; }
    }
}
