using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBroken : MonoBehaviour
{
    public void AnimEnd() 
    {
        Destroy(gameObject);
    }
}
