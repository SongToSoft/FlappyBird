using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SirenaEngineMG.SirenaSrc.Components
{
    class SEFontComponent : SESubComponent
    {
        private string text;
        private SpriteFont font;
        private Color color;

        public SEFontComponent() : base()
        {
            name = "fontComponent";
            text = "";
            font = null;
            color = Color.White;
        }

        public string GetText()
        {
            return text;
        }

        public void SetText(string _text)
        {
            text = _text;
        }

        public void Concatenation(string _text)
        {
            text += _text;
        }

        public void SetFont(SpriteFont _font)
        {
            font = _font;
        }

        public SpriteFont GetFont()
        {
            return font;
        }

        public void SetColor(Color _color)
        {
            color = _color;
        }

        public Color GetColor()
        {
            return color;
        }
    }
}
