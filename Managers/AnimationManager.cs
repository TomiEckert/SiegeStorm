using System.Collections.Generic;
using System.IO;

namespace SiegeStorm.Managers
{
    public class AnimationManager
    {
        private const string PATH = "Content/Animation/Textures/";

        private Dictionary<string, FileInfo[]> animations;

        public AnimationManager()
        {
            animations = new Dictionary<string, FileInfo[]>();
            LoadContent();
        }

        public void LoadContent()
        {
            var dir = new DirectoryInfo(PATH);
            var files = dir.GetFiles("anim_*_00.png");

            foreach (var file in files)
            {
                var name = file.Name.Split('_')[1];
                var local = dir.GetFiles("anim_" + file.Name.Split('_')[1] + "*");

                if (animations.ContainsKey(name))
                    continue;

                animations.Add(name, local);
            }
        }

        public Animation GetAnimation(string name)
        {
            if (!animations.ContainsKey(name))
                throw new System.Exception("Animation is not loaded.");
            return new Animation(animations[name]);
        }
    }
}