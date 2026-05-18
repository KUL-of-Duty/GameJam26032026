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

    public float _gravityForce = -20f;
    public float _runSpeed = 3.5f;
    public float jumpHeight = 2.5f;

    bool movementEnabled = true;

    float lastGroundedTime = 0f;
    float lastJumpTime = 0f;
    float jumpInterval = 0.2f;

    [SerializeField] float groundCheckRadius = 0.3f;
    [SerializeField] float groundCheckOffset = 1.0f;

    private Vector3 _velocity;
    private CharacterController _cc;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!movementEnabled) return;
        Movement();
    }

    void Movement()
    {
        bool grounded = IsGrounded();

        // Reset downward velocity when grounded
        if (grounded && _velocity.y < 0)
            _velocity.y = -2f;

        // Coyote time + jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool withinCoyoteTime = Time.time - lastGroundedTime <= jumpInterval;
            bool cooldownPassed = Time.time - lastJumpTime > jumpInterval;

            if ((grounded || withinCoyoteTime) && cooldownPassed)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * _gravityForce);
                lastJumpTime = Time.time;
                lastGroundedTime = -10f; // consume coyote time
                audioSource.PlayOneShot(jumpingAudio);
            }
        }

        // Mouse look
        float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        _yRotation -= y;
        _yRotation = Mathf.Clamp(_yRotation, -60, 50);
        cm.transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
        transform.Rotate(Vector3.up * x);

        // Horizontal movement
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveDirection = cm.transform.forward * input.y + cm.transform.right * input.x;
        moveDirection.y = 0;
        float speed = Sprint() ? _runSpeed * 2f : _runSpeed;
        _cc.Move(moveDirection.normalized * speed * Time.deltaTime);

        // Gravity
        _velocity.y += _gravityForce * Time.deltaTime;
        _cc.Move(_velocity * Time.deltaTime);

        // Animations & audio
        bool isMoving = moveDirection.magnitude > 0 && grounded;
        cameraWalkCycleAnimator.SetBool("IsWalking", isMoving);
        cameraWalkCycleAnimator.speed = Sprint() ? 2f : 1f;

        if (isMoving && !audioSource.isPlaying)
        {
            audioSource.pitch = Sprint() ? 2f : 1f;
            audioSource.clip = walkingAudio;
            audioSource.Play();
        }
        else if (!isMoving)
        {
            audioSource.Stop();
        }
    }

    public bool IsGrounded()
    {
        Vector3 checkOrigin = transform.position + Vector3.down * groundCheckOffset;
        Collider[] hits = Physics.OverlapSphere(checkOrigin, groundCheckRadius);

        foreach (Collider hit in hits)
        {
            if (hit.gameObject != gameObject && hit.CompareTag("Ground"))
            {
                lastGroundedTime = Time.time;
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded() ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * groundCheckOffset, groundCheckRadius);
    }

    bool Sprint()
    {
        return Input.GetKey(KeyCode.LeftShift) && IsGrounded();
    }

    public void EnableMoving(bool value)
    {
        movementEnabled = value;
    }
}