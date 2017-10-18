using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3_app
{
    class Calculator
    {
        private IStackADT stack = new LinkedStack();

        private TextReader textReader = Console.In;

        Boolean DoCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            String input = "2 2 +";
            Console.Write("> ");

            input = textReader.ReadLine();

            if (input.StartsWith("q") || input.StartsWith("Q"))
            {
                return false;
            }

            String output = "4";
            try
            {
                output = EvaluationPostFixInput(input);
            }
            catch (ArgumentException e)
            {
                output = e.GetBaseException().ToString(); //Converts message to a string, then puts it in output
            }
            Console.WriteLine("\n\t>>> " + input + " = " + output);
            return true;
        }

        public String EvaluationPostFixInput(string input)
        {
            if (input == null || input.Equals(""))
                throw new ArgumentException("Null or the empty string are not valid postfix expressions.");
            stack.Clear();

            String fullString;
            String[] subStrings;
            Double a, b, c, number;

            fullString = input;
            subStrings = fullString.Split(); //Split the string into an array
            foreach (String str in subStrings )
            {
                if (Double.TryParse(str, out number) == true) //If it's a number, push it onto the stack
                {
                    stack.Push(number);
                }
                else
                {
                    if (str.Length > 1)
                    {
                        throw new ArgumentException("Input Error: " + str + " is not an allowed number or operator.");
                    }
                    if (stack.IsEmpty())
                    {
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    b = ((Double)(stack.Pop())); //Might be wrong
                    if (stack.IsEmpty())
                    {
                        throw new ArgumentException("Improper input format. Stack became empty when expecting first operand.");
                    }
                    a = ((Double)(stack.Pop()));
                    c = DoOperation(a, b, str);
                    stack.Push(c);
                }
            }
            return ((Double)(stack.Pop())).ToString();
        }

        public Double DoOperation(Double a, Double b, String s)
        {
            double c = 0.0;
            //Console.WriteLine("1: " + a.ToString() + " 2: " + b.ToString() + "Oper: " + s);
            if (s.Equals("+"))
                c = (a + b);
            else if (s.Equals("-"))
                c = (a - b);
            else if (s.Equals("*"))
                c = (a * b);
            else if (s.Equals("/"))
            {
                try
                {
                    c = (a / b);
                    if (c == Double.NegativeInfinity || c == Double.PositiveInfinity)
                        throw new ArgumentException("Can't divide by zero");
                }
                catch (ArithmeticException e)
                {
                    throw new ArgumentException(e.Message);
                }
            }
            else
                throw new ArgumentException("Improper operator: " + s +", is not one of +, -, *, or /");
            return c;
        }

        static void Main(string[] args)
        {
            Calculator app = new Calculator();
            Boolean playAgain = true;
            Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");
            while (playAgain)
            {
                playAgain = app.DoCalculation();
            }
            Console.WriteLine("Bye.");

            /*Console.WriteLine("Hello World");

            for(int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine("Args {0} : {1}", i, args[i]);
            }
            string[] myArgs = Environment.GetCommandLineArgs();
            Console.WriteLine(string.Join(", ", myArgs));

            SayHello();

            bool canIVote = true;
            Console.WriteLine("Biggest float : {0}, ", float.MaxValue);
            Console.WriteLine("Smallest float : {0}, ", float.MinValue);

            Console.ReadLine();
        }

        private static void SayHello()
        {
            string name = "";
            Console.Write("What is your name : ");
            name = Console.ReadLine();
            Console.WriteLine("Hello {0}", name);
        } */
        }

    }
}

public interface IStackADT
{
    /// <summary>
    /// Push an item onto the top of the stack. Pushing an object that 
	/// doesn't exist should result in an error and should not succeed.
	/// Pushing an object that is not an item should result in an error.
	/// This operation returns a reference (pointer or link, but not a copy)
	/// to the item pushed so that an anonymous object can be pushed and then used.
    /// </summary>
    /// <param name="newItem">The object to push onto the top of the stack. Should not be null</param>
    /// <returns>A reference to the object that was pushed, or null if newItem == null</returns>
    Object Push(Object newItem);

    /// <summary>
    /// Remove and return the top item on the stack. This operation should 
	/// result in an error if the stack is empty.Returns a reference to the
    /// item removed.
    /// </summary>
    /// <returns>A reference to the item currently on the top of the stack or null if the stack is empty</returns>
    Object Pop();

    /// <summary>
    /// Return the top item but do not remove it. Generally should result in 
	/// an error if the stack is empty.An acceptable alternative is to return 
	/// something which the user can use to check to see if the stack was in fact empty.
    /// </summary>
    /// <returns></returns>
    Object Peek();

    /// <summary>
    /// Query the stack to see if it is empty or not. Cannot produce an error.
    /// </summary>
    /// <returns>True if the stack is empty, false otherwise</returns>
    Boolean IsEmpty();

    /// <summary>
    /// Reset the stack by emptying it. The exact technique used to clear 
	/// the stack is up to the implementor.The user should pay attention to what 
	/// this behavior is.
    /// </summary>
    void Clear();

}

public class LinkedStack : IStackADT
{
    /// <summary>
    /// A singly linked stack implemenation.
    /// </summary>
    private Node top;

    public LinkedStack()
    {
        top = null; //Default, top is null
    }

    public void Clear()
    {
        top = null;
    }

    public bool IsEmpty()
    {
        return top == null;
    }

    public object Peek()
    {
        if(IsEmpty())
        {
            return null;
        }
        return top.data;
    }

    public object Pop()
    {
        if(IsEmpty())
        {
            return null;
        }
        Object topItem = top.data;
        top = top.next;
        return topItem;
    }

    public object Push(object newItem)
    {
        if(newItem == null)
        {
            return null;
        }
        Node newNode = new Node(newItem, top);
        top = newNode;
        return newItem;
    }
}

public class Node
{
    /// <summary>
    ///  A simple singly linked node class.
    /// </summary>
    public Object data; //The data inside the Node
    public Node next; //Reference to the next Node

    public Node()
    {
        data = null;
        next = null;
    }

    public Node(Object data, Node next)
    {
        this.data = data;
        this.next = next;
    }
}