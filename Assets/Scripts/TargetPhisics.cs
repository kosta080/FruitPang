using UnityEngine;

public class TargetPhisics : MonoBehaviour
{
	[Header("Scoring")]
	[SerializeField] private int targetScoreValue;

	private Rigidbody2D rb;
	private float[] scales = { 12.0f ,10.0f,8.0f,4.0f}; // initial scale biggerst target
	private int scaleState = 0;
	private float xStartSpeed = 4.0f;
	private float yStartSpeed = 6.0f;
	
	public void SetScale(int state)
	{
		scaleState = state;
	}
	public void SetPos(Vector3 _position)
	{
		transform.position = _position;
	}
	public void SetDir(int _direction)
	{
		if (_direction == (int)TargetSpawner.direction.left)
		{
			xStartSpeed *= -1;
		}
	}
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(xStartSpeed, yStartSpeed);
		transform.localScale = new Vector3(scales[scaleState], scales[scaleState], scales[scaleState]);
	}

	private void OnCollisionEnter2D(Collision2D _collision)
	{
		if (_collision.gameObject.tag == "Arrow")
		{
			Destroy(_collision.gameObject); // destroy Arrow
			TargetSpawner.Instance.SpawnNextGen(transform.position, scaleState, scales.Length); //spawn new Targets
			GameManager.Instance.TargetHit(targetScoreValue);
			SoundManager.Instance.PlaySfx(SoundManager.Instance.targetHit);
			Destroy(gameObject); // destroy this target
		}

		if (_collision.gameObject.tag == "Player")
		{
			SoundManager.Instance.PlaySfx(SoundManager.Instance.playerHit);
			GameManager.Instance.PlayerDeath();
		}
	}
}
