using System.Collections;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
	public static TargetSpawner Instance { get; private set; }

	[SerializeField] private GameObject targetsContainer;
    [SerializeField] private GameObject targetPrefab;

	private enum direction { right,left}
	private void Start()
	{
		StartCoroutine(spawnTaret());
	}

	private IEnumerator spawnTaret()
	{
		while (true)
		{
			//10 8 6 4
			spawnTarget(Vector3.zero, 10.0f, (int)direction.right);
			yield return new WaitForSeconds(10.0f);
		}
	}

	public void SpawnNextGen(Vector3 _position, float _scale)
	{
		if (_scale > 4)
		{
			spawnTarget(_position, _scale - 4, (int)direction.right);
			spawnTarget(_position, _scale - 4, (int)direction.left);
		}
	}
	private void spawnTarget(Vector3 _position, float _scale, int _direction)
	{
		TargetPhisics targethisics =  Instantiate(targetPrefab, targetsContainer.transform).GetComponent<TargetPhisics>();
		targethisics.SetScale(_scale);
		targethisics.SetPos(_position);
		targethisics.SetDir(_direction);
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this);
			return;
		}
		Instance = this;
	}
}
