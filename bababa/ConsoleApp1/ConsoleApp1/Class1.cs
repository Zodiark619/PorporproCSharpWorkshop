/*

Person p1 = new() { Name = "Aiden", Age = 41 };
Person p2 = new() { Name = "Sif", Age = 69 };
Person p3 = new() { Name = "Walter", Age = 12 };
Person p4 = new() { Name = "Anatoli", Age = 25 };

List<Person> meong = new() { p1, p2, p3, p4 };


Disp("Kids", meong, IsMinor);
Disp("Adult", meong, IsAdult);
Disp("Senior", meong, IsSenior);


static void Disp(string title, List<Person> people, bucin bucin)
{
    Console.WriteLine(title);
    foreach (var person in people)
    {
        if (bucin(person))
            Console.WriteLine("{0}, {1} years old.", person.Name, person.Age);
    }
}

static bool IsMinor(Person p)
{
    return p.Age < 18;
}

static bool IsAdult(Person p)
{
    return p.Age <= 65;
}


static bool IsSenior(Person p)
{
    return p.Age > 65;
}


public delegate bool bucin(Person p);
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

}

*/