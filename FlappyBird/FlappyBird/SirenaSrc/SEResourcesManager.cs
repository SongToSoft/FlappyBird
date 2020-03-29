using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;


namespace SirenaEngineMG.SirenaSrc
{
    static class SEResourcesManager
    {
        private static Dictionary<string, Texture2D> loadedSprites;
        private static Dictionary<string, SpriteFont> loadedFont;
        private static Dictionary<string, SoundEffect> loadedSounds;

        public static void Init()
        {
            loadedSprites = new Dictionary<string, Texture2D>();
            loadedFont = new Dictionary<string, SpriteFont>();
            loadedSounds = new Dictionary<string, SoundEffect>();
        }

        public static void LoadSprite(ContentManager content, string spriteName)
        {
            loadedSprites.Add(spriteName, content.Load<Texture2D>(spriteName));
        }

        public static Texture2D GetSpriteByName(string spriteName)
        {
            Texture2D outSprite = null;
            loadedSprites.TryGetValue(spriteName, out outSprite);
            return outSprite;
        }

        public static void LoadFont(ContentManager content, string fontName)
        {
            loadedFont.Add(fontName, content.Load<SpriteFont>(fontName));
        }

        public static SpriteFont GetFontByName(string fontName)
        {
            SpriteFont outFont = null;
            loadedFont.TryGetValue(fontName, out outFont);
            return outFont;
        }

        public static void LoadSound(ContentManager content, string soundName)
        {
            loadedSounds.Add(soundName, content.Load<SoundEffect>(soundName));
        }

        public static SoundEffect GetSoundByName(string soundName)
        {
            SoundEffect outSong = null;
            loadedSounds.TryGetValue(soundName, out outSong);
            return outSong;
        }
    }
}
