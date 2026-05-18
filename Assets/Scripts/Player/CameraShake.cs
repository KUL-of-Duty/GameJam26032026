using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
        float duration = 0.1f;
    [SerializeField]
        float magnitude = 0.1f;

    public void Shake()
    {
        StartCoroutine("ShakeObject");
    }
    IEnumerator ShakeObject()
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(
                originalPos.x + offsetX,
                originalPos.y + offsetY,
                originalPos.z
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos; // reset position
    }
}
