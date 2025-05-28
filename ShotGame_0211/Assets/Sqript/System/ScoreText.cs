using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject Score;

    private void Update()
    {
        int score=
            Score.GetComponent<ScoreManagere>().GetScore();

        text.text = score.ToString();
    }
}
