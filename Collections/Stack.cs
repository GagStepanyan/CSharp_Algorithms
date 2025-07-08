using System;
using System.Collections;
using System.Collections.Generic;
using Implementations.DAImplement;

namespace Implementations.StackImplementation;

class MyStack<T> where T : IComparable
{
    private DA<T> _elements;

    public MyStack()
    {
        _elements = new DA<T>();
    }

    public void Push(T val)
    {
        _elements.PushBack(val);
    }

    public T Pop()
    {
        if (_elements.IsEmpty())
        {
            Console.WriteLine("the stack is empty... Default value returned");
            return default(T);
        }
        T ret = _elements[_elements.Count - 1];
        _elements.PopBack();
        return ret;
    }

    public void Empty()
    {
        if (_elements.IsEmpty())
            return;
        _elements.Empty();
    }

    public T Peek()
    {
        if (_elements.IsEmpty())
        {
            Console.WriteLine("The Stack is empty, default value returned");
            return default(T);
        }

        return _elements[_elements.Count - 1];
    }


}