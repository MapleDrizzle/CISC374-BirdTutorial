using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
    public GameObject player;

    public int JumpForce = 10;
    public bool Alive = true;
    public LogicScript logic;
    public int OutofBounds = 15;
    public AudioSource flapSFX;
    public AudioSource gameOverSFX;
    public bool playSFX;
    public float tiltUpMax = 20f;
    public float tiltDownMax = -20f;
    public float rotateSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(Alive) {
            // Bird tilts flapping occurs
            float velocity = player.GetComponent<Rigidbody2D>().linearVelocityY;
            float rotationValue = Mathf.Lerp(tiltDownMax, tiltUpMax, (velocity + 5) / 10); 
            player.transform.rotation = Quaternion.Lerp(
                player.transform.rotation,
                Quaternion.Euler(0, 0, rotationValue),
                rotateSpeed * Time.deltaTime
            );
            
        }
        if(Input.GetKeyDown(KeyCode.Space) == true && Alive == true) {
            Jump();
            flapSFX.Play();

        }
        if((transform.position.y > OutofBounds || transform.position.y < (-1 * OutofBounds)) && playSFX == false) {
            logic.gameOver();
            Alive = false;
            gameOverSFX.Play();
            playSFX = true;
        }
    }

    void Jump() {
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * JumpForce;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        Alive = false;
        if(playSFX == false) {
            gameOverSFX.Play();
            playSFX = true;
        }
    }

}
