using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SirenaEngineMG.SirenaSrc;
using SirenaEngineMG.SirenaSrc.Animations;
using SirenaEngineMG.SirenaSrc.InputManagers;
using SirenaEngineMG.SirenaSrc.Objects;

namespace SirenaEngineMG.FlappyBirdProjectCode
{
    class Bird : SEObject
    {
        private bool isFalling;
        private DateTime timeFalling;
        private float fallingSpeed;
        private float jumpSpeed;
        private float scaleValue;

        public Bird() : base("bird")
        {
            scaleValue = 1.4f;
            isFalling = true;
            fallingSpeed = 5.0f;
            jumpSpeed = 7.0f;
            component.GetSpriteComponent().SetSprite(SEResourcesManager.GetSpriteByName("yellowbird-downflap"));
            component.GetTransformComponent().SetPosition(SEProperties.GetGameWindowWidth() / 4, SEProperties.GetGameWindowHeight() / 2);
            component.GetTransformComponent().SetSize(component.GetSpriteComponent().GetSpriteWidth(),
                                                      component.GetSpriteComponent().GetSpriteHeight());
            component.GetTransformComponent().SetScale(scaleValue, scaleValue);
            component.GetTransformComponent().SetOriginRotatePosition(component.GetSpriteComponent().GetSpriteWidth() / 2, component.GetSpriteComponent().GetSpriteHeight() / 2);
            component.GetTransformComponent().SetSpeed(fallingSpeed);

            SESequentialChangeSprite changeSpriteAnim = new SESequentialChangeSprite(0.1f);
            changeSpriteAnim.AddSprite(SEResourcesManager.GetSpriteByName("yellowbird-midflap"));
            changeSpriteAnim.AddSprite(SEResourcesManager.GetSpriteByName("yellowbird-upflap"));
            changeSpriteAnim.AddSprite(SEResourcesManager.GetSpriteByName("yellowbird-downflap"));
            changeSpriteAnim.SetObject(this);
            component.GetActionComponent().AddAction("changeSprite", changeSpriteAnim);

            component.GetAudioSourceComponent().AddSound(@"FlappyBird\sfx_die");
            component.GetAudioSourceComponent().AddSound(@"FlappyBird\sfx_hit");
            component.GetAudioSourceComponent().AddSound(@"FlappyBird\sfx_point");
            component.GetAudioSourceComponent().AddSound(@"FlappyBird\sfx_swooshing");
            component.GetAudioSourceComponent().AddSound(@"FlappyBird\sfx_wing");
            component.GetAudioSourceComponent().SetVolume(0.1f);
            //component.GetAudioSourceComponent().SetVolume(0.0f);

            component.GetCircleColliderComponent().SetRadius(component.GetSpriteComponent().GetSpriteWidth() / 2);
            component.GetCircleColliderComponent().SetCenterPosition(component.GetTransformComponent().GetPosition().X,
                                                                     component.GetTransformComponent().GetPosition().Y);
        }

        public void Jump()
        {
            component.GetAudioSourceComponent().Play(@"FlappyBird\sfx_wing");
            component.GetTransformComponent().SetRotateAngle(-0.3f);
            timeFalling = DateTime.Now;
            isFalling = false;
            component.GetTransformComponent().SetSpeed(jumpSpeed);
        }

        public void WaitRunGame()
        {
            component.GetActionComponent().StartAction("changeSprite");
            if (SEKeyboardManager.CheckKeyDown(Keys.Space))
            {
                Jump();
                FlappyBirdProperties.SetBirdFlyStatus(true);
                FlappyBirdProperties.SetGameWaitingStatus(false);
                FlappyBirdProperties.GetTextLabel().SetEnable(false);
            }
        }

        public override void CustomUpdate()
        {
            component.GetCircleColliderComponent().SetCenterPosition(component.GetTransformComponent().GetPosition().X,
                                                                     component.GetTransformComponent().GetPosition().Y);

            component.GetActionComponent().StartAction("changeSprite");
            if (isFalling)
            {
                if (component.GetTransformComponent().GetRotateAngle() < 1.5f)
                {
                    component.GetTransformComponent().Rotate(0.03f);
                }
                component.GetTransformComponent().MoveDown();
                if (SEKeyboardManager.CheckKeyDown(Keys.Space))
                {
                    Jump();
                }
            }
            else
            {
                TimeSpan span = DateTime.Now - timeFalling;
                if ((span.TotalSeconds) > 0.2f)
                {
                    component.GetTransformComponent().SetSpeed(fallingSpeed);
                    isFalling = true;
                }
                component.GetTransformComponent().MoveUp();
            }
            if ((GetComponent().GetTransformComponent().GetPositionY() > FlappyBirdProperties.GetGroundHeigth()) ||
                (GetComponent().GetTransformComponent().GetPositionY() < 0))
            {
                component.GetAudioSourceComponent().Play(@"FlappyBird\sfx_die");
                Collapse();
            }
        }

#if DEBUG
        public override void CustomDraw(SpriteBatch spriteBatch)
        {
            if (component.GetSpriteComponent().GetVisible())
            {
                if (component.GetSpriteComponent().GetSprite() != null)
                {
                    spriteBatch.Draw(component.GetSpriteComponent().GetSprite(),
                                     component.GetTransformComponent().GetRectangle(),
                                     component.GetSpriteComponent().GetDrawingRectangle(),
                                     component.GetSpriteComponent().GetColor(),
                                     component.GetTransformComponent().GetRotateAngle(),
                                     component.GetTransformComponent().GetOriginRotatePosition(),
                                     component.GetSpriteComponent().GetEffect(),
                                     component.GetSpriteComponent().GetLayerDepth());
                }
            }
            component.GetCircleColliderComponent().Draw(spriteBatch);
            DrawBorder(spriteBatch);
        }
#endif

        public void Collapse()
        {
            FlappyBirdProperties.SetBirdFlyStatus(false);
            FlappyBirdProperties.GetTextLabel().GetComponent().GetFontComponent().SetText("Tap on space to reload game");
            FlappyBirdProperties.GetTextLabel().SetEnable(true);
            component.GetTransformComponent().SetSpeed(8);
#if DEBUG
            Console.WriteLine("Collapse");
#endif
        }

        public override void Reload()
        {
            component.GetTransformComponent().SetPosition(SEProperties.GetGameWindowWidth() / 4, SEProperties.GetGameWindowHeight() / 2);
            isFalling = true;
            component.GetTransformComponent().SetRotateAngle(0.0f);
        }
    }
}
