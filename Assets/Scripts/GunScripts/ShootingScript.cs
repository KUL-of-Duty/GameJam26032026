using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    GameObject gunModel;

    [SerializeField]
    GameObject handModel;

    [SerializeField]
    bool GunEnabledInScene;

    [SerializeField]
    ParticleSystem[] particles;

    [SerializeField]
    CameraShake camShake;
    bool gunEnabled = false;
    bool gunVisible = false;

    [SerializeField]
    AudioSource audio;
    void Start()
    {
        if(GunEnabledInScene) Pickup();
    }


    void Update()
    {
        if(!gunEnabled) return;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach(ParticleSystem particle in particles){
                particle.Play();
            }
            anim.SetBool("Shoot", true);  
            audio.Play();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            camShake.Shake();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            foreach(ParticleSystem particle in particles){
                particle.Stop();
            }
            anim.SetBool("Shoot", false);  
            audio.Stop();
        }
    }


    public void Pickup()
    {
        gunEnabled = true;
        ChangeVisibility(true);
    }

    void ChangeVisibility(bool boolean)
    {
        if (boolean)
        {
            gunVisible = true;
            gunModel.SetActive(true);
            handModel.SetActive(false);
            anim.SetTrigger("ShowGun");
            return;
        } 

        gunVisible = false;
        gunModel.SetActive(false);
        handModel.SetActive(true);
        anim.SetTrigger("HideGun");
    }
    
}
