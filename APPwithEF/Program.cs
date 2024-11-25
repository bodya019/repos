namespace APPwithEF;
public class Program
{
    static void Main()
    {
        while (true)
        {
            string name;
            int age;
            Guid guid;
            PersonService personService = new PersonService();
            Console.WriteLine("Выберете действие которые вы хотите выполнить");
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Обновить пользователя");
            Console.WriteLine("3. Найти пользователя");
            Console.WriteLine("4. Удалить пользователя");

            int value = Convert.ToInt32(Console.ReadLine());

            switch (value)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Введите имя");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите возраст");
                    age = Convert.ToInt32(Console.ReadLine());
                    personService.AddPerson(name, age);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Введите ID");
                    guid = new Guid(Console.ReadLine());
                    Console.WriteLine("Введите новое имя");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите новый возраст");
                    age = Convert.ToInt32(Console.ReadLine());
                    personService.UpdatePerson(name, age, guid);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Введите ID");
                    guid = new Guid(Console.ReadLine());
                    Person person = personService.SearchPerson(guid);
                    Console.WriteLine($"ИМЯ :{person.Name}");
                    Console.WriteLine($"Возраст :{person.Age}");
                    Thread.Sleep(1000);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Введите ID которого хотите обновить");
                    guid = new Guid(Console.ReadLine());
                    personService.RemovePerson(guid);
                    break;

            }
            Console.Clear(  );
        }
        
    }
}