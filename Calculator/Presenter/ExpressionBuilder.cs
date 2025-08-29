using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.Presenter
{
    /// <summary>
    /// Interface used for test mocking - for more info check ExpressionBuilder
    /// </summary>
    public interface IExpressionBuilder
    {
        public event Action<string> UpdateTextDisplay;
        public string expression { get; set; }
        public bool onlyTwoDecimal { get; set; }
        void Reset(bool update = true);
        void CleanEntry();
        string? ValidateExpression();
        void AddComa();
        void AddPower(bool square = false);
        void AddDigit(string digit);
        void AddOperator(string oper);
        void AddFunction(string text);
        void AddLeftParenthesis();
        void AddRightParenthesis();
        void SetResult(double result);

    }


    public class ExpressionBuilder : IExpressionBuilder
    {
        private const char LEFT_PAREN = '(';
        private const char RIGHT_PAREN = ')';
        private const char COMA = ',';
        private const char PLUS = '+';
        private const char MINUS = '-';
        private const char POWER = '^';
        private const char ZERO = '0';

        private const string EMPTYSTRING = "";
        private const string ZEROSTRING = "0";


        public event Action<string> UpdateTextDisplay;
        public string expression { get; set; }
        private int openedParenthesis;
        private bool fractionalPart;
        public bool onlyTwoDecimal { get; set; }

        public ExpressionBuilder()
        {
            Reset();
        }

        public void Reset(bool update=true)
        {
            expression = ZEROSTRING;
            openedParenthesis = 0;
            fractionalPart = false;
            if (update)
                UpdateTextDisplay?.Invoke(expression);
        }

        private char lastCharacter()
        {
            return expression.Length > 0 ? expression[^1] : '\0';
        }

        public void CleanEntry()
        {
            var lastChar = lastCharacter();
            if (expression.Length > 1)
            {
                if (lastChar == RIGHT_PAREN)
                    openedParenthesis++;
                else if (lastChar == LEFT_PAREN)
                    openedParenthesis--;
                else if (lastChar == COMA)
                    fractionalPart = false;
                expression = expression.Substring(0, expression.Length - 1);
            }
            else
                expression = ZEROSTRING;

            if (expression.Length == 1 && (lastChar == PLUS || lastChar == MINUS))
                expression = ZEROSTRING;

            UpdateTextDisplay?.Invoke(expression);
        }


        public string? ValidateExpression()
        {
            if (lastCharacter() == POWER)
                return null;
            while (openedParenthesis > 0)
            {
                expression += RIGHT_PAREN;
                openedParenthesis--;
            }
            if (expression[0] == PLUS || expression[0] == MINUS)
            {
                expression = ZEROSTRING + expression;
            }
            return expression;
            
        }

        public void AddComa()
        {
            if (fractionalPart)
                return;
            if (expression.Length == 0 || !char.IsDigit(lastCharacter()))
            {
                expression += "0,";
                fractionalPart = true;

            }
            else if (expression[^1] != COMA)
            {
                expression += COMA;
                fractionalPart = true;
            }
            UpdateTextDisplay?.Invoke(expression);
        }

        public void AddPower(bool square = false)
        {
            if (!char.IsDigit(lastCharacter()))
                return;

            if (square)
            {
                expression += "^2";
                UpdateTextDisplay?.Invoke(expression);
                return;
            }

            string number = EMPTYSTRING;
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                char c = expression[i];
                if (char.IsDigit(c) || c == COMA || c == MINUS)
                    number = c + number;
                else
                {
                    openedParenthesis++;
                    expression = expression.Substring(0, i + 1) + LEFT_PAREN + number + POWER;
                    UpdateTextDisplay?.Invoke(expression);
                    return;
                }
            }
            if (number != EMPTYSTRING)
                number += RIGHT_PAREN;
            else
                openedParenthesis++;
            expression = LEFT_PAREN + number + POWER;
            UpdateTextDisplay?.Invoke(expression);
        }

        public void AddDigit(string digit)
        {
            var len = expression.Length;
            if (onlyTwoDecimal && len > 3 && Char.IsDigit(expression[len - 1]) && Char.IsDigit(expression[len - 2]) && expression[len - 3] == COMA)
                return;
            if (len == 1 && expression[0] == ZERO)
                expression = digit;
            else
                expression += digit;
            UpdateTextDisplay?.Invoke(expression);
        }

        public void AddOperator(string oper)
        {
            //if (expression.Length == 1 && expression[0] == ZERO)
            //{
            //    expression += oper;
            //    UpdateTextDisplay?.Invoke(expression);
            //    return;
            //}

            string last_symbol = expression[^1].ToString();

            if ("+-/÷*^,".Contains(last_symbol))
            {
                string text = expression;
                expression = text.Remove(expression.Length - 1) + oper;
            }
            else if (last_symbol == LEFT_PAREN.ToString())
            {
                expression += ZEROSTRING + oper;
            }
            else
            {
                expression += oper;
            }
            fractionalPart = false;
            UpdateTextDisplay?.Invoke(expression);
        }

        public void AddFunction(string text)
        {
            string number = EMPTYSTRING;
            for (int i = expression.Length-1; i>=0; i--)
            {
                char c = expression[i];
                if (char.IsDigit(c) || c == COMA)
                    number = c + number;
                else if (c == MINUS)
                {
                    expression = ZEROSTRING;
                    UpdateTextDisplay?.Invoke("Error: Number must be positive");
                    return;
                }
                else
                {
                    if (number != EMPTYSTRING)
                        number += RIGHT_PAREN;
                    else
                        openedParenthesis++;
                    expression = expression.Substring(0, i + 1) + text + LEFT_PAREN + number;
                    UpdateTextDisplay?.Invoke(expression);
                    return;
                }
            }
            if (number != EMPTYSTRING)
                number += RIGHT_PAREN;
            else
                openedParenthesis++;
            expression = text + LEFT_PAREN + number;
            UpdateTextDisplay?.Invoke(expression);
        }

        public void AddLeftParenthesis()
        {
            if (expression.Length == 1 && expression[0] == ZERO)
                expression = LEFT_PAREN.ToString();
            else
                expression += LEFT_PAREN;
            openedParenthesis++;
            UpdateTextDisplay?.Invoke(expression);
        }

        public void AddRightParenthesis()
        {
            if (openedParenthesis > 0)
            {
                expression += RIGHT_PAREN;
                openedParenthesis--;
                UpdateTextDisplay?.Invoke(expression);
            }
        }

        public void SetResult(double result)
        {
            Reset(false);
            expression = result.ToString();
            UpdateTextDisplay?.Invoke(expression);
        }
    }
}
