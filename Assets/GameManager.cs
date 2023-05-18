using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Transform targetContainer;
    [SerializeField] private Transform arrowContainer;
    [SerializeField] private PlayerController playerController;

    public void PlayerDeath()
    {
        Time.timeScale = 0;
        StartCoroutine(restartLevel());
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
