using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorialButton : DetectableItem
{
    [SerializeField] SkinnedMeshRenderer levelMesh;

    public GameObject buttonColor_1 = null;
    public GameObject buttonColor_2 = null;

    public GameObject player;
    [SerializeField] 
    GameObject corridors;
    [SerializeField]
    float playersRotationY = 0f;
    [SerializeField]
    string[] strings;

    [SerializeField]
    GameObject key;

    int stringsint = -1;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        while(player == null) player = GameObject.FindWithTag("Player");
    }

    public override void Interact()
    {
        SceneManager.LoadScene(2);
    } 

    private void ShowCorridors()
    {
        corridors.SetActive(true);
    }

    public string GetNextString ()
    {
        stringsint++;
        Debug.Log(stringsint);
        if (stringsint == 2) FinishPuzzle();
        return strings[stringsint];
    }

    private void FinishPuzzle()
    {
        key.SetActive(true);
    }
}
