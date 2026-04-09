using UnityEngine;

public class PressurePlates : MonoBehaviour
{
    [SerializeField]
    GameObject DogPressurePlate;
    [SerializeField]
    GameObject Plate;
    [SerializeField]
    GameObject Dog;
    [SerializeField]
    GameObject Door;
    [SerializeField]
    bool value = false;

    bool DogPressure = false;

    private void Awake()
    {
        Dog = GameObject.FindWithTag("Dog");
    }
    public void ActivateDoors()
    {
        Door.SetActive(value);
    }
}
