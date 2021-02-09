using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    [SerializeField] private float pushOffsetX;
    [SerializeField] private float pushOffsetY;
    [SerializeField] private AudioClip[] availableSounds;
    [SerializeField] private float randomFactor;
    
    private PaddleController _paddle;
    private Rigidbody2D _rigidbody2D;
    private AudioSource _audioSource;
    private float _defaultBonus = 1;
    private float _increaseBonus = 0.1f;
    private int _blockTouchCount = 0;
    
    private Vector3 _offset;
    private bool _gameStarted;
    
    private void Awake()
    {
        _paddle = FindObjectOfType<PaddleController>();
        if (_paddle == null)
        {
            Debug.LogError("No PaddleController was found");
            return;
        }
        _offset = new Vector3(0, _paddle.BallOffset, 0);

        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_rigidbody2D == null)
        {
            Debug.LogError("No Rigidbody2D component on the ball object");
            return;
        }

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("No AudioSource component on the ball object");
            return;
        }
    }

    private void Start()
    {
        UpdateBallPositionOnPaddle();
    }

    private void Update()
    {
        if (!_gameStarted)
        {
            CheckMouseButtonDown();
        }
    }

    private void LateUpdate()
    {
        if (!_gameStarted)
            UpdateBallPositionOnPaddle();
    }

    private void UpdateBallPositionOnPaddle()
    {
        transform.position = _paddle.transform.position + _offset;
    }

    private void CheckMouseButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
            LaunchTheBall();
        
    }
    private void LaunchTheBall()
    {
        _gameStarted = true;
        var randomOffset = Random.Range(-pushOffsetX, pushOffsetX);

        _rigidbody2D.velocity = new Vector2(randomOffset, pushOffsetY);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_gameStarted)
        {
            AddRandomVelocityTweak();
            PlaySFX();
            SetBonus(other.gameObject);
        }
    }

    private void AddRandomVelocityTweak()
    {
        var velocityTweak = new Vector2(
            Random.Range(-randomFactor, randomFactor),
            Random.Range(-randomFactor, randomFactor));
        _rigidbody2D.velocity += velocityTweak;
    }

    private void PlaySFX()
    {
        var randomClip = availableSounds[Random.Range(0, availableSounds.Length)];
        _audioSource.PlayOneShot(randomClip);
    }

    private void SetBonus(GameObject collideGameObject)
    {
        var isPaddle = collideGameObject.GetComponent<PaddleController>() != null;
        if (isPaddle)
        {
            _blockTouchCount = 0;
            return;
        }

        var block = collideGameObject.GetComponent<BlockController>();
        if (block != null)
        {
            if (block.Breakable)
                _blockTouchCount++;
        }
    }

    public float GetBonus()
    {
        if (_blockTouchCount <= 1)
            return _defaultBonus;
        
        return _defaultBonus + _increaseBonus * (_blockTouchCount - 1);
    }
}
