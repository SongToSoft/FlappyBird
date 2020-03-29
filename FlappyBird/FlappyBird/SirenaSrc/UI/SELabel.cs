using Microsoft.Xna.Framework.Graphics;
using SirenaEngineMG.SirenaSrc.Objects;

namespace SirenaEngineMG.SirenaSrc.UI
{
    class SELabel : SEObject
    {
        public SELabel(SpriteFont font) : base("label")
        {
            component.GetFontComponent().SetFont(font);
        }

        public override void CustomDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(component.GetFontComponent().GetFont(),
                                   component.GetFontComponent().GetText(),
                                   component.GetTransformComponent().GetPosition(),
                                   component.GetFontComponent().GetColor());
        }
    }
}
