using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SiegeStorm.GameObjects.InventoryAndShop
{
    class ItemButton : GameButton
    {

        private string name;
        private string desc;
        private int price;
        private int stat;

        public ItemButton(string name, string desc, int price, int stat)
        {
            this.name = name;
            this.desc = desc;
            this.price = price;
            this.stat = stat;
        }

        public override void Pressed()
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime)
        {
            SiegeStorm.SpriteBatch.DrawString(SiegeStorm.StringManager.GetFont(), name, new Vector2(50, 50), Color.White);
            base.Draw(gameTime);
        }
    }
}
