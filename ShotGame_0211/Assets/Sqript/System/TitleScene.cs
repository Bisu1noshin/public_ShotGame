using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    [SerializeField] GameObject Score;
    private void Start()
    {
        Score.GetComponent<ScoreManagere>().ResetScore();
    }

    private void Update()
    {
        EndGame();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainGame");
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
