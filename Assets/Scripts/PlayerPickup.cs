using UnityEngine;

public class PlayerPickup : MonoBehaviour {
    public void OnTriggerEnter(Collider other)
    {
        IPickable pickable = other.GetComponent<IPickable>();
        if (pickable == null) {
            return;
        } 

        pickable.OnPickup(gameObject);
        Destroy(other.gameObject);
    }
}
