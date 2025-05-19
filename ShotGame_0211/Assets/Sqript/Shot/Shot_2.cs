using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_2 : ShotParent
{
    protected override void ShotMove()
    {
        Vector3 vector = new(0, 0.3f, 0);
        this.transform.position += vector;
    }

    public override Vector3 ShotInstancePos()
    {
        Vector3 vector = new(0, 0.5f);
        return vector;
    }
}
