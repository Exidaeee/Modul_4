using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul.Models
{
    public class Artist
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? InstagramUrl { get; set; } 
        public virtual ICollection<Song> Songs { get; set;}
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
