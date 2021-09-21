using Framework.Architecture.Base;
using UnityEngine;
using Game.Module.Currency;
using Game.Module.Calculator;
using Game.Module.AudioPlayer;

namespace Game.Module.Analytic
{
    public class AnalyticController : BaseController<AnalyticController>
    {
        private AudioPlayerController _audioPlayerController;

        public void TrackGold(CurrencyMessage message)
        {
            Debug.Log($"Analytic Tracked Gold : {message.Gold}");
        }

        public void TrackResult(SubCalculatorMessage message)
        {
            Debug.Log($"Analytic Tracked Result : {message.Result}");
        }
    }
}
