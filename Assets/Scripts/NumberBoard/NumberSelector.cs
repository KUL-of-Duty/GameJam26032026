using UnityEngine;
using Unity.Cinemachine;
public class NumberSelector : MonoBehaviour
{
    RaycastHit hit;
    public CinemachineCamera cm;
    bool isFreezed = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(Physics.Raycast(cm.transform.position, transform.forward, out hit, 100f)){
                Debug.DrawRay(cm.transform.position, transform.forward, Color.white, 100.0f, true);
                hit = Physics.Raycast(transform.position, transform.forward, out hit, 2f) ? hit : default;
                Debug.Log(hit.collider != null ? hit.collider.tag : "No hit");
                if(hit.collider==null) return;
                if(hit.collider.CompareTag("NumberPick")&&GetComponent<MovementScript>().enabled==true){
                    cm.GetComponentInParent<MovementScript>().enabled = false;
                    NumberPickScript numberPickScript = hit.collider.GetComponentInChildren<NumberPickScript>();
                    Debug.Log("NumberPickScript found: " + (numberPickScript != null));
                        isFreezed = true;
                }
                else if(hit.collider.CompareTag("NumberPick")&&GetComponent<MovementScript>().enabled==false){
                    cm.GetComponentInParent<MovementScript>().enabled =true;
                        cm.transform.localPosition = new Vector3(0, 0.75f, 0);
                        cm.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    isFreezed = false;
                }
            }
        }
        if(isFreezed){

            if(Input.GetKeyDown(KeyCode.RightArrow)){
                hit.collider.GetComponentInChildren<NumberPickScript>().IncreaseNumber();
            }else if(Input.GetKeyDown(KeyCode.LeftArrow)){
                hit.collider.GetComponentInChildren<NumberPickScript>().DecreaseNumber();
            }
        }
    }
}