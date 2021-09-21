using System.Collections;
using System.Collections.Generic;
using Framework.Architecture.Base;
using Game.Module.Calculator;
using UnityEngine;

namespace Game.Module.AudioPlayer
{
    public class AudioPlayerController : ObjectController<AudioPlayerController, AudioPlayerView>
    {
        public override IEnumerator Initialize()
        {
            return base.Initialize();
        }

        public void PlayAudioClip()
        {
            _view.PlaySound();
        }

        public void ConnectButtonToAudio(AudioPlayerController controller)
        {
            PlayAudioClip();
        }
    }
}

