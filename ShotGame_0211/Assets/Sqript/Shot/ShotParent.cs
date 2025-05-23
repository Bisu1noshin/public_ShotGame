﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

abstract public class ShotParent : MonoBehaviour
{
    protected GameObject shot;
    protected Collider2D coll;

    protected int attackPoint;
    protected float isShotTime = 0.5f;
    private float shotTimeCnt;

    private void Start()
    {
        shot = this.gameObject;
        attackPoint = 1;
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        shotTimeCnt += Time.deltaTime;
        ShotDestroy();
        ShotMove();
    }

    // 抽象メソッド

    /// <summary>
    /// 弾の移動処理
    /// </summary>
    abstract protected void ShotMove();

    abstract public Vector3 ShotInstancePos();

    // 参照可能メソッド

    // 弾の攻撃力の参照
    public int GetAttackPoint() { return attackPoint; }

    // 存在時間
    private void ShotDestroy() 
    {
        if (shotTimeCnt >= isShotTime)
        {
            Destroy(gameObject);
        }
    }

    // 接触判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ItemParent>()) { return; }
        Destroy(gameObject);
    }
}
