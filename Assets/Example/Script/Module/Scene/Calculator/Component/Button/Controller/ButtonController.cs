using System.Collections;
using Framework.Architecture.Base;
using Game.Module.Calculator;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Module.SubButton
{ 
    public class ButtonController : BaseController<ButtonController>
    {
        private SubCalculatorController _subCalc;

        public override IEnumerator Initialize()
        {
            return base.Initialize();
        }
        public void SetView(ButtonView view)
        {
            if (view.ButtonType == CalculatorTextType.Operator)
            {
                view.InitOperator(() => OnTappedOperator(view.GetTextLabel()));
            }
            else if (view.ButtonType == CalculatorTextType.Number)
            {
                view.InitNumber(() => OnTappedNumber(int.Parse(view.GetTextLabel())));
            }         
            else if (view.ButtonType == CalculatorTextType.Result)
            {
                view.InitResult(OnTappedHasil); 
            }
            else
            {
                view.InitEmpty(OnTappedEmpty);
            }
        }

        public void OnTappedNumber(int value)
        {
            Debug.Log("Tapped : " + value);
            _subCalc.ClickNumber(value);
        }

        public void OnTappedOperator(string value)
        {
            Debug.Log("Tapped : " + value);
            _subCalc.ClickOperation(value);
        }

        public void OnTappedHasil()
        {
            _subCalc.ClickHasil();
        }    

        public void OnTappedEmpty()
        {
            _subCalc.ClickEmpty();
        }    
    }
}

