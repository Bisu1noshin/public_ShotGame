using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    private float gameTimeCnt;
    void Start()
    {
        Application.targetFrameRate = 60;
        gameTimeCnt = 0;
    }

    private void Update()
    {
        gameTimeCnt += Time.deltaTime;
    }
}
