using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public partial class Playercontllore : MonoBehaviour
{
    // �e�̔��ˏ���
    private void ShotInstance()
    {
        bool goShot = TaskPlayerLevel(playerLevel);

        if (!goShot) { Debug.Log("���x�����s��"); }
    }

    // ���x���ɉ����Ēe��ς���
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
            default:
                break;
        }

        return level;
    }

    // �t�@���l������
    private void CreateFunnel() 
    {

    }
}
