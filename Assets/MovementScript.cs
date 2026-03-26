using UnityEngine;
using Unity.Cinemachine;

public class MovementScript : MonoBehaviour
{
    public CinemachineCamera cm;
    public float mouseSensitivity = 100f;
    private float _yRotation = 0f;
    public bool _isGrounded = false;
    private Vector3 _velocity = Vector3.zero;
    public float _gravityForce = -9.8f;
    void Start()
    {  
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        movement();
    }

    void movement(){
        Jump();
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

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded) _velocity.y = Mathf.Sqrt(2f * -_gravityForce);
    }
    

}
