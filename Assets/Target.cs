using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float health = 100;

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
