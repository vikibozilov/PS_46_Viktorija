using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("User Information:");
            Console.WriteLine($"Name: {_viewModel.Name}");
            Console.WriteLine($"Password: {_viewModel.Password}");
            Console.WriteLine($"Role: {_viewModel.Role}");
            Console.WriteLine($"Faculty Number: {_viewModel.FacultyNumber}");
            Console.WriteLine($"Email: {_viewModel.Email}");
        }

        public string DisplayError()
        {
            throw new Exception("Error occurred");
        }
    }
}
