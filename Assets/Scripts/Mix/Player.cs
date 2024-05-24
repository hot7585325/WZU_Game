using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public Rigidbody2D RB2D;
    public float Speed,Power;
    public Animator _Animator;
    public SpriteRenderer _SpriteRenderer;
    public bool IsStop;
    public bool IsGround;
   // public bool AutoRun;
   // public bool IsRun;
    // Start is called before the first frame update
    void Start()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _Animator = GetComponent<Animator>();
        RB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RB2D.constraints = RigidbodyConstraints2D.FreezeRotation; //限制旋轉
        VJ_Movement();
        PlayerMovement();
       

        if (IsGround == true)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            _Animator.SetBool("onground",true);
            IsGround = true;
        }
        if (collision.collider.tag == "obstacle")
        {
            _Animator.SetInteger("State", 0);
            _Animator.SetTrigger("Read");
            Destroy(collision.gameObject);
            IsStop=true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            _Animator.SetBool("onground", false);
            IsGround = false;
        }
    }

    //禁止移動(碰到書時作用)
    public void SetIsStop()
    {
        IsStop = false;
    }

    //鍵盤控制跳躍
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _Animator.SetInteger("State", 2);
            RB2D.AddForce(Vector2.up * Power);
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            _Animator.SetInteger("State", 0);
        }
    }

    //鍵盤控制移動
    public void PlayerMovement()
    {
        if (!IsStop)
        {
            if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
            {
                _SpriteRenderer.flipX = false;
                transform.Translate(Vector3.right * Speed * Time.deltaTime);
                _Animator.SetInteger("State", 1);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _SpriteRenderer.flipX = true;
                transform.Translate(Vector3.left * Speed * Time.deltaTime);
                _Animator.SetInteger("State", 1);
            }


            if (Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.RightArrow))
            {
                _Animator.SetInteger("State", 0);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _Animator.SetInteger("State", 0);
            }
        }
    }
    //UI跳
    public void JumpButtonDown()
    {
        if (IsGround == true)
        {
            _Animator.SetInteger("State", 2);
            RB2D.AddForce(Vector2.up * Power);
        }
    }
    public void JumpButtonUp()
    {
        _Animator.SetInteger("State", 0);
    }

    public void VJ_Movement()
    {
        if (!IsStop)
        {
            Vector3 direction = Vector3.right * variableJoystick.Horizontal;
            transform.Translate(direction * Speed * Time.deltaTime);
            if (direction.x ==0)
            {
                _SpriteRenderer.flipX = false;
                _Animator.SetInteger("State", 0);
                Debug.Log("1");
            }
            if (direction.x > 0)
            {
                _SpriteRenderer.flipX = false;
                _Animator.SetInteger("State", 1);
                Debug.Log("2");
            }
            if (direction.x < 0)
            {
                _SpriteRenderer.flipX = true;
                _Animator.SetInteger("State", 1);
                Debug.Log("3");
            }
        }
    }



}
