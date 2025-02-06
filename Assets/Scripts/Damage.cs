using UnityEngine;

public class Damage : MonoBehaviour, IPickable
{
    public void OnPickup(GameObject player) {
        Debug.Log("Damage picked up");
        player.GetComponent<PlayerHealth>().UpdateHealth(-50);
    }
}
