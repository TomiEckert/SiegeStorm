namespace SiegeStorm.Screens
{
    internal class MainMenu : GameScreen
    {
        private GameObjects.MainMenu.Background bg;
        private GameObjects.MainMenu.ButtonStart start;
        private GameObjects.MainMenu.ButtonSettings settings;
        private GameObjects.MainMenu.ButtonExit exit;

        internal override void LoadContent()
        {
            bg = new GameObjects.MainMenu.Background();
            AddObject(bg);
            start = new GameObjects.MainMenu.ButtonStart();
            AddObject(start);
            settings = new GameObjects.MainMenu.ButtonSettings();
            AddObject(settings);
            exit = new GameObjects.MainMenu.ButtonExit();
            AddObject(exit);
        }

        public override void ScreenOpen()
        {
            SiegeStorm.SoundManager.PlaySong("MainMenu");
        }

        public override void ScreenClose()
        {
            SiegeStorm.SoundManager.StopSong();
        }
    }
}