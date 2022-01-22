using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static float cameraWidth = 10.0f;
   public static float cameraHeight = 5.1f;
   public Apple appleScript;
   public Transform apple, snake;
   public GameObject mainMenu;

   public void PlayGame()
   {
      Instantiate(snake, new Vector3(0, 0, 0), Quaternion.identity);
      Instantiate(apple, new Vector3(0, 0, 0), Quaternion.identity);
      appleScript.RandomizePosition();
      mainMenu.SetActive(false);
   }
}
