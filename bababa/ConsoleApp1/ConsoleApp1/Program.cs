
using System.Data;
using System.Globalization;
using System.Text.Json;
using AutoMapper;
using ConsoleApp1.Data;
using ConsoleApp1.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

IConfiguration config=new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
DataContextDapper dapper=new DataContextDapper(config);



// Computer myComputer=new(){
//     Motherboard="Z690",
//     HasWifi=true,
//     HasLTE=false,
//     ReleaseDate=DateTime.Now,
//     Price=943.87m,
//     VideoCard="RTX 2060"
// };

// string sql=@"insert into tutorialappschema.computer (
//     Motherboard,
//     HasWifi,
//     HasLTE,
//     ReleaseDate,
//     Price,
//     VideoCard
//     ) values(
//         '" +myComputer.Motherboard 
//         + "','"+myComputer.HasWifi
//         + "','"+myComputer.HasLTE
//         + "','"+myComputer.ReleaseDate
//         + "','"+myComputer.Price.ToString("0.00",CultureInfo.InvariantCulture)
//         + "','"+myComputer.VideoCard
//       +  "')";


   //File.WriteAllText("log.txt","\n"+sql+"\n");

// using StreamWriter openFile=new("log.txt",append:true);
// openFile.WriteLine("\n"+sql+"\n");
// openFile.Close();

// string fileText=File.ReadAllText("log.txt");
// Console.WriteLine(fileText);


string computersJson=File.ReadAllText("ComputersSnake.json");
Mapper mapper=new Mapper(new MapperConfiguration((cfg)=>{
    cfg.CreateMap<ComputerSnake,Computer>()
        .ForMember(destination=>destination.ComputerId,
                    options=>options.MapFrom(source=>source.computer_id))
        .ForMember(destination=>destination.CpuCores,
                    options=>options.MapFrom(source=>source.cpu_cores))
        .ForMember(destination=>destination.HasLTE,
                    options=>options.MapFrom(source=>source.has_lte))
        .ForMember(destination=>destination.HasWifi,
                    options=>options.MapFrom(source=>source.has_wifi))
        .ForMember(destination=>destination.Motherboard,
                    options=>options.MapFrom(source=>source.motherboard))
        .ForMember(destination=>destination.VideoCard,
                    options=>options.MapFrom(source=>source.video_card))
        .ForMember(destination=>destination.ReleaseDate,
                    options=>options.MapFrom(source=>source.release_date))
        .ForMember(destination=>destination.Price,
                    options=>options.MapFrom(source=>source.price));
}));

IEnumerable<ComputerSnake>? computersSystem=System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson);
if(computersSystem!=null){
    IEnumerable<Computer> computerResult=mapper.Map<IEnumerable<Computer>>(computersSystem);
    System.Console.WriteLine("Automapper count : "+computerResult.Count());
    // foreach(Computer computer in computerResult){
    //     System.Console.WriteLine(computer.Motherboard);
    // }
}

IEnumerable<Computer>? computersJsonPropertyMapping=System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);
if(computersJsonPropertyMapping!=null){
    System.Console.WriteLine("JSON property count: "+computersJsonPropertyMapping.Count());
    // foreach(Computer computer in computersSystem){
    //     System.Console.WriteLine(computer.Motherboard);
    // }
}









//Console.WriteLine(computersJson);

// JsonSerializerOptions options=new JsonSerializerOptions(){
//     PropertyNamingPolicy=JsonNamingPolicy.CamelCase
// };
// IEnumerable<Computer>? computersNewtonsoft=JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);
// IEnumerable<Computer>? computersSystem=System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);
// if(computersNewtonsoft!=null){
//     foreach(Computer computer in computersNewtonsoft){
//        string sql=@"insert into tutorialappschema.computer (
//     Motherboard,
//     HasWifi,
//     HasLTE,
//     ReleaseDate,
//     Price,
//     VideoCard
//     ) values(
//         '" +EscapeSingleQuote(computer.Motherboard )
//         + "','"+computer.HasWifi
//         + "','"+computer.HasLTE
//         + "','"+computer.ReleaseDate
//         + "','"+computer.Price.ToString("0.00",CultureInfo.InvariantCulture)
//         + "','"+EscapeSingleQuote(computer.VideoCard)
//       +  "')";
//       dapper.ExecuteSql(sql);
//     }
// }

// JsonSerializerSettings settings=new JsonSerializerSettings(){
// ContractResolver=new CamelCasePropertyNamesContractResolver()
// };
// string computersCopyNewtonsoft=JsonConvert.SerializeObject(computersNewtonsoft,settings);
// File.WriteAllText("computersCopyNewtonsoft.json",computersCopyNewtonsoft);
// string computersCopySystem=System.Text.Json.JsonSerializer.Serialize(computersSystem,options);
// File.WriteAllText("computersCopySystem.json",computersCopySystem);

// static string EscapeSingleQuote(string input){
// string output=input.Replace("'","''");
// return output;
// }