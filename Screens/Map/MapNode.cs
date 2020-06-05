﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SiegeStorm.GameScreens.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Map
{
    class MapNode : GameButton
    {
        Level level;
        public MapNode(Level level, int posX, int posY) : base()
        {
            this.level = level;
            //TODO set texture
            SetTexture(SiegeStorm.TextureManager.GetTexture(this));
            //Set position
            var x = (int)(SiegeStorm.ScreenWidth*.1 - Texture.Width);
            var y = (int)(SiegeStorm.ScreenHeight*.1 - Texture.Height);
            SetPosition(new Vector2(x, y));
            level = SiegeStorm.LevelManager.GetLevel("First battle");
        }

        public override void Pressed()
        {
            var levelName = SiegeStorm.LevelManager.GetLevelName(this.level);
            if (SiegeStorm.LevelManager.IsLevelUnlocked(levelName)){
                level.Run();
            }
        }
    }
}
