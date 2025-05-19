using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontllore : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float[] playerMoveLimit = new float[4];
    [SerializeField] public int playerHitPoint;

    [SerializeField] GameObject BreakEffect;
    [SerializeField] GameObject[] Shot;

    enum StateType
    {
        Non,
        Idle,
        Left,
        Right,
        Break
    };
    StateType state;
    StateType prestate;

    GameObject player;
    Animator anim;
    @ShotGame_0211 _gameInputs;

    Vector2 moveVec = new(0, 0);
    int playerLevel;
    bool shotflag;

    private void Awake()
    {
        // Actionスクリプトのインスタンス生成
        _gameInputs = new @ShotGame_0211();

        // Actionイベント登録
        _gameInputs.Player.Move.started += Move;
        _gameInputs.Player.Move.performed += Move;
        _gameInputs.Player.Move.canceled += Move;
        _gameInputs.Player.Fire.performed += OnFire;
        _gameInputs.Player.Fire.canceled += ExitFire;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _gameInputs.Enable();
    }

    private void Start()
    {
        player = this.gameObject;
        anim = GetComponent<Animator>();
        state = StateType.Non;
        prestate = StateType.Non;
        moveSpeed = 0.1f;
        playerHitPoint = 10;
        playerLevel = 1;

        for (int i = 0; i > playerMoveLimit.Length; i++) {
            playerMoveLimit[i] = 0;
        }

    }

    private void Update()
    {
        UpDataState();
        PlayerMove(moveSpeed);
        PlayerAnimation();
        PlayerDeath();

        if (shotflag) {
            ShotInstance();
        }


#if UNITY_EDITOR
        // デバッグ用関数
        PlayerDebug();
#endif
    }

    // playerの状態遷移
    private void UpDataState()
    {
        if (playerHitPoint <= 0)
        {
            state = StateType.Break;
            return;
        }

        if (moveVec.x > 0) { state = StateType.Right; }
        else if (moveVec.x < 0) { state = StateType.Left; }
        else { state = StateType.Idle; }
    }

    // playerの移動
    private void PlayerMove(float speed_)
    {
        Vector3 move = new(moveVec.x, moveVec.y, 0.0f);
        player.transform.position += move * speed_;
        PlayerVec();
    }

    // playerの移動制御
    private void PlayerVec()
    {
        Vector3 vector = player.transform.position;

        if (vector.x <= playerMoveLimit[0]) 
        {
            vector =
                new(playerMoveLimit[0], vector.y, 0);
        }

        if (vector.x >= playerMoveLimit[1])
        {
            vector =
                new(playerMoveLimit[1], vector.y, 0);
        }

        if (vector.y <= playerMoveLimit[2])
        {
            vector =
                new(vector.x, playerMoveLimit[2], 0);
        }

        if (vector.y >= playerMoveLimit[3])
        {
            vector =
                new(vector.x, playerMoveLimit[3], 0);
        }

        player.transform.position = vector;
    }

    // playerのアニメーション
    private void PlayerAnimation()
    {
        if (state == prestate) { return; }

        if (state == StateType.Left)
        {
            anim.Play("Player_TurnLeft", 0, 1);
        }

        if (state == StateType.Right)
        {
            anim.Play("Player_TurnRight", 0, 1);
        }

        if (state == StateType.Idle)
        {
            anim.Play("Player_Idle", 0, 1);
        }

        prestate = state;
    }

    // ゲームオーバーの処理
    private void PlayerDeath()
    {
        if (state == StateType.Break)
        {
            Vector3 vector = player.transform.position;
            GameObject go = BreakEffect;
            Instantiate(go);
            go.transform.position = vector;
            Destroy(player);
        }
    }

    // 弾の発射処理
    private void ShotInstance()
    {
        GameObject[] go = new GameObject[playerLevel];

        for (int i = 0; i < playerLevel; i++)
        {
            if (Shot[i] == null) { break; }

            go[i] = Shot[i];
            Vector3 newpos = player.transform.position;
            Instantiate(go[i]);
            go[i].GetComponent<ShotParent>().ShotInstancePos(newpos);
        }
    }

    // 入力イベント

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 vector = context.ReadValue<Vector2>();

        moveVec = vector;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        shotflag = true;
    }

    public void ExitFire(InputAction.CallbackContext context)
    {
        shotflag = false;
    }

    // デバッグ用

    void PlayerDebug() 
    {
        playerKill();
    }

    void playerKill() 
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            playerHitPoint = 0;
        }
    }
}