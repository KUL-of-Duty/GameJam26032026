using Unity.Cinemachine;
using UnityEngine;

public class CorridorButton : DetectableItem
{
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
        ShowCorridors();
        Vector3 currentEuler = player.transform.eulerAngles;
        currentEuler.y = playersRotationY;
        player.transform.eulerAngles = currentEuler;
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
