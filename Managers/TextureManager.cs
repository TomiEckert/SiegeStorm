using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace SiegeStorm.Managers
{
    public class TextureManager
    {
        private Dictionary<string, FileInfo> textures;
        private Dictionary<GameObject, string> objects;
        private Dictionary<string, Texture2D> memory;

        public TextureManager()
        {
            textures = new Dictionary<string, FileInfo>();
            objects = new Dictionary<GameObject, string>();
            memory = new Dictionary<string, Texture2D>();
        }

        public void LoadContent()
        {
            DirectoryInfo dir = new DirectoryInfo("Content/Textures");
            FileInfo[] Files = dir.GetFiles("*.png");
            foreach (FileInfo file in Files)
            {
                var name = file.Name.Remove(file.Name.Length - file.Extension.Length);
                textures.Add(name, file);
            }
        }

        public Texture2D GetTexture(GameObject obj, string name = "default")
        {
            if (!textures.ContainsKey(name))
                return GetTexture(obj, "default");

            Texture2D tex;
            if (TryLoadFromMem(name, out tex))
            {
                AddToObjects(obj, name);
                return tex;
            }

            tex = ReadTexFromFile(textures[name]);
            AddToMemory(name, tex);
            AddToObjects(obj, name);
            return tex;
        }

        public void Dispose(GameObject obj)
        {
            RemoveFromObjects(obj);
            RefreshMemory();
        }

        private bool TryLoadFromMem(string name, out Texture2D tex)
        {
            tex = null;
            if (memory.ContainsKey(name))
            {
                tex = memory[name];
                return true;
            }
            return false;
        }

        private void RefreshMemory()
        {
            List<string> remove = new List<string>();
            foreach (var key in memory.Keys)
            {
                foreach (var o in objects.Values)
                {
                    if (o == key)
                    {
                        continue;
                    }
                }
                remove.Add(key);
            }

            RemoveFromMemory(remove);
        }

        private Texture2D ReadTexFromFile(FileInfo file)
        {
            FileStream fs = new FileStream(file.FullName, FileMode.Open);
            var tex = Texture2D.FromStream(SiegeStorm.Graphics.GraphicsDevice, fs);
            fs.Close();
            return tex;
        }

        private void AddToObjects(GameObject obj, string name)
        {
            if (objects.ContainsKey(obj))
                objects[obj] = name;
            else
                objects.Add(obj, name);
        }

        private void RemoveFromObjects(GameObject obj)
        {
            if (objects.ContainsKey(obj))
                objects.Remove(obj);
        }

        private void AddToMemory(string name, Texture2D tex)
        {
            if (memory.ContainsKey(name))
                return;
            memory.Add(name, tex);
        }

        private void RemoveFromMemory(string name)
        {
            if (memory.ContainsKey(name))
                memory.Remove(name);
        }

        private void RemoveFromMemory(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                RemoveFromMemory(name);
            }
        }
    }
}