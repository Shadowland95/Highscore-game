using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public string data = "HELLO WORLD";
    public int funnyNumber = 1337;
    public float floaty  = 42.42f;

    public Float3 position = new Float3();
}

[System.Serializable]

public class Float3
{
    public float x, y, z;

    public void FromVector(Vector3 v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }
}