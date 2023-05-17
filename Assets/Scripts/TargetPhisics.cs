using UnityEngine;

public class TargetPhisics : MonoBehaviour
{
	private Rigidbody2D rb;
	private float scale = 12.0f; // initial scale biggerst target
	public void SetScale(float s)
	{
		scale = s;
	}
	public void SetPos(Vector3 p)
	{
		transform.position = p;
	}
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(4.0f, 6.0f);
		transform.localScale = new Vector3(scale, scale, scale);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			TargetSpawner.Instance.SpawnNextGen(transform.position, scale);
			Destroy(gameObject);
		}
	}
}
