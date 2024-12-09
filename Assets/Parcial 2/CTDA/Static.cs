using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static<T> : TDAG<T>
{
    private T[] elements;

    public Static(int arraySize)
    {
        elements = new T[arraySize];
    }

    public override bool Add(T item)
    {
        if (Contains(item)) return false;

        for (int i = 0; i < elements.Length; i++)
        {
            if (EqualityComparer<T>.Default.Equals(elements[i], default(T)))
            {
                elements[i] = item;
                return true;
            }
        }
        return false;
    }

    public override int Cardinality()
    {
        return elements.Length;
    }

    public override bool Contains(T item)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    public override bool IsEmpty()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i] != null)
            {
                return false;
            }
        }

        return true;
    }

    public override bool Remove(T item)
    {
        if (Contains(item))
        {
            int lastIndex = GetLastElementIndex();

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].Equals(item))
                {
                    elements[i] = elements[lastIndex];
                    elements[lastIndex] = default;

                    return true;
                }
            }
        }

        return false;
    }

    private int GetLastElementIndex()
    {
        for (int i = elements.Length - 1; i >= 0; i--)
        {
            if (elements[i] != null)
            {
                return i;
            }
        }

        return -1;
    }

    public override string Show()
    {
        string text = "Static Set Contents: \n";

        foreach (var element in elements)
        {
            text += "Element: " + element + "\n";
        }

        return text;
    }

    public override TDAG<T> Union(TDAG<T> otherSet)
    {
        int newArraySize = 0;

        foreach (var item in elements)
        {
            newArraySize++;
        }
        foreach (var item in otherSet.GetGroup())
        {
            if (!Contains(item)) newArraySize++;
        }

        Static<T> unionSet = new Static<T>(newArraySize);

        foreach (var item in elements)
        {
            unionSet.Add(item);
        }
        foreach (var item in otherSet.GetGroup())
        {
            unionSet.Add(item);
        }
        return unionSet;
    }

    public override TDAG<T> Difference(TDAG<T> otherSet)
    {
        int newArraySize = 0;

        foreach (var item in elements)
        {
            if (!otherSet.Contains(item))
            {
                newArraySize++;
            }
        }

        foreach (var item in otherSet.GetGroup())
        {
            if (!Contains(item))
            {
                newArraySize++;
            }
        }

        Static<T> differenceSet = new Static<T>(newArraySize);

        foreach (var item in elements)
        {
            if (!otherSet.Contains(item))
            {
                differenceSet.Add(item);
            }
        }
        foreach (var item in otherSet.GetGroup())
        {
            if (!Contains(item))
            {
                differenceSet.Add(item);
            }
        }

        return differenceSet;
    }

    public override TDAG<T> Intersection(TDAG<T> otherSet)
    {
        int newArraySize = 0;

        foreach (var item in elements)
        {
            if (otherSet.Contains(item))
            {
                newArraySize++;
            }
        }

        Static<T> intersectionSet = new Static<T>(newArraySize);

        foreach (var item in elements)
        {
            if (otherSet.Contains(item))
            {
                intersectionSet.Add(item);
            }
        }
        return intersectionSet;
    }

    public override T[] GetGroup()
    {
        return elements;
    }
}
