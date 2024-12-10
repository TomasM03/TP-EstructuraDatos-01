using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zed : StoreItem
{
    public Zed(Sprite image) : base("Zed", 500, image)
    {
        type = Type.Assasin;
    }
}

