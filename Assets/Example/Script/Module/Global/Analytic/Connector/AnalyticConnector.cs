using Framework.Architecture.Base;
using Game.Module.AudioPlayer;
using Game.Module.Calculator;
using Game.Module.Currency;

namespace Game.Module.Analytic
{
    public class AnalyticConnector : BaseConnector
    {
        private AnalyticController _analytic;

        protected override void Connect()
        {
            Subscribe<SubCalculatorMessage>(_analytic.TrackResult);
        }

        protected override void Disconnect()
        {
            Unsubscribe<SubCalculatorMessage>(_analytic.TrackResult);
        }
    }
}
