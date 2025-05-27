using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffect : EnemyParent
{
    protected override void Start()
    {
        base.Start();
        enemyAtkp = 1;
        enemyHp = 10000;
    }
    protected override void EnemyUpDate()
    {
        // pass
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

    public override string GetEnemyName() { return "EnemyEffect"; }
}
