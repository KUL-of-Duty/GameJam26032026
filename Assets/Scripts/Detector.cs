using UnityEngine;

public class Detector : MonoBehaviour
{
    public float detectionDistance = 10.0f; // 10000 to bardzo du¿o, 100 zazwyczaj wystarcza
    public DetectableItem lastItem = null; // Pamiêæ podrêczna ostatniego obiektu

    void Update()
    {
        // 1. Interakcja (klikniêcie)
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
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance))
        {
            // GetComponentInParent jest bezpieczniejsze, jeœli collider jest na dziecku obiektu
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
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance))
        {
            DetectableItem currentItem = hit.collider.GetComponentInParent<DetectableItem>();

            // Sprawdzamy, czy patrzymy na przedmiot z DetectableItem
            if (currentItem != null)
            {
                // JEŒLI TO NOWY PRZEDMIOT (w³aœnie na niego najechaliœmy)
                if (currentItem != lastItem)
                {
                    print("Patrzysz na obiekt: " + currentItem.name); // <--- TWÓJ PRINT

                    if (lastItem != null) lastItem.HideOutline(); // Wy³¹cz stary (jeœli by³)
                    currentItem.DrawOutline(); // W³¹cz nowy

                    lastItem = currentItem; // Zapamiêtaj obecny przedmiot
                }
            }
            else
            {
                // Trafiliœmy w coœ innego (np. œcianê) - wyczyœæ pamiêæ
                ClearLastItem();
            }
        }
        else
        {
            // Nie trafiamy w nic (patrzymy w niebo) - wyczyœæ pamiêæ
            ClearLastItem();
        }
    }

    private void ClearLastItem()
    {
        if (lastItem != null)
        {
            print("Przesta³eœ patrzeæ na obiekt.");
            lastItem.HideOutline();
            lastItem = null;
        }
    }
}