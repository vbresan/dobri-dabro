using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    [SerializeField] public int coins = 0;
    [SerializeField] private TextMeshProUGUI text;

    public void Start() {
        //Load();
    }

    public void Increment() {
        coins++;
        text.text = coins.ToString();
    }

    public void Save() {
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void Load() {
        coins = PlayerPrefs.GetInt("Coins");
        text.text = coins.ToString();
    }
}
