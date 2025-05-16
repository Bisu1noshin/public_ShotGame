using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] GameObject[] Shot;

    GameObject player;
    int playerLevel;
    bool shotflag;
    bool oneflag;
    @ShotGame_0211 _gameInputs;

    private void Awake()
    {
        // Actionスクリプトのインスタンス生成
        _gameInputs = new @ShotGame_0211();

        // Actionイベント登録
        _gameInputs.Player.Fire.started += EnterFire;
        _gameInputs.Player.Fire.performed += OnFire;
        _gameInputs.Player.Fire.canceled += ExitFire;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _gameInputs.Enable();
    }

    private void Start()
    {
        playerLevel = 1;
        oneflag = false;
        shotflag = false;
        player = gameObject;
    }

    private void FixedUpdate()
    {
        if(oneflag == false) { oneflag = true; return; }

        if(shotflag)
        {
            ShotInstance();
        }
    }

    private void ShotInstance()
    {
        GameObject[] go = new GameObject[playerLevel];

        for (int i = 0; i < playerLevel; i++) 
        {
            if (Shot[i] == null) { break; }

            go[i] = Shot[i];
            Instantiate(go[i]);
            Vector3 newpos = player.transform.position;
            go[i].GetComponent<ShotParent>().ShotInstancePos(newpos);
        }
    }


    // 入力イベント
    public void EnterFire(InputAction.CallbackContext context)
    {
        oneflag = false;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        shotflag = true;
    }

    public void ExitFire(InputAction.CallbackContext context)
    {
        oneflag = false;
        shotflag = false;
    }
}
