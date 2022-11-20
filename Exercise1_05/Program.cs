
using System;

Console.WriteLine("Are the local and utc dates equal? {0}",DateTime.Now.Date==DateTime.UtcNow.Date);

Console.WriteLine("If the dates are equal, does it mean that there's no TimeSpan interval between them? {0}",
(DateTime.Now.Date-DateTime.UtcNow.Date)==TimeSpan.Zero);

DateTime localTime=DateTime.Now;
DateTime utcTime=DateTime.UtcNow;
TimeSpan interval=(localTime-utcTime);

Console.WriteLine("\nDifference between the {0} time and {1} time: {2}:{3} hours",
localTime.Kind.ToString(),utcTime.Kind.ToString(),interval.Hours,interval.Minutes);


Console.WriteLine("\nIf we jump two days to the future on {0} we'll be on {1}",
new DateTime(2022, 11, 18).ToShortDateString(),
new DateTime(2022, 11, 18).AddDays(2).ToShortDateString());


