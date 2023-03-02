using Microsoft.EntityFrameworkCore;
using Modul.Models;
using System.ComponentModel.DataAnnotations;

namespace Modul
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=Modul4;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            var options = optionsBuilder.UseSqlServer(connStr).Options;
            using (var contex = new DatabaseContext(options)) 
            {
                var result1 = from s in contex.Songs
                             join sa in contex.SongsArtists on s.Id equals sa.SongId
                             join a in contex.Artists on sa.ArtistId equals a.Id
                             where s.Genre != null && contex.Artists.Any(x => x.Id == a.Id)
                             select new
                             {
                                 SongTitle = s.Title,
                                 ArtistName = a.Name,
                                 GenreName = s.Genre.Title
                             };
                var result2 = from s in contex.Songs
                             group s by s.Genre.Title into g
                             select new
                             {
                                 GenreName = g.Key,
                                 SongCount = g.Count()
                             };
                var youngestArtistBirthDate = contex.Artists.Min(a => a.DateOfBirth);
                var result3 = from s in contex.Songs
                             where s.ReleasedDate < youngestArtistBirthDate
                             select s;                
            }           
        }
    }
}