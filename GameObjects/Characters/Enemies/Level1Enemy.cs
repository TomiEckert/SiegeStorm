using Microsoft.Xna.Framework;
using SiegeStorm.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Characters.Enemies
{
    class Level1Enemy: Character
    {
        public Level1Enemy(): base("Enemy Lvl 1")
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture());
            var x = SiegeStorm.ScreenWidth / 6 - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }
    }
}
