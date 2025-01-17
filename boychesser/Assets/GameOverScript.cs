using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameOverScript : MonoBehaviour
{
    public TMP_Text Moves;
    public GameObject gameOverUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Setup(int moves) {
        gameOverUI.SetActive(true);
        Moves.text = "MOVES: " + moves.ToString();
    }
}
