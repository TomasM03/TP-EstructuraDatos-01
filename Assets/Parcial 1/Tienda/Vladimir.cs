using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vladimir : StoreItem
{
    public Vladimir(Sprite image) : base("Vladimir", 400, image)
    {
        type = Type.Mage;
    }
}
