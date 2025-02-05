using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float  maxDistance = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, maxDistance)) {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null) {
                    target.TakeDamage(50f);
                }
            }
        }
    }
}
