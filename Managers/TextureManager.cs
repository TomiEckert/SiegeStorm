using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Managers
{
    public class TextureManager
    {
        Dictionary<string, Texture2D> textures;

        public TextureManager()
        {
            textures = new Dictionary<string, Texture2D>();
        }

        public void LoadContent()
        {
            DirectoryInfo dir = new DirectoryInfo("Content/Textures");
            FileInfo[] Files = dir.GetFiles("*.png");
            foreach (FileInfo file in Files) {
                var name = file.Name.Remove(file.Name.Length-file.Extension.Length);
                FileStream fs = new FileStream(file.FullName, FileMode.Open);
                var tex = Texture2D.FromStream(SiegeStorm.Graphics.GraphicsDevice, fs);
                fs.Close();
                if (!textures.ContainsKey(name)) {
                    textures.Add(name, tex);
                }
            }
        }

        public Texture2D GetTexture(string name = "default")
        {
            if (textures.ContainsKey(name))
                return textures[name];
            return textures["default"];
        }
    }
}
