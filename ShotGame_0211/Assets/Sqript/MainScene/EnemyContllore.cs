﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContllore : MonoBehaviour
{
    private EnemyParent[] Enemy;
    private GameObject[] EnemyPrefab;
    private GameObject[] ItemPrefab;
    private float gameTimeCnt;
    private float enemyTimeCnt;
    private float timeSpeed;
    private int enemyCount;
    private List<CreateEnemyDate.CREATEENEMYDATE> CREATEENEMYDATE;

    const int EnemySize = 20;

    private float[] enemyCreateTime;
    private void Start()
    {
        timeSpeed = 1.0f;
        enemyTimeCnt = 0;
        gameTimeCnt = 0;
        enemyCount = 1;

        // 敵のプレファブを登録する
        {
            int objectValue = 1;

            while(true)
            {
                if(Resources.Load<GameObject>
                    ("Enemy/Enemy_" + (objectValue).ToString()) == null) { break; }

                objectValue++;
            }

            EnemyPrefab = new GameObject[objectValue];

            // objectを登録する
            for(int i = 1; i < EnemyPrefab.Length; i++)
            {
                EnemyPrefab[i] = Resources.Load<GameObject>
                    ("Enemy/Enemy_" + (i).ToString());
            }
        }
        // アイテムのプレファブを登録する
        {
            int objectValue = 1;

            while(true)
            {
                if(Resources.Load<GameObject>
                    ("Item/Item_" + (objectValue).ToString()) == null) { break; }

                objectValue++;
            }

            ItemPrefab = new GameObject[objectValue];

            // objectを登録する
            for(int i = 1; i < ItemPrefab.Length; i++)
            {
                ItemPrefab[i] = Resources.Load<GameObject>
                    ("Item/Item_" + (i).ToString());
            }
        }

        // CSVから拾ってくる
        {
            string f = "hsiug";
            CREATEENEMYDATE = CreateEnemyDate.ENEMY_read_csv(f);
        }

        Enemy = new EnemyParent[EnemySize];
    }

    private void Update()
    {
        enemyTimeCnt = Time.deltaTime * timeSpeed;
        gameTimeCnt += Time.deltaTime;

        CreateEnemy(CREATEENEMYDATE);

        for (int i = 0; i < EnemySize; i++) {

            if(Enemy[i] == null) { continue; }

            Enemy[i].SetEnemyTimeCnt(enemyTimeCnt);
        }
    }

    private void CreateEnemy(List<CreateEnemyDate.CREATEENEMYDATE> list) {

        if(list[enemyCount].CreateTime >= gameTimeCnt)
        {
            // 空きがあった時の処理
            for(int i = 0; i < Enemy.Length; i++) {

                Enemy[i] = GetEnemyClass(
                list[enemyCount].EnemyValue,
                list[enemyCount].CreateVec
                );

                if(list[enemyCount].isItem != 0)
                {
                    Enemy[i].SetItem(ItemPrefab[list[enemyCount].isItem]);
                }

                enemyCount++;
            }
        }
    }

    private EnemyParent GetEnemyClass(int EnemyValue, Vector3 vector)
    {
        GameObject e_ = EnemyPrefab[EnemyValue];
        Quaternion r = transform.rotation;
        return Instantiate(e_, vector, r).GetComponent<EnemyParent>();
    }
}
