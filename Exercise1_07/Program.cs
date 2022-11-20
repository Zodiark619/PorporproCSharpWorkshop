
var aGolden=new GoldenRetriever(){Name="Aspen"};
var anotherGolden=new GoldenRetriever(){Name="Aspen"};

var aBorder=new BorderCollie(){Name="Aspen"};
var anotherBorder=new BorderCollie(){Name="Aspen"};

var aBernese=new Bernese(){Name="Aspen"};
var anotherBernese=new Bernese(){Name="Aspen"};

var goldenComparison=aGolden.Equals(anotherGolden)?"These golder retrieves have a same name."
:"These goldens have different names";
var borderComparison=aBorder.Equals(anotherBorder)?"These border retrieves have a same name."
:"These border have different names";
var berneseComparison=aBernese.Equals(anotherBernese)?"These Bernes have a same name."
:"These bernes have different names";
Console.WriteLine(goldenComparison);
Console.WriteLine(borderComparison);
Console.WriteLine(berneseComparison);



struct GoldenRetriever{
    public string Name{get;set;}
}
class BorderCollie{
    public string Name{get;set;}
}
class Bernese{
    public string Name{get;set;}

    public override bool Equals(object obj){
        if(obj is Bernese borderCollie&&obj!=null){
            return this.Name==borderCollie.Name;
        }
        return false;
    }
}
