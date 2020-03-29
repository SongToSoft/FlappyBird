using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SirenaEngineMG.SirenaSrc.Components
{
    class SESpriteComponent : SESubComponent
    {
        private bool isVisible;
        private Texture2D sprite;
        private Color color;
        private Vector2 size;
        private SpriteEffects spriteEffect;
        private float layerDepth;
        private Rectangle? drawingRectangle;

        public SESpriteComponent() : base()
        {
            name = "spriteComponent";
            isVisible = true;
            color = Color.White;
            size.X = 0;
            size.Y = 0;
            spriteEffect = SpriteEffects.None;
            layerDepth = 0;
            drawingRectangle = null;
        }

        public bool GetVisible()
        {
            return isVisible;
        }

        public void SetVisible(bool status)
        {
            isVisible = status;
        }

        public Texture2D GetSprite()
        {
            return sprite;
        }

        public void SetSprite(Texture2D _sprite)
        {
            sprite = _sprite;
            size.X = sprite.Width;
            size.Y = sprite.Height;
        }

        public Color GetColor()
        {
            return color;
        }

        public void SetColor(Color _color)
        {
            color = _color;
        }

        public Vector2 GetSpriteSize()
        {
            return size;
        }

        public float GetSpriteWidth()
        {
            return size.X;
        }

        public float GetSpriteHeight()
        {
            return size.Y;
        }

        public void SetEffect(SpriteEffects _spriteEffect)
        {
            spriteEffect = _spriteEffect;
        }

        public SpriteEffects GetEffect()
        {
            return spriteEffect;
        }

        public void SetLayerDepth(float _layerDepth)
        {
            layerDepth = _layerDepth;
        }

        public float GetLayerDepth()
        {
            return layerDepth;
        }

        public void SetDrawingRectangle(Rectangle? _drawingRectangle)
        {
            drawingRectangle = _drawingRectangle;
        }

        public Rectangle? GetDrawingRectangle()
        {
            return drawingRectangle;
        }
    }
}
