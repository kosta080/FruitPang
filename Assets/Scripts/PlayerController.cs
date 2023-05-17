using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public enum InputMethod{NotSet,Keyboard,Gui}
    public InputMethod CurrentInputMethod;
    public IinputProvider inputProvider;

    [SerializeField] private GameObject character;
    [SerializeField] private float moveSpeed;

    private InputMethod PrevInputMethod = InputMethod.NotSet;
    private KeyboardInput keyboardInput = new KeyboardInput();
    private GuiInput guiInput = new GuiInput();
    private Animator characterAnimator;
    private SpriteRenderer characterSprite;

    private void Start()
    {
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
        if (CurrentInputMethod == InputMethod.Gui)
            inputProvider = guiInput;
        else if (CurrentInputMethod == InputMethod.Keyboard)
            inputProvider = keyboardInput;
    }


    private void Update()
    {
        bool runState = false;

        if (CurrentInputMethod != PrevInputMethod)
        {
            PrevInputMethod = CurrentInputMethod;
            ChangeInputMethod();
        }

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

        if (characterAnimator.GetBool("Run") != runState)
            characterAnimator.SetBool("Run", runState);

        character.transform.position += inputProvider.GetAxies() * moveSpeed * Time.deltaTime;
    }

}
