using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContllore : MonoBehaviour
{
    // 敵の生成用のデータ
    public struct CREATEENEMYDATE
    {
        float CreateTime;   // 敵の出現タイミング
        Vector3 CreateVec;  // 敵の生成位置（X,Y）
        int EnemyVallu;     // 敵の種類
        int isItem;         // アイテムの有無
    }

    //敵の構造体を格納するリスト
    public static List<CREATEENEMYDATE> enemy = new List<CREATEENEMYDATE>();

    private GameObject[] Enemy;
    private GameObject[] EnemyPrefab;
    private float gameTimeCnt;
    private float enemyTimeCnt;
    private float timeSpeed;

    private float[] enemyCreateTime;
    private void Start()
    {
        timeSpeed = 1.0f;
        enemyTimeCnt = 0;
        gameTimeCnt = 0;

        // objectの数を数える
        int objectValue = 1;

        while (true)
        {
            if (Resources.Load<GameObject>
                ("Enemy/Enemy_" + (objectValue).ToString()) == null) { break; }

            objectValue++;
        }

        EnemyPrefab = new GameObject[objectValue];

        // objectを登録する
        for (int i = 1; i < EnemyPrefab.Length; i++)
        {
            EnemyPrefab[i] = Resources.Load<GameObject>
                ("Enemy/Enemy_" + (i).ToString());
        }
    }

    private void Update()
    {
        enemyTimeCnt = Time.deltaTime * timeSpeed;
        gameTimeCnt += Time.deltaTime;

        for (int i = 0; i < enemyCreateTime.Length; i++) {
            if (enemyCreateTime[i] >= gameTimeCnt)
            {
                Enemy[i] = CreateEnemy();
            }
        }
    }

    private GameObject CreateEnemy()
    {
        return gameObject;
    }
}
