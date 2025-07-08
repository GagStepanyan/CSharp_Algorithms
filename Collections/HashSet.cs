using System;
using System.Collections.Generic;
namespace Implementations.HS;

class HashMap<K, V>
{
    private class Entry
    {
        public K Key;
        public V Value;

        public Entry(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }

    private LinkedList<Entry>[] _slots;
    private int _elementsCount;
    private const float _loadFactorTrashhold = 0.75f;
    private const int _initialCapacity = 3;

    public HashMap()
    {
        _slots = new LinkedList<Entry>[_initialCapacity];
        for (int i = 0; i < _initialCapacity; ++i)
            _slots[i] = new LinkedList<Entry>();
        _elementsCount = 0;
    }

    private int HashFunction(K key)
    {
        return Math.Abs(key.GetHashCode());
    }

    private int GetIndex(K key)
    {
        return HashFunction(key) % _slots.Length;
    }

    private float GetLoadFactor()
    {
        return (float)(_elementsCount + 1) / _slots.Length;
    }

    public void Add(K key, V value)
    {
        if (GetLoadFactor() > _loadFactorTrashhold)
            Resize();

        int index = GetIndex(key);
        var slot = _slots[index];

        foreach (var entry in slot)
        {
            if (entry.Key.Equals(key))
            {
                Console.WriteLine("Key is already mapped");
                return;
            }
        }

        _slots[index].AddFirst(new Entry(key, value));
        ++_elementsCount;
    }

    public bool TryGetValue(K key, out V value)
    {
        int index = GetIndex(key);
        var slot = _slots[index];

        foreach (var entry in slot)
        {
            if (entry.Key.Equals(key))
            {
                value = entry.Value;
                return true;
            }
        }

        Console.WriteLine("The Element is not found... Default value is returned");
        value = default(V);
        return false;
    }

    public bool Erase(K key)
    {
        int index = GetIndex(key);
        var slot = _slots[index];

        var current = slot.First;

        while (current != null)
        {
            if (current.Value.Key.Equals(key))
            {
                slot.Remove(current);
                --_elementsCount;
                return true;
            }
            current = current.Next;
        }

        Console.WriteLine("The Element was not fount... Erasing failed");
        return false;
    }

    public bool ContainsKey(K key)
    {
        return TryGetValue(key, out _);
    }

    private void Resize()
    {
        int newCapacity = _slots.Length * 2;
        var newSlots = new LinkedList<Entry>[newCapacity];
        for (int i = 0; i < newCapacity; ++i)
            newSlots[i] = new LinkedList<Entry>();

        foreach (var slot in _slots)
        {
            foreach (var entry in slot)
            {
                int newIndex = HashFunction(entry.Key) % newCapacity;
                newSlots[newIndex].AddFirst(new Entry(entry.Key, entry.Value));
            }
        }

        _slots = newSlots;
    }
}