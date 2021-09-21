using System.Collections;
using Framework.Architecture.Base;
using Framework.Architecture.Pattern.MVC;
using Game.Boot;
using Game.Module.Analytic;
using Game.Module.AudioPlayer;
using Game.Module.Calculator;
using Game.Module.SubButton;
using UnityEditor;
using UnityEngine;

namespace Game.Scene.Calculator
{
    public class CalculatorLauncher : SceneLauncher<CalculatorLauncher, CalculatorView>
    {
        private SubCalculatorController _calcController;
        private AudioPlayerController _audioPlayerController;
        private ButtonController _buttonController;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new AudioPlayerConnector()
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new AudioPlayerController(),
                new ButtonController(),
                new SubCalculatorController()
            };
        }

        protected override string GetSceneName()
        {
            return "Calculator";
        }

        protected override CalculatorView GetSceneView()
        {
            var prefab = AssetDatabase.LoadAssetAtPath<CalculatorView>("Assets/Example/Resources/CalculatorView.prefab");
            CalculatorView view = Instantiate(prefab);
            return view;
        }

        protected override IEnumerator InitSceneObject()
        {
            _calcController.SetView(_view.Calculator);
            _audioPlayerController.SetView(_view.AudioPlayerView);
            for (int i = 0; i < _view.ButtonViews.Length; i++)
            {
                _buttonController.SetView(_view.ButtonViews[i]);
            }
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}


