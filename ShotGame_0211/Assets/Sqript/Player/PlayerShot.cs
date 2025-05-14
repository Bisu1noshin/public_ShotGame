using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField]
    GameObject[] Shot;

    int shotLenge = 0;

    private void Start()
    {
        shotLenge = Shot.Length;
    }
}
