using Microsoft.Xna.Framework.Input;
using SirenaEngineMG.SirenaSrc.InputManagers;

namespace SirenaEngineMG.SirenaSrc.Objects
{
    class SEScene : SEObject
    {
        public SEScene(string _name) : base(_name)
        {
        }

#if DEBUG
        public override void CustomUpdate()
        {
            for (int i = 0; i < childs.Count; ++i)
            {
                if (SEKeyboardManager.IsKeyPressed(Keys.LeftControl) && childs[i].GetComponent().GetTransformComponent().GetRectangle().Contains(SEMouseManager.GetCursorPosition()))
                {
                    childs[i].SetShowBorder(true);
                }
                else
                {
                    childs[i].SetShowBorder(false);
                }
            }
        }
#endif
    }
}
