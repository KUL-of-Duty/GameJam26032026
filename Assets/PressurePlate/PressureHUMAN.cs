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


    private void OnTriggerEnter(Collider other)
    {
        if (Vector3.Distance(otherPressurePlate.transform.position, dog.transform.position) > 3f) return;
        pressure.ActivateDoors();
    }
}
