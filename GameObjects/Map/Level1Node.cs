using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Map
{
    class Level1Node : MapNode
    {
        public Level1Node() : base("level1")
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture());
            var x = SiegeStorm.ScreenWidth/6 - Texture.Width;
            var y = SiegeStorm.ScreenHeight/3 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }
    }
}
