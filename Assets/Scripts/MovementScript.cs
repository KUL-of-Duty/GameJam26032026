using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Audio;

public class MovementScript : MonoBehaviour
{
    [SerializeField] Animator cameraWalkCycleAnimator;
    public AudioSource audioSource;
    public AudioClip walkingAudio;
    public AudioClip jumpingAudio;

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
<<<<<<< HEAD:Assets/Scripts/MovementScript.cs
    float jumpInterval = 0.2f; // Czêstotliwoœæ
=======
    float jumpInterval = 0.2f; // CzÄ™stotliwoÅ›Ä‡
>>>>>>> origin/Olek_1:Assets/MovementScript.cs
    void Start()
    {  
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        movement();
    }

<<<<<<< HEAD:Assets/Scripts/MovementScript.cs
    void movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
=======
    void movement(){
        if(Input.GetKeyDown(KeyCode.Space))
>>>>>>> origin/Olek_1:Assets/MovementScript.cs
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
<<<<<<< HEAD:Assets/Scripts/MovementScript.cs
        moveDirection.y = 0; // Zapobiega poruszaniu siê w górê lub w dó³
        transform.position += moveDirection.normalized * Time.deltaTime * (Sprint() ? _runSpeed * 2 : _runSpeed);

        cameraWalkCycleAnimator.SetBool("IsWalking", moveDirection.magnitude > 0);
        cameraWalkCycleAnimator.speed = Sprint() ? 2 : 1;


        if (cameraWalkCycleAnimator.GetBool("IsWalking"))
        {
            if (!audioSource.isPlaying)
            {
                if (Sprint())
                {
                    audioSource.pitch = 2;
                }
                else
                {
                    audioSource.pitch = 1;
                }
                audioSource.clip = walkingAudio;
                audioSource.Play();
            }
        }
    }
    void Jump()
    {

        if (IsGrounded() && Time.time - lastGroundCheckTime > jumpInterval)
        {
            _velocity.y = Mathf.Sqrt(2.5f * (-_gravityForce));
            GetComponent<Rigidbody>().AddForce(_velocity, ForceMode.VelocityChange);
            //transform.position += _velocity ;
            Debug.Log(_velocity);
            lastGroundCheckTime = Time.time;
        }
        else if (IsGrounded())
        {
            lastGroundCheckTime = Time.time;
        }
    }

    public bool IsGrounded()
    {
        _isGrounded = Physics.SphereCast(transform.position, 1.2f, Vector3.down, out RaycastHit hitInfo);
        return _isGrounded;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1.2f);
    }

    bool Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && IsGrounded())
        {
=======
        moveDirection.y = 0; // Zapobiega poruszaniu siÄ™ w gÃ³rÄ™ lub w dÃ³Å‚
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
    }

    public bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround);
    }

    bool Sprint(){
        if (Input.GetKey(KeyCode.LeftShift) && IsGrounded())
        {
>>>>>>> origin/Olek_1:Assets/MovementScript.cs
            return true;
        }
        return false;
    }
    public void EnableMoving(bool value)
    {
        movementEnabled = value;
    }

<<<<<<< HEAD:Assets/Scripts/MovementScript.cs
}
=======
}
>>>>>>> origin/Olek_1:Assets/MovementScript.cs
