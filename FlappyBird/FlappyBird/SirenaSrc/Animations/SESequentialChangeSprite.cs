using System;
using Microsoft.Xna.Framework.Graphics;
using SirenaEngineMG.SirenaSrc.Objects;
using System.Collections.Generic;

namespace SirenaEngineMG.SirenaSrc.Animations
{
    class SESequentialChangeSprite : SEAction
    {
        private List<Texture2D> spriteList;
        private int currentIndex;
        private SEObject obj;
        private DateTime lastAction;
        private float delay;

        public SESequentialChangeSprite(float _delay)
        {
            spriteList = new List<Texture2D>();
            currentIndex = 0;
            SetAction(GetNextSprite);
            obj = null;
            delay = _delay;
            lastAction = DateTime.Now;
        }

        public void SetObject(SEObject _obj)
        {
            obj = _obj;
        }

        public void AddSprite(Texture2D sprite)
        {
            spriteList.Add(sprite);
        }

        public void GetNextSprite()
        {
            if ((DateTime.Now - lastAction).TotalSeconds > delay)
            {
                ++currentIndex;
                if (currentIndex == spriteList.Count)
                {
                    currentIndex = 0;
                }
                obj.GetComponent().GetSpriteComponent().SetSprite(spriteList[currentIndex]);
                lastAction = DateTime.Now;
            }
        }
    }
}
