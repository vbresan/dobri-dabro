using UnityEngine;

public class Heal : MonoBehaviour, IPickable
{
    public void OnPickup(GameObject player) {
        Debug.Log("Heal picked up"); 
        player.GetComponent<PlayerHealth>().UpdateHealth(20);
    }
}
