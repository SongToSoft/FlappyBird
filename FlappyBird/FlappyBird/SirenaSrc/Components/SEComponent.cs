using System;
using System.Collections.Generic;

namespace SirenaEngineMG.SirenaSrc.Components
{
    class SEComponent
    {
        private Lazy<SESpriteComponent> spriteComponent;
        private Lazy<SETransformComponent> transformComponent;
        private Lazy<SEActionComponent> actionComponent;
        private Lazy<SEFontComponent> fontComponent;
        private Lazy<SEAudioSourceComponent> audioSourceComponent;
        private Lazy<SECircleColliderComponent> circleColliderComponent;

        public SEComponent()
        {
            spriteComponent = new Lazy<SESpriteComponent>();
            transformComponent = new Lazy<SETransformComponent>();
            actionComponent = new Lazy<SEActionComponent>();
            fontComponent = new Lazy<SEFontComponent>();
            audioSourceComponent = new Lazy<SEAudioSourceComponent>();
            circleColliderComponent = new Lazy<SECircleColliderComponent>();
        }

        public SESpriteComponent GetSpriteComponent()
        {
            return spriteComponent.Value;
        }

        public SETransformComponent GetTransformComponent()
        {
            return transformComponent.Value;
        }

        public SEActionComponent GetActionComponent()
        {
            return actionComponent.Value;
        }

        public SEFontComponent GetFontComponent()
        {
            return fontComponent.Value;
        }

        public SEAudioSourceComponent GetAudioSourceComponent()
        {
            return audioSourceComponent.Value;
        }

        public SECircleColliderComponent GetCircleColliderComponent()
        {
            return circleColliderComponent.Value;
        }
    }
}
