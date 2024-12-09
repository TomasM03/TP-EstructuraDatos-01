using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic<T> : TDAG<T>
{
    private List<T> elements = new List<T>();

    public Dynamic()
    {

    }

    public override bool Add(T item)
    {
        if (!Contains(item))
        {
            elements.Add(item);
            return true;
        }
        return false;
    }

    public override bool Remove(T item)
    {
        if (Contains(item))
        {
            elements.Remove(item);
            return true;
        }
        return false;
    }

    public override bool Contains(T item)
    {
        return elements.Contains(item);
    }

    public override string Show()
    {
        string text = "Dynamic Set Contents: \n";

        foreach (var element in elements)
        {
            text += "Element: " + element + "\n";
        }

        return text;
    }

    public override int Cardinality()
    {
        return elements.Count;
    }

    public override bool IsEmpty()
    {
        if (elements.Count == 0)
        {
            return true;
        }
        return false;
    }

    public override TDAG<T> Union(TDAG<T> otherSet)
    {
        Dynamic<T> unionSet = new Dynamic<T>();

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

    public override TDAG<T> Intersection(TDAG<T> otherSet)
    {
        Dynamic<T> intersectionSet = new Dynamic<T>();
        foreach (var item in elements)
        {
            if (otherSet.Contains(item))
            {
                intersectionSet.Add(item);
            }
        }
        return intersectionSet;
    }

    public override TDAG<T> Difference(TDAG<T> otherSet)
    {
        Dynamic<T> differenceSet = new Dynamic<T>();
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

    public override T[] GetGroup()
    {
        return elements.ToArray();
    }
}
