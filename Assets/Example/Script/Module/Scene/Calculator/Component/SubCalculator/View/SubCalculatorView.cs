using System.Collections;
using System.Collections.Generic;
using Framework.Architecture.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Module.Calculator
{
    public class SubCalculatorView : ObjectView<ISubCalculatorModel>
    {
        [SerializeField]
        protected Text _inputText;

        protected override void InitRenderModel(ISubCalculatorModel model)
        {
            _inputText.text = model.Temp.ToString();
        }

        protected override void UpdateRenderModel(ISubCalculatorModel model)
        {
            _inputText.text = model.Temp.ToString();
        }
    }
}

