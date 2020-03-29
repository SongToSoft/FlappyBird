using System.Collections.Generic;
using SirenaEngineMG.SirenaSrc.Animations;

namespace SirenaEngineMG.SirenaSrc.Components
{
    class SEActionComponent : SESubComponent
    {
        private Dictionary<string, SEAction> actions;

        public SEActionComponent() : base()
        {
            name = "actionComponent";
            actions = new Dictionary<string, SEAction>();
        }

        public void AddAction(string animationName, SEAction animation)
        {
            actions.Add(animationName, animation);
        }

        public void StartAction(string animationName)
        {
            SEAction animation;
            actions.TryGetValue(animationName, out animation);
            if (animation != null)
            {
                animation.Play();
            }
        }
    }
}
