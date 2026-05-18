using UnityEngine;

public class GunPickupPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject rayOrigin;
    
    [SerializeField]
    LayerMask layerMask;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.TransformDirection(Vector3.forward),Color.white, 1f,true);
            if(Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.TransformDirection(Vector3.forward), out hit, 300f, layerMask))
            {
                hit.collider.GetComponent<GunPickupG>().AKPickup();
                gameObject.GetComponent<ShootingScript>().Pickup();
            }
        }    
    }
}
