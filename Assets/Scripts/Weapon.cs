using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private ParticleSystem impactEffect;

    void Start() {
        // playerCamera = transform.parent.GetComponent<Camera>();
    }

    void Update() {

        if (!Input.GetButtonDown("Fire1")) {
            return;
        }

        // TODO: shake camera
        muzzleFlash.Play();
        PlaySoundEffect();

        bool hitSomething = Physics.Raycast(
            playerCamera.transform.position, 
            playerCamera.transform.forward, 
            out RaycastHit hit, 
            maxDistance
        );
        if (!hitSomething) {
            return;
        }

        Debug.Log(hit.transform.name);

        Target target = hit.transform.GetComponent<Target>();
        if (target != null) {
            // TODO: make damage depend on the distance
            // TODO: make damage depend on the experience
            target.TakeDamage(50f);
        }

        Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
    }

    void PlaySoundEffect() {

        GameObject  gameObject  = new GameObject("AK47 Single Shot Sound");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip   = Resources.Load<AudioClip>("AK47SingleShot");
        audioSource.pitch  = Random.Range(0.9f, 1.1f);
        audioSource.volume = 1;
        audioSource.Play();

        Destroy(gameObject, audioSource.clip.length);
    }
}
