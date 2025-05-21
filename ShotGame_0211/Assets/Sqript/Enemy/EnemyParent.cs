using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyParent : MonoBehaviour
{
    protected float enemyTimeCnt;
    protected int enemyHp;

    // ���ۃ��\�b�h
    protected abstract void Start();
    protected abstract void EnemyUpDate();
    protected abstract void EnemyAttack();
    protected abstract GameObject DestroyEffect();

    private void Update()
    {
        EnemyUpDate();
        EnemyAttack();
        EnemyDestroy();
        OutEnemy();
    }

    private void OutEnemy() {
        float r = 10.0f;
        float x = transform.position.x;
        float y = transform.position.y;
        float lenge = Mathf.Sqrt(x * x + y * y);
        if (r - lenge < 0) { Destroy(gameObject); }
    }

    private void EnemyDestroy() {
        if (enemyHp <= 0) { 
            Destroy(gameObject);
        }
    }
    // �Q�Ɖ\���\�b�h

    public void SetEnemyTimeCnt(float time) {
        enemyTimeCnt = time;
    }
}
