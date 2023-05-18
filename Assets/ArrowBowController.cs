using UnityEngine;

public class ArrowBowController : MonoBehaviour
{
    [SerializeField] private float arrowSpeed;
    
    void Update()
    {
        transform.position += new Vector3(0, arrowSpeed, 0) * Time.deltaTime;
    }

	private void OnCollisionEnter2D(Collision2D _collision)
	{
        if (_collision.gameObject.tag == "Ceiling")
        {
            Destroy(gameObject);
        }
	}
}
