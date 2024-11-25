using System.Xml.Linq;

namespace sychnosti;
public class Program
{
    public static void Main(string[] args)
    {
        using (MyContext app = new MyContext())
        {
            User Tom = new User { Name = "Tom", Password = "123Q", Email = "Tom@mail.ru", Adress = "str.Link" };
            User Pop = new User { Name = "Pop", Password = "235g", Email = "Pop@mail.ru", Adress = "str.Marya" };
            app.Users.Add(Tom);
            app.Users.Add(Pop);
            app.SaveChanges();

            var users = app.Users.ToList();

            foreach (var item in users)
            {
                Console.WriteLine($"{item.Name}. {item.Email}. {item.Adress} - {item.Password}");
            }

        }
    }
}