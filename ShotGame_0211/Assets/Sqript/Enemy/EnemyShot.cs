using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : EnemyParent
{
    protected override void Start()
    {
        base.Start();
        enemyAtkp = 1;
        enemyHp = 1;
    }
    protected override void EnemyUpDate()
    {
        Vector3 moveVec = new(0, -2.0f, 0);
        float moveSpeed = 3;
        transform.position += moveVec * Time.deltaTime * moveSpeed;
    }

    protected override void EnemyAttack()
    {
        // pass
    }

    protected override void SetInvincibleTime()
    {
        invincibleTime = 0f;
    }

    protected override GameObject DestroyEffect()
    {
        return null;
    }

    public override string GetEnemyName() { return "EnemyShot"; }
}
