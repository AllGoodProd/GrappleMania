
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{


    public PlayerMovement movement;
    

    private void OnCollisionEnter(Collision collisionInfo)
    {
        
        if (collisionInfo.collider.tag == "Obstacle")
        {
            GetComponent<PlayerMovement>().enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }


}
