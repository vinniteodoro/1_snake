using UnityEngine;

public class AppleScript : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.tag == "Player") RandomizePosition();
   }

   public void RandomizePosition()
   {
      transform.position = new Vector3(Random.Range(-GameManagerScript.cameraWidth + .3f, GameManagerScript.cameraWidth - .3f), Random.Range(-GameManagerScript.cameraHeight + .3f, GameManagerScript.cameraHeight - .3f), 0);
   }
}