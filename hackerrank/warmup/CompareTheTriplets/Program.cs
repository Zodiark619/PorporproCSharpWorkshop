
static List<int> CompareTriplets(List<int> a,List<int> b){



int alice=0;
int bob=0;
for(int i=0;i<a.Count;i++){
    if(a[i]<b[i]){
        bob++;
    }else if(a[i]>b[i]){
        alice++;
    }
}
List<int> meong=new(){alice,bob};
return meong;



}

List<int> a=new(){17,28,30};
List<int> b=new(){99,16,8};
Console.WriteLine("Input 1: ");
foreach(var i in a){
    Console.Write(i);
    Console.Write(" ");
}
Console.WriteLine();
Console.WriteLine("Input 2: ");
foreach(var i in b){
    Console.Write(i);
    Console.Write(" ");
}
Console.WriteLine();

Console.WriteLine($"Alice: {CompareTriplets(a,b)[0]} - Bob: {CompareTriplets(a,b)[1]}");