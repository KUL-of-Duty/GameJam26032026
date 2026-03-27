using Unity.Cinemachine;
using UnityEngine;

public class ClockScript : DetectableItem
{
    [SerializeField]
    GameObject hours;
    [SerializeField]
    GameObject minutes;
    [SerializeField]
    GameObject seconds;
    Vector3 temp;
    GameObject player;

    [SerializeField]
    int hoursInt = 180;
    [SerializeField]
    int minutesInt = 90;
    [SerializeField]
    int secondsInt = 0;

    int currentClockHand = 0;
    public bool ClockActive = false;

    [SerializeField]
    CinemachineCamera cm;

    bool active = true;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    public override void Interact()
    {
        if(!active) return;
        Func();
  
    }

    void Func()
    {
              if (ClockActive)
        {
            ClockActive = false;
            cm.Priority = 1;
            player.GetComponent<MovementScript>().EnableMoving(true);
        } else
        {
            ClockActive = true;
            cm.Priority = 5;
            player.GetComponent<MovementScript>().EnableMoving(false);
        }
    }
    private void Update()
    {
        if (!ClockActive) return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (currentClockHand)
            {
                case 0:
                    temp = hours.transform.rotation.eulerAngles;
                    temp.z += 30;
                    hours.transform.eulerAngles = temp;
                    break;
                case 1:
                    temp = minutes.transform.rotation.eulerAngles;
                    temp.z += 30;
                    minutes.transform.eulerAngles = temp;
                    break;
                case 2:
                    temp = seconds.transform.rotation.eulerAngles;
                    temp.z += 30;
                    seconds.transform.eulerAngles = temp;
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (currentClockHand)
            {
                case 0:
                    temp = hours.transform.rotation.eulerAngles;
                    temp.z -= 30;
                    hours.transform.eulerAngles = temp;
                    break;
                case 1:
                    temp = minutes.transform.rotation.eulerAngles;
                    temp.z -= 30;
                    minutes.transform.eulerAngles = temp;
                    break;
                case 2:
                    temp = seconds.transform.rotation.eulerAngles;
                    temp.z -= 30;
                    seconds.transform.eulerAngles = temp;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetNextHand(false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetNextHand(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Func();
        }

    }


    void GetNextHand(bool add)
        {
        if (add) currentClockHand++;
        else currentClockHand--;

        if (currentClockHand == 3)
                currentClockHand =  0;
        else if (currentClockHand == -1)
            currentClockHand = 2;
    }


    public bool CheckAnwsers()
    {
        float hoursLocal = hours.transform.eulerAngles.z;
        float minutesLocal = minutes.transform.eulerAngles.z;
        float secondsLocal = seconds.transform.eulerAngles.z;

        if ((Mathf.Abs(hoursLocal - hoursInt) <= 14 && Mathf.Abs(minutesLocal - minutesInt) <= 14) && (Mathf.Abs(secondsLocal) <= 14 || Mathf.Abs(secondsLocal - 360) <= 14)) return true;
        return false;
    }

    public void CanBeActivated(bool value)
    {
        active = value;
    }
}
