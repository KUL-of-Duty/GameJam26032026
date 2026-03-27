using UnityEngine;
using UnityEngine.InputSystem;

public class Detector : MonoBehaviour
{
    public GameObject detectedItem = null;
    public float detectionDistance = 10000.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            if (hit.collider.GetComponent<DetectableItem>() != null) 
            {
                hit.collider.GetComponent<DetectableItem>().Interact();
            }
        }
    }
}
