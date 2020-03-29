using Microsoft.Xna.Framework.Graphics;
using SirenaEngineMG.SirenaSrc;
using SirenaEngineMG.SirenaSrc.Objects;


namespace SirenaEngineMG.FlappyBirdProjectCode
{
    class Obstacle : SEObject
    {
        private float width = 80;

        private float topHeight = 190;
        private float bottmoHeight = 190;
        private bool isActive;

        public Obstacle() : base("obstacle")
        {
            float shift = SEProperties.GetRandomizer().Next(0, 80);
            component.GetTransformComponent().SetSpeed(5.0f);
            bool isTopHigher = SEProperties.GetRandomizer().Next(0, 100) > 50 ? true : false;

            if (isTopHigher)
            {
                topHeight += shift;
                bottmoHeight -= shift;
            }
            else
            {
                topHeight -= shift;
                bottmoHeight += shift;
            }

            SEObject top = new SEObject("top");
            top.GetComponent().GetSpriteComponent().SetSprite(SEResourcesManager.GetSpriteByName("pipe-green"));
            top.GetComponent().GetTransformComponent().SetPosition(SEProperties.GetGameWindowWidth() + 50, 0);
            top.GetComponent().GetTransformComponent().SetSize(width, topHeight);
            top.GetComponent().GetTransformComponent().SetSpeed(5.0f);
            top.GetComponent().GetSpriteComponent().SetEffect(SpriteEffects.FlipVertically);
            top.GetComponent().GetSpriteComponent().SetLayerDepth(1.0f);

            SEObject bottom = new SEObject("bottom");
            bottom.GetComponent().GetSpriteComponent().SetSprite(SEResourcesManager.GetSpriteByName("pipe-green"));
            bottom.GetComponent().GetTransformComponent().SetPosition(SEProperties.GetGameWindowWidth() + 50, SEProperties.GetGameWindowHeight() - bottmoHeight);
            bottom.GetComponent().GetTransformComponent().SetSize(width, bottmoHeight);
            bottom.GetComponent().GetTransformComponent().SetSpeed(5.0f);
            bottom.GetComponent().GetSpriteComponent().SetLayerDepth(1.0f);

            AddChild(top);
            AddChild(bottom);

            isActive = true;
        }

        public bool IsActive()
        {
            return isActive;
        }

        public void SetNonActive()
        {
            isActive = false;
        }

        public override void CustomUpdate()
        {
            component.GetTransformComponent().MoveLeft();
            for (int i = 0; i < childs.Count; ++i)
            {
                childs[i].GetComponent().GetTransformComponent().MoveLeft();
            }
        }
    }
}
