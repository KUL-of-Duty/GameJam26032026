using UnityEngine;

public class ClockScript : MonoBehaviour
{
    [SerializeField]
    GameObject hours;
    [SerializeField]
    GameObject minutes;
    [SerializeField]
    GameObject seconds;
    Vector3 temp;

    [SerializeField]
    int hoursInt = 180;
    [SerializeField]
    int minutesInt = 90;
    [SerializeField]
    int secondsInt = 0;

    int currentClockHand = 0;
    public bool ClockActive = false;

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
        if (hours.transform.rotation.z == hoursInt && minutes.transform.rotation.z == minutesInt && seconds.transform.rotation.z == secondsInt) return true;
        return false;
    }
}
