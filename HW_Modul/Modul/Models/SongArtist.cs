using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul.Models
{
    public class SongArtist
    {
        public int ArtistId { get; set; }
        public int SongId { get; set; }
        public virtual Artist Artist { get; set; } 
        public virtual Song Song { get; set; }
    }
}
