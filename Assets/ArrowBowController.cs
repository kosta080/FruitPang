using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBowController : MonoBehaviour
{
    [SerializeField] private float arrowSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, arrowSpeed, 0) * Time.deltaTime;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Ceiling")
        {
            Destroy(gameObject);
        }
	}
}
