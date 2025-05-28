using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_8 : EnemyParent
{
    [SerializeField] GameObject effect;
    private GameObject p_;
    
    protected override void Start()
    {
        base.Start();
        enemyAtkp = 1;
        enemyHp = 800;
        p_ = GameObject.Find("Player");
    }

    protected override void EnemyUpDate()
    {
        float speed = 0.2f * enemyTimeCnt;

        if (p_ == null) { return; }

        transform.position = Vector2.MoveTowards(
           transform.position,
           p_.transform.position,
           speed
           );
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
        return effect;
    }

    public override string GetEnemyName() { return "Enemy_8"; }
}
