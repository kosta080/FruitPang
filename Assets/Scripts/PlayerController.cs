using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private float moveSpeed;

    private KeyboardInput keyboardInput;
    private GuiInput guiInput;

    public IinputProvider inputProvider;

    private Animator characterAnimator;
    private SpriteRenderer characterSprite;
    private void Start()
    {
        keyboardInput = new KeyboardInput();
        guiInput = new GuiInput();

        ChangeInputMethod();

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
    private void ChangeInputMethod()
    {
        inputProvider = guiInput;
    }


    private void Update()
    {
        character.transform.position += inputProvider.GetAxies() * moveSpeed * Time.deltaTime;
        bool runState = false;
        if (inputProvider.GetAxies().x > 0)
        {
            characterSprite.flipX = false;
            runState = true;
            characterAnimator.SetBool("Run", true);
        }
        else if (inputProvider.GetAxies().x < 0)
        {
            characterSprite.flipX = true;
            runState = true;
            characterAnimator.SetBool("Run", true);
        }
        else
        {
            runState = false;

        }

        if (characterAnimator.GetBool("Run") != runState)
            characterAnimator.SetBool("Run", runState);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
