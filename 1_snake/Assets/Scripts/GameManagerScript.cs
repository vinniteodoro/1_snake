using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
   public static float cameraWidth = 10.0f;
   public static float cameraHeight = 5.1f;
   public static bool withWalls;
   public GameObject mainMenu, snake, apple;

   public void GameOver()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void WithWalls()
   {
      InitializeWorld();
      withWalls = true;
   }

   public void WithoutWalls()
   {
      InitializeWorld();
      withWalls = false;
   }

   public void InitializeWorld()
   {
      Instantiate(snake, new Vector3(0, 0, 0), Quaternion.identity);
      Instantiate(apple, new Vector3(0, 0, 0), Quaternion.identity);
      
      RandomizePosition();
      
      mainMenu.SetActive(false);
   }

   public void RandomizePosition()
   {
      apple.transform.position = new Vector3(Random.Range(-GameManagerScript.cameraWidth + .3f, GameManagerScript.cameraWidth - .3f), Random.Range(-GameManagerScript.cameraHeight + .3f, GameManagerScript.cameraHeight - .3f), 0);
   }
}