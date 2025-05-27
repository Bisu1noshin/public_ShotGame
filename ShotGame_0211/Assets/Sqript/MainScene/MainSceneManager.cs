using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] GameObject p_;

    float timeCnt;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if(p_ == null) {

            timeCnt ++;

            if (timeCnt >= 60) {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
