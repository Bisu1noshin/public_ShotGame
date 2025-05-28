using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public partial class Playercontllore : MonoBehaviour
{
    private float shotTime;
    const float MaxshotTime = 0.1f;

    // 弾の発射処理
    private void ShotInstance()
    {
        shotTime += Time.deltaTime;

        if (shotTime >= MaxshotTime) {

            bool goShot = TaskPlayerLevel(playerLevel);

            if (!goShot) { Debug.Log("レベルが不正"); }

            shotTime = 0;
        }
    }

    // レベルに応じて弾を変える
    private bool TaskPlayerLevel(int l_)
    {
        bool level = false;
        GameObject[] go = Shot;
        Vector3 frontPos = new Vector3(0.2f, 0, 0);

        switch (l_)
        {
            case 1:
                {
                    Quaternion r = transform.rotation;
                    Vector3 v = transform.position + shotpos[l_ - 1];
                    Instantiate(go[l_ - 1], v, r);
                    level = true;
                    break;
                }
            case 2:
                {
                    for (int i = 0; i < l_; i++)
                    {
                        Quaternion r = transform.rotation;
                        Vector3 v;
                        if (i == 0) { v = transform.position + shotpos[i] + frontPos; }
                        else { v = transform.position + shotpos[i] + frontPos * -1; }
                        Instantiate(go[i], v, r);
                    }
                    level = true;
                    break;
                }
            case 3:
                {
                    for (int i = 0; i < l_; i++)
                    {
                        Quaternion r = transform.rotation;
                        Vector3 v;
                        if (i == 0) { v = transform.position + shotpos[i] + frontPos; }
                        else if (i == 2) { v = transform.position + shotpos[i]; }
                        else { v = transform.position + shotpos[i] + frontPos * -1; }
                        Instantiate(go[i], v, r);
                    }
                    level = true;
                    break;
                }
            case 4:
                {
                    for (int i = 0; i < l_ - 1; i++)
                    {
                        Quaternion r = transform.rotation;
                        Vector3 v;
                        if (i == 0) { v = transform.position + shotpos[i] + frontPos; }
                        else if (i == 2) { v = transform.position + shotpos[i]; }
                        else { v = transform.position + shotpos[i] + frontPos * -1; }
                        Instantiate(go[i], v, r);
                    }

                    level = true;
                    break;
                }
            case 5:
                {
                    for (int i = 0; i < l_; i++)
                    {
                        Quaternion r = transform.rotation;
                        Vector3 v;
                        if (i == 0) { v = transform.position + shotpos[i] + frontPos; }
                        else if (i == 1) { v = transform.position + shotpos[i] + frontPos * -1; }
                        else { v = transform.position + shotpos[i]; }
                        Instantiate(go[i], v, r);
                    }

                    level = true;
                    break;
                }
            default:
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Quaternion r = transform.rotation;
                        Vector3 v;
                        if (i == 0) { v = transform.position + shotpos[i] + frontPos; }
                        else if (i == 1) { v = transform.position + shotpos[i] + frontPos * -1; }
                        else { v = transform.position + shotpos[i]; }
                        Instantiate(go[i], v, r);
                    }

                    level = true;
                    break;
                }
        }

        return level;
    }

    // ファンネル生成
    private GameObject CreateFunnel(GameObject p_)
    {
        GameObject f_ = funnelPrefab;
        Quaternion r = transform.rotation;
        Vector3 vector = new(0, 1.0f);
        Vector3 v = p_.transform.position + vector;
        return Instantiate(f_, v, r);
    }

    private void FunnelCnt()
    {
        if (playerLevel == 4)
        {
            if (createFunnelFrag[0] == false) {
                funnel[0] = CreateFunnel(player);
                funnel[0].GetComponent<FunnelConttlore>().parent = player;
                createFunnelFrag[0] = true;
            }
        }

        if (playerLevel >= 6)
        {
            if (playerLevel - 4 > 30) { return; }
            for (int b = 1; b < playerLevel - 4; b++) {
                if (createFunnelFrag[b] == false)
                {
                    funnel[b] = CreateFunnel(funnel[b - 1]);
                    funnel[b].GetComponent<FunnelConttlore>().parent = funnel[b - 1];
                    createFunnelFrag[b] = true;
                }
            }
        }
    }
}
