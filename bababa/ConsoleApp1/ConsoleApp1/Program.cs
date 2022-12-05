
using System.Data;
using System.Globalization;
using ConsoleApp1.Data;
using ConsoleApp1.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

IConfiguration config=new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

DataContextDapper dapper=new DataContextDapper(config);
DataContextEF entityFramework=new DataContextEF(config);
DateTime rightNow=dapper.LoadDataSingle<DateTime>("select getdate()");
Computer myComputer=new(){
    Motherboard="Z690",
    HasWifi=true,
    HasLTE=false,
    ReleaseDate=DateTime.Now,
    Price=943.87m,
    VideoCard="RTX 2060"
};
entityFramework.Add(myComputer);
entityFramework.SaveChanges();
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
      computer.ComputerId,
       computer.Motherboard,
    computer.HasWifi,
    computer.HasLTE,
    computer.ReleaseDate,
    computer.Price,
    computer.VideoCard
     from tutorialappschema.computer";
IEnumerable<Computer> computers=dapper.LoadData<Computer>(sqlSelect);
      System.Console.WriteLine("'ComputerId','Motherboard','HasWifi','HasLTE','ReleaseDate','Price','VideoCard'");

foreach(Computer singleComputer in computers){
    System.Console.WriteLine("'"  +singleComputer.ComputerId
        + "','"+singleComputer.Motherboard 
        + "','"+singleComputer.HasWifi
        + "','"+singleComputer.HasLTE
        + "','"+singleComputer.ReleaseDate
        + "','"+singleComputer.Price
        + "','"+singleComputer.VideoCard
      +  "'");
}




IEnumerable<Computer>? computersEF=entityFramework.Computer?.ToList<Computer>();
if(computersEF!=null){

System.Console.WriteLine();

foreach(Computer juju in computersEF){
    System.Console.WriteLine("'" +juju.ComputerId
         + "','"+juju.Motherboard 
        + "','"+juju.HasWifi
        + "','"+juju.HasLTE
        + "','"+juju.ReleaseDate
        + "','"+juju.Price
        + "','"+juju.VideoCard
      +  "'");
}}