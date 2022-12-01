
using System.Data;
using System.Globalization;
using ConsoleApp1.Data;
using ConsoleApp1.Models;
using Dapper;
using Microsoft.Data.SqlClient;

DataContextDapper dapper=new DataContextDapper();
DateTime rightNow=dapper.LoadDataSingle<DateTime>("select getdate()");
Computer myComputer=new(){
    Motherboard="Z690",
    HasWifi=true,
    HasLTE=false,
    ReleaseDate=DateTime.Now,
    Price=943.87m,
    VideoCard="RTX 2060"
};
string sql=@"insert into tutorialappschema.computer (
    Motherboard,
    HasWifi,
    HasLTE,
    ReleaseDate,
    Price,
    VideoCard
    ) values(
        '" +myComputer.Motherboard 
        + "','"+myComputer.HasWifi
        + "','"+myComputer.HasLTE
        + "','"+myComputer.ReleaseDate
        + "','"+myComputer.Price.ToString("0.00",CultureInfo.InvariantCulture)
        + "','"+myComputer.VideoCard
      +  "')";
      System.Console.WriteLine(sql);
      bool result=dapper.ExecuteSql(sql);
      System.Console.WriteLine( result);

      string sqlSelect=@"select
       computer.Motherboard,
    computer.HasWifi,
    computer.HasLTE,
    computer.ReleaseDate,
    computer.Price,
    computer.VideoCard
     from tutorialappschema.computer";
IEnumerable<Computer> computers=dapper.LoadData<Computer>(sqlSelect);
      System.Console.WriteLine("'Motherboard','HasWifi','HasLTE','ReleaseDate','Price','VideoCard'");

foreach(Computer singleComputer in computers){
    System.Console.WriteLine("'" +singleComputer.Motherboard 
        + "','"+singleComputer.HasWifi
        + "','"+singleComputer.HasLTE
        + "','"+singleComputer.ReleaseDate
        + "','"+singleComputer.Price
        + "','"+singleComputer.VideoCard
      +  "'");
}

