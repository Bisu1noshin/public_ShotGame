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
    //ゲーム終了
    private void EndGame()
    {
        //Escが押された時
        if (Input.GetKey(KeyCode.Escape))
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }

    }
}
