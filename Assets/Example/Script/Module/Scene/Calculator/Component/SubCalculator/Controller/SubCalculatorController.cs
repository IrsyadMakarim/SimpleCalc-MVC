using System.Collections;
using Framework.Architecture.Base;
using Game.Module.AudioPlayer;

namespace Game.Module.Calculator
{
    public class SubCalculatorController : ObjectController<SubCalculatorController, SubCalculatorModel, ISubCalculatorModel, SubCalculatorView>
    {
        public override IEnumerator Initialize()
        {
            return base.Initialize();
        }

        public override void SetView(SubCalculatorView view)
        {
            base.SetView(view);
        }

        public void ClickNumber(int val)
        {
            _model.ClickNumber(val);
            Publish<AudioPlayerController>(new AudioPlayerController());
        }

        public void ClickOperation(string val)
        {
            _model.ClickOperation(val);
            Publish<AudioPlayerController>(new AudioPlayerController());
        }

        public void ClickHasil()
        {
            _model.ClickHasil();
            Publish<SubCalculatorMessage>(new SubCalculatorMessage(_model.Result));
            Publish<AudioPlayerController>(new AudioPlayerController());
        }

        public void ClickEmpty()
        {
            _model.ClickEmpty();
            Publish<AudioPlayerController>(new AudioPlayerController());
        }
    }
}