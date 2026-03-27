using System.Collections.Generic;
using UnityEngine;

public class NumberBoard : MonoBehaviour
{
    [SerializeField]
    public List<NumberPickScript> numberPickScript;
    [SerializeField]
    public MeshRenderer Doors;
    Vector3 startPos;

    void Start()
    {
        startPos = Doors.GetComponent<Transform>().transform.localPosition;
    }

    public bool allCorrect(){
        foreach(NumberPickScript number in numberPickScript){
            if(!number.isCorrect){
                //Doors.transform.position=startPos;
                return false;
            }
        }
        Doors.transform.position=new Vector3(0, 0, 2);
        return true;
    }
}
