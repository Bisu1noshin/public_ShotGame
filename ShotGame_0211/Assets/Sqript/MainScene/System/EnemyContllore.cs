using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContllore : MonoBehaviour
{
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

        // objectÇÃêîÇêîÇ¶ÇÈ
        int objectValue = 1;

        while (true)
        {
            if (Resources.Load<GameObject>
                ("Enemy/Enemy_" + (objectValue).ToString()) == null) { break; }

            objectValue++;
        }

        EnemyPrefab = new GameObject[objectValue];

        // objectÇìoò^Ç∑ÇÈ
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
