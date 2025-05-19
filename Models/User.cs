using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username {get; set;}
        public string Password { get; set; }
        public User()
        {

        }
        public User( string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
        }

        
    }
   
}
