

 static int SolveMeFirst(int a,int b){
    return a+b;
}
Console.Write("Input 1: ");
int a=int.Parse(Console.ReadLine());
Console.Write("Input 2: ");

int b=int.Parse(Console.ReadLine());


Console.WriteLine($"{a} + {b} = {SolveMeFirst(a,b)}");