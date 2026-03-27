using System;
using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject dogSpot;
    public GameObject dogSpot2;

    [SerializeField]
    ParticleSystem[] particles;

    [SerializeField]
    CameraShake camShake;

    float hitTime;
    float cooldown = 1f;

    RaycastHit hit;

    public void AtackPlayer()
    {
        foreach (var particle in particles)
        {
            particle.Play();
            camShake.Shake();
        }
    }

    private void Awake()
    {
        hitTime = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atack();
        }
    }

    void Atack()
    {
        if (Time.time - hitTime < cooldown) return;
        hitTime = Time.time;

        StartCoroutine(AtackCooldowned());
    }

    IEnumerator AtackCooldowned()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        if (Physics.Raycast(origin, direction, out hit, 3f))
        {
            Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    yield return new WaitForSeconds(0.5f);
                    enemy.AtackEnemy();
                }
            }
        }

        Debug.DrawRay(origin, direction * 3f, Color.red, 1f);
    }
}
