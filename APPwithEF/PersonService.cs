namespace APPwithEF;

internal class PersonService
{
    public void AddPerson(string name, int age)
    {
        using (AppContext context = new AppContext())
        {
            context.Persons.Add(new Person(name, age));
            context.SaveChanges();
        }
    }

    public void RemovePerson(Guid id)
    {
        using (AppContext context = new AppContext())
        {
            var person = context.Persons.FirstOrDefault(x => x.Id == id);
            if (person != null)
            {

                context.Persons.Remove(person);
                context.SaveChanges();
            }
        }
    }
    public void UpdatePerson(string name, int age, Guid id)
    {
        using (AppContext context = new AppContext())
        {
            var person = context.Persons.FirstOrDefault(x => x.Id == id);
            person.Name = name;
            person.Age = age;
            context.Persons.Update(person);
            context.SaveChanges();
        }
    }
    public Person SearchPerson(Guid id)
    {
        using (AppContext context = new AppContext())
        {
            var person = context.Persons.FirstOrDefault(x => x.Id == id);
           
            return person;            
        }

    }
}
