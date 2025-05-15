using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] GameObject[] Shot;

    int playerLevel;
    bool shotflag;
    @ShotGame_0211 _gameInputs;

    private void Awake()
    {
        // Actionスクリプトのインスタンス生成
        _gameInputs = new @ShotGame_0211();

        // Actionイベント登録
        _gameInputs.Player.Fire.performed += Fire;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _gameInputs.Enable();
    }

    private void Start()
    {
        playerLevel = 1;
    }

    private void Update()
    {
        // pass
    }

    private void ShotInstance()
    {
        GameObject[] go = new GameObject[playerLevel];

        for (int i = 0; i < playerLevel; i++) 
        {
            if (Shot[i] == null) { break; }

            go[i] = Shot[i];
            Instantiate(go[i]);
            Vector3 pos = transform.position;
            go[i].transform.position = pos;
        }
    }


    // 入力イベント
    public void Fire(InputAction.CallbackContext context)
    {
        ShotInstance();
    }
}
