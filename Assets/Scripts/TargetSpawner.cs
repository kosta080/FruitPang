using System.Collections;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
	public static TargetSpawner Instance { get; private set; }

	[SerializeField] private GameObject targetsContainer;
	[SerializeField] private GameObject bonusesContainer;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject[] bonussPrefabs;
	//[SerializeField] private int targetsSpawnCount;
	[SerializeField] private float spawnTimeInterval;
	[SerializeField] private float chenceBonusSpawn;

	public enum direction { right,left}
	public void SpawnTarget() => spawnTarget(Vector3.zero, 0, (int)direction.right);
	
	public void SpawnNextGen(Vector3 _position, int _scaleState, int _scaleStateCount)
	{
		//allow spawn next generation of targets if the scales array has value in _scaleState position +1
		if (_scaleState+1 < _scaleStateCount)
		{
			spawnTarget(_position, _scaleState+1, (int)direction.right);
			spawnTarget(_position, _scaleState+1, (int)direction.left);
		}
		spawnRandomBonus(_position);
	}
	private void spawnTarget(Vector3 _position, int _scaleState, int _direction)
	{
		TargetPhisics targetPhisics =  Instantiate(targetPrefab, targetsContainer.transform).GetComponent<TargetPhisics>();
		targetPhisics.SetScale(_scaleState);
		targetPhisics.SetPos(_position);
		targetPhisics.SetDir(_direction);
	}
	private void spawnRandomBonus(Vector3 _position)
	{
		float r = Random.value;
		if (r < chenceBonusSpawn)
		{
			int randomBonus = Random.Range(0, bonussPrefabs.Length-1);
			BonusPhisics bonusPhisics = Instantiate(bonussPrefabs[randomBonus], bonusesContainer.transform).GetComponent<BonusPhisics>(); ;
			bonusPhisics.SetPos(_position);
		}
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
