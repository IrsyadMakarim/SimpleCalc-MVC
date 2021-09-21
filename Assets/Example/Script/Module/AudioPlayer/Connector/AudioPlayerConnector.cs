using System.Collections;
using Framework.Architecture.Base;
using Game.Module.Calculator;
using UnityEngine;

namespace Game.Module.AudioPlayer
{
    public class AudioPlayerConnector : BaseConnector
    {
        private AudioPlayerController _audioPlayerController;

        protected override void Connect()
        {
            Subscribe<AudioPlayerController>(_audioPlayerController.ConnectButtonToAudio);
        }

        protected override void Disconnect()
        {
            Unsubscribe<AudioPlayerController>(_audioPlayerController.ConnectButtonToAudio);
        }
    }
}