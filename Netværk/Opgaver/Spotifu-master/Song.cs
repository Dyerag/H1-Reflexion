using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifu
{
    internal class Song
    {
        public string Name { get; set; }
        public List<Artist> Artists { get; set; }
        public Song(string name,Artist artist)
        {
            Name = name;
            Artists.Add(artist);
        }
    }
}
