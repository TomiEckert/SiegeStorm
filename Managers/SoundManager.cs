using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Managers
{
    public class SoundManager
    {
        private Dictionary<string, Song> songs;

        public SoundManager()
        {
            songs = new Dictionary<string, Song>();
        }

        public void LoadContent()
        {
            DirectoryInfo dir = new DirectoryInfo("Content/Sounds/Songs");
            FileInfo[] Files = dir.GetFiles("*.mp3");
            foreach (FileInfo file in Files)
            {
                var name = file.Name.Remove(file.Name.Length - file.Extension.Length);
                var sound = Song.FromUri(name, new Uri(file.FullName));
                if (!songs.ContainsKey(name))
                {
                    songs.Add(name, sound);
                }
            }
        }

        public int GenerateInt()
        {
            Random r = new Random();
            int number = r.Next(0,1000);
            return number;
        }

        public Song GetSong(string name)
        {
            if (songs.ContainsKey(name))
                return songs[name];
            return null;
        }

        public void PlaySong(string name)
        {
            MediaPlayer.Play(GetSong(name));
            MediaPlayer.IsRepeating = true;
        }

        public void StopSong()
        {
            MediaPlayer.Stop();
        }
    }
}
