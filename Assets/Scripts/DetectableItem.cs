
using UnityEngine;

public abstract class DetectableItem : MonoBehaviour {
    public bool isOutline = false;
    public Outline outline = null;

    public virtual void Interact()
    {
        Debug.Log("Franek -> To jest domyœlna reakcja, nadpisz j¹ u¿ywaj¹c tego interfaceu w klasie");
    }

    public virtual void DrawOutline()
    {
        if (!outline) outline = GetComponent<Outline>();
        else
        {
            outline.enabled = true;
        }
            
    }

    public virtual void HideOutline()
    {
        if (!outline) outline = GetComponent<Outline>();
        else
        {
            outline.enabled = false;
        }
    }
}

