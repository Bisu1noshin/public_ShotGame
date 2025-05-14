using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColider : MonoBehaviour
{
    Collider2D coll;
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
