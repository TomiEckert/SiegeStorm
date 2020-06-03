using Microsoft.Xna.Framework;
using SiegeStorm.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Items
{
    public class Weapon : Item
    {

        public Weapon(string name, string description, int statValue, int price, bool isArmor) : base(name, description, statValue, price, isArmor)
        {
            //get and set texture
            SetTexture(SiegeStorm.TextureManager.GetTexture());
            //set position
            var x = SiegeStorm.ScreenWidth / 6 - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }
    }
}
