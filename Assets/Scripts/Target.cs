using UnityEngine;

// TODO: show health bar above the target
public class Target : MonoBehaviour
{
    [SerializeField] private float health = 100;

    // TODO: make damage depend on the body part
    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }

}
