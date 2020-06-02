﻿using Microsoft.Xna.Framework;
using SiegeStorm.Abstracts;
using SiegeStorm.GameObjects.Items;
using SiegeStorm.GameObjects.Items.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm.GameObjects.Characters.Players
{
    class Player: Character
    {
        int xp;
        int gold;
        int health;
        int power;
        Item armor;
        Item weapon;

        public Player(string name): base(name)
        {
            this.xp = 0;
            this.gold = 50;
            this.armor = new DefaultArmor();
            this.weapon = new DefaultWeapon();
            this.setHealth();
            this.setPower();

            //TODO set texture
            SetTexture(SiegeStorm.TextureManager.GetTexture());
            //TODO set position
            var x = SiegeStorm.ScreenWidth / 6 - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height;
            SetPosition(new Vector2(x, y));
        }

        //TODO movement
        //TODO attack

        //Setters
        void setHealth() 
        {
            this.health = this.GetBaseHealth() + this.armor.GetStatValue();
        }
        void setPower()
        {
            this.power = this.GetBasePower() + this.weapon.GetStatValue();
        }
        
        //Equipping item, changing corresponding stats (health / power)
        public void EquipItem(Item item)
        {
            if (item.GetIsArmor())
            {
                this.armor = item;
                this.health += item.GetStatValue();
            }
            else
            {
                this.weapon = item;
                this.power += item.GetStatValue();
            }
        }
        //Unequipping item, changing corresponding stats (health / power)
        public void UnequipItem(Item item)
        {
            if (item.GetIsArmor())
            {
                this.armor = new DefaultArmor();
                this.health -= item.GetStatValue();
            }
            else
            {
                this.weapon = new DefaultWeapon();
                this.power -= item.GetStatValue();
            }
        }
        //Increasing xp and leveling up
        public void AddXP(int amount)
        {
            this.xp += amount;
            if(this.xp >= this.getLevel()*100)
            {
                this.xp -= this.getLevel() * 100;
                this.LevelUp();
                this.setHealth();
                this.setPower();
            }
        }

        //Adding gold
        public void AddGold(int amount)
        {
            this.gold += amount;
        }
        //Removing gold
        public void RemoveGold(int amount)
        {
            this.gold -= amount;
        }
    }
}