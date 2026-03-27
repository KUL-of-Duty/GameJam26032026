using UnityEngine;

public class PressureHUMAN : MonoBehaviour
{
    [SerializeField]
    PressurePlates pressure;

    private void OnTriggerEnter(Collider other)
    {
        pressure.ActivateDoors();
    }
}
