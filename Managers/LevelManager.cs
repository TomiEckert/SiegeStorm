using Microsoft.Xna.Framework;
using SiegeStorm.GameObjects.Levels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Managers
{
    public class LevelManager
    {
        List<Level> levels;

        string textfile;

        public void LoadContent()
        {
            this.levels = new List<Level>();
            this.textfile = "../Content/Levels.txt";
            constructLevels();
        }

        void constructLevels()
        {
            string[] lines = System.IO.File.ReadAllLines(textfile);
            foreach (var line in lines)
            {
                string[] words = line.Split(':');
                //TODO adjust parameters
                var level = new Level(Boolean.Parse(words[1]), Boolean.Parse(words[1]) /*words[2]*/);
                levels.Add(level);
            }
        }

        void saveLevels()
        {
            File.WriteAllText(this.textfile, String.Empty);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(this.textfile))
            {
                foreach (var level in this.levels)
                {
                    string line = level.ToLine();
                    file.WriteLine(line);
                }
            }
        }
    }
}
