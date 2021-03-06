﻿using Microsoft.Xna.Framework;

namespace SiegeStorm.GameObjects.InventoryAndShop
{
    internal class ButtonEquip : GameButton
    {
        public ButtonEquip()
        {
            SetTexture(SiegeStorm.TextureManager.GetTexture(this, "EquipButton"));
            var x = SiegeStorm.ScreenWidth / 2 - Texture.Width / 2;
            var y = SiegeStorm.ScreenHeight / 10 * 7 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
        }
    }
}