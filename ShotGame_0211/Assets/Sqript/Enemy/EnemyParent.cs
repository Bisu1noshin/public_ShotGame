using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyParent : MonoBehaviour
{
    protected float enemyTimeCnt;
    protected int enemyHp;
    protected int enemyAtkp;
    protected float invincibleTime;
    private Animator animator;

    // 抽象メソッド
    protected abstract void EnemyUpDate();
    protected abstract void EnemyAttack();
    protected abstract void SetInvincibleTime();
    protected abstract GameObject DestroyEffect();

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        EnemyUpDate();
        EnemyAttack();
        EnemyDestroy();
        OutEnemy();
        InvincibleEnemy();
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
    private void InvincibleEnemy() {

        invincibleTime -= Time.deltaTime;

        if (invincibleTime <= 0)
        {
            animator.SetBool("Hit", false);
            invincibleTime = 0;
        }
        else { animator.SetBool("Hit", true); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShotParent s_;

        if ( s_ = collision.GetComponent<ShotParent>()) {

            if (invincibleTime > 0) { return; }

            int atk = s_.GetAttackPoint();

            if (enemyHp - atk <= 0) { 
                enemyHp = 0;
                return;
            }

            enemyHp -= atk;
            SetInvincibleTime();
        }
    }

    // 参照可能メソッド
    public void SetEnemyTimeCnt(float time) {
        enemyTimeCnt = time;
    }
    public int GetEnemyAttackPoint() { return enemyAtkp; }

    public abstract string GetEnemyName();
}
