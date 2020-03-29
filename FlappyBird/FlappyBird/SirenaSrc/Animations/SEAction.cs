namespace SirenaEngineMG.SirenaSrc.Animations
{
    delegate void Effect();

    class SEAction
    {
        private Effect action;

        public void SetAction(Effect _action)
        {
            action = _action;
        }

        public void Play()
        {
            action();
        }
    }
}
