using DataLayers.Database;
using DataLayers.Model;

using (var context = new DatabaseContext())
{
    context.Database.EnsureCreated();
    context.Add<DatabaseUser>(new DatabaseUser("user", "password",  Welcome.Others.UserRolesEnum.STUDENT, "1234", "user@mail", 1, DateTime.Now)
    {   
    });
    context.SaveChanges();
    var users = context.Users.ToList();
    Console.ReadKey();
}