using UnityEngine;

public class GiveBone : DetectableItem
{
    [SerializeField]
    DogBehaviour dog;
    [SerializeField]
    GameObject bone;
    bool used = false;
    [SerializeField]
    GameObject text;
    [SerializeField]
    GameObject Sign;
    [SerializeField]
    GameObject text2;
    [SerializeField]
    GameObject player;

    [SerializeField]
    string soundName;
    [SerializeField]
    string textSound;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    public override void Interact()
    {
        if (used) return;

        used = true;
        bone.SetActive(true);
        dog.isActive = true;
        text.SetActive(true);
        Sign.SetActive(false);
        text2.SetActive(false);
        player.GetComponentInChildren<DubbingPlayer>().PlayFrase(soundName, textSound);
    }
}
