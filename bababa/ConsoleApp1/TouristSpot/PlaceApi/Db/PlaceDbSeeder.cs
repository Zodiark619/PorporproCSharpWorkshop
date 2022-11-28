using Microsoft.EntityFrameworkCore;
using PlaceApi.Db.Models;

namespace PlaceApi.Db
{
    public class PlaceDbSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new PlaceDbContext(serviceProvider.GetRequiredService<DbContextOptions<PlaceDbContext>>());
            if (context.Places.Any()) { return; }
            context.Places.AddRange(
                new Place
                {
                    Id = 1,
                    Name = "Coron Island",
                    Location = "Palawan, Philippines",
                    About = "Coron is one of the top destinations for tourists to add to their wish list.",
                    Reviews = 10,
                    ImageDataUrl = GetImage("coron_island.jpg", "image/jpeg"),
                    LastUpdated = DateTime.Now

                },
                new Place
                {
                    Id = 2,
                    Name = "Olsob Cebu",
                    Location = "Cebu, Phillipines",
                    About = "Whale shark watching is the most popular tourist attraction in Cebu.",
                    Reviews = 3,
                    ImageDataUrl = GetImage("oslob_whalesharks.png", "image/png"),
                    LastUpdated = DateTime.Now

                }
                );
            context.SaveChanges();
        }
        private static string GetImage(string fileName,string fileType)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Db/Images", fileName);
            var imageBytes = File.ReadAllBytes(path);
            return $"data:{fileType};base4,{Convert.ToBase64String(imageBytes)}";
        }
    }
}
