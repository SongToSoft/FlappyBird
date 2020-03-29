using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SirenaEngineMG.SirenaSrc;
using SirenaEngineMG.SirenaSrc.Animations;
using SirenaEngineMG.SirenaSrc.InputManagers;
using SirenaEngineMG.SirenaSrc.Objects;
using SirenaEngineMG.SirenaSrc.UI;
using System.Collections.Generic;

namespace SirenaEngineMG.FlappyBirdProjectCode
{
    class FlappyBirdMainGameScene : SEScene
    {
        private Bird bird;
        private ObstacleManager obstacleManager;

        public FlappyBirdMainGameScene(string _name) : base(_name)
        {
            FlappyBirdProperties.Init();

            SEObject background = new SEObject("background");
            background.GetComponent().GetSpriteComponent().SetSprite(SEResourcesManager.GetSpriteByName("background-day"));
            background.GetComponent().GetTransformComponent().SetSize(SEProperties.GetGameWindowWidth(),
                                                                      SEProperties.GetGameWindowHeight());
            background.GetComponent().GetSpriteComponent().SetLayerDepth(1.0f);
            AddChild(background);

            bird = new Bird();
            AddChild(bird);

            obstacleManager = new ObstacleManager();
            AddChild(obstacleManager);

            Ground ground = new Ground();
            AddChild(ground);

            AddChild(FlappyBirdProperties.GetScoreLabel());
            AddChild(FlappyBirdProperties.GetHighScoreLabel());
            AddChild(FlappyBirdProperties.GetTextLabel());
        }

        public override void Reload()
        {
            FlappyBirdProperties.Reload();
            bird.Reload();
            obstacleManager.Reload();
        }

        public override void Update()
        {
            if (FlappyBirdProperties.IsBirdFly())
            {
                base.Update();
            }
            else
            {
                if (FlappyBirdProperties.IsGameWaiting())
                {
                    bird.WaitRunGame();
                }
                else
                {
                    if (SEKeyboardManager.CheckKeyDown(Keys.Space))
                    {
                        Reload();
                    }
                    bird.GetComponent().GetCircleColliderComponent().SetCenterPosition(bird.GetComponent().GetTransformComponent().GetPosition().X,
                                                                                       bird.GetComponent().GetTransformComponent().GetPosition().Y);
                    if (bird.GetComponent().GetTransformComponent().GetPositionY() < FlappyBirdProperties.GetGroundHeigth())
                    {
                        bird.GetComponent().GetTransformComponent().Rotate(0.02f);
                        bird.GetComponent().GetTransformComponent().MoveDown();
                    }
                }
            }
        }

        public override void CustomUpdate()
        {
            base.CustomUpdate();
            obstacleManager.CheckBirdCollapse(bird);
        }
    }
}
