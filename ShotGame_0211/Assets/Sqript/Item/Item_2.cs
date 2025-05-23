using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Item_2 : ItemParent
{
    protected override void ItemeMove(){
        Vector3 moveVec = new(0.0f, 1.0f, 0);
        float moveSpeed = 3;
        transform.position += moveVec * itemTimeCnt * moveSpeed;
    }
    public override void Itemtask(Playercontllore p_)
    {
        p_.AddPlayerLevel();
    }
    public override string ItemName() {
        return "Item_2";
    }
}
