using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
	public static TargetSpawner Instance { get; private set; }

	[SerializeField] private GameObject targetsContainer;
    [SerializeField] private GameObject targetPrefab;
	private void Start()
	{
		StartCoroutine(spawnTaret());
	}

	private IEnumerator spawnTaret()
	{
		while (true)
		{
			//10 8 6 4
			spawnTarget(Vector3.zero, 10.0f);
			yield return new WaitForSeconds(10.0f);
		}
	}

	public void SpawnNextGen(Vector3 position, float scale)
	{
		if (scale > 4)
		{
			spawnTarget(position, scale - 4);
		}
	}
	private void spawnTarget(Vector3 position, float scale)
	{
		TargetPhisics targethisics =  Instantiate(targetPrefab, targetsContainer.transform).GetComponent<TargetPhisics>();
		targethisics.SetScale(scale);
		targethisics.SetPos(position);
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
