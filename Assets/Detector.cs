using UnityEngine;
using UnityEngine.InputSystem;

public class Detector : MonoBehaviour
{
    public GameObject detectedItem = null;
    public float detectionDistance = 10000.0f;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            PerformRaycast();
        }
    }

    private void PerformRaycast()
    {
        Vector3 direction = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, detectionDistance))
        {
            hit.collider.GetComponent<DetectableItem>().Interact();
        }
    }
}
