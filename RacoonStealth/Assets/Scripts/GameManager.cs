using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject completeGameScreen;
    public GameObject player;
    public Tilemap DarkMap;
    public Tilemap BlurredMap;
    public Tilemap BackgroundMap;
    public Tile DarkTile;
    public Tile BlurredTile;
    [SerializeField]

    private void Awake() 
    {
        isGameOver = false;
    }

    void Start()
    {
        DarkMap.origin = BlurredMap.origin = BackgroundMap.origin;
        DarkMap.size = BlurredMap.size = BackgroundMap.size;

        foreach (Vector3Int p in DarkMap.cellBounds.allPositionsWithin)
        {
            DarkMap.SetTile(p, DarkTile);
        }
        foreach (Vector3Int p in BlurredMap.cellBounds.allPositionsWithin)
        {
            BlurredMap.SetTile(p, BlurredTile);
        }
    }

    void Update()
    {
        CheckIsOver();
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void CheckIsOver()
    {
        if (isGameOver){
            gameOverScreen.SetActive(true);
            player.SetActive(false);
        }
    }

    public IEnumerator CompleteGame(){
        completeGameScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        player.SetActive(false);
    }
}
