using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private string _name;
        private string _password;
        private UserRolesEnum _role;
        private string _fnum;
        private string _email;
        private int _id;
        private DateTime _expires;

        public string Name 
        { 
            get { return _name; } 
            set {  _name = value; } 
        }
        public string Password 
        { 
            get { return _password; } 
            set { _password = EncryptPassword(value); } 
        }
        
        public UserRolesEnum Role 
        { 
            get { return _role; } 
            set { _role = value; } 
        }
        public string FacultyNumber 
        { 
            get { return _fnum; } 
            set { _fnum = value; } 
        }
        public string Email 
        { 
            get { return _email; } 
            set { _email = value; } 
        }
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
        public User(string name, string password, UserRolesEnum role, string fnum, string email, int id, DateTime expires) 
        { 
            Name = name;
            Password = password;
            Role = role;
            FacultyNumber = fnum;
            Email = email;
            Id = id;
            Expires = expires;
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}