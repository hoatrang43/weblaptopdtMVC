using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTopOBJ
{
    public class Users
    {
        public string MaNV { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Users() { }
        public Users(string manv, string pass, string role)
        {
            this.MaNV = manv;
            this.Password = pass;
            this.Role = role;
        }
    }
}