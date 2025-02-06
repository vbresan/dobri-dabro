using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private Slider slider;

    public void Start() {
        //Load();
    }

    public void UpdateHealth(int amount) {

        health += amount;

        if (health > 100) {
            health = 100;
        }
        if (health < 0) {
            health = 0;
        }

        slider.value = health;

        if (health == 0) {
            Die();
        }
    }

    private void Die() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Save() {
        PlayerPrefs.SetInt("Health", health);
    }

    public void Load() {
        health = PlayerPrefs.GetInt("Health");
        slider.value = health;
    }
}
