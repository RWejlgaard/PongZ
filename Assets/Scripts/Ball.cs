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

    public void RestartPosition() {
        var initalVelocity = Random.value;
        transform.position = new Vector3(0, 0, 0);
        _timeElapsed = 0;
        GetComponent<Rigidbody2D>().velocity = initalVelocity >= 0.5f ? Vector2.right * Speed : Vector2.left * Speed;
    }

    private float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
		return (ballPos.y - racketPos.y) / racketHeight;
	}

    private void Update() {
        _timeElapsed += Time.deltaTime;
    }

    // ReSharper disable once UnusedMember.Local
    private void OnCollisionEnter2D(Collision2D col) {
        switch (col.gameObject.name) {
            case "PaddleLeft":
                {
                    var y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
                    var dir = new Vector2(1, y).normalized;

                    GetComponent<Rigidbody2D>().velocity = dir * (Speed + _timeElapsed * SpeedUpRate);
                }
                break;

            case "PaddleLeft(Clone)": {
                var y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
                var dir = new Vector2(1, y).normalized;

                GetComponent<Rigidbody2D>().velocity = dir * (Speed + _timeElapsed * SpeedUpRate);
            }
            break;

            case "PaddleRight": {
                var y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
                var dir = new Vector2(-1, y).normalized;

                GetComponent<Rigidbody2D>().velocity = dir*(Speed + _timeElapsed * SpeedUpRate);
            }
            break;

            case "PaddleRight(Clone)":
                {
                    var y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
                    var dir = new Vector2(-1, y).normalized;

                    GetComponent<Rigidbody2D>().velocity = dir * (Speed + _timeElapsed * SpeedUpRate);
                }
                break;

            case "LeftGoal": {
                _scoreManager.RightScored();
                RestartPosition();
            }
            break;

            case "RightGoal": {
                _scoreManager.LeftScored();
                RestartPosition();
            }
            break;
        }
    }
}