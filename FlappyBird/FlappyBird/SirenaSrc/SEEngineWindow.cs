using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SirenaEngineMG.SirenaSrc.Animations;
using SirenaEngineMG.SirenaSrc.Objects;
using SirenaEngineMG.SirenaSrc.UI;

namespace SirenaEngineMG.SirenaSrc
{
    public class SEEngineWindow : Game
    {
        private GraphicsDeviceManager engineGraphics;
        private SpriteBatch engineSpriteBatch;
        private SEPanel childsPanel, componentsPanel;
        private SEScene engineScene;

        public SEEngineWindow()
        {
            engineGraphics = new GraphicsDeviceManager(this);
            engineGraphics.PreferredBackBufferWidth = SEProperties.GetEngineWindowWidth();
            engineGraphics.PreferredBackBufferHeight = SEProperties.GetEngineWindowHeight();
            engineGraphics.IsFullScreen = SEProperties.IsEngineFullScreen();

            IsMouseVisible = SEProperties.IsEngineMouseVisible();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            SEResourcesManager.LoadSprite(Content, @"Debug\frame");

            engineScene = new SEScene("engineScene");
            childsPanel = new SEPanel(new Rectangle(0, 0, SEProperties.GetEngineWindowWidth() / 2, SEProperties.GetGameWindowHeight()), SEResourcesManager.GetSpriteByName(@"Debug\frame"));
            componentsPanel = new SEPanel(new Rectangle(SEProperties.GetEngineWindowWidth() / 2, 0, SEProperties.GetEngineWindowWidth() / 2, SEProperties.GetGameWindowHeight()), SEResourcesManager.GetSpriteByName(@"Debug\frame"));
            engineScene.AddChild(childsPanel);
            engineScene.AddChild(componentsPanel);
        }


        protected override void LoadContent()
        {
            engineSpriteBatch = new SpriteBatch(engineGraphics.GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            engineScene.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            engineGraphics.GraphicsDevice.Clear(Color.Black);

            engineSpriteBatch.Begin();

            engineScene.Draw(engineSpriteBatch);

            engineSpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
