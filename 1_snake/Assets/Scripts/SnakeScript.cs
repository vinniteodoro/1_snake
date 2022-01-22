using UnityEngine;
using System.Collections.Generic;

public class SnakeScript : MonoBehaviour
{
   private List<GameObject> snakeObjectsList = new List<GameObject>();
   private List<List<Vector3>> snakePositionsList = new List<List<Vector3>>();
   private float speed = 5f;
   private Rigidbody2D headRB;
   private float x, y;
   [SerializeField] GameObject bodyPreFab;
   [SerializeField] GameManagerScript gMScript;

   private void Start()
   {
      headRB = GetComponent<Rigidbody2D>(); 
      snakeObjectsList.Add(this.gameObject);
      snakePositionsList.Add(new List<Vector3>());
   }

   private void FixedUpdate()
   {
      MoveHead();
      VerifyBoundaries();
      TrackObjectsPosition();
      MoveBodies();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.tag == "Apple") 
      {
         var insertNewBody = Instantiate(bodyPreFab, new Vector3(0, 0, 0), Quaternion.identity);
         snakeObjectsList.Add(insertNewBody);
         snakePositionsList.Add(new List<Vector3>());
      }
      else if(other.tag == "Body") gMScript.GameOver();
   }

   private void TrackObjectsPosition()
   {
      for(int i = 0; i <= snakeObjectsList.Count - 1; i++)
      {
         snakePositionsList[i].Add(snakeObjectsList[i].transform.position);
      }
   }

   private void MoveBodies()
   {
      for (int i = snakeObjectsList.Count - 1; i > 0; i--)
      {
         snakeObjectsList[i].transform.position = snakePositionsList[i - 1][snakePositionsList[i - 1].Count - 5];
      }
   }

   private void VerifyBoundaries()
   {
      if(transform.position.x >= GameManagerScript.cameraWidth || transform.position.x <= -GameManagerScript.cameraWidth || transform.position.y >= GameManagerScript.cameraHeight || transform.position.y <= -GameManagerScript.cameraHeight)
      {
         if(GameManagerScript.withWalls) gMScript.GameOver();
         else 
         {
            if(transform.position.x >= GameManagerScript.cameraWidth) transform.position = new Vector3(-GameManagerScript.cameraWidth, transform.position.y, 0);
            else if(transform.position.x <= -GameManagerScript.cameraWidth) transform.position = new Vector3(GameManagerScript.cameraWidth, transform.position.y, 0);
            else if(transform.position.y >= GameManagerScript.cameraHeight) transform.position = new Vector3(transform.position.x, -GameManagerScript.cameraHeight, 0);
            else if(transform.position.y <= -GameManagerScript.cameraHeight) transform.position = new Vector3(transform.position.x, GameManagerScript.cameraHeight, 0);
         }
      }
   }

   private void MoveHead()
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