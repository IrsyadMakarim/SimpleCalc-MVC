using System.Collections;
using Framework.Architecture.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Module.SubButton
{
    public class ButtonView : BaseView
    {
        [SerializeField]
        private Text label;
        [SerializeField]
        private string value;
        [SerializeField]
        private CalculatorTextType _buttonType;
        [SerializeField]
        private Button _buttonNumber;
        [SerializeField]
        private Button _buttonString;
        [SerializeField]
        private Button _buttonResult;
        [SerializeField]
        private Button _buttonEmpty;

        public CalculatorTextType ButtonType => _buttonType;

        private void Start()
        {
            label.text = value;
        }

        public void InitNumber(UnityAction onAddNumber)
        {
            _buttonNumber.onClick.RemoveAllListeners();
            _buttonNumber.onClick.AddListener(onAddNumber);
        }

        public void InitOperator(UnityAction onAddOperator)
        {
            _buttonString.onClick.RemoveAllListeners();
            _buttonString.onClick.AddListener(onAddOperator);
        }

        public void InitResult(UnityAction onAddResult)
        {
            _buttonResult.onClick.RemoveAllListeners();
            _buttonResult.onClick.AddListener(onAddResult);
        }

        public void InitEmpty(UnityAction onAddEmpty)
        {
            _buttonEmpty.onClick.RemoveAllListeners();
            _buttonEmpty.onClick.AddListener(onAddEmpty);
        }

        public string GetTextLabel()
        {
            return value;
        }
    }

    public enum CalculatorTextType
    {
        Number,
        Operator,
        Result,
        Empty
    }
}