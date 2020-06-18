using Microsoft.Xna.Framework;
using SiegeStorm.GameScreens.Levels;

namespace SiegeStorm.GameObjects.Map
{
    internal class MapNode : GameButton
    {
        private Level level;

        public MapNode(Level level, int posX, int posY) : base()
        {
            this.level = level;
            //TODO set texture
            SetTexture(SiegeStorm.TextureManager.GetTexture(this));
            //Set position
            var x = (int)( posX  - Texture.Width);
            var y = (int)( posY - Texture.Height);
            SetPosition(new Vector2(x, y));
        }

        public override void Pressed()
        {
            var levelName = SiegeStorm.LevelManager.GetLevelName(this.level);
            if (SiegeStorm.LevelManager.IsLevelUnlocked(levelName))
            {
                level.Run();
            }
        }
    }
}