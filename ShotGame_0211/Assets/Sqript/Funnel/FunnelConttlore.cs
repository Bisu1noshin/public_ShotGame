using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelConttlore : MonoBehaviour
{
    public GameObject parent;
    GameObject shot;
    Vector3 shotpos;

    private void Start()
    {
        shot = Resources.Load<GameObject>("Shot/PlayerShot_1");
        shotpos = shot.GetComponent<ShotParent>().ShotInstancePos();
    }

    private void Update()
    {
        if (parent == null) { return; }
        shotCreate();
        moveUpdate();
    }

    private void moveUpdate() 
    {
        // 親オブジェクトの円範囲の中は移動不可


        // 外にいるときはで追従

    }

    private void shotCreate() 
    {
        Quaternion r = transform.rotation;
        Vector3 v = transform.position + shotpos;
        Instantiate(shot, v, r);
    }
}
