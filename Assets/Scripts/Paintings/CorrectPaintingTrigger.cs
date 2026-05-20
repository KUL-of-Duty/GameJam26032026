using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Used on a paiting's trigger (doors which have had to be opened) to check if all the paintings are in the correct place.
/// This script is used to check if all the paintings are in the correct place. 
/// If they are, it will move the mesh renderer up. 
/// If not, it will move it back to its original position.
/// </summary>
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
        meshRenderer.GetComponent<Transform>().transform.localPosition=new Vector3(0, 20, 0);
        return true;
    }
}
