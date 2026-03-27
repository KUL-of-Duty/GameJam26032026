using System.Collections.Generic;
using UnityEngine;

public class CorrectPaintingTrigger : MonoBehaviour
{
    public List<FrameScript> correctPaintings = new List<FrameScript>();
    public MeshRenderer meshRenderer;
    Vector3 startPos;

    void Start()
    {
        startPos = meshRenderer.GetComponent<Transform>().transform.localPosition;
    }
    void Update()
    {
        allPaintingsCorrect();
    }
    public bool allPaintingsCorrect(){
        foreach(FrameScript frame in correctPaintings){
            if(!frame.isRightPlaced){
                meshRenderer.GetComponent<Transform>().transform.localPosition=startPos;
                return false;
            }
        }
        meshRenderer.GetComponent<Transform>().transform.localPosition=new Vector3(0, 2, 0);
        return true;
    }
}
