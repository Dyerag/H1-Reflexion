using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecFagTilmeldingAppDag2Opgave
{
    internal class SoundShenanigans
    {
        public static void AudioAntics()
        {
            Random rnd = new Random();

            Console.Write("choosing random soundclip");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Thread.Sleep(500);

            int soundclip = rnd.Next(1, 10);
            string myCurrentDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory());
            string appDir = "";

            if (soundclip == 0) { appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\EEnE Yodel Goofy.wav"); }
            else if (soundclip == 1) { appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\EEnE VOX EDDY - ahem HELP ME.wav"); }
            else if (soundclip == 2) { appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\EEnE VOX EDDY - And You Kiss Your Mother.wav"); }
            else if (soundclip == 3) { appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\EEnE VOX KEVIN AND ROLF banter.wav"); }
            else if (soundclip == 4) { appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\EEnE VOX ROLF - Born To Be Wild.wav"); }
            else if (soundclip == 5) { appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\EEnE VOX ROLF - Do Not Fool Rolf.wav"); }
            else if (soundclip == 6) { appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\EEnE VOX ROLF - EEHAAAAUGH.wav"); }
            else if (soundclip == 7) { appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\EEnE VOX ROLF Many Doors Ed Boy.wav"); }
            else if (soundclip == 8) { appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\EEnE Yodel Goofy.wav"); }
            else if (soundclip == 9) { appDir = System.IO.Path.Combine(myCurrentDir, @"Audio\im-going-to-kill-you-and-then-kill-you-again-By-Tuna.wav"); }

            System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();
            soundPlayer.SoundLocation = appDir;
            soundPlayer.Play();

            Console.ReadKey();
        }

    }
}
