using Unity.Cinemachine;
using UnityEngine;

public class CorridorButton : DetectableItem
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

    public override void Interact()
    {
        player.transform.Rotate(0, 0, 180);
    }
}
