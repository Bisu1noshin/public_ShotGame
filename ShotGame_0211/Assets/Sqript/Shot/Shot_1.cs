using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_1 : ShotParent
{
    protected override void ShotMove()
    {
        Vector3 vector = new(0, 0.3f, 0);
        this.transform.position += vector;
    }

    public override void ShotInstancePos(Vector3 p)
    {
        Vector3 vector = new(0, 0.5f);
        transform.position = p + vector;
    }
}
