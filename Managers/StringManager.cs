using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Managers
{
    public class StringManager
    {
        Dictionary<string, string> strings;
        Dictionary<string, SpriteFont> fonts;

        public void LoadContent()
        {
            strings = new Dictionary<string, string>();
            fonts = new Dictionary<string, SpriteFont>();
            var font = SiegeStorm.ContentManager.Load<SpriteFont>("BasicFont");
            fonts.Add("Default", font);

            var lines = File.ReadAllLines("Content/Strings.txt");
            foreach (var line in lines) {

                if (line.Length < 4)
                    continue;

                var key = line.Split(':')[0];
                var value = line.Remove(0, key.Length + 1);

                if (strings.ContainsKey(key))
                    continue; // TODO log error

                strings.Add(key, value);
            }
        }

        public SpriteFont GetFont(string name = "Default")
        {
            if (fonts.ContainsKey(name))
                return fonts[name];
            return null; // TODO log error
        }

        public string GetString(string name)
        {
            if (name == null)
                return null; // TODO log error

            if (strings.ContainsKey(name))
                return strings[name];
            return null; // TODO log error
        }
    }
}
