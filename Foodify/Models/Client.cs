using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Models
{
    public class Client
    {
        public int ID { get; }
        public string Username { get; }


        public Client(int iD, string username)
        {
            ID = iD;
            Username = username;
        }

        
    }
}
