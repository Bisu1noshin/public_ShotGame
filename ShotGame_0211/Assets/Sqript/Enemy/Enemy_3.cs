using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : EnemyParent
{
    protected override void Start()
    {
        base.Start();
        enemyAtkp = 1;
        enemyHp = 3;
    }
    protected override void EnemyUpDate()
    {
        Vector3 moveVec = new(1.0f, 1.0f, 0);
        float moveSpeed = 3;
        transform.position += moveVec * enemyTimeCnt * moveSpeed;
    }

    protected override void EnemyAttack()
    {
        // pass
    }

    protected override void SetInvincibleTime()
    {
        invincibleTime = 0.1f;
    }

    protected override GameObject DestroyEffect()
    {
        return null;
    }

    public override string GetEnemyName() { return "Enemy_3"; }
}
