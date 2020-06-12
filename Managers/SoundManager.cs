using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SiegeStorm.Managers
{
    public class SoundManager
    {
        private Dictionary<string, Song> songs;
        private Dictionary<string, SoundEffect> sfx;
        private Dictionary<int, SoundEffectInstance> sfxPlaying;
        private Random random;

        public SoundManager()
        {
            songs = new Dictionary<string, Song>();
            sfx = new Dictionary<string, SoundEffect>();
            sfxPlaying = new Dictionary<int, SoundEffectInstance>();
            random = new Random();
        }

        public void LoadContent()
        {
            // Loading songs for the game
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

            dir = new DirectoryInfo("Content/Sounds/SoundEffects");
            Files = dir.GetFiles("*.wav");
            foreach (FileInfo file in Files)
            {
                var name = file.Name.Remove(file.Name.Length - file.Extension.Length);
                FileStream fs = new FileStream(file.FullName, FileMode.Open);
                var sound = SoundEffect.FromStream(fs);
                fs.Close();
                if (!sfx.ContainsKey(name))
                {
                    sfx.Add(name, sound);
                }
            }
        }

        private int GenerateID()
        {
            int id = 0;
            do
            {
                id = random.Next(1000, 9999);
            } while (sfxPlaying.ContainsKey(id));

            return id;
        }

        public Song GetSong(string name)
        {
            if (songs.ContainsKey(name))
                return songs[name];
            return null;
        }

        public SoundEffect GetSFX(string name)
        {
            if (sfx.ContainsKey(name))
                return sfx[name];
            return null;
        }

        public void PlaySong(string name)
        {
            MediaPlayer.Play(GetSong(name));
            MediaPlayer.IsRepeating = true;
        }

        public int PlaySFX(string name)
        {
            var sound = GetSFX(name);
            var id = GenerateID();
            if (sound != null)
            {
                var i = sound.CreateInstance();
                sfxPlaying.Add(id, i);
                i.IsLooped = false;
                i.Play();
                return id;
            }
            return -1;
        }

        public void StopSFX(int id)
        {
            if (sfxPlaying.ContainsKey(id))
            {
                sfxPlaying[id].Stop();
                sfxPlaying.Remove(id);
            }
        }

        public void StopSong()
        {
            MediaPlayer.Stop();
        }

        public void Update(GameTime gameTime)
        {
            var tmp = sfxPlaying.ToArray();
            foreach (var fx in tmp)
            {
                if (fx.Value.State == SoundState.Stopped)
                {
                    if (sfxPlaying.ContainsKey(fx.Key))
                        sfxPlaying.Remove(fx.Key);
                }
            }
        }
    }
}