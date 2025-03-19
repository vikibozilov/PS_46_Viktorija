using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    class Program
    {
        public static object Log {  get; private set; }
        static void Main(string[] args)
        {
            User user1 = new User("Test User", "123", UserRolesEnum.ANONYMOUS, "123456", "test@example.com", 1, DateTime.Now);

            UserViewModel viewModel1 = new UserViewModel(user1);

            UserView view1 = new UserView(viewModel1);

            view1.Display();

            Console.ReadKey();
        }
    }
}
