using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
