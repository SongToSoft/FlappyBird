using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SirenaEngineMG.SirenaSrc.Objects;

namespace SirenaEngineMG.SirenaSrc.Animations
{
    class SEFlash : SEAction
    {
        private Color color;
        private TimeSpan timer;
        private SpriteBatch spriteBatch;
        private Texture2D sprite;
        private Rectangle rectangle;
        private bool isStart;

        public SEFlash(SpriteBatch _spriteBatch, TimeSpan _timer, Texture2D _sprite, Rectangle _rectangle) : base()
        {
            color = Color.White;
            timer = _timer;
            spriteBatch = _spriteBatch;
            sprite = _sprite;
            rectangle = _rectangle;
            isStart = false;
            SetAction(Flash);
        }

        public void SetColor(Color _color)
        {
            color = _color;
        }

        public void Flash()
        {
            spriteBatch.Draw(sprite, rectangle, color);
        }
    }
}
