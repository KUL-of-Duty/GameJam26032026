using System.Security.Cryptography;
using NUnit.Framework;
using Unity.Cinemachine;
using UnityEngine;

public class PaintingPickup : MonoBehaviour
{
    public CinemachineCamera cm;
    public int paintingId;
    PaintingScript painting;
    FrameScript frame;
    bool isHoldingPainting = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            Vector3 start = cm.transform.position;
            Vector3 dir = cm.transform.forward;
            if(Physics.Raycast(start, dir, out RaycastHit hit, 2f)){
                if(hit.collider.CompareTag("Painting")&&!isHoldingPainting){
                    painting = hit.collider.GetComponent<PaintingScript>();
                    isHoldingPainting = true;
                    paintingId = painting.paintingId;
                    Debug.Log("Picked up painting: " + painting.paintingId);
                    painting.transform.SetParent(cm.transform);
                    painting.transform.localPosition = new Vector3(0, -1f, 1f);
                    painting.PaintingTrigger();
                }
                else if(hit.collider.CompareTag("Painting")&&isHoldingPainting){
                    PaintingScript temp = hit.collider.GetComponent<PaintingScript>();

                    hit.collider.GetComponent<PaintingScript>().paintingId = paintingId;
                    paintingId = painting.paintingId;
                    isHoldingPainting = false;
                    Debug.Log("Dropped painting: " + temp.paintingId);
                    temp.PaintingTrigger();
                }

                if(isHoldingPainting&&hit.collider.CompareTag("Frame")){
                    frame = hit.collider.GetComponent<FrameScript>();
                    Debug.Log("Placed painting: " + paintingId + " in frame: " + frame.frameId);
                    frame.FrameTrigger(GetComponentInChildren<PaintingScript>());
                    painting.transform.SetParent(frame.transform);
                    painting.transform.localPosition = new Vector3(0, 0, -1f);
                    isHoldingPainting = false;
                }
            }
        }
    }
}