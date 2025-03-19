using System;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Loggers;

namespace WelcomeExtended
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logFilePath = "log.txt";

            var fileLoggerProvider = new FileLoggerProvider(logFilePath);

            var fileLogger = fileLoggerProvider.CreateLogger("FileLogger");

            var hashLogger = new HashLogger("ConsoleLogger");

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            loggerFactory.AddProvider(fileLoggerProvider);

            var logger = loggerFactory.CreateLogger<Program>();

            try
            {
                UserData userData = new UserData();

                User studentUser = new User("student", "123", UserRolesEnum.STUDENT, "121221748", "student@example.com", 3, DateTime.UtcNow) { };
                userData.AddUser(studentUser);

                User studentUser2 = new User("Student2", "321", UserRolesEnum.STUDENT, "121221756", "student2@example.com", 2, DateTime.UtcNow) { };
                userData.AddUser(studentUser2);

                User teacherUser = new User("Teacher", "1234", UserRolesEnum.PROFESSOR, null, "teacher@example.com", 1, DateTime.UtcNow){};
                userData.AddUser(teacherUser);

                User adminUser = new User("Admin", "12345", UserRolesEnum.ADMIN, null, "admin@example.com", 0, DateTime.UtcNow) { };
                userData.AddUser(adminUser);

                Console.WriteLine("Enter your username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();

                bool isValid = userData.ValidateUser(username, password);

                //bool isValidLambda = userData.ValidateUserLambda(username, password);

                //bool isValidLinq = userData.ValidateUserLinq(username, password);


                //var user = new User("John Smith", "password123", UserRolesEnum.STUDENT, "121221748", "johnsmith@gmail.com");


                //var viewModel = new UserViewModel(user);
                //var view = new UserView(viewModel);
                //view.Display();

                logger.LogInformation("This is an information message.");

                //view.DisplayError();

                var exception = new Exception("An error occurred.");
                logger.LogError(exception, "An error occurred.");
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occurred.");
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }

            Console.ReadKey();
        }
    }
}