using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Azir : StoreItem
{
    public Azir(Sprite image) : base("Azir", 600, image)
    {
        type = Type.Mage;
    }
}
