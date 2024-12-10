using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem
{
    public string Name;
    public int Price;
    public Sprite Image;

    public enum Type
    {
        Mage,
        Assasin,
    }

    public Type type;

    public StoreItem(string name, int price, Sprite image)
    {
        Name = name;
        Price = price;
        Image = image;
    }
}
