using Framework.Architecture.Base;
using Game.Module.AudioPlayer;
using Game.Module.Calculator;
using Game.Module.SubButton;
using UnityEngine;

namespace Game.Scene.Calculator
{
    public class CalculatorView : SceneView
    {
        [SerializeField]
        public SubCalculatorView Calculator;
        [SerializeField]
        public AudioPlayerView AudioPlayerView;
        [SerializeField]
        public ButtonView[] ButtonViews;
    }
}

