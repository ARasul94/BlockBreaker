using UnityEngine;

public class Ball : MonoBehaviour
{   
    private Paddle paddle1; 
    [SerializeField] float xVel = 0f; 
    [SerializeField] float yVel = 15f; 
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    bool hasStarted = false;
    Vector2 paddleToBallVector; 
    // Cash
    AudioSource myAudioSource;

    Rigidbody2D myrigidbody2D;


    void Start()
    {
        paddle1 = FindObjectOfType<Paddle>();
        paddleToBallVector =  transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted){
            LockBallToPaddle(); 
            
        }
       LaunchOnSpacePressed();

    }

    private void LaunchOnSpacePressed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.velocity = new Vector2 (0f, 15f);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle(){
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }



    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted){

            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);  
            myrigidbody2D.velocity +=velocityTweak;
        }
       

    }

}
