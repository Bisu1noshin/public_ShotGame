using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelConttlore : MonoBehaviour
{
    public GameObject parent;
    public bool shotFlag;
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
        
        moveUpdate(parent);
        GetShotFlag();

        if (shotFlag) {
            shotCreate();
        }
    }

    private void moveUpdate(GameObject p_) 
    {
        // 親オブジェクトの円範囲の中は移動不可
        float pr = 1.0f;
        Vector3 lengh = p_.transform.position - transform.position;
        float r = lengh.x * lengh.x + lengh.y * lengh.y;
        if (pr - Mathf.Sqrt(r) > 0) { return; }

        // 外にいるときは追従
        float speed = 0.1f;
        transform.position = Vector2.MoveTowards(
           transform.position,
           p_.transform.position,
           speed
           );
    }

    private void shotCreate() 
    {
        Quaternion r = transform.rotation;
        Vector3 v = transform.position + shotpos;
        Instantiate(shot, v, r);
    }

    private void GetShotFlag() 
    {
        if (parent.GetComponent<Playercontllore>()) {
            this.shotFlag = parent.GetComponent<Playercontllore>().shotflag;
        }
        if (parent.GetComponent<FunnelConttlore>()){
            this.shotFlag = parent.GetComponent<FunnelConttlore>().shotFlag;
        }
    }
}
