using UnityEngine;

public class Snake : MonoBehaviour
{
   public float speed = 15f;
   private Rigidbody2D headRB;
   private float x, y;

   private void Start()
   {
      headRB = GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate()
   {
      MoveHead();
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
