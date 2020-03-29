using Microsoft.Xna.Framework;
using SirenaEngineMG.SirenaSrc;
using SirenaEngineMG.SirenaSrc.Animations;
using SirenaEngineMG.SirenaSrc.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirenaEngineMG.FlappyBirdProjectCode
{
    class Ground : SEObject
    {
        private float xPositionLastPart;

        public Ground() : base("ground")
        {
            xPositionLastPart = 0;
            for (int i = 0; i < 2; ++i)
            {
                CreateNewGroundPart();
                xPositionLastPart += SEProperties.GetGameWindowWidth();
            }
            xPositionLastPart = SEProperties.GetGameWindowWidth();
        }

        public override void CustomUpdate()
        {
            for (int i = 0; i < childs.Count; ++i)
            {
                childs[i].GetComponent().GetTransformComponent().MoveLeft();
                if (childs[i].GetComponent().GetTransformComponent().GetPositionX() + childs[i].GetComponent().GetTransformComponent().GetSizeX() < 0)
                {
                    childs.Remove(childs[i]);
                    CreateNewGroundPart();
                }

            }
#if DEBUG
            Console.WriteLine("Ground Parts Count: " + childs.Count());
#endif
        }

        private void CreateNewGroundPart()
        {
            SEObject groundPart = new SEObject("ground");
            groundPart.GetComponent().GetSpriteComponent().SetSprite(SEResourcesManager.GetSpriteByName("base"));
            groundPart.GetComponent().GetTransformComponent().SetPosition(xPositionLastPart, FlappyBirdProperties.GetGroundHeigth());
            groundPart.GetComponent().GetTransformComponent().SetSize(SEProperties.GetGameWindowWidth(), (int)(SEProperties.GetGameWindowHeight() - FlappyBirdProperties.GetGroundHeigth()));
            groundPart.GetComponent().GetTransformComponent().SetRectangle(new Rectangle((int)xPositionLastPart,
                                                                                         (int)FlappyBirdProperties.GetGroundHeigth(),
                                                                                         SEProperties.GetGameWindowWidth(),
                                                                                         (int)(SEProperties.GetGameWindowHeight() - FlappyBirdProperties.GetGroundHeigth())));
            groundPart.GetComponent().GetSpriteComponent().SetLayerDepth(0.0f);

            groundPart.GetComponent().GetTransformComponent().SetSpeed(4f);
            AddChild(groundPart);
        }
    }
}
