using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public enum Lanes
{
    up, centre, down
}

public class PlayerJump : MonoBehaviour
{
    
    Lanes currentlane;
    [SerializeField] Transform[] lanesTransform;
    public float speed = 5f;
    //private Rigidbody2D rb;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite[] sprites;
    private float playerPositionX;
    private const string PLAYERTAG = "Player";
    

    public Text scoreText;

   


    void Start()
    {
        GridShape();
        //rb = GetComponent<Rigidbody2D>();
        playerPositionX = transform.position.x;
        scoreText.text = "Score: " + Scoring.totalScore;
    }

    private void GridShape()
    {
        int rand = Random.Range(0, sprites.Length);
        _spriteRenderer.sprite = sprites[rand];
        switch (rand)
        {
            case 0:
                gameObject.tag = "Circle";
                break;

            case 1:
                gameObject.tag = "Square";
                break;
            case 2:
                gameObject.tag = "Triangle";
                break;
        }
    }

    void Update() 
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
     

           if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDown();
            }

        
    }
    private void MoveUp()
    {
        switch (currentlane)
        {
            case (global::Lanes.up):
                return;
            case (global::Lanes.centre):
                currentlane = global::Lanes.up;
                transform.position = new Vector3(playerPositionX, lanesTransform[0].position.y, 0);
                return;
            case (global::Lanes.down):
                currentlane = global::Lanes.centre;
                transform.position = new Vector3(playerPositionX, lanesTransform[1].position.y, 0);
                return;
        }
    }
    private void MoveDown()
    {
        switch (currentlane)
        {
            case (global::Lanes.up):
                currentlane = global::Lanes.centre;
                transform.position = new Vector3(playerPositionX, lanesTransform[1].position.y, 0);
                return;
            case (global::Lanes.centre):
                currentlane = global::Lanes.down;
                transform.position = new Vector3(playerPositionX, lanesTransform[2].position.y, 0);
                return;
            case (global::Lanes.down):
                return;
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag))
        {
            // Collided with the correct shape
            Scoring.totalScore += 1;
            scoreText.text = "Score: " + Scoring.totalScore;
            Destroy(collision.gameObject);
        }
        else
        {
            // Collided with the wrong shape, destroy the player
            DestroyPlayer();
            DisplayText.isGAMEOVER = true;
        }
    }


    private void DestroyPlayer()
    {
        Destroy(gameObject);
        //gameObject.SetActive(false);


       
    }
    /*private void DestroyPlayer()
    {
        // Disable the player object
        gameObject.SetActive(false);

        // Display the Game Over text
        gameOverText.SetActive(true);
    }*/
}
