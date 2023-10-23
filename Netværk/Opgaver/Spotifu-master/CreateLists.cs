using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifu
{
    internal class CreateLists
    {
        public static List<Artist> CreateArtist()
        {
            List<Artist> list = new();

            Artist ed = new("Ed Sheeran"); //0
            list.Add(ed);
            Artist drake = new("Drake");//1
            list.Add(drake);
            Artist Connor = new("Connor Price");//2
            list.Add(Connor);
            Artist marshmello = new("Marshmello");//3
            list.Add(marshmello);

            return list;
        }

        public static List<Song> CreateSong()
        {
            List<Song> list = new();

            Song ed = new("");
            list.Add(ed);
            Song drake = new("Drake");
            list.Add(drake);
            Song Connor = new("Connor Price");
            list.Add(Connor);
            Song marshmello = new("Marshmello");
            list.Add(marshmello);

            return list;
        }

        public static List<Album> CreateAlbum()
        {
            List<Album> list = new();

            return list;

        }
    }
}
