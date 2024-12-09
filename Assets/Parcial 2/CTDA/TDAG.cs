using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TDAG<T> : MonoBehaviour
{
    public abstract bool Add(T item);

    public abstract bool Remove(T item);

    public abstract bool Contains(T item);

    public abstract string Show();

    public abstract int Cardinality();

    public abstract bool IsEmpty();

    public abstract T[] GetGroup();

    public abstract TDAG<T> Union(TDAG<T> otherSet);

    public abstract TDAG<T> Intersection(TDAG<T> otherSet);

    public abstract TDAG<T> Difference(TDAG<T> otherSet);
}
