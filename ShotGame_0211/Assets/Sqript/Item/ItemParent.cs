using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemParent : MonoBehaviour
{
    // 抽象メソッド
    protected abstract void ItemeMove();

    // プレイヤーで呼び出す処理
    public abstract void Itemtask(Playercontllore p_);
    public abstract string ItemName();

    private void Update()
    {
        OutItem();
        ItemeMove();
    }

    private void OutItem()
    {
        float r = 10.0f;
        float x = transform.position.x;
        float y = transform.position.y;
        float lenge = Mathf.Sqrt(x * x + y * y);
        if (r - lenge < 0) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Playercontllore p_;
        if (p_ = collision.GetComponent<Playercontllore>())
        {
            Destroy(gameObject);
        }
    }
}
