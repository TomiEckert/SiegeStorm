namespace SiegeStorm.Screens
{
    internal class SettingsMenu : GameScreen
    {
        private GameObjects.SettingsMenu.ButtonReturn returnButton;
        private GameObjects.SettingsMenu.ButtonFullscreen fullscreenButton;
        private GameObjects.SettingsMenu.ButtonFPS fpsButton;

        internal override void LoadContent()
        {
            returnButton = new GameObjects.SettingsMenu.ButtonReturn();
            AddObject(returnButton);
            fullscreenButton = new GameObjects.SettingsMenu.ButtonFullscreen();
            AddObject(fullscreenButton);
            fpsButton = new GameObjects.SettingsMenu.ButtonFPS();
            AddObject(fpsButton);
        }
    }
}