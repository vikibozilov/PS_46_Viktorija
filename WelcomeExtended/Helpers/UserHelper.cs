using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string ToString(this User user)
        {
            return $"Name: {user.Name}, Role: {user.Role}";
        }
        public static string ValidateCredentials(this UserData userData, string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "The name cannot be empty.";
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                return "The password cannot be empty.";
            }
            return "";
        }
        public static User GetUser(this UserData userData, string name, string password)
        {
            return null;
        }
    }
}
