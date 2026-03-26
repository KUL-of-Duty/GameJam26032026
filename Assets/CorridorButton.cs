using Unity.Cinemachine;
using UnityEngine;

public class CorridorButton : MonoBehaviour
{
    public GameObject player;
    public CinemachineCamera cm;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        while(player == null) player = GameObject.FindWithTag("Player");
    }
    void Interact()
    {
        
    }
}
