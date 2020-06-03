using Microsoft.Xna.Framework;
using SiegeStorm.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Characters.Enemies
{
    public class Enemy: Character
    {
        public Enemy(): base("Enemy Lvl 1")
        {
            //TODO set texture
            SetTexture(SiegeStorm.TextureManager.GetTexture());
            //TODO set position
            var x = SiegeStorm.ScreenWidth / 6 - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }
        //TODO movement
        //TODO attack
    }
}
