using System;
using System.Collections.Generic;

namespace MIN_MAX_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MinStack<int> min = new MinStack<int>();
            min.Push(-2);
            min.Push(0);
            min.Push(-3);
            Console.WriteLine(min.GetMin());
            min.Pop();
            Console.WriteLine(min.Top());
            Console.WriteLine(min.GetMin());

            MaxStack<double> max = new MaxStack<double>();
            max.Push(4.0);
            max.Push(3.0);
            max.Push(9.0);
            max.Push(2.0);
            max.Push(8.0);
            Console.WriteLine(max.GetMax());
            Console.WriteLine(max.Top());
            Console.WriteLine(max.PopMax());
            Console.WriteLine(string.Join("-", max.stack));
            Console.WriteLine(max.GetMax());
            max.Pop();
            max.Pop();
            max.Pop();
            Console.WriteLine(max.GetMax());
        }
    }

    public class MinStack<T> where T : IComparable<T>
    {
        public Stack<T> stack ;
        public Stack<T> minStack;

        public MinStack()
        {
            stack = new Stack<T>();
            minStack = new Stack<T>();
        }

        public void Push(T value) 
        {
            stack.Push(value);
            if (minStack.Count == 0 || value.CompareTo(minStack.Peek()) <= 0)
                minStack.Push(value);
        }

        public void Pop()
        {
            if (stack.Peek().Equals(minStack.Peek()))
                minStack.Pop();
            stack.Pop();
        }

        public T Top()
        {
            return stack.Peek();
        }

        public T GetMin()
        {
            return minStack.Peek();
        }
    }

    public class MaxStack<T> where T : IComparable<T>
    {
        public Stack<T> stack;
        public Stack<T> maxStack;

        public MaxStack()
        {
            stack = new Stack<T>();
            maxStack = new Stack<T>();
        }

        public void Push(T value)
        {
            T max = value;
            if (maxStack.Count != 0 && value.CompareTo(maxStack.Peek()) <= 0)
                max = maxStack.Peek();
            stack.Push(value);
            maxStack.Push(max);
        }

        public T Pop()
        {
            maxStack.Pop();
            return stack.Pop();
        }

        public T Top()
        {
            return stack.Peek();
        }

        public T GetMax()
        {
            return maxStack.Peek();
        }

        // https://leetcode.com/problems/max-stack/discuss/108938/Java-AC-solution
        public T PopMax()
        {
            T max = maxStack.Peek();
            Stack<T> temp = new Stack<T>();
            while (!stack.Peek().Equals(max))
            {
                temp.Push(stack.Pop());
                maxStack.Pop();
            }
            stack.Pop();
            maxStack.Pop();
            while (temp.Count > 0)
            {
                Push(temp.Pop());
            }
            return max;
        }
    }
}
