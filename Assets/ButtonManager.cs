using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Canvas menuCanvas;
    public void ExitGame(){
        Application.Quit();
        Debug.Log("Exit Button Pressed");
    }
    public string sceneName;
    public void StartGame(){
        SceneManager.LoadScene(sceneName);
        Debug.Log("Start Button Pressed");
    }

    public void ContinueButton(){
        menuCanvas.enabled = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Continue Button Pressed");
        // GetComponent<AudioSource>().Play();
        // GetComponent<MovementScript>().enabled = true;
    }
}
