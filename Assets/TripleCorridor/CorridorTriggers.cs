using TMPro;
using UnityEngine;

public class CorridorTriggers : MonoBehaviour
{
    bool triggered = false;
    [SerializeField]
    GameObject button;
    [SerializeField]
    TMP_Text tmp;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        triggered = true;

        tmp.text = button.GetComponent<CorridorButton>().GetNextString();
    }
}
