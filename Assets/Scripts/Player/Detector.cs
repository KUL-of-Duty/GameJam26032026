using UnityEngine;

public class Detector : MonoBehaviour
{
    public float detectionDistance = 10.0f; // 10000 to bardzo du�o, 100 zazwyczaj wystarcza
    public DetectableItem lastItem = null; // Pami�� podr�czna ostatniego obiektu
    [SerializeField]
    GameObject initRaycast;

    void Update()
    {
        // 1. Interakcja (klikni�cie)
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformInteractionRaycast();
        }

        // 2. Wykrywanie "patrzenia" (hover)
        PerformHoverLogic();
    }

    private void PerformInteractionRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(initRaycast.transform.position, initRaycast.transform.TransformDirection(Vector3.forward), out hit, detectionDistance))
        {
            // GetComponentInParent jest bezpieczniejsze, je�li collider jest na dziecku obiektu
            DetectableItem item = hit.collider.GetComponentInParent<DetectableItem>();
            if (item != null)
            {
                item.Interact();
            }
        }
    }

    private void PerformHoverLogic()
    {
        RaycastHit hit;
        if (Physics.Raycast(initRaycast.transform.position, initRaycast.transform.forward, out hit, detectionDistance))
        {
            DetectableItem currentItem = hit.collider.GetComponentInParent<DetectableItem>();

            // Sprawdzamy, czy patrzymy na przedmiot z DetectableItem
            if (currentItem != null)
            {
                // JE�LI TO NOWY PRZEDMIOT (w�a�nie na niego najechali�my)
                if (currentItem != lastItem)
                {
                    print("Patrzysz na obiekt: " + currentItem.name); // <--- TW�J PRINT

                    if (lastItem != null) lastItem.HideOutline(); // Wy��cz stary (je�li by�)
                    currentItem.DrawOutline(); // W��cz nowy

                    lastItem = currentItem; // Zapami�taj obecny przedmiot
                }
            }
            else
            {
                // Trafili�my w co� innego (np. �cian�) - wyczy�� pami��
                ClearLastItem();
            }
        }
        else
        {
            // Nie trafiamy w nic (patrzymy w niebo) - wyczy�� pami��
            ClearLastItem();
        }
    }

    private void ClearLastItem()
    {
        if (lastItem != null)
        {
            print("Przesta�e� patrze� na obiekt.");
            lastItem.HideOutline();
            lastItem = null;
        }
    }
}