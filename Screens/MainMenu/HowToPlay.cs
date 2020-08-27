namespace SiegeStorm.Screens
{
    internal class HowToPlay : GameScreen
    {
        private GameObjects.MainMenu.Background bg;
        private GameObjects.MainMenu.Controls controls;
        private GameObjects.MainMenu.ButtonStartReal startReal;

        internal override void LoadContent()
        {
            bg = new GameObjects.MainMenu.Background();
            AddObject(bg);
            startReal = new GameObjects.MainMenu.ButtonStartReal();
            AddObject(startReal);
            controls = new GameObjects.MainMenu.Controls();
            AddObject(controls);
        }
    }
}