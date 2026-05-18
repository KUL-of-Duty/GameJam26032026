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
    float jumpInterval = 0.2f;

    // Small sphere radius for ground check — much smaller than before
    [SerializeField] float groundCheckRadius = 0.3f;
    // Offset downward from pivot to where the feet are
    [SerializeField] float groundCheckOffset = 1.0f;
    // Which layers count as ground
    [SerializeField] LayerMask groundMask = ~0;

    public enum SphereCastOrRayCast
    {
        SPHERECAST, RAYCAST
    }

    public SphereCastOrRayCast sphereOrRay;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!movementEnabled) return;
        movement();
        IsGrounded();
    }

    void movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _yRotation -= y;
        _yRotation = Mathf.Clamp(_yRotation, -60, 50);

        cm.transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
        transform.Rotate(Vector3.up * x);

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveDirection = cm.transform.forward * move.y + cm.transform.right * move.x;
        moveDirection.y = 0;
        transform.position += moveDirection.normalized * Time.deltaTime * (Sprint() ? _runSpeed * 2 : _runSpeed);

        cameraWalkCycleAnimator.SetBool("IsWalking", moveDirection.magnitude > 0);
        cameraWalkCycleAnimator.speed = Sprint() ? 2 : 1;

        if (cameraWalkCycleAnimator.GetBool("IsWalking"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.pitch = Sprint() ? 2 : 1;
                audioSource.clip = walkingAudio;
                audioSource.Play();
            }
        }
    }

    float lastGroundedTime = 0f;

    public bool IsGrounded()
    {
        Vector3 checkOrigin = transform.position + Vector3.down * groundCheckOffset;
        Collider[] hits = Physics.OverlapSphere(checkOrigin, groundCheckRadius);

        foreach (Collider hit in hits)
        {
            if (hit.gameObject != gameObject && hit.CompareTag("Ground"))
            {
                _isGrounded = true;
                lastGroundedTime = Time.time; // refresh while on ground
                return true;
            }
        }

        _isGrounded = false;
        return false;
    }

    void Jump()
    {
        bool withinCoyoteTime = Time.time - lastGroundedTime <= jumpInterval;

        if (!IsGrounded() && !withinCoyoteTime) return;

        if (Time.time - lastGroundCheckTime > jumpInterval)
        {
            _velocity.y = Mathf.Sqrt(2.5f * -_gravityForce);
            GetComponent<Rigidbody>().AddForce(_velocity, ForceMode.VelocityChange);
            Debug.Log(_velocity);
            lastGroundCheckTime = Time.time;
            lastGroundedTime = -jumpInterval; // consume coyote time so you cant jump twice
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the actual ground check sphere
        Gizmos.color = IsGrounded() ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * groundCheckOffset, groundCheckRadius);
    }

    bool Sprint()
    {
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