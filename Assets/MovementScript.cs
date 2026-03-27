using UnityEngine;
using Unity.Cinemachine;
using System;

public class MovementScript : MonoBehaviour
{
    public CinemachineCamera cm;
    public float mouseSensitivity = 100f;
    private float _yRotation = 0f;
    public bool _isGrounded = false;
    float distanceToGround = 1.2f;
    private Vector3 _velocity = Vector3.zero;
    public float _gravityForce = -9.8f;
    public float _runSpeed = 3.5f;
    bool movementEnabled = true;
    float lastGroundCheckTime = 0f;
    float jumpInterval = 0.2f; // Częstotliwość
    void Start()
    {  
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        movement();
    }

    void movement(){
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        Sprint();
        float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _yRotation -= y;
        _yRotation = Mathf.Clamp(_yRotation, -60, 50);

        cm.transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
        transform.Rotate(Vector3.up * x);
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveDirection = cm.transform.forward * move.y + cm.transform.right * move.x;
        moveDirection.y = 0; // Zapobiega poruszaniu się w górę lub w dół
        transform.position += moveDirection.normalized * Time.deltaTime * (Sprint()?_runSpeed*2:_runSpeed);
    }

    void Jump(){
       
        if(IsGrounded() && Time.time - lastGroundCheckTime > jumpInterval){
            _velocity.y = Mathf.Sqrt(2.5f * (-_gravityForce));
            GetComponent<Rigidbody>().AddForce(_velocity, ForceMode.VelocityChange); 
            //transform.position += _velocity ;
             Debug.Log(_velocity);
            lastGroundCheckTime = Time.time;
        }
        else if (IsGrounded()){
            lastGroundCheckTime = Time.time;
        }
        IsGrounded();
    }

    public bool IsGrounded() {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, distanceToGround);
        return _isGrounded;
    }

    bool Sprint(){
        if (Input.GetKey(KeyCode.LeftShift) && IsGrounded())
        {
            return true;
        }
        return false;
    }
    public void EnableMoving(bool value)
    {
        movementEnabled = value;
    }

}
