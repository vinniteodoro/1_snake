using UnityEngine;

public class Apple : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.tag == "Player") RandomizePosition();
   }

   public void RandomizePosition()
   {
      transform.position = new Vector3(Random.Range(-GameManager.cameraWidth + .3f, GameManager.cameraWidth - .3f), Random.Range(-GameManager.cameraHeight + .3f, GameManager.cameraHeight - .3f), 0);
   }
}
