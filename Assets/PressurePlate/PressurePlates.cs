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
    private void OnTriggerEnter(Collider other)
    {
        if (!DogPressure)
        {
            Dog.GetComponent<DogBehaviour>().GoToButton(DogPressurePlate);
            DogPressure = true;
        }
    }

    public void ActivateDoors()
    {
        if (!DogPressure) return;

        Dog.GetComponent<DogBehaviour>().TaskDone();
        Door.SetActive(false);
        Bone.SetActive(false);
    }
}
