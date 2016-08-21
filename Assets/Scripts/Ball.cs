using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	public float Speed = 30;
    public float SpeedUpRate = 0.2f;
    public int ScoreLimit = 10;
    private float _timeElapsed;
    private GameObject _scoreGameObject;
    private Text _scoreText;
    private ScoreManager _scoreManager;
    public GameObject lastplayer;


    // ReSharper disable once UnusedMember.Local
    private void Start() {
        lastplayer = GameObject.FindGameObjectsWithTag("Player")[0];
        RestartPosition();
        _scoreText = GameObject.FindGameObjectsWithTag("Score")[0].transform.GetComponent<Text>();
        _scoreManager = _scoreText.GetComponent<ScoreManager>();

    }

    private void RestartPosition() {
        var initalVelocity = Random.value;
        transform.position = new Vector3(0, 0, 0);
        _timeElapsed = 0;
        switch (lastplayer.name) {
            case "PaddleLeft":
                GetComponent<Rigidbody2D>().velocity = Vector2.right * Speed;
                break;
            case "PaddleRight":
                GetComponent<Rigidbody2D>().velocity = Vector2.left * Speed;
                break;
            default:
                GetComponent<Rigidbody2D>().velocity = Vector2.right * Speed;
                break;
        }
    }

    private float BallBounce(Vector2 ballPos, Vector2 paddlePos, float paddleHeight) {
		return (ballPos.y - paddlePos.y) / paddleHeight;
	}

    private void Update() {
        _timeElapsed += Time.deltaTime;

        if (transform.position.x < -10f) {
            _scoreManager.RightScored();
            RestartPosition();
        }
        else if (transform.position.x > 10f) {
            _scoreManager.LeftScored();
            RestartPosition();
        }
    }
   

    // ReSharper disable once UnusedMember.Local
    private void OnCollisionEnter2D(Collision2D col) {
        switch (col.gameObject.name) {
            case "PaddleLeft": {
                var y = BallBounce(transform.position, col.transform.position, col.collider.bounds.size.y);
                var dir = new Vector2(1, y).normalized;
                lastplayer = col.gameObject;
                
                GetComponent<Rigidbody2D>().velocity = dir*(Speed + _timeElapsed*SpeedUpRate);
            }
                break;
            case "PaddleRight": {
                var y = BallBounce(transform.position, col.transform.position, col.collider.bounds.size.y);
                var dir = new Vector2(-1, y).normalized;
                lastplayer = col.gameObject;

                GetComponent<Rigidbody2D>().velocity = dir*(Speed + _timeElapsed*SpeedUpRate);
            }
                break;
            case "Brick": {
                Destroy(col.gameObject);
                var y = BallBounce(transform.position, col.transform.position, col.collider.bounds.size.y);
            }
                break;
        }
    }
}