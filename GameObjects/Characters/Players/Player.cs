using Microsoft.Xna.Framework;
using SiegeStorm.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Characters.Players
{
    class Player: Character
    {
        public Player(string name): base(name)
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture());
            var x = SiegeStorm.ScreenWidth / 6 - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }
        public void EquipItem(Item item)
        {
            item.Equip(this);
        }

        public void UnequipItem(Item item)
        {
            item.Unequip(this);
        }
    }
}
