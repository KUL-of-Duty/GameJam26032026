using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField]
    string soundName;
    [SerializeField]
    string text;
    bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" || triggered) return;
        triggered = true;
        other.GetComponentInChildren<DubbingPlayer>().PlayFrase(soundName, text);
    }
}
