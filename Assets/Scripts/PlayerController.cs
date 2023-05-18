using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum InputMethod{NotSet,Keyboard,Gui}
    public InputMethod CurrentInputMethod;
    public IinputProvider inputProvider;

    [SerializeField] private GameObject character;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireDelay;

    private InputMethod PrevInputMethod = InputMethod.NotSet;
    private KeyboardInput keyboardInput = new KeyboardInput();
    private GuiInput guiInput = new GuiInput();
    private Animator characterAnimator;
    private SpriteRenderer characterSprite;
    private float nextShot;
    private Vector3 initialPlayerPosition;

    public void ResetPlayer()
    {
        Debug.Log(initialPlayerPosition);
        character.transform.position = initialPlayerPosition;
        characterAnimator.SetTrigger("Restart");
    }
    public void StartDeathAnim()
    {
        characterAnimator.SetTrigger("Death");
    }

    private void Start()
    {
        ChangeInputMethod();
        initialPlayerPosition = transform.position;

        Debug.Log(character);
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
        bool runState = false;

        //change input method if CurrentInputMethod was changed
        if (CurrentInputMethod != PrevInputMethod)
        {
            PrevInputMethod = CurrentInputMethod;
            ChangeInputMethod();
        }

        //handle movement left, right, stop
        if (inputProvider.GetAxies().x > 0)
        {
            characterSprite.flipX = false;
            runState = true;
        }
        else if (inputProvider.GetAxies().x < 0)
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
        character.transform.position += inputProvider.GetAxies() * moveSpeed * Time.deltaTime;

        //handle fire
        if (inputProvider.GetFire() && nextShot < 0.1)
        {
            nextShot = fireDelay;
            ArrowSpawner.Instance.SpawnArrow(character.transform.position);
        }
        nextShot -= Time.deltaTime;
    }
    private void ChangeInputMethod()
    {
        if (CurrentInputMethod == InputMethod.Gui)
            inputProvider = guiInput;
        else if (CurrentInputMethod == InputMethod.Keyboard)
            inputProvider = keyboardInput;
    }


}
