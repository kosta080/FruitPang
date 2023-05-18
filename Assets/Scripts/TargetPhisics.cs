using UnityEngine;

public class TargetPhisics : MonoBehaviour
{
	private Rigidbody2D rb;
	private float startScale = 12.0f; // initial scale biggerst target
	private float xStartSpeed = 4.0f;
	private float yStartSpeed = 6.0f;
	private enum direction { right,left};
	public void SetScale(float _scale)
	{
		startScale = _scale;
	}
	public void SetPos(Vector3 _position)
	{
		transform.position = _position;
	}
	public void SetDir(int _direction)
	{
		if (_direction == (int)direction.left)
		{
			xStartSpeed *= -1;
		}
		//rb.velocity = new Vector2(4.0f, horisontalSpeed);
	}
	private void Start()
	{
		Debug.Log(xStartSpeed);
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(xStartSpeed, yStartSpeed);
		transform.localScale = new Vector3(startScale, startScale, startScale);
	}

	private void OnCollisionEnter2D(Collision2D _collision)
	{
		if (_collision.gameObject.tag == "Arrow")
		{
			Destroy(_collision.gameObject); // destroy Arrow
			TargetSpawner.Instance.SpawnNextGen(transform.position, startScale); //spawn new Targets
			Destroy(gameObject); // destroy this target
		}
	}
}
