using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
	public static ArrowSpawner Instance { get; private set; }

	[SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowContainer;
    
    public void SpawnArrow(Vector3 _position)
    {
        GameObject ar =  Instantiate(arrowPrefab, arrowContainer);
        ar.transform.position = _position;
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
