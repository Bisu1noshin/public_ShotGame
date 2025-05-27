using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Enemy_7 : EnemyParent
{
    enum State { 
        Non,
        Create,
        Idle,
        Chase
    };

    private State state;
    private float timeCnt;
    private GameObject p_;
    private Vector3 targetPos;

    protected override void Start()
    {
        base.Start();
        enemyAtkp = 3;
        enemyHp = 20;
        state = State.Create;
        timeCnt = 0;

        p_ = GameObject.Find("Player");
        if (p_ == null) { Destroy(gameObject); }
        targetPos = p_.transform.position;
    }
    protected override void EnemyUpDate()
    {

        switch (state)
        {
            case State.Idle:
                IdleUpDate();
                break;
            case State.Create:
                CreateUpDate();
                break;
            case State.Chase:
                ChaseUpDate();
                break;
        }
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

    public override string GetEnemyName() { return "Enemy_7"; }

    private void CreateUpDate() {

        if (Mathf.Approximately(targetPos.x, transform.position.x))
            if (Mathf.Approximately(targetPos.y, transform.position.y)) {
                state = State.Idle;
                return;
            }

        float speed = 0.1f;
        transform.position = Vector2.MoveTowards(
           transform.position,
           targetPos,
           speed
           );
    }

    private void IdleUpDate() {

        timeCnt += Time.deltaTime;

        if (timeCnt >= 2.0f){
            state = State.Chase;
            targetPos = p_.transform.position;
            timeCnt = 0;
        }
    }

    private void ChaseUpDate() {

        float speed = 1f * enemyTimeCnt;

        transform.position += targetPos * speed;
    }
}
