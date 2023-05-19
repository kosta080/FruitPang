using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireDelay;
    [SerializeField] private Vector3 initialPlayerPosition;

    private InputAgrigator inputAgrigator = new InputAgrigator();

    private Animator characterAnimator;
    private SpriteRenderer characterSprite;
    private float nextShot;
    

    public void ResetPlayer()
    {
        character.transform.position = initialPlayerPosition;
        characterAnimator.SetTrigger("Restart");
        characterAnimator.SetBool("Run", false);
        characterSprite.flipX = false;
    }
    public void StartDeathAnim()
    {
        characterAnimator.SetTrigger("Death");
    }

    private void Start()
    {
        inputAgrigator.initInput();

        if (character)
        {
            characterAnimator = character.GetComponent<Animator>();
            characterSprite = character.GetComponent<SpriteRenderer>();
        }
        else
        {
            Debug.LogWarning("Player controller needs reference to a character GameObject");
        }
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;

        bool runState = false;

        //handle movement left, right, stop
        if (inputAgrigator.GetAxies().x > 0)
        {
            characterSprite.flipX = false;
            runState = true;
        }
        else if (inputAgrigator.GetAxies().x < 0)
        {
            characterSprite.flipX = true;
            runState = true;
        }
        else
        {
            runState = false;
        }
        //trigger animatins
        if (characterAnimator.GetBool("Run") != runState)
            characterAnimator.SetBool("Run", runState);

        //move character
        character.transform.position += inputAgrigator.GetAxies() * moveSpeed * Time.deltaTime;

        //handle fire
        if (inputAgrigator.GetFire() && nextShot < 0.1)
        {
            nextShot = fireDelay;
            ArrowSpawner.Instance.SpawnArrow(character.transform.position);
        }
        nextShot -= Time.deltaTime;
    }

}
