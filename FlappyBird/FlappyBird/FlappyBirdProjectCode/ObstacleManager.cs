using System;
using Microsoft.Xna.Framework.Graphics;
using SirenaEngineMG.SirenaSrc.Objects;

namespace SirenaEngineMG.FlappyBirdProjectCode
{
    class ObstacleManager : SEObject
    {
        private DateTime time;

        public ObstacleManager() : base("obstacleManager")
        {
            time = DateTime.Now;
        }

        public override void CustomDraw(SpriteBatch spriteBatch) { }

        public override void CustomUpdate()
        {
            TimeSpan span = DateTime.Now - time;
            if ((span.TotalSeconds) > 1.4f)
            {
#if DEBUG
                Console.WriteLine("Add obstacle: " + childs.Count);
#endif
                AddChild(new Obstacle());
                time = DateTime.Now;
            }
            for (int i = 0; i < childs.Count; ++i)
            {
                if (childs[i].GetComponent().GetTransformComponent().GetPositionX() < -1000)
                {
                    RemoveChild(childs[i]);
                }
            }
        }

        public bool CheckBirdCollapse(Bird bird)
        {
            for (int i = 0; i < childs.Count; ++i)
            {
                if ((childs[i].GetChilds()[0].GetComponent().GetTransformComponent().GetPositionX() < bird.GetComponent().GetTransformComponent().GetPositionX()) && (childs[i] as Obstacle).IsActive())
                {
                    bird.GetComponent().GetAudioSourceComponent().Play(@"FlappyBird\sfx_point");
                    FlappyBirdProperties.IncreaseScore();
                    FlappyBirdProperties.GetScoreLabel().GetComponent().GetFontComponent().SetText(FlappyBirdProperties.GetScore().ToString());
                    (childs[i] as Obstacle).SetNonActive();
                }

                for (int j = 0; j < childs[i].GetChilds().Count; ++j)
                {
                    if (bird.GetComponent().GetCircleColliderComponent().Contains(childs[i].GetChilds()[j].GetComponent().GetTransformComponent().GetRectangle()))
                    {
                        bird.GetComponent().GetAudioSourceComponent().Play(@"FlappyBird\sfx_hit");
                        bird.Collapse();
                        return true;
                    }
                }
            }
            return false;
        }

        public override void Reload()
        {
            time = DateTime.Now;
            for (int i = 0; i < childs.Count; ++i)
            {
                RemoveChild(childs[i]);
            }
            if ((childs.Count >= 1) && (childs[0] != null))
            {
                RemoveChild(childs[0]);
            }
        }
    }
}
