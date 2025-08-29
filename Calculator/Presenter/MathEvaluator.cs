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
    public class MathEvaluator
    {

        private const string OPERATORS = "+-x÷^";
        private const string FUNCTIONS = "!√";

        private DatabaseManager databaseManager;

        public MathEvaluator()
        {
            databaseManager = new DatabaseManager();
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
        /// A Shunting Yard Algorithm that parses expression to a Reverse Polish notation
        /// Based on "The algorithm in detail" section from https://en.wikipedia.org/wiki/Shunting_yard_algorithm
        /// </summary>
        /// <param name="tokens">list of tokens to be parsed</param>
        /// <returns>string in Reverse Polish notation</returns>
        public List<string> ShuntingYardAlgorithm(List<string> tokens)
        {
            var precedence = new Dictionary<string, int>();
            precedence.Add("(", 5);
            precedence.Add(")", 5);
            precedence.Add("^", 4);
            precedence.Add("x", 3);
            precedence.Add("÷", 3);
            precedence.Add("-", 2);
            precedence.Add("+", 2);
            var operatorsStack = new Stack<string>();
            var outputQueue =new List<string>();

            foreach (string token in tokens) // read a token
            {
                double i = 0;
                if (token == "")
                    continue;
                else if (double.TryParse(token, out i)) // if a number 
                {
                    outputQueue.Add(token);   // put it into the output queue
                }
                else if (FUNCTIONS.Contains(token)) // if a function
                {
                    operatorsStack.Push(token); // push it onto the operator stack 
                }
                else if (OPERATORS.Contains(token)) //if an operator o1
                {
                    string topOfStack = "";
                    //while there is an operator o2 at the top of the operator stack which is not a left parenthesis, and o2 has greater precedence than o1 or: o1 and o2 have the same precedence and o1 is left - associative))
                    while (operatorsStack.TryPeek(out topOfStack)
                        && OPERATORS.Contains(topOfStack)
                        && (precedence[topOfStack] > precedence[token]
                            || precedence[topOfStack] == precedence[token]
                                && OPERATORS.Contains(topOfStack)))
                    {
                        outputQueue.Add(operatorsStack.Pop()); //Pop operators from the operator stack into the output queue
                    }
                    operatorsStack.Push(token); //Push the current operator onto the operator stack
                }
                else if (token == "(") // if left parenthesis
                {
                    operatorsStack.Push(token); // push it onto the operator stack
                }
                else if (token == ")") // if right parenthesis
                {
                    string topOfStack = "";
                    while (operatorsStack.TryPeek(out topOfStack) && topOfStack != "(") // while the operator at the top of the operator stack is not a left parenthesis
                    {
                        outputQueue.Add(operatorsStack.Pop()); // pop the operator from the operator stack into the output queue
                    }
                    if (operatorsStack.TryPeek(out topOfStack) && topOfStack == "(") // there is a left parenthesis at the top of the operator stack
                        operatorsStack.Pop(); // pop the left parenthesis from the operator stack and discard it
                    else
                        throw new InvalidOperationException("missing ')'"); //assert the operator stack is not empty; assert there is a left parenthesis at the top of the operator stack
                    if (operatorsStack.TryPeek(out topOfStack) && FUNCTIONS.Contains(topOfStack)) // if there is a function token at the top of the operator stack
                        outputQueue.Add(operatorsStack.Pop());   //  pop the function from the operator stack into the output queue

                }
            }
            while (operatorsStack.Count > 0) // while there are tokens on the operator stack
            {
                var oper = operatorsStack.Pop();
                if (oper == "(")
                    throw new InvalidOperationException("unclosed left parenthesis"); // assert the operator on top of the stack is not a left parenthesis
                outputQueue.Add(oper); // pop the operator from the operator stack onto the output queue
            }

            return outputQueue;
        }

        private double CalulcateNumber(string firstOperand, string secondOperand, string oper)
        {
            var number1 = Convert.ToDouble(firstOperand);
            var number2 = Convert.ToDouble(secondOperand);
            switch (oper)
            {
                case "+":
                    return number1 + number2;
                case "-":
                    return number1 - number2;
                case "x":
                    return number1 * number2;
                case "÷":
                    return number1 / number2;
                case "^":
                    return Math.Pow(number1,number2);
            }
            throw new InvalidOperationException($"Unknown operator: {oper}");
        }

        public static long Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("Negative numbers are not allowed.");
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        private double CalulcateNumber(string operand, string oper)
        {
            var number = Convert.ToDouble(operand);
            if (oper == "!")
            {
                if (Math.Abs((int)number - number) < 0.00001)
                    return Factorial((int)number);
                else
                    return SpecialFunctions.Gamma(number + 1);
            }
            else if (oper == "√")
                return Math.Sqrt(number);
            throw new InvalidOperationException($"Unknown operator: {oper}");
        }

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
                    if (token == "!" || token == "√")
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
        /// <returns>a list of strings where each value represents a number or operator in order</returns>
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
