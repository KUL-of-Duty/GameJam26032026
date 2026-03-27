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
    public bool isHoldingPainting = false;
    Vector3 scale;
    Vector3 start;
    Vector3 dir;
    void Start()
    {
        scale = new Vector3(0.8f, 0.8f, 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            start = cm.transform.position;
            dir = cm.transform.forward;
            if(Physics.Raycast(start, dir, out RaycastHit hit, 2f)){
                if(!isHoldingPainting){
                    PickupPainting(hit);
                }
                else if(isHoldingPainting){
                    ReplacePainting(hit);
                }

                if(isHoldingPainting&&hit.collider.CompareTag("Frame")){
                    frame = hit.collider.GetComponent<FrameScript>();
                    PutPainting(frame, painting);
                }
            }
        }
    }

    void PickupPainting(RaycastHit hit){
        if(hit.collider.CompareTag("Painting"))
            painting = hit.collider.GetComponent<PaintingScript>();
            if(painting==null)return;
            isHoldingPainting = true;
            paintingId = painting.paintingId;
            Debug.Log("Picked up painting: " + painting.paintingId);
            painting.transform.SetParent(cm.transform);
            painting.transform.localPosition = new Vector3(0, -1f, 1f);
            painting.PaintingTrigger();
            painting.transform.localScale = new Vector3(1,1,0.1f);
    }

    void ReplacePainting(RaycastHit hit){
        PaintingScript temp = hit.collider.GetComponent<PaintingScript>();
        if(temp==null)return;
        FrameScript tempFrame = temp.GetComponentInParent<FrameScript>();
        temp.transform.SetParent(cm.transform);
        temp.transform.localPosition = new Vector3(0, -1f, 1f);

        PutPainting(tempFrame, painting);

        PickupPainting(hit);
    }

    void PutPainting(FrameScript frame, PaintingScript painting){
        Debug.Log("Placed painting: " + paintingId + " in frame: " + frame.frameId);
        frame.FrameTrigger(GetComponentInChildren<PaintingScript>());
        painting.transform.SetParent(frame.transform);
        painting.transform.localPosition = new Vector3(0, 0, -1f);
        painting.transform.localRotation = painting.GetComponentInParent<FrameScript>().transform.rotation;
        //painting.transform.localScale = scale;
        painting.transform.localScale = scale;
        isHoldingPainting = false;
    }
}