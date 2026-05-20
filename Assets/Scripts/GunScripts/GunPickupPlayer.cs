using UnityEngine;

public class GunPickupPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject rayOrigin;
    
    [SerializeField]
    LayerMask layerMask;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.TransformDirection(Vector3.forward), out hit, 300f, layerMask))
            {
                if (hit.collider.GetComponent<GunPickupG>() == null) return;
                hit.collider.GetComponent<GunPickupG>().AKPickup();
                gameObject.GetComponent<ShootingScript>().Pickup();
            }
        }    
    }
}
