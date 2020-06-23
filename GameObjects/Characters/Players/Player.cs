using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SiegeStorm.Abstracts;
using SiegeStorm.GameObjects.HUD;
using SiegeStorm.GameObjects.Characters.Enemies;
using SiegeStorm.GameObjects.Items;
using SiegeStorm.Managers;
using System.Linq.Expressions;

namespace SiegeStorm.GameObjects.Characters.Players
{
    public class Player : Character
    {
        private int xp;
        private int gold;
        private int health;
        private int power;
        private Armor armor;
        private Weapon weapon;
        private Inventory inventory;
        private Shop shop;
        private int currentLane;
        private Animation walkRight;
        private Animation walkLeft;
        private Healthbar healthbar;
        private Animation fightRight;
        private Animation fightLeft;

        private Animation die;

        public Player(string name) : base(name)
        {
            this.xp = 0;
            this.gold = 50;
            this.armor = SiegeStorm.ItemManager.GetArmor("Cotton Outfit");
            this.weapon = SiegeStorm.ItemManager.GetWeapon("Wooden Stick");
            this.SetHealth();
            this.SetPower();

            //Position
            var x = SiegeStorm.ScreenWidth / 6 - Texture.Width;
            var y = SiegeStorm.ScreenHeight / 3 - Texture.Height;
            Vector2 position = new Vector2(x, y);

            walkRight = SiegeStorm.AnimationManager.GetAnimation("walk");
            walkLeft = SiegeStorm.AnimationManager.GetAnimation("walkLeft");
            die = SiegeStorm.AnimationManager.GetAnimation("die");
            fightRight = SiegeStorm.AnimationManager.GetAnimation("playerFight");
            fightLeft = SiegeStorm.AnimationManager.GetAnimation("fightLeft");
            healthbar = new Healthbar();
        }

        public void SetVerticalPosition(int position)
        {
            SetPosition(new Vector2(Position.X, position));
        }
        public float getPositionX()
        {
            return Position.X;
        }

        public void SetLane(int lane)
        {
            currentLane = lane;
        }

        public int GetLane()
        {
            return currentLane;
        }

        //Setters
        private void SetHealth()
        {
            this.health = this.GetBaseHealth() + this.armor.GetStatValue();
        }

        private void getDamage(int damage)
        {
            this.health -= damage; 
        }

        private int getHealth()
        {
            return this.health;
        }

        private void SetPower()
        {
            this.power = this.GetBasePower() + this.weapon.GetStatValue();
        }

        public Inventory GetInventory()
        {
            return inventory;
        }

        public void SetInventory(Inventory newInventory)
        {
            inventory = newInventory;
        }

        public void SetShop(Shop newShop)
        {
            shop = newShop;
        }

        public Shop GetShop()
        {
            return shop;
        }

        public void AddItemToShop(Item item)
        {
            shop.AddItemToShop(item);
        }

        //Equipping item, changing corresponding stats (health / power)
        public void EquipItem(Item item)
        {
            UnequipItem(item);
            if (item.GetType() == typeof(Armor))
            {
                this.armor = (Armor)item;
                this.health += item.GetStatValue();
            }
            else
            {
                this.weapon = (Weapon)item;
                this.power += item.GetStatValue();
            }
        }

        //Unequipping item, changing corresponding stats (health / power)
        public void UnequipItem(Item item)
        {
            if (item.GetType() == typeof(Armor))
            {
                this.health -= armor.GetStatValue();
            }
            else
            {
                this.power -= weapon.GetStatValue();
            }
        }

        //Increasing xp and leveling up
        public void AddXP(int amount)
        {
            this.xp += amount;
            if (this.xp >= this.getLevel() * 100)
            {
                this.xp -= this.getLevel() * 100;
                this.LevelUp();
                this.SetHealth();
                this.SetPower();
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

        private bool wDown;
        private bool sDown;
        private bool alive = true;
        public bool attacked = false;

        private bool turn = false;
        public override void Update(GameTime gameTime)
        {
               // Player - Enemy collision
            for (int i = 0; i < SiegeStorm.EnemyManager.GetEnemies().Length; i++)
            {
                
                if (SiegeStorm.EnemyManager.GetEnemies()[i].GetLane() == GetLane() &&
                    SiegeStorm.EnemyManager.GetEnemies()[i].getPositionX() < (Position.X + Texture.Width) && SiegeStorm.EnemyManager.GetEnemies()[i].getPositionX() > (Position.X - Texture.Width / 2) && SiegeStorm.EnemyManager.GetEnemies()[i].dead == false)
                {
                    this.getDamage(10);
                }
                if (SiegeStorm.PlayerManager.GetPlayers()[0].getHealth() < 0)
                {
                    alive = false;
                }

            }
            healthbar.SetHealth(health, Position);
  
            if (Keyboard.GetState().IsKeyDown(Keys.D) && Position.X < (SiegeStorm.ScreenWidth - Texture.Width))
            {
                SetPosition(new Vector2(Position.X + 5, Position.Y));
               // turn = false;
            }
  
            if (Keyboard.GetState().IsKeyDown(Keys.A) && Position.X > 0)
            {
                SetPosition(new Vector2(Position.X - 5, Position.Y));
                turn = true;
            }


            if (Keyboard.GetState().IsKeyUp(Keys.A))
            {
                turn = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && !wDown)
            {
                wDown = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) && !sDown)
            {
                sDown = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.S) && currentLane < 4 && sDown)
            {
                SetLane(currentLane + 1);
                sDown = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.S) && currentLane == 4 && sDown)
            {
                sDown = false;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.W) && currentLane > 0 && wDown)
            {
                SetLane(currentLane - 1);
                wDown = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.W) && currentLane == 0 && wDown)
            {
                wDown = false;
            }

            
            if (Keyboard.GetState().IsKeyDown(Keys.F) && attacked == false)
            {
                attacked = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.F))
            {
                attacked = false;
            }
        
           

        

        }

        public override void Draw(GameTime gameTime)
        {
            healthbar.Draw(gameTime);
            if (alive == false)
            {
                die.Draw(gameTime, Position);
            }
            else
            {
                if (attacked)
                {
                    if (turn)
                    {
                        fightLeft.Draw(gameTime, Position);
                    }
                    else
                    {
                        fightRight.Draw(gameTime, Position);
                    }

                }
                else
                {
                    if (!turn)
                    {
                        walkRight.Draw(gameTime, Position);

                    }
                    if(turn)
                    {
                        walkLeft.Draw(gameTime, Position);

                    }

                }        
            }     
        }
    }
}