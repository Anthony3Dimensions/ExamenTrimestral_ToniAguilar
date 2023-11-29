using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5;
    [SerializeField] private float _jumpForce = 3;
    Animator _animator;
    private float _playerInputHorizontal;
    private Rigidbody2D _rBody2D;
    // Start is called before the first frame update
    void Start()
    {
       _rBody2D = GetComponent<Rigidbody2D>();
       _animator = GetComponentInChildren<Animator>(); 
    }


    // Update is called once per frame
    void Update()
    {
        
    if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
    {
        Jump();
    }
    _animator.SetBool("isJumping", !GroundSensor._isGrounded);
    

    }

    void FixedUpdate()
    {
        Movimiento();
    }

    void Movimiento()
    {

        _rBody2D.velocity = new Vector2(_playerInputHorizontal * _playerSpeed, _rBody2D.velocity.y);

        _playerInputHorizontal = Input.GetAxis("Horizontal");

        
        if(_playerInputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("isRunning", true);
        }

        else if(_playerInputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("isRunning", true);
        }

        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

}  
