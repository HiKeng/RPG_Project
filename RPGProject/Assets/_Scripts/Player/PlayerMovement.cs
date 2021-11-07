using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] AudioSource _footStepSFX;
    [SerializeField] float _upgradeMovementModifier = 0.2f;

    Rigidbody rigid;

    public float[] moveSpeedBase;
    public float moveSpeed;
    public float[] maxSpeed;

    [HideInInspector] public bool isMoveLeft;
    [HideInInspector] public bool isMoveRight;
    [HideInInspector] public bool isMoveUp;
    [HideInInspector] public bool isMoveDown;

    [HideInInspector] public bool _isAvailable = true;


    [Header("Events")]
    [SerializeField] UnityEvent _onStartMove;
    [SerializeField] UnityEvent _onEndMove;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    void Start()
    {
        _SetSpeed();
    }

    void Update()
    {
        _SetSpeed();
        checkButtonUP();
    }

    void FixedUpdate()
    {
        moving();
        speedChange();
    }

    public void _SetSpeed()
    {
        stopMoving();
        //moveSpeed = moveSpeedBase[0];

        moveSpeed = moveSpeedBase[0] + 
                    GetComponent<PlayerSkillPoint>()._movementUpgrade * _upgradeMovementModifier;
    }

    void moving()
    {
        if(!_isAvailable) { return; }


        //if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        //{
        //    _onStartMove.Invoke();
        //}

        if (isMoveUp || isMoveDown || isMoveLeft || isMoveRight)
        {
            if(!_footStepSFX.isPlaying)
            {
                _onStartMove.Invoke();
            }
        }
        else
        {
            _onEndMove.Invoke();
        }

        /////// Move Vertically /////////
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * Time.deltaTime);
            isMoveUp = true;
            isMoveDown = false;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed * Time.deltaTime);
            isMoveDown = true;
            isMoveUp = false;
        }
        ////////////////////////////////////


        /////// Move Horizontally /////////
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            isMoveRight = true;
            isMoveLeft = false;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            isMoveLeft = true;
            isMoveRight = false;

        }
        ////////////////////////////////////
    }

    void checkButtonUP()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            isMoveUp = false;
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            isMoveDown = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            isMoveRight = false;
        }

        else if (Input.GetKeyUp(KeyCode.A))
        {
            isMoveLeft = false;
        }
    }

    void speedChange()
    {
        moveSpeed = moveSpeedBase[0];
    }

    public void stopMoving()
    {
        rigid.AddForce(Vector3.zero);
    }

    public void _SetAvailablity(bool _state)
    {
        _isAvailable = _state;
    }

    public bool _IsMoving()
    {
        bool _isMove = false;

        if(isMoveUp || isMoveDown || isMoveRight || isMoveLeft)
        {
            _isMove = true;
        }

        return _isMove;
    }
}
