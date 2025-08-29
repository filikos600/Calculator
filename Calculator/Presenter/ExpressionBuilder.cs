using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.Presenter
{
    public class ExpressionBuilder
    {
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
            expression = "0";
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
                if (lastChar == ')')
                    openedParenthesis++;
                else if (lastChar == '(')
                    openedParenthesis--;
                else if (lastChar == ',')
                    fractionalPart = false;
                expression = expression.Substring(0, expression.Length - 1);
            }
            else
                expression = "0";

            if (expression.Length == 1 && (lastChar == '-' || lastChar == '+'))
                expression = "0";

            UpdateTextDisplay?.Invoke(expression);
        }


        public string? ValidateExpression()
        {
            if (lastCharacter() == '^')
                return null;
            while (openedParenthesis > 0)
            {
                expression += ")";
                openedParenthesis--;
            }
            if (expression[0] == '+' || expression[0] == '-')
            {
                expression = "0" + expression;
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
            else if (expression[^1] != ',')
            {
                expression += ",";
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

            string number = "";
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                char c = expression[i];
                if (char.IsDigit(c) || c == ',' || c =='-')
                    number = c + number;
                else
                {
                    openedParenthesis++;
                    expression = expression.Substring(0, i + 1) + "(" + number + "^";
                    UpdateTextDisplay?.Invoke(expression);
                    return;
                }
            }
            if (number != "")
                number += ")";
            else
                openedParenthesis++;
            expression = "(" + number + "^";
            UpdateTextDisplay?.Invoke(expression);
        }

        public void AddDigit(string digit)
        {
            var len = expression.Length;
            if (onlyTwoDecimal && len > 3 && Char.IsDigit(expression[len - 1]) && Char.IsDigit(expression[len - 2]) && expression[len - 3] == ',')
                return;
            if (len == 1 && expression[0] == '0')
                expression = digit;
            else
                expression += digit;
            UpdateTextDisplay?.Invoke(expression);
        }

        public void AddOperator(string oper)
        {
            //if (expression.Length == 1 && expression[0] == '0')
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
            else if (last_symbol == "(")
            {
                expression += "0" + oper;
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
            string number = "";
            for (int i = expression.Length-1; i>=0; i--)
            {
                char c = expression[i];
                if (char.IsDigit(c) || c == ',')
                    number = c + number;
                else if (c == '-')
                {
                    UpdateTextDisplay?.Invoke("Error: Number must be positive");
                    return;
                }
                else
                {
                    if (number != "")
                        number += ")";
                    else
                        openedParenthesis++;
                    expression = expression.Substring(0, i + 1) + text + "(" + number;
                    UpdateTextDisplay?.Invoke(expression);
                    return;
                }
            }
            if (number != "")
                number += ")";
            else
                openedParenthesis++;
            expression = text + "(" + number;
            UpdateTextDisplay?.Invoke(expression);
        }

        public void AddLeftParenthesis()
        {
            if (expression.Length == 1 && expression[0] =='0')
                expression = "(";
            else
                expression += "(";
            openedParenthesis++;
            UpdateTextDisplay?.Invoke(expression);
        }

        public void AddRightParenthesis()
        {
            if (openedParenthesis > 0)
            {
                expression += ")";
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
