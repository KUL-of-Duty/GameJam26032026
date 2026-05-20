using UnityEngine;

public class PressureHUMAN : MonoBehaviour
{
    [SerializeField]
    PressurePlates pressure;
    [SerializeField]
    DogBehaviour dog;
    [SerializeField]
    GameObject otherPressurePlate;

    private void Awake()
    {
        dog = GameObject.FindWithTag("Dog").GetComponent<DogBehaviour>();    
    }


    private void OnTriggerStay(Collider other)
    {
        if (Vector3.Distance(otherPressurePlate.transform.position, dog.transform.position) > 2f && Vector3.Distance(pressure.transform.position, dog.transform.position) > 2f) return;
        pressure.ActivateDoors();
    }
}
