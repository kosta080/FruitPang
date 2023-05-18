using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Transform targetContainer;
    [SerializeField] private Transform arrowContainer;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject getReady;

	public void PlayerDeath()
    {
        Time.timeScale = 0;
        StartCoroutine(restartLevel());
    }
	private void Start()
	{
        Time.timeScale = 0;
        StartCoroutine(startLevel());
    }
    private IEnumerator startLevel()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        getReady.SetActive(false);
        Time.timeScale = 1;
    }
    private IEnumerator restartLevel()
    {
        playerController.StartDeathAnim();

        yield return new WaitForSecondsRealtime(2.0f);

        foreach (Transform child in targetContainer)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in arrowContainer)
        {
            Destroy(child.gameObject);
        }

        playerController.ResetPlayer();
        Time.timeScale = 1;
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
