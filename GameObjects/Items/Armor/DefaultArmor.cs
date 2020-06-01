using Microsoft.Xna.Framework;
using SiegeStorm.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Items
{
    class DefaultArmor : Item
    {
        public DefaultArmor(): base("Cotton Outfit", "Normal clothes, not giving any protection or power.", 0, 0)
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture());
            var x = SiegeStorm.ScreenWidth / 6 - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }
    }
}
