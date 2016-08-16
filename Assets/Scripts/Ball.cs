using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	public float Speed = 30;
    public float SpeedUpRate = 0.2f;
    public int ScoreLimit = 10;
    private float _timeElapsed;
    private GameObject _scoreGameObject;
    private Text _scoreText;
    private int _leftScore;
    private int _rightScore;
    private ScoreManager _scoreManager;


    // ReSharper disable once UnusedMember.Local
    private void Start() {
        RestartPosition();
        _scoreText = GameObject.FindGameObjectsWithTag("Score")[0].transform.GetComponent<Text>();
        _scoreManager = _scoreText.GetComponent<ScoreManager>();

    }

    private void RestartPosition() {
        var initalVelocity = Random.value;
        transform.position = new Vector3(0, 0, 0);
        _timeElapsed = 0;
        GetComponent<Rigidbody2D>().velocity = initalVelocity >= 0.5f ? Vector2.right * Speed : Vector2.left * Speed;
    }

    private float BallBounce(Vector2 ballPos, Vector2 paddlePos, float paddleHeight) {
		return (ballPos.y - paddlePos.y) / paddleHeight;
	}

    private void Update() {
        _timeElapsed += Time.deltaTime;

		if (transform.position.x < -10f) {
			_scoreManager.RightScored ();
			RestartPosition ();
		} else if (transform.position.x > 10f) {
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

                GetComponent<Rigidbody2D>().velocity = dir*(Speed + _timeElapsed*SpeedUpRate);
            }
                break;
            case "PaddleRight": {
                var y = BallBounce(transform.position, col.transform.position, col.collider.bounds.size.y);
                var dir = new Vector2(-1, y).normalized;

                GetComponent<Rigidbody2D>().velocity = dir*(Speed + _timeElapsed*SpeedUpRate);
            }
                break;
        }
    }
}