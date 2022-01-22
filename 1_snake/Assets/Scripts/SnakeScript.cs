using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeScript : MonoBehaviour
{
   private float speed = 5f;
   private Rigidbody2D headRB;
   private float x, y;

   private void Start()
   {
      headRB = GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate()
   {
      MoveHead();
      VerifyBoundaries();
   }

   public void GameOver()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void VerifyBoundaries()
   {
      if(transform.position.x >= GameManagerScript.cameraWidth || transform.position.x <= -GameManagerScript.cameraWidth || transform.position.y >= GameManagerScript.cameraHeight || transform.position.y <= -GameManagerScript.cameraHeight)
      {
         if(GameManagerScript.withWalls) GameOver();
         else 
         {
            if(transform.position.x >= GameManagerScript.cameraWidth) transform.position = new Vector3(-GameManagerScript.cameraWidth, transform.position.y, 0);
            else if(transform.position.x <= -GameManagerScript.cameraWidth) transform.position = new Vector3(GameManagerScript.cameraWidth, transform.position.y, 0);
            else if(transform.position.y >= GameManagerScript.cameraHeight) transform.position = new Vector3(transform.position.x, -GameManagerScript.cameraHeight, 0);
            else if(transform.position.y <= -GameManagerScript.cameraHeight) transform.position = new Vector3(transform.position.x, GameManagerScript.cameraHeight, 0);
         }
      }
   }

   public void MoveHead()
   {
      if(Input.GetKey(KeyCode.RightArrow))
      {
         if(x != -1)
         {
            x = 1;
            y = 0;
         }
      }

      if(Input.GetKey(KeyCode.LeftArrow))
      {
         if(x != 1)
         {
            x = -1;
            y = 0;
         }
      }
      if(Input.GetKey(KeyCode.UpArrow))
      {
         if(y != -1)
         {
            x = 0;
            y = 1;
         }
      }
      if(Input.GetKey(KeyCode.DownArrow))
      {
         if(y != 1)
         {
            x = 0;
            y = -1;
         }
      }

      headRB.velocity = new Vector3(x * speed, y * speed, 0);
   }
}