using UnityEngine;

public class FrameScript : MonoBehaviour
{
    public int frameId;
    public PaintingScript paintingScript;
    public int paintingId;
    public bool isRightPlaced =false;
    void Start()
    {
        Debug.Log("Frame ID: " + frameId);
        paintingScript = GetComponentInChildren<PaintingScript>();
    }

    public void FrameTrigger(PaintingScript painting){
        paintingScript = painting;
        paintingId = paintingScript.paintingId;
        Debug.Log("Frame Triggered with Painting: " + paintingScript.paintingId);
        if(paintingId == frameId){
            isRightPlaced = true;
            Debug.Log("Correct Painting Placed in Frame: " + frameId);
        }else{
            isRightPlaced = false;
            Debug.Log("Wrong Painting Placed in Frame: " + frameId);
        }
    }

     void Update()
    {
        
    }
}
