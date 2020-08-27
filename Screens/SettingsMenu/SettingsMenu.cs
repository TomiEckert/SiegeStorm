namespace SiegeStorm.Screens
{
    internal class SettingsMenu : GameScreen
    {
        private GameObjects.SettingsMenu.ButtonReturn returnButton;
        private GameObjects.SettingsMenu.ButtonFullscreen fullscreenButton;
        private GameObjects.SettingsMenu.ButtonFPS fpsButton;
        private GameObjects.SettingsMenu.Background bg;
        private GameObjects.SettingsMenu.FpsCounterText FpsText;
        private GameObjects.SettingsMenu.FullScreenText FullscreenText;

        internal override void LoadContent()
        {
            bg = new GameObjects.SettingsMenu.Background();
            AddObject(bg);
            returnButton = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(returnButton);
            fullscreenButton = new GameObjects.SettingsMenu.ButtonFullscreen();
            AddObject(fullscreenButton);
            fpsButton = new GameObjects.SettingsMenu.ButtonFPS();
            AddObject(fpsButton);
            FpsText = new GameObjects.SettingsMenu.FpsCounterText();
            AddObject(FpsText);
            FullscreenText = new GameObjects.SettingsMenu.FullScreenText();
            AddObject(FullscreenText);
        }
    }
}