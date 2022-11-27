namespace Activity02_1{

public static class Solution{
    public static void Main(){
        Circle circle1=new Circle(3);
        Circle circle2=new Circle(3);
Circle circle3=circle1+circle2;
        Console.WriteLine($"Adding circles of radius of {circle1.Radius} and {circle2.Radius} results in a new circle with a new radius {circle3.Radius}");

    }
}
}