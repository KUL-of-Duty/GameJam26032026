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
    GameObject Bone;

    bool DogPressure = false;

    private void Awake()
    {
        Dog = GameObject.FindWithTag("Dog");
    }
    public void ActivateDoors()
    {
        if (Vector3.Distance(DogPressurePlate.transform.position, Dog.transform.position) > 5f && Vector3.Distance(Plate.transform.position, Dog.transform.position) > 5f) return;
        Door.SetActive(false);
        Bone.SetActive(false);
    }
}
