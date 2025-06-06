using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] GameObject p_;
    EnemyContllore ene;

    float timeCnt;
    void Start()
    {
        Application.targetFrameRate = 60;

        ene = GameObject.Find("EnemyCreateManager").GetComponent<EnemyContllore>();
    }

    private void Update()
    {
        EndGame();

        if(p_ == null) {

            timeCnt ++;

            if (timeCnt >= 60) {
                SceneManager.LoadScene("EndScene");
            }
        }

        if (ene.GetCreaeFlag()) {

            timeCnt++;

            if (timeCnt >= 90)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
    //Q[IΉ
    private void EndGame()
    {
        //Escͺ³κ½
        if (Input.GetKey(KeyCode.Escape))
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//Q[vCIΉ
#else
    Application.Quit();//Q[vCIΉ
#endif
        }

    }
}
