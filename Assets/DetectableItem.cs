
using UnityEngine;

public abstract class DetectableItem : MonoBehaviour {
    public virtual void Interact()
    {
        Debug.Log("Franek -> To jest domyœlna reakcja, nadpisz j¹ u¿ywaj¹c tego interfaceu w klasie");
    }
}

