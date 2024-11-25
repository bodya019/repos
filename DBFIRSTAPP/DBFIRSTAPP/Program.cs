namespace DBFIRSTAPP;
public class Program
{
    static void Main(string[] args)
    {
        //MyDataBaseContext DB = new MyDataBaseContext();
        //var users = DB.Users.ToList();
        //foreach (var user in users) {
        //   Console.WriteLine( $"{user.Id}.{user.Name} - {user.Age}" );
        //}

        using (AppBaseCOntext DB = new AppBaseCOntext())
        {
            var users = DB.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
            }
        }
    }
}