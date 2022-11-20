
int numberToBeGuessed=new Random().Next(0,10);
int remainingChances=5;

bool numberFound=false;

while(remainingChances>0){
    Console.WriteLine($"Number of chances left: {remainingChances}");
    Console.Write("Input guess: ");
    int number=int.Parse(Console.ReadLine());
    if(number==numberToBeGuessed){

        numberFound=true;
        break;
    }else{
        remainingChances--;
        Console.WriteLine("");
    }
}
if(numberFound){
        Console.WriteLine($"Congrats! You've guessed the number with {remainingChances} chances left!");

}else{
    Console.WriteLine($"You're out of chances. The number was {numberToBeGuessed}");
}