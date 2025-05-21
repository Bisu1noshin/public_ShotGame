using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class Playercontllore : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public bool shotflag;
    [SerializeField] public float[] playerMoveLimit = new float[4];
    [SerializeField] public int playerHitPoint;

    [SerializeField] GameObject BreakEffect;

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
    GameObject[] Shot;
    GameObject funnelPrefab;
    GameObject[] funnel;

    Vector2 moveVec = new(0, 0);
    Vector3[] shotpos;
    int playerLevel;
    bool[] createFunnelFrag;

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

        int objectValue = 0;

        // objectの数を数える
        while (true)
        {
            if (Resources.Load<GameObject>
                ("Shot/PlayerShot_" + (objectValue + 1).ToString()) == null) { break; }

            objectValue++;
        }

        Shot = new GameObject[objectValue];
        shotpos = new Vector3[objectValue];

        // objectを登録する
        for (int i = 0; i < Shot.Length; i++)
        {
            Shot[i] = Resources.Load<GameObject>
                ("Shot/PlayerShot_" + (i + 1).ToString());
            shotpos[i] = Shot[i].GetComponent<ShotParent>().ShotInstancePos(); 
        }

        funnelPrefab = Resources.Load<GameObject>("Funnel/Funnel");

        funnel = new GameObject[30];
        createFunnelFrag = new bool[funnel.Length];
        for (int b = 0; b < createFunnelFrag.Length; b++){
            createFunnelFrag[b] = false;
        }
    }

    private void Update()
    {
        if (shotflag)
        {
            ShotInstance();
        }

        UpDataState();
        PlayerMove(moveSpeed);
        PlayerAnimation();
        PlayerDeath();
        FunnelCnt();

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
        AddplayerLevel();
    }

    void playerKill() 
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            playerHitPoint = 0;
        }
    }

    void AddplayerLevel() {
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            playerLevel++;
            Debug.Log("playerLevel:" + playerLevel);
        }
    }
}