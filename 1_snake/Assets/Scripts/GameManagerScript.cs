using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
   public static float cameraWidth = 10.0f;
   public static float cameraHeight = 5.1f;
   public static bool withWalls;
   [SerializeField] GameObject mainMenu, gameOver, apple, snake;
   [SerializeField] AppleScript appleScript;

   public void GameOver()
   {
      gameOver.SetActive(true);
      snake.SetActive(false);
      apple.SetActive(false);
      
      GameObject[] bodies = GameObject.FindGameObjectsWithTag("Body");
      foreach(GameObject body in bodies) GameObject.Destroy(body);
   }

   private void QuitGame()
   {
      Application.Quit();
   }

   private void RestartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   private void WithWalls()
   {
      InitializeWorld();
      withWalls = true;
   }

   private void WithoutWalls()
   {
      InitializeWorld();
      withWalls = false;
   }

   private void InitializeWorld()
   {
      snake.SetActive(true);
      apple.SetActive(true);
      appleScript.RandomizePosition();
      mainMenu.SetActive(false);
   }
}