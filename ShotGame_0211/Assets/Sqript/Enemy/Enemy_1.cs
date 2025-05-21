using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : EnemyParent
{
    protected override void Start()
    {
        enemyHp = 10;
    }

    protected override void EnemyUpDate() { 
        Vector3 moveVec = new(1.0f, 1.0f, 0);
        float moveSpeed = 3;
        transform.position += moveVec * enemyTimeCnt * moveSpeed;
    }

    protected override void EnemyAttack() { 
        // pass
    }

    protected override GameObject DestroyEffect() { 
        return null;
    }

}
