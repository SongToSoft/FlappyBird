using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Point = Microsoft.Xna.Framework.Point;

namespace SirenaEngineMG.SirenaSrc.Components
{
    class SECircleColliderComponent : SESubComponent
    {
        private Vector2 centerPosition;
        private float radius;
#if DEBUG
        private Texture2D circleSprite;
        private Rectangle rectangle;
#endif
        public SECircleColliderComponent() : base()
        {
            name = "circleColliderComponent";
#if DEBUG
            circleSprite = SEResourcesManager.GetSpriteByName(@"Debug\circle_red");
            UpdateRectangle();
#endif
        }

        public void SetCenterPosition(Vector2 _centerPosition)
        {
            centerPosition = _centerPosition;
#if DEBUG
            UpdateRectangle();
#endif
        }

        public void SetCenterPosition(float x, float y)
        {
            centerPosition.X = x;
            centerPosition.Y = y;
#if DEBUG
            UpdateRectangle();
#endif
        }

        public void SetCenterPosition(Point _centerPosition)
        {
            centerPosition.X = _centerPosition.X;
            centerPosition.Y = _centerPosition.Y;
#if DEBUG
            UpdateRectangle();
#endif
        }

        public Vector2 GetCenterPosition()
        {
            return centerPosition;
        }

        public void SetRadius(float _radius)
        {
            radius = _radius;
#if DEBUG
            UpdateRectangle();
#endif
        }


        public float GetRadius()
        {
            return radius;
        }

        public bool Contains(Vector2 point)
        {
            return (((centerPosition.X - point.X) * (centerPosition.X - point.X)) + ((centerPosition.Y - point.Y) * (centerPosition.Y - point.Y)) <= (radius * radius));
        }

        public bool Contains(Rectangle rectangle)
        {
            float rW = (rectangle.Width) / 2;
            float rH = (rectangle.Height) / 2;

            float distX = Math.Abs(centerPosition.X - (rectangle.Left + rW));
            float distY = Math.Abs(centerPosition.Y - (rectangle.Top + rH));

            if (distX >= radius + rW || distY >= radius + rH)
            {
                return false;
            }
            if (distX < rW || distY < rH)
            {
                return true;
            }

            distX -= rW;
            distY -= rH;

            if (distX * distX + distY * distY < radius * radius)
            {
                return true;
            }
            return false;
        }

#if DEBUG
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(circleSprite, rectangle, null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
        }

        public void UpdateRectangle()
        {
            rectangle = new Rectangle((int)(centerPosition.X - radius), (int)(centerPosition.Y - radius), (int)(radius * 2), (int)(radius * 2));
        }
#endif
    }
}
