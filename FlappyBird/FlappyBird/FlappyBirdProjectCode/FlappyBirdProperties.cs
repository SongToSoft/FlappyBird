using SirenaEngineMG.SirenaSrc;
using SirenaEngineMG.SirenaSrc.Serialization;
using SirenaEngineMG.SirenaSrc.UI;
using System;

namespace SirenaEngineMG.FlappyBirdProjectCode
{
    static class FlappyBirdProperties
    {
        private static float groundHeigth;
        private static bool isBirdFly;
        private static bool isGameWaiting;
        private static int score, highScore;
        private static SELabel scoreLabel, highScoreLabel;
        private static SELabel textLabel;

        public static void Init()
        {
            score = 0;
            highScore = SerializationSystem.GetValue<int>("highScore.json");

            isBirdFly = false;
            isGameWaiting = true;

            highScoreLabel = new SELabel(SEResourcesManager.GetFontByName("PixelFontScore"));
            highScoreLabel.GetComponent().GetFontComponent().SetText(highScore.ToString());
            highScoreLabel.GetComponent().GetTransformComponent().SetPosition(SEProperties.GetGameWindowWidth() / 2, SEProperties.GetGameWindowHeight() / 8);

            scoreLabel = new SELabel(SEResourcesManager.GetFontByName("PixelFontScore"));
            scoreLabel.GetComponent().GetFontComponent().SetText(score.ToString());
            scoreLabel.GetComponent().GetTransformComponent().SetPosition(SEProperties.GetGameWindowWidth() / 2, SEProperties.GetGameWindowHeight() / 20);

            textLabel = new SELabel(SEResourcesManager.GetFontByName("PixelFontText"));
            textLabel.GetComponent().GetFontComponent().SetText("Tap on space to play game");
            textLabel.GetComponent().GetTransformComponent().SetPosition(150, 400);

            groundHeigth = 450;
        }

        public static void Reload()
        {
            if (SerializationSystem.GetValue<int>("highScore.json") < score)
            {
                SerializationSystem.SaveValue(score);
                highScore = score;
            }
            score = 0;
            isBirdFly = false;
            isGameWaiting = true;
            scoreLabel.GetComponent().GetFontComponent().SetText(score.ToString());
            highScoreLabel.GetComponent().GetFontComponent().SetText(highScore.ToString());
            textLabel.GetComponent().GetFontComponent().SetText("Tap on space to play game");
        }

        public static bool IsBirdFly()
        {
            return isBirdFly;
        }

        public static void SetBirdFlyStatus(bool status)
        {
            isBirdFly = status;
        }

        public static bool IsGameWaiting()
        {
            return isGameWaiting;
        }

        public static void SetGameWaitingStatus(bool status)
        {
            isGameWaiting = status;
        }

        public static void IncreaseScore()
        {
            ++score;
        }

        public static int GetScore()
        {
            return score;
        }

        public static void SetScore(int _score)
        {
            score = _score;
        }

        public static SELabel GetScoreLabel()
        {
            return scoreLabel;
        }

        public static SELabel GetHighScoreLabel()
        {
            return highScoreLabel;
        }

        public static SELabel GetTextLabel()
        {
            return textLabel;
        }

        public static float GetGroundHeigth()
        {
            return groundHeigth;
        }
    }
}
