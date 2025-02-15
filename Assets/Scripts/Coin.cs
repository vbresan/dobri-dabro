using UnityEngine;

public class Coin : MonoBehaviour, IPickable {

    public void OnPickup(GameObject player) {
        AudioManager.PlaySound(Sounds.Coin);
        player.GetComponent<PlayerCoins>().Increment();
    }
}
