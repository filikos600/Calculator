using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator
{
    public class ExpressionBuilder
    {
        private IEvaluator evaluator;
        public event Action<string> UpdateTextDisplay;
        public string expression { get; set; }
        private char? last_character;
        private int openedParenthesis;
        private bool fractionalPart;

        public ExpressionBuilder()      //TODO depedency inejctions
        {
            Reset();
            evaluator = new BasicEvaluator();
           
        }

        public void Reset(bool update=true)
        {
            expression = "0";
            last_character = null;
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
            if (expression.Length > 1)
            {
                if (lastCharacter() == ')')
                    openedParenthesis++;
                else if (lastCharacter() == '(')
                    openedParenthesis--;
                expression = expression.Substring(0, expression.Length - 1);
            }
            else
                expression = "0";

            if (expression.Length == 1 && ((lastCharacter() == '-' || lastCharacter() == '+')))
                expression = "0";

            UpdateTextDisplay?.Invoke(expression);
        }


        public double? EvaluateExpression()
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

            double result;
            string old_expression = expression;

            try
            {
                result = evaluator.Evaluate(expression);
                SetResult(result);
                return result;
            }
            catch(Exception ex)
            {
                Reset();
                UpdateTextDisplay?.Invoke(ex.ToString());
                return null;
            }
            
        }

        public void AddComa()
        {
            if (fractionalPart)
                return;
            if (expression.Length == 0 || !Char.IsDigit(lastCharacter()))
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
            if (!Char.IsDigit(lastCharacter()))
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
                if (Char.IsDigit(c) || c == ',' || c =='-')
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
            if (expression.Length == 1 && expression[0] == '0')
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
                if (Char.IsDigit(c) || c == ',')
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
