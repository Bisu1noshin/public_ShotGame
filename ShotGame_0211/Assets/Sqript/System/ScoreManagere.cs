using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagere : MonoBehaviour
{
    private static int score;

    public int GetScore() { return score; }
    public void AddScore() { score++; }
    public void Add10Score() { score += 10; }
    public void ResetScore() { score = 0; }
}
