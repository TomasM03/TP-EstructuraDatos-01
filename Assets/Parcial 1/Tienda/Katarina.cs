using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katarina : StoreItem
{
    public Katarina(Sprite image) : base("Katarina", 450, image)
    {
        type = Type.Assasin;
    }
}
