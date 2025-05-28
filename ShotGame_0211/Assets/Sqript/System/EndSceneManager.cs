using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] texts = new TextMeshProUGUI[3];
    private float timeCnt;

    private int Cnt = 0;

    private void Start()
    {
        for(int i = 0; i > 3;i++)
        {
            texts[i].enabled = false;
        }
        Cnt = 0;
        timeCnt = 0;
    }


    private void Update()
    {
        EndGame();
        timeCnt += Time.deltaTime;

        //if (Cnt > 2) {
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        SceneManager.LoadScene("TitleScene");
        //    }
        //}

        //if (timeCnt >= 2.0f) {

        //    if (Cnt > 2) { return; }

        //    texts[Cnt].enabled = true;
        //    timeCnt = 0;
        //    Cnt++;
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TitleScene");
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
