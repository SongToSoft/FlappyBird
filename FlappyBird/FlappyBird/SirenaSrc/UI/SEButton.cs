using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SirenaEngineMG.SirenaSrc.InputManagers;
using SirenaEngineMG.SirenaSrc.Objects;

namespace SirenaEngineMG.SirenaSrc.UI
{
    delegate void CallbackAction();

    class SEButton : SEObject
    {
        private CallbackAction callback;

        public SEButton(SpriteFont font, Texture2D buttonSprite) : base("button")
        {
            component.GetFontComponent().SetFont(font);
            component.GetSpriteComponent().SetSprite(buttonSprite);
            callback = null;
        }

        public void SetCallback(CallbackAction _callback)
        {
            callback = _callback;
        }

        public void Play()
        {
            callback?.Invoke();

        }

        public override void CustomUpdate()
        {
            if (component.GetTransformComponent().GetRectangle().Contains(SEMouseManager.GetCursorPosition()))
            {
                if (SEMouseManager.CheckMouseLeftClick())
                {
                    Play();
                }
                component.GetSpriteComponent().SetColor(Color.LightGray);
            }
            else
            {
                component.GetSpriteComponent().SetColor(Color.White);
            }
        }

        public override void CustomDraw(SpriteBatch spriteBatch)
        {
            base.CustomDraw(spriteBatch);
            spriteBatch.DrawString(component.GetFontComponent().GetFont(),
                                   component.GetFontComponent().GetText(),
                                   component.GetTransformComponent().GetPosition(),
                                   component.GetFontComponent().GetColor());
        }
    }
}
