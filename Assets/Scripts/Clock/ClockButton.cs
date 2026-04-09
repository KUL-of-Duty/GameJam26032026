using UnityEngine;

public class ClockButton : DetectableItem
{
    ClockScript clock;
    [SerializeField]
    GameObject Doors;

    private void Awake()
    {
        clock = GetComponentInParent<ClockScript>();
    }
    public override void Interact()
    {
        if (clock.CheckAnwsers())
        {
            clock.CanBeActivated(false);
            Doors.SetActive(true);
        }
        else
        {
            Debug.Log("Wrong anwser");
        }
    }
}
