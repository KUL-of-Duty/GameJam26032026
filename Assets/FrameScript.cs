using UnityEngine;

public class FrameScript : MonoBehaviour
{
    public int frameId;
    public PaintingScript paintingScript;
    void Start()
    {
        Debug.Log("Frame ID: " + frameId);
        paintingScript = GetComponentInChildren<PaintingScript>();
    }

    public void FrameTrigger(PaintingScript painting){
        paintingScript = painting;
        Debug.Log("Frame Triggered with Painting: " + paintingScript.paintingId);
    }

     void Update()
    {
        
    }
}
