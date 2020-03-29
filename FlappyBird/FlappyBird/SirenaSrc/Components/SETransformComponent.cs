using Microsoft.Xna.Framework;

namespace SirenaEngineMG.SirenaSrc.Components
{
    class SETransformComponent : SESubComponent
    {
        private Vector2 position;
        private Vector2 scale;
        private Vector2 size;
        private Rectangle rectangle;
        private float speed;
        private float rotateAngle;
        private Vector2 originRotatePosition;

        public SETransformComponent() : base()
        {
            name = "transformComponent";
            position = new Vector2(0, 0);
            scale = new Vector2(1, 1);
            size = Vector2.Zero;
            rectangle = new Rectangle(0, 0, 0, 0);
            speed = 0.0f;
            rotateAngle = 0.0f;
            originRotatePosition = Vector2.Zero;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public float GetPositionX()
        {
            return position.X;
        }

        public float GetPositionY()
        {
            return position.Y;
        }

        public void SetPosition(Vector2 _position)
        {
            position = _position;
            UpdateSpriteRectangle();
        }

        public void SetPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;
            UpdateSpriteRectangle();
        }

        public void SetPositionX(float x)
        {
            position.X = x;
            UpdateSpriteRectangle();
        }

        public void SetPositionY(float y)
        {
            position.Y = y;
            UpdateSpriteRectangle();
        }

        public Vector2 GetScale()
        {
            return scale;
        }

        public float GetScaleX()
        {
            return scale.X;
        }

        public float GetScaleY()
        {
            return scale.Y;
        }

        public void SetScale(Vector2 _scale)
        {
            scale = _scale;
            UpdateSpriteRectangle();
        }

        public void SetScale(float x, float y)
        {
            scale.X = x;
            scale.Y = y;
            UpdateSpriteRectangle();
        }

        public void SetScaleX(float x)
        {
            scale.X = x;
            UpdateSpriteRectangle();
        }

        public void SetScaleY(float y)
        {
            scale.Y = y;
            UpdateSpriteRectangle();
        }

        public Vector2 GetSize()
        {
            return size;
        }

        public float GetSizeX()
        {
            return size.X;
        }

        public float GetSizeY()
        {
            return size.Y;
        }

        public void SetSize(Vector2 _size)
        {
            size = _size;
        }

        public void SetSize(float x, float y)
        {
            size.X = x;
            size.Y = y;
            UpdateSpriteRectangle();
        }

        public void SetSizeX(float x)
        {
            size.X = x;
            UpdateSpriteRectangle();
        }

        public void SetSizeY(float y)
        {
            size.Y = y;
            UpdateSpriteRectangle();
        }

        public Rectangle GetRectangle()
        {
            return rectangle;  
        }

        public void SetRectangle(Rectangle _rectangle)
        {
            rectangle = _rectangle;
            position.X = rectangle.X;
            position.Y = rectangle.Y;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(float _speed)
        {
            speed = _speed;
        }

        public void MoveRight()
        {
            position.X += speed;
            UpdateSpriteRectangle();
        }

        public void MoveLeft()
        {
            position.X -= speed;
            UpdateSpriteRectangle();
        }

        public void MoveDown()
        {
            position.Y += speed;
            UpdateSpriteRectangle();
        }

        public void MoveUp()
        {
            position.Y -= speed;
            UpdateSpriteRectangle();
        }

        public void SetRotateAngle(float _rotateAngle)
        {
            rotateAngle = _rotateAngle;
        }

        public float GetRotateAngle()
        {
            return rotateAngle;
        }

        public void Rotate(float angle)
        {
            rotateAngle += angle;
        }

        public void SetOriginRotatePosition(Vector2 _originRotatePosition)
        {
            originRotatePosition = _originRotatePosition;
        }

        public void SetOriginRotatePosition(float x, float y)
        {
            originRotatePosition.X = x;
            originRotatePosition.Y = y;
        }

        public Vector2 GetOriginRotatePosition()
        {
            return originRotatePosition;
        }

        private void UpdateSpriteRectangle()
        {
            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;
            rectangle.Width = (int)(size.X * scale.X);
            rectangle.Height = (int)(size.Y * scale.Y);
        }
    }
}
