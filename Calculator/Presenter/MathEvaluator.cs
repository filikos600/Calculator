using Calculator.Model;
using MathNet.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Presenter
{
    /// <summary>
    /// Interface used for test mocking - for more info check <see cref="ExchangeEvaluator"/.
    /// </summary>
    public interface IMathEvaluator
    {

        Task<double> Evaluate(string expression);
        List<string> ShuntingYardAlgorithm(List<string> tokens);
        static long Factorial(int n) => throw new NotImplementedException();
    }


    /// <summary>
    /// Evaluates given mathematic expression by tokenizing it, using Shunting Yard algorithm, transforming it into RPN and then caluclating the result
    /// </summary>
    public class MathEvaluator : IMathEvaluator
    {
        private readonly IDatabaseManager databaseManager;

        private const string LEFT_PAREN = "(";
        private const string RIGHT_PAREN = ")";
        private const string PLUS = "+";
        private const string MINUS = "-";
        private const string MULTIPLY = "x";
        private const string DIVIDE = "÷";
        private const string POWER = "^";

        private const string FACTORIAL = "!";
        private const string SQRT = "√";

        private const string OPERATORS = "+-x÷^";
        private const string FUNCTIONS = "!√";

        public MathEvaluator(IDatabaseManager databaseManager)
        {
            this.databaseManager = databaseManager;
        }

        /// <summary>
        /// Tries to evaluate given expression, TODO throws and error if fails in any way
        /// </summary>
        /// <param name="expression"> given expression</param>
        /// <returns>evaluated expression as a double</returns>
        public async Task<double> Evaluate(string expression)
        {
            var tokens = Tokenize(expression);
            var rpn = ShuntingYardAlgorithm(tokens);
            var result = CalulcateReversePolishNotation(rpn);

            try
            {
                await Task.Run(() => databaseManager.AddOperation(expression, result, DBOperationTypes.math.ToString()));
            }
            catch (Exception exDB)
            {
                MessageBox.Show("DataBase Error:\n" + exDB.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result;
        }

        /// <summary>
        /// A Shunting Yard Algorithm that parses expression to a Reverse Polish notation.
        /// Based on "The algorithm in detail" section from https://en.wikipedia.org/wiki/Shunting_yard_algorithm.
        /// </summary>
        /// <param name="tokens">list of tokens to be parsed.</param>
        /// <returns>Reverse Polish notation as a string.</returns>
        public List<string> ShuntingYardAlgorithm(List<string> tokens)
        {
            var precedence = new Dictionary<string, int>();
            precedence.Add(RIGHT_PAREN, 5);
            precedence.Add(LEFT_PAREN, 5);
            precedence.Add(POWER, 4);
            precedence.Add(MULTIPLY, 3);
            precedence.Add(DIVIDE, 3);
            precedence.Add(MINUS, 2);
            precedence.Add(PLUS, 2);
            var operatorsStack = new Stack<string>();
            var outputQueue =new List<string>();

            foreach (string token in tokens) 
            {
                double i = 0;
                if (token == "")
                    continue;
                else if (double.TryParse(token, out i))
                {
                    outputQueue.Add(token); 
                }
                else if (FUNCTIONS.Contains(token)) 
                {
                    operatorsStack.Push(token);
                }
                else if (OPERATORS.Contains(token)) 
                {
                    string topOfStack = "";
                    while (operatorsStack.TryPeek(out topOfStack)
                        && OPERATORS.Contains(topOfStack)
                        && (precedence[topOfStack] > precedence[token]
                            || precedence[topOfStack] == precedence[token]
                                && OPERATORS.Contains(topOfStack)))
                    {
                        outputQueue.Add(operatorsStack.Pop());
                    }
                    operatorsStack.Push(token);
                }
                else if (token == LEFT_PAREN)
                {
                    operatorsStack.Push(token);
                }
                else if (token == RIGHT_PAREN) 
                {
                    string topOfStack = "";
                    while (operatorsStack.TryPeek(out topOfStack) && topOfStack != LEFT_PAREN) 
                    {
                        outputQueue.Add(operatorsStack.Pop());
                    }
                    if (operatorsStack.TryPeek(out topOfStack) && topOfStack == LEFT_PAREN)
                        operatorsStack.Pop();
                    else
                        throw new InvalidOperationException("missing ')'");
                    if (operatorsStack.TryPeek(out topOfStack) && FUNCTIONS.Contains(topOfStack))
                        outputQueue.Add(operatorsStack.Pop()); 

                }
            }
            while (operatorsStack.Count > 0)
            {
                var oper = operatorsStack.Pop();
                if (oper == LEFT_PAREN)
                    throw new InvalidOperationException("unclosed left parenthesis");
                outputQueue.Add(oper);
            }

            return outputQueue;
        }

        /// <summary>
        /// Calcualte two numbers using given operator.
        /// </summary>
        /// <param name="firstOperand">First number.</param>
        /// <param name="secondOperand">Second number.</param>
        /// <param name="oper">Operator.</param>
        /// <returns>Result of the operation</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private double CalulcateNumber(string firstOperand, string secondOperand, string oper)
        {
            var number1 = Convert.ToDouble(firstOperand);
            var number2 = Convert.ToDouble(secondOperand);
            switch (oper)
            {
                case PLUS:
                    return number1 + number2;
                case MINUS:
                    return number1 - number2;
                case MULTIPLY:
                    return number1 * number2;
                case DIVIDE:
                    return number1 / number2;
                case POWER:
                    return Math.Pow(number1,number2);
            }
            throw new InvalidOperationException($"Unknown operator: {oper}");
        }

        /// <summary>
        /// Calcualte factorial from integer.
        /// </summary>
        /// <param name="n">Input number.</param>
        /// <returns>Result of the operation.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static long Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("Negative numbers are not allowed.");
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }


        /// <summary>
        /// Calculate the function (sqrt or factorial) for given token.
        /// </summary>
        /// <param name="operand">Input token.</param>
        /// <param name="oper">Function.</param>
        /// <returns>Result of the operation.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private double CalulcateNumber(string operand, string oper)
        {
            var number = Convert.ToDouble(operand);
            if (oper == FACTORIAL)
            {
                if (Math.Abs((int)number - number) < 0.00001)
                    return Factorial((int)number);
                else
                    return SpecialFunctions.Gamma(number + 1);
            }
            else if (oper == SQRT)
                return Math.Sqrt(number);
            throw new InvalidOperationException($"Unknown operator: {oper}");
        }

        /// <summary>
        /// Calculate Reverse Polish Notation
        /// </summary>
        /// <param name="RPN">List of tokens</param>
        /// <returns>Result as a number</returns>
        /// <exception cref="ArgumentException"></exception>
        private double CalulcateReversePolishNotation(List<string> RPN)
        {
            var stack = new Stack<string>();
            foreach(string token in RPN)
            {
                double i = 0d;
                if (double.TryParse(token, out i))
                    stack.Push(token);
                else
                {
                    string firstOperator = stack.Pop();
                    if (token == FACTORIAL || token == SQRT)
                    {
                        var result = CalulcateNumber(firstOperator, token);
                        stack.Push(result.ToString());
                    }
                    else
                    {
                        var secondOperator = stack.Pop();
                        var result = CalulcateNumber(secondOperator, firstOperator, token);
                        stack.Push(result.ToString());
                    }
                        
                }
            }

            if (stack.Count != 1)
            {
                throw new ArgumentException("Invalid stack size at the end of expression");
            }

            return Convert.ToDouble(stack.Pop());
        }


        /// <summary>
        /// Tokenize string expression into list of tokens, where token is a number or an operator
        /// </summary>
        /// <param name="expression">given expression</param>
        /// <returns>List of tokens where each value represents a number or operator in order</returns>
        private List<string> Tokenize(string expression)
        {
            var tokens = new List<string>();
            string currentToken = "";

            for (int i = 0; i<expression.Length; i++)
            {
                char c = expression[i];
                if (char.IsDigit(c) || c == ',')
                {
                    currentToken += c;
                }
                else if (c == 'f' && expression.Substring(i,4) == "fact" )
                {
                    currentToken += "!";
                    i += 3;
                }
                else if (c == 's' && expression.Substring(i, 4) == "sqrt")
                {
                    currentToken += "√";
                    i += 3;
                }
                else
                {
                    tokens.Add(currentToken);
                    tokens.Add(c.ToString());
                    currentToken = "";
                }
            }

            if (currentToken != "")
                tokens.Add(currentToken);

            return tokens;
        }

    }
}
