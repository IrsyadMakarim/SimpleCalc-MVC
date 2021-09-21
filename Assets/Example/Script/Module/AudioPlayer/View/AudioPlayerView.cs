using System.Collections;
using System.Collections.Generic;
using Framework.Architecture.Base;
using UnityEngine;

namespace Game.Module.AudioPlayer
{
    public class AudioPlayerView : BaseView
    {
        [SerializeField]
        private AudioSource _audioSource;

        public void PlaySound()
        {
            if (_audioSource == null)
            {
                GetAudioSource();
            }
            _audioSource.Play();
        }

        private void GetAudioSource()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
}


