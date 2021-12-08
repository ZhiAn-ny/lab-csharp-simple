using System;
using ComplexAlgebra;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';

        private Complex _value;
        private char _operation;

        public Complex Value
        {
            get => _value; 
            set
            {
                _value = value;
            }
        }

        private Complex Result { get; set; }

        public char Operation
        {
            get => _operation;
            set
            {
                ComputeResult();
                _operation = value;
                Value = null;
            }
        }

        public void Reset()
        {
            Value = null;
            _operation = '\0';
        }

        public void ComputeResult()
        {
            if (Operation.Equals(OperationPlus) && Result != null)
            {
                Result = Result.Plus(Value);
            }
            else if (Operation.Equals(OperationMinus) && Result != null)
            {
                Result = Result.Minus(Value);
            }
            else
            {
                Result = Value;
            }
            _operation = '\0';
            Value = Result;
        }
        
        public override String ToString()
        {
            String val = Value == null ? "null" : Value.ToString();
            String op = Operation == '\0' ? "null" : _operation.ToString();
            return $"{val}, {op}";
        }
        
    }
}