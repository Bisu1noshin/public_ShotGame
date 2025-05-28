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
    protected Color defaltColor = Color.white;
    private Color hitColor;
    private SpriteRenderer sp;
    private GameObject Item;
    private ScoreManagere Score;

    // 抽象メソッド
    protected abstract void EnemyUpDate();
    protected abstract void EnemyAttack();
    protected abstract void SetInvincibleTime();
    protected abstract GameObject DestroyEffect();

    protected virtual void Start()
    {
        hitColor = Color.red;
        sp = GetComponent<SpriteRenderer>();
        Score = GameObject.Find("Score").GetComponent<ScoreManagere>();
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
        float r = 15.0f;
        float x = transform.position.x;
        float y = transform.position.y;
        float lenge = Mathf.Sqrt(x * x + y * y);
        if (r - lenge < 0) { enemyHp = 0; }
    }
    private void EnemyDestroy() {

        if (enemyHp <= 0) {

            Vector3 v = transform.position;
            Quaternion q = transform.rotation;

            if (Item != null){

                Instantiate(Item, v, q);
            }

            GameObject e = DestroyEffect();
            if (e != null) {
                
                Instantiate(e, v, q);
            }
            Destroy(gameObject);
        }
    }
    private void InvincibleEnemy() {

        invincibleTime -= Time.deltaTime;

        if (invincibleTime <= 0)
        {
            sp.color = defaltColor;
            invincibleTime = 0;
        }
        else 
        { 
            sp.color = hitColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShotParent s_;

        if ( s_ = collision.GetComponent<ShotParent>()) {

            //if (invincibleTime > 0) { return; }

            int atk = s_.GetAttackPoint();

            if (enemyHp - atk <= 0) {

                Score.AddScore();
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
    public void SetItem(GameObject i_) { Item = i_; }
    public abstract string GetEnemyName();
}
