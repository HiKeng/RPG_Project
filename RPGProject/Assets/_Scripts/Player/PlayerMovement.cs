using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rigid;

    public float[] moveSpeedBase;
    public float moveSpeed;
    public float[] maxSpeed;

    public bool isMoveLeft;
    public bool isMoveRight;
    public bool isMoveUp;
    public bool isMoveDown;

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
        moveSpeed = moveSpeedBase[0];
    }

    void moving()
    {
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
}
