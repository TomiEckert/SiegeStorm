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

        public Weapon(string name, string description, int statValue, int price) : base(name, description, statValue, price)
        {
            //get and set texture
            SetTexture(SiegeStorm.TextureManager.GetTexture(this));
            //set position
            var x = SiegeStorm.ScreenWidth / 6 - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public Weapon(string[] attributes) : this(attributes[0], attributes[1], int.Parse(attributes[2]), int.Parse(attributes[3]))
        {

        }
    }
}
