using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void Shake()
    {
        StartCoroutine("ShakeObject");
    }
    IEnumerator ShakeObject()
    {
        float duration = 0.3f;
        float magnitude = 0.1f;
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
