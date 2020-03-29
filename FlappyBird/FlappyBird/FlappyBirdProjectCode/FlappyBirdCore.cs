using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SirenaEngineMG.SirenaSrc;

namespace SirenaEngineMG.FlappyBirdProjectCode
{
    public class FlappyBirdCore : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public FlappyBirdCore()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = SEProperties.GetGameWindowWidth();
            graphics.PreferredBackBufferHeight = SEProperties.GetGameWindowHeight();
            graphics.IsFullScreen = SEProperties.IsGameFullScreen();
            graphics.PreferMultiSampling = true;

            IsMouseVisible = SEProperties.IsGameMouseVisible();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
#if DEBUG
            SEResourcesManager.LoadSprite(Content, @"UI\PNG\yellow_panel");
            SEResourcesManager.LoadSprite(Content, @"Debug\debug");
            SEResourcesManager.LoadSprite(Content, @"Debug\debug_2");
            SEResourcesManager.LoadSprite(Content, @"Debug\red_border");
            SEResourcesManager.LoadSprite(Content, @"Debug\circle_red");
#endif

            SEResourcesManager.LoadSprite(Content, "yellowbird-downflap");
            SEResourcesManager.LoadSprite(Content, "yellowbird-midflap");
            SEResourcesManager.LoadSprite(Content, "yellowbird-upflap");
            SEResourcesManager.LoadSprite(Content, "background-day");
            SEResourcesManager.LoadSprite(Content, "pipe-green");
            SEResourcesManager.LoadSprite(Content, "base");

            SEResourcesManager.LoadSprite(Content, @"UI\PNG\blue_button00");

            SEResourcesManager.LoadFont(Content, "PixelFontScore");
            SEResourcesManager.LoadFont(Content, "PixelFontText");
            SEResourcesManager.LoadFont(Content, "ButtonText");

            SEResourcesManager.LoadSound(Content, @"FlappyBird\sfx_die");
            SEResourcesManager.LoadSound(Content, @"FlappyBird\sfx_hit");
            SEResourcesManager.LoadSound(Content, @"FlappyBird\sfx_point");
            SEResourcesManager.LoadSound(Content, @"FlappyBird\sfx_swooshing");
            SEResourcesManager.LoadSound(Content, @"FlappyBird\sfx_wing");

            FlappyBirdMainGameScene flappyBirdScene = new FlappyBirdMainGameScene("flappyBirdScene");
            SESceneManager.AddScene(flappyBirdScene);
            SESceneManager.LoadScene(flappyBirdScene.GetName());
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
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

            SESceneManager.GetCurrentScene().Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.BackToFront);

            SESceneManager.GetCurrentScene().Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
