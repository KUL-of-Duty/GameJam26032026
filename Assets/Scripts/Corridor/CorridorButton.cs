using Unity.Cinemachine;
using UnityEngine;

public class CorridorButton : DetectableItem
{
    [SerializeField] GameObject DoorsToOpen;

    public GameObject buttonColor_1 = null;
    public GameObject buttonColor_2 = null;

    public GameObject player;
    //[SerializeField] 
    //GameObject corridors;
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
        Debug.Log("HIDE GATES");
        ShowCorridors();
        buttonColor_2.SetActive(true);
        buttonColor_1.SetActive(false);
        //Vector3 currentEuler = player.transform.eulerAngles;
        //currentEuler.y = playersRotationY;
        //player.transform.eulerAngles = currentEuler;
        DoorsToOpen.SetActive(false);

       // Mesh bakeMesh = new Mesh();
        //levelMesh.BakeMesh(bakeMesh);

        //var collider = levelMesh.GetComponent<MeshCollider>();
       // collider.sharedMesh = bakeMesh;

        //player.GetComponentInChildren<DubbingPlayer>().PlayFrase("wooow", "Wow! Id� dalej!");
    }

    private void ShowCorridors()
    {
       // corridors.SetActive(true);
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
