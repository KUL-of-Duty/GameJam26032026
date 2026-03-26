using UnityEngine;
using Unity.Cinemachine;
using System;
using Unity.Mathematics;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    public CinemachineCamera cm;
    public float mouseSensitivity = 100f;
    private float _yRotation = 0f;
    public bool _isGrounded = false;
    private Vector3 _velocity = Vector3.zero;
    public float _gravityForce = -9.8f;
    //public CharacterController controller;
    void Start()
    {  
        //cm = GetComponent<CinemachineCamera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement(){
        //_isGrounded = controller.isGrounded;
        //Gravity();
        if(Input.GetKeyDown(KeyCode.Space)) Debug.Log("Jump");
        float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _yRotation -= y;
        _yRotation = Mathf.Clamp(_yRotation, -60, 50);

        cm.transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
        transform.Rotate(Vector3.up * x);
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveDirection = cm.transform.forward * move.y + cm.transform.right * move.x;
        transform.position += moveDirection * Time.deltaTime * 5f;
    }

    // void Gravity()
    // {
    //     if (_isGrounded && _velocity.y < 0) _velocity.y = 2f;
    //     if (!_isGrounded)
    //     {
    //         _velocity.y -= _gravityForce * Time.deltaTime;
    //         controller.Move(_velocity * Time.deltaTime);
    //     }
    // }

}
