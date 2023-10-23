namespace Spotifu
{
    internal class Program
    {
        //the 
        public static List<Artist> Artists = ArtistList();
        public static List<Song> Songs = SongList();
        public static List<Album> Albums = AlbumList();
        static void Main(string[] args)
        {
            //todo create a method that saves the artists, songs and albums in a json. make it one universal method using generics
            Console.CursorVisible = false;
            GUI.ProgramName();
            GUI.Print(50, 9, "[1] Songs");
            GUI.Print(50, 11, "[2] Artists");
            GUI.Print(50, 13, "[3] Albums");

        }

        private static List<Album> AlbumList()
        {
            List<Album> list = new List<Album>();
            list.AddRange(CreateLists.CreateAlbum());
            return list;
        }

        private static List<Song> SongList()
        {
            List<Song> list = new List<Song>();
            list.AddRange(CreateLists.CreateSong());
            return list;
        }

        private static List<Artist> ArtistList()
        {
            //todo make the program check for a file containing artists, and fetch it if found. Does the file not exist, create it
            List<Artist> list = new List<Artist>();
            list.AddRange(CreateLists.CreateArtist());

            return list;
        }
    }
}