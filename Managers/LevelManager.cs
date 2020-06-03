using Microsoft.Xna.Framework;
using SiegeStorm.GameObjects.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.Managers
{
    public class LevelManager
    {
        List<Level> levels;

        public void LoadContent()
        {
            levels = new List<Level>();
            constructLevels();
        }

        void constructLevels()
        {
            string textfile = "../Content/Levels.txt";
            string[] lines = System.IO.File.ReadAllLines(textfile);
            foreach (var line in lines)
            {
                string[] words = line.Split(':');
                //TODO adjust parameters
                var level = new Level(/*words[0], words[1], words[2]*/);
                levels.Add(level);
            }
        }
    }
}
