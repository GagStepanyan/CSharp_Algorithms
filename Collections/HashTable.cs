using System;
using System.Collections;
using System.Collections.Generic;

namespace Implementations.HashTableImplementation;

class HashTable
{
    private const int _defaultSize = 3;
    private const float _loadFactorTrashhold = 0.75f;
    private LinkedList<int>[] _slots;
    private int _elementsCount;

    public HashTable()
    {
        _slots = new LinkedList<int>[_defaultSize];
        for (int i = 0; i < _slots.Length; ++i)
            _slots[i] = new LinkedList<int>();

        _elementsCount = 0;
    }

    private int HashFunction(int x)
    {
        return x.GetHashCode();
    }

    private float GetLoadFactor()
    {
        return (float)(_elementsCount + 1) / _slots.Length;
    }

    private int GetIndex(int key)
    {
        return Math.Abs(HashFunction(key)) % _slots.Length;
    }

    public void Add(int key)
    {
        if (GetLoadFactor() > _loadFactorTrashhold)
            Resize();

        int index = GetIndex(key);
        var slot = _slots[index];

        foreach (var item in slot)
        {
            if (item == key)
            {
                Console.WriteLine("The Key Already Exists.");
                return;
            }
        }

        _slots[index].AddFirst(key);
        ++_elementsCount;
    }

    public int Search(int key)
    {
        int index = GetIndex(key);
        var slot = _slots[index];

        foreach (var item in slot)
        {
            if (item == key)
                return item;
        }

        Console.WriteLine("Item was not found... Default value returned.");

        return default(int);
    }

    public bool Remove(int key)
    {
        int index = GetIndex(key);
        var slot = _slots[index];

        var current = slot.First;
        while (current != null)
        {
            if (current.Value == key)
            {
                slot.Remove(current);
                --_elementsCount;
                return true;
            }
            current = current.Next;
        }

        Console.WriteLine("There is no such Element");
        return false;
    }

    public bool ContainsKey(int key)
    {
        int index = GetIndex(key);
        foreach (var item in _slots[index])
        {
            if (item == key) return true;
        }

        return false;
    }

    private void Resize()
    {
        int newCapacity = _slots.Length * 2;
        var newSlots = new LinkedList<int>[newCapacity];
        for (int i = 0; i < newSlots.Length; ++i)
            newSlots[i] = new LinkedList<int>();

        foreach (var slot in _slots)
        {
            foreach (var item in slot)
            {
                int newIndex = Math.Abs(HashFunction(item)) % newCapacity;
                newSlots[newIndex].AddFirst(item);
            }
        }

        _slots = newSlots;
    }
}