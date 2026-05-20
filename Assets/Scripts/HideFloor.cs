using UnityEngine;

public class HideFloor : MonoBehaviour
{
    [SerializeField]
    GameObject[] objects;
    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject gm in objects)
        {
            gm.SetActive(false);
        }
    }
}
