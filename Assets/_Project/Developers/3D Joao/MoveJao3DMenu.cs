using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveJao3DMenu : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 180f;
    [SerializeField] private Animator _animator;
    
    //jump
    public float raycastDistance = 5.1f;
    public LayerMask groundLayer;

    private Rigidbody _rigidbody;
    private float moveInput;
    private float mouseX;
    [SerializeField] private bool _isGrounded;
    private bool _startJump;
    [SerializeField] private float _jumpForce = 10f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
    }

    void Update()
    {
        // Movimentação
        moveInput = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");

        if (Input.GetButton("Jump"))
        {
            _startJump = true;
            _animator.SetBool("Jump", _startJump);
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = transform.forward * moveInput;
        Vector3 rotation = new Vector3(0f, mouseX * _rotationSpeed * Time.deltaTime, 0f);
        transform.Rotate(rotation);
        _rigidbody.velocity = new Vector3(moveDirection.x * _speed, _rigidbody.velocity.y, moveDirection.z * _speed);

        if (_rigidbody.velocity.magnitude >= 0.2f)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
        
        Ray ray = new Ray(transform.position, Vector3.down);
        _isGrounded = Physics.Raycast(ray, out RaycastHit hit, raycastDistance, groundLayer);

        if (_startJump && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _startJump = false;
            _animator.SetBool("Jump", _startJump);
        }
    }
}
