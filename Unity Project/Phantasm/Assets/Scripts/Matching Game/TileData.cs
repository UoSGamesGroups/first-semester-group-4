using System.Collections;
using UnityEngine;

public class TileData : ScriptableObject
{

    public Sprite sprBack, sprFront;
    public int id;

    public TileData(int id, Sprite sprBack, Sprite sprFront)
    {
        this.id = id;
        this.sprBack = sprBack;
        this.sprFront = sprFront;
    }

}
