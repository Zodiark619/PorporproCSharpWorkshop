
static int SimpleArraySum(List<int> arr){
int total=0;
foreach(var i in arr){
    total+=i;
}
return total;
}


List<int> meong=new(){1,2,3,4,10,11};
Console.Write("Input: ");
foreach(var i in meong){
Console.Write(i+" ");

}
Console.WriteLine();
Console.WriteLine($"Output: {SimpleArraySum(meong)}");