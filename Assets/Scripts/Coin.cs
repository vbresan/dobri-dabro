using UnityEngine;

public class Coin : MonoBehaviour, IPickable {

    public void OnPickup(GameObject player) {

        player.GetComponent<PlayerCoins>().Increment();
        Debug.Log("Coin picked up"); 
    }
}
