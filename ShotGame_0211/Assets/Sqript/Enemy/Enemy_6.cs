using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_6 : EnemyParent
{
    [SerializeField] private GameObject shot;

    private float shottime;
    protected override void Start()
    {
        base.Start();
        enemyAtkp = 1;
        enemyHp = 10;

        enemyTimeCnt = Time.deltaTime;
    }
    protected override void EnemyUpDate()
    {
        Vector3 moveVec = new(1.0f, 0, 0);
        float moveSpeed = 2;
        transform.position += moveVec * enemyTimeCnt * moveSpeed;
    }

    protected override void EnemyAttack()
    {
        shottime += Time.deltaTime;

        if (shottime >= 2.0f)
        {
            Vector3 v = transform.position;
            Quaternion q = transform.rotation;
            Instantiate(shot, v, q);
            shottime = 0;
        }
    }

    protected override void SetInvincibleTime()
    {
        invincibleTime = 0.1f;
    }

    protected override GameObject DestroyEffect()
    {
        return null;
    }

    public override string GetEnemyName() { return "Enemy_6"; }
}
