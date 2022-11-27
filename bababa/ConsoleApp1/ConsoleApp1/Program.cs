Cat sss1 = new() { Name = "ANSajskdn", Race = "White", Age = 21 };
Cat sss2 = new() { Name = "cbgfbfg", Race = "Black", Age = 2 };
Cat sss3 = new() { Name = "4354353", Race = "Black", Age = 17 };
Cat sss4 = new() { Name = "kk", Race = "White", Age = 5 };

List<Cat> kucing = new()
{
    sss1,sss2,sss3,sss4
};
Meongzz("Kitten",kucing,Kitten);
Console.WriteLine();
Meongzz("Adult", kucing, Adult);
Console.WriteLine();
Meongzz("White", kucing, White);
static bool Kitten(Cat cat)
{
    return cat.Age < 10;
}
static bool Adult(Cat cat)
{
    return cat.Age > 10;
}
static bool White(Cat cat)
{
    return cat.Race == "White";
}
static void Meongzz(string title, List<Cat> cats, Kucingzz kucingzz)
{
    Console.WriteLine(title);
    foreach(var cat in cats)
    {
        if (kucingzz(cat))
        {
            Console.WriteLine(cat.Name+" "+cat.Race+" "+cat.Age);

        }
    }

   


}
public class Cat
{
    public string Name { get; set; }
    public string Race { get; set;}
    public int Age { get; set; }
}

public delegate bool Kucingzz(Cat cat);

