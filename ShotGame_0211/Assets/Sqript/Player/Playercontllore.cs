using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontllore : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
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

    Vector2 moveVec = new(0, 0);


    private void Start()
    {
        player = this.gameObject;
        anim = GetComponent<Animator>();
        state = StateType.Non;
        prestate = StateType.Non;
        moveSpeed = 0.1f;
        playerHitPoint = 10;

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

#if UNITY_EDITOR
        // �f�o�b�O�p�֐�
        PlayerDebug();
#endif
    }

    // player�̏�ԑJ��
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

    // player�̈ړ�
    private void PlayerMove(float speed_)
    {
        Vector3 move = new(moveVec.x, moveVec.y, 0.0f);
        player.transform.position += move * speed_;
        PlayerVec();
    }

    // player�̈ړ�����
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

    // player�̃A�j���[�V����
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

    // �Q�[���I�[�o�[�̏���
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



    // ���̓C�x���g

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 vector = context.ReadValue<Vector2>();

        moveVec = vector;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("");
    }

    // �f�o�b�O�p

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