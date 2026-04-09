using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas menuCanvas;

    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }
    void Update(){
        if(Application.targetFrameRate != 60){
            Application.targetFrameRate = 60;
        }
        if(Input.GetKeyDown(KeyCode.Escape)&&!menuCanvas.enabled){
            menuCanvas.enabled = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            // GetComponent<AudioSource>().Pause();
            // GetComponent<MovementScript>().enabled = false;
        }else if(Input.GetKeyDown(KeyCode.Escape)&&menuCanvas.enabled){
            menuCanvas.enabled = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            // GetComponent<AudioSource>().UnPause();
            // GetComponent<MovementScript>().enabled = true;
        }
    }
}
