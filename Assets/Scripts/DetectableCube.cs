using UnityEngine;

public class DetectableCube : DetectableItem
{
    public override void Interact()
    {
        Debug.Log("DetectableCube zadzia³a³ nadpisuj¹c Interact() z DetectableItem");
    }
}