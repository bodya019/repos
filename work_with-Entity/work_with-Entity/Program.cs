namespace work_with_Entity;
class Program
{
    static void Main (string[] args) {
        using (AppContext app = new AppContext())
        {
            User Tom = new User {Name = "Tom", Age = 23 };
            User Klark = new User { Name = "Klark", Age = 25 };

            app.Users.Add(Tom);
            app.Users.Add(Klark);
            app.SaveChanges();

            var users = app.Users.ToList();

            foreach (var user in users) { 
                Console.WriteLine($"{user.Id}.{user.Name} - {user.Age} ");
            }  
        }
    }
}