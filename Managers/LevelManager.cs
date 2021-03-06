﻿using SiegeStorm.GameObjects.Characters.Enemies;
using SiegeStorm.GameScreens.Levels;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SiegeStorm.Managers
{
    public class LevelManager
    {
        private Dictionary<string, Level> levels;
        private Dictionary<string, LevelData> levelData;

        private const string FILE = "Content/Levels.txt";

        public LevelManager()
        {
            this.levels = new Dictionary<string, Level>();
            this.levelData = new Dictionary<string, LevelData>();
        }

        public void LoadContent()
        {
            levels = new Dictionary<string, Level>();
            levelData = new Dictionary<string, LevelData>();
            LoadLevels();
        }

        private void LoadLevels()
        {
            var lines = File.ReadAllLines(FILE);
            foreach (var line in lines)
            {
                if (line[0] == '#')
                    continue;

                var attributes = line.Split(':');
                if (attributes.Length < 4)
                    continue;

                Level level;
                LevelData data;
                if (!TryConstructLevel(attributes, out level, out data))
                    continue;

                levelData.Add(data.Name, data);
                levels.Add(data.Name, level);
            }
        }

        private bool TryConstructLevel(string[] attributes, out Level level, out LevelData data)
        {
            var lanes = new Lane[5];
            data = new LevelData();

            for (int i = 0; i < lanes.Length; i++)
            {
                lanes[i] = new Lane();
            }

            level = null;
            // Name:Unlock_Name:EnemiesPerWave:Nxxxxxx:Nxxxxx

            string name = attributes[0];

            string unlock = attributes[1];

            int enemiesPerWave;
            if (!int.TryParse(attributes[2], out enemiesPerWave))
                return false;

            for (int i = 4; i < attributes.Length; i++)
            {
                int laneID;
                if (!int.TryParse(attributes[i][0].ToString(), out laneID))
                    continue;

                var enemyQueue = attributes[i].Remove(0, 1);
                List<Enemy> enemies = new List<Enemy>();
                foreach (var e in enemyQueue)
                {
                    if (e == 'x')
                    {
                        enemies.Add(new Enemy());
                    }
                    else if (e == ' ')
                    {
                        enemies.Add(null);
                    }
                    else
                    {
                        continue;
                    }
                }
                lanes[laneID].SetEnemies(enemies);
            }

            data = new LevelData(name, unlock);
            level = new Level(lanes, enemiesPerWave);
            level.LoadContent();
            if (data.Name == "First battle")
                data.Unlock();
            return true;
        }

        public List<Level> GetLevels()
        {
            List<Level> levels = new List<Level>();
            foreach (KeyValuePair<string, Level> level in this.levels)
            {
                levels?.Add(level.Value);
            }
            return levels;
        }

        public Level GetLevel(string name)
        {
            if (levels.ContainsKey(name))
                return levels[name];
            return null;
        }

        public bool IsLevelUnlocked(string name)
        {
            if (levelData.ContainsKey(name))
                return levelData[name].Unlocked;
            return false;
        }

        public string GetUnlockName(string name)
        {
            if (levelData.ContainsKey(name))
                return levelData[name].UnlockName;
            return null;
        }

        public void Unlock(string name)
        {
            if (levelData.ContainsKey(name))
            {
                levelData[name].Unlock();
            }
        }

        /// <summary>
        /// Returns the name of the level passed as parameter.
        /// IMPORTANT: Might return the wrong key. TRY NOT TO USE THIS.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public string GetLevelName(Level level)
        {
            if (levels.ContainsValue(level))
            {
                return levels.FirstOrDefault(x => x.Value == level).Key;
            }
            return null;
        }

        private class LevelData
        {
            public string Name;
            public string UnlockName;
            public bool Unlocked;

            public void Unlock()
            {
                Unlocked = true;
            }

            public void Lock()
            {
                Unlocked = false;
            }

            public LevelData()
            {
            }

            public LevelData(string name, string unlockName)
            {
                Name = name;
                UnlockName = unlockName;
            }
        }
    }
}