using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirenaEngineMG.SirenaSrc.Components
{
    [Obsolete]
    class SERectangleCollider : SESubComponent
    {
        private Vector2 leftUpPoint, leftDownPoint, rightUpPoint, rightDownPoint;

        public SERectangleCollider(Rectangle rectangle, float angle, Vector2 originRotatePosition) : base()
        {
            name = "rectangleColliderComponent";

            leftUpPoint.X = rectangle.X;
            leftUpPoint.Y = rectangle.Y;
            leftUpPoint.X = (float)(originRotatePosition.X + (leftUpPoint.X - originRotatePosition.X) * Math.Cos(angle) - (leftUpPoint.Y - originRotatePosition.Y) * Math.Sin(angle));
            leftUpPoint.Y = (float)(originRotatePosition.Y + (leftUpPoint.Y - originRotatePosition.Y) * Math.Cos(angle) + (leftUpPoint.X - originRotatePosition.X) * Math.Sin(angle));

            leftDownPoint.X = rectangle.X;
            leftDownPoint.Y = rectangle.Y + rectangle.Height;
            leftDownPoint.X = (float)(originRotatePosition.X + (leftDownPoint.X - originRotatePosition.X) * Math.Cos(angle) - (leftDownPoint.Y - originRotatePosition.Y) * Math.Sin(angle));
            leftDownPoint.Y = (float)(originRotatePosition.Y + (leftDownPoint.Y - originRotatePosition.Y) * Math.Cos(angle) + (leftDownPoint.X - originRotatePosition.X) * Math.Sin(angle));

            rightUpPoint.X = rectangle.X + rectangle.Width;
            rightUpPoint.Y = rectangle.Y;
            rightUpPoint.X = (float)(originRotatePosition.X + (rightUpPoint.X - originRotatePosition.X) * Math.Cos(angle) - (rightUpPoint.Y - originRotatePosition.Y) * Math.Sin(angle));
            rightUpPoint.Y = (float)(originRotatePosition.Y + (rightUpPoint.Y - originRotatePosition.Y) * Math.Cos(angle) + (rightUpPoint.X - originRotatePosition.X) * Math.Sin(angle));

            rightDownPoint.X = rectangle.X + rectangle.Width;
            rightDownPoint.Y = rectangle.Y + rectangle.Height;
            rightDownPoint.X = (float)(originRotatePosition.X + (rightDownPoint.X - originRotatePosition.X) * Math.Cos(angle) - (rightDownPoint.Y - originRotatePosition.Y) * Math.Sin(angle));
            rightDownPoint.Y = (float)(originRotatePosition.Y + (rightDownPoint.Y - originRotatePosition.Y) * Math.Cos(angle) + (rightDownPoint.X - originRotatePosition.X) * Math.Sin(angle));
        }

        public Vector2 GetLeftUpPoint()
        {
            return leftUpPoint;
        }

        public Vector2 GetLeftDownPoint()
        {
            return leftDownPoint;
        }

        public Vector2 GetRightUpPoint()
        {
            return rightUpPoint;
        }

        public Vector2 GetRightDownPoint()
        {
            return rightDownPoint;
        }

        public bool Contains(Vector2 point)
        {
            //return ((point.X >= leftUpPoint.X) && (point.X <= rightUpPoint.X)) &&
            //       ((point.Y >= leftUpPoint.Y) && point.Y <= leftDownPoint.Y);
            return false;

        }

        public bool Contains(Rectangle rec)
        {
            return false;

        }
    }
}
