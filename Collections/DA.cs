using System;
using System.Collections;
using System.Collections.Generic;
namespace Implementations.DAImplement;

class DA <T> : IEnumerable<T>, IEnumerable where T : IComparable
{
    private T[] _items;
    private int _size;
    private const int DefaultCapacity = 4;

    public DA()
    {
        _items = new T[DefaultCapacity];
        _size = 0;
    }

    public DA(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException("Capacity cannot be negative or 0.\nDA Construction Failed.");

        _items = new T[capacity];
        _size = 0;
    }

    public int Count => _size;
    public int Capacity => _items.Length;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException("Index is out of range");
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException("Index is out of range");
            _items[index] = value;
        }
    }

    private void Resize()
    {
        T[] arr = new T[_size * 2];
        for (int i = 0; i < _size; ++i)
        {
            arr[i] = _items[i];
        }

        _items = arr;
    }

    public void PushBack(T value)
    {
        if (_size == Capacity)
            Resize();
        
        _items[_size++] = value;
    }

    public void PopBack()
    {
        if (_size == 0)
            return;
        
        --_size;
    } 

    public void Insert(T value, int pos)
    {
        if (pos < 0 || pos >= _size)
        {
            Console.WriteLine("Invalid argument\nInsertion Failed");
            return;
        }

        if (_size == Capacity)
            Resize();
        
        if (pos == _size - 1)
            PushBack(value);
        
        for (int i = _size - 1; i >= pos; --i)
            _items[i + 1] = _items[i];
        

        _items[pos] = value;
        ++_size;
    }

    public void Erase(int pos)
    {
        if (pos < 0 || pos >= _size)
        {
            Console.WriteLine("Invalid Argument\n Erasing failed");
            return;
        }

        if (pos == _size - 1)
            PopBack();

        for (int i = pos; i < _size - 1; ++i)
            _items[i] = _items[i + 1];
        
        --_size;
    }

    public void ShrinkToFit()
    {
        if (Capacity > _size)
        {
            T[] items = new T[_size];
            for (int i = 0; i < _size; ++i)
                items[i] = _items[i];
            
            _items = items;
        }
    }

    public bool IsEmpty()
    {
        return _size == 0 ? true : false;
    }

    public void Empty()
    {
        _items = new T[DefaultCapacity];
    }

    public int SimpleSearch(T value)
    {
        for (int i = 0; i < _size; ++i)
        {
            if (_items[i].CompareTo(value) == 0)
                return i;
        }

        return -1;
    }

    public int BinarySearch(T val)
    {
        int left = 0;
        int right = _size - 1;
        int mid;

        while (left <= right)
        {
            mid = left + (right - left) / 2;
            int comparsion = _items[mid].CompareTo(val);

            if (comparsion == 0)
                return mid;

            if (comparsion < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _size; ++i)
            yield return _items[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}