using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SirenaEngineMG.SirenaSrc.Components;

namespace SirenaEngineMG.SirenaSrc.Objects
{
    class SEObject
    {
        protected string name;
        protected SEComponent component;
        protected bool isEnable;
        protected List<SEObject> childs;
        protected bool dontDestroyOnLoad;
#if DEBUG
        protected bool showBorder;
        protected Texture2D border;
#endif

        public SEObject(string _name)
        {
            name = _name;
            isEnable = true;
            childs = new List<SEObject>();
            component = new SEComponent();
            dontDestroyOnLoad = false;
#if DEBUG
            showBorder = false;
            border = SEResourcesManager.GetSpriteByName(@"Debug\red_border");
#endif
        }
        public void RemoveChilds()
        {
            for (int i = 0; i < childs.Count; ++i)
            {
                childs.Remove(childs[i]);
            }
        }

        public void DontDestroyOnLoad()
        {
            dontDestroyOnLoad = true;
        }

        public void DestroyOnLoad()
        {
            dontDestroyOnLoad = false;
        }

        public bool IsDestroyOnLoad()
        {
            return dontDestroyOnLoad;
        }

        public virtual void Reload() { }

        public string GetName()
        {
            return name;
        }

        public SEComponent GetComponent()
        {
            return component;
        }

        public bool GetEnable()
        {
            return isEnable;
        }

        public void SetEnable(bool status)
        {
            isEnable = status;
        }

        public List<SEObject> GetChilds()
        {
            return childs;
        }

        public void AddChild(SEObject child)
        {
            childs.Add(child);
        }

        public void RemoveChild(SEObject child)
        {
            childs.Remove(child);
        }

        public virtual void Update()
        {
            if (isEnable)
            {
                CustomUpdate();
                for (int i = 0; i < childs.Count; ++i)
                {
                    childs[i].Update();
                }
            }
        }

        public virtual void CustomUpdate() { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isEnable)
            {
                CustomDraw(spriteBatch);
                for (int i = 0; i < childs.Count; ++i)
                {
                    childs[i].Draw(spriteBatch);
                }
            }
        }

        public virtual void CustomDraw(SpriteBatch spriteBatch)
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
#if DEBUG
            DrawBorder(spriteBatch);
#endif
        }

#if DEBUG
        public void SetShowBorder(bool status)
        {
            showBorder = status;
        }

        public bool GetShowBorder()
        {
            return showBorder;
        }

        public void DrawBorder(SpriteBatch spriteBatch)
        {
            if (showBorder)
            {
                spriteBatch.Draw(border, component.GetTransformComponent().GetRectangle(), component.GetSpriteComponent().GetColor());
            }
        }

        public void PrintNameOfChilds()
        {
            for (int i = 0; i < childs.Count; ++i)
            {
                Console.WriteLine(i + " " + childs[i].GetName());
            }
        }
#endif
    }
}
