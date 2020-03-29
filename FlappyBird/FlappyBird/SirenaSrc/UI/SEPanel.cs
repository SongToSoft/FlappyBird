using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SirenaEngineMG.SirenaSrc.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirenaEngineMG.SirenaSrc.UI
{
    class SEPanel : SEObject
    {
        public SEPanel(Rectangle rectangle, Texture2D panelSprite) : base("panel")
        {
            component.GetTransformComponent().SetRectangle(rectangle);
            component.GetSpriteComponent().SetSprite(panelSprite);
        }
    }
}
