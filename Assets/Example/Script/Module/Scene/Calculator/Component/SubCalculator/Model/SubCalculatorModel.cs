using System.Collections;
using Framework.Architecture.Base;
using UnityEngine;

namespace Game.Module.Calculator
{
    public interface ISubCalculatorModel : IBaseModel
    {
        float Input { get; }
        float AnotherInput { get; }
        float Result { get; }
        string Operation { get; }
        string CurrInput { get; }
        bool HasilPressed { get; }
        float Temp { get; }
    }

    public class SubCalculatorModel : BaseModel, ISubCalculatorModel
    {
        public float Input { get; protected set; } 
        public float AnotherInput { get; protected set; }
        public float Result { get; protected set; } = 0;
        public string Operation { get; protected set; }
        public string CurrInput { get; protected set; }
        public bool HasilPressed { get; protected set; }
        public float Temp { get; protected set; } = 0;

        public void ClickHasil()
        {
            Calculate();
            HasilPressed = true;
            SetDataAsDirty();
        }

        public void ClickNumber(int val)
        {
            if (!string.IsNullOrEmpty(CurrInput))
            {
                if(CurrInput.Length < 10)
                {
                    CurrInput += val;
                    SetDataAsDirty();
                }
            }
            else
            {
                CurrInput = val.ToString();
                SetDataAsDirty();
            }
            Temp = float.Parse(CurrInput);
            SetDataAsDirty();
        }

        public void ClickOperation(string val)
        {
            if (Input == 0)
            {
                SetCurrentInput();
                Operation = val;
            }
            else
            {
                if (HasilPressed)
                {
                    HasilPressed = false;
                    Operation = val;
                    AnotherInput = 0;
                }
                else
                {
                    if (Operation.Equals(val, System.StringComparison.OrdinalIgnoreCase))
                    {
                        Calculate();
                    }
                    else;
                    {
                        Operation = val;
                        AnotherInput = 0;
                    }
                }
            }
            SetDataAsDirty();
        }

        public void Calculate()
        {
            if (Input != 0 && !string.IsNullOrEmpty(Operation))
            {
                SetCurrentInput();
                switch (Operation)
                {
                    case "+":
                        CalculatePlus();
                        break;
                    case "-":
                        CalculateMinus();
                        break;
                    case "*":
                        CalculatePerkalian();
                        break;
                    case "/":
                        CalculatePembagian();
                        break;
                }

                Debug.Log("Result : " + Result);
                Input = Result;
                Temp = Result;
                SetDataAsDirty();
            }
        }

        public void SetCurrentInput()
        {
            if (!string.IsNullOrEmpty(CurrInput))
            {
                if (Input == 0)
                {
                    Input = int.Parse(CurrInput);
                    SetDataAsDirty();
                }
                else
                {
                    AnotherInput = int.Parse(CurrInput);
                    SetDataAsDirty();
                }
                CurrInput = "";
                SetDataAsDirty();
            }
        }

        public void ClickEmpty()
        {
            Input = 0;
            AnotherInput = 0;
            Result = 0;
            Operation = "";
            CurrInput = "";
            Temp = 0;
            SetDataAsDirty();
        }

        public void CalculatePlus()
        {
            Result = Input + AnotherInput;
            SetDataAsDirty();
        }

        public void CalculateMinus()
        {
            Result = Input - AnotherInput;
            SetDataAsDirty();
        }

        public void CalculatePerkalian()
        {
            Result = Input * AnotherInput;
            SetDataAsDirty();
        }

        public void CalculatePembagian()
        {
            Result = Input / AnotherInput;
            SetDataAsDirty();
        }
    }
}