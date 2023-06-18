
using UnityEngine;

public class AutoMove : MonoBehaviour
{
     public float speed = 5f; // Adjust the speed as desired
                              //private GameObject Triangle;
    [SerializeField] float lanePositionY;
    private float gameX;
     //private Vector2 respawn;
     //public GameObject fallDetector;
     

     void Start()
     {
        gameX = 0;
        //respawn = transform.position;
     }

    void Update()
    
    {
        gameX = Time.deltaTime * speed;
        transform.position= new Vector3(transform.position.x-gameX, transform.position.y, transform.position.z);
        
    }
        
        /* private void OnTriggerEnter2D(Collider2D collision)
         {
           
            if (collision.tag == "FallDetector")
            {

                transform.position = respawn;

            }
            else if (collision.tag == "CheckPoint")
            {
                respawn = transform.position;
            }
           
         }*/
    
}
