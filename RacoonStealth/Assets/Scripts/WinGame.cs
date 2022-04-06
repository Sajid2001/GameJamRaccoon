using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameManager gameManager;
    void OnTriggerEnter2D() {
        StartCoroutine(gameManager.CompleteGame());
    }
}
