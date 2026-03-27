using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField]
    int sceneint;
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(sceneint);
    }
}
