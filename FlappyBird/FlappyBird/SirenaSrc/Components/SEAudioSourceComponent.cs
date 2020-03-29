using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirenaEngineMG.SirenaSrc.Components
{
    class SEAudioSourceComponent : SESubComponent
    {
        private Dictionary<string, SoundEffect> sounds;
        private float volume;
        private float pitch;
        private float pan;

        public SEAudioSourceComponent() : base()
        {
            name = "audioSourceComponent";
            sounds = new Dictionary<string, SoundEffect>();
            volume = 1.0f;
            pitch = 0.0f;
            pan = 0.0f;
        }

        public void SetVolume(float _volume)
        {
            volume = _volume;
        }

        public float GetVolume()
        {
            return volume;
        }

        public void SetPitch(float _pitch)
        {
            pitch = _pitch;
        }

        public float GetPitch()
        {
            return pitch;
        }

        public void SetPan(float _pan)
        {
            pan = _pan;
        }

        public float GetPan()
        {
            return pan;
        }

        public void AddSound(string soundName)
        {
            sounds.Add(soundName, SEResourcesManager.GetSoundByName(soundName));
        }

        public void Play(string soundName)
        {
            SoundEffect outSound = null;
            sounds.TryGetValue(soundName, out outSound);
            if (outSound != null)
            {
                outSound.Play(volume, pitch, pan);
            }
        }
    }
}
