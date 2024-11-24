using UnityEngine;
using UnityEngine.InputSystem;

public class KeypadEnterDetector : MonoBehaviour
{
    private InputAction enterAction;
    private InputAction keypadEnterAction;

    void Awake()
    {
        var inputActionAsset = new InputActionAsset(); // Your .inputactions asset reference here

        // Create and bind actions to the corresponding keys
        enterAction = inputActionAsset.FindAction("Player Controls/Enter", throwIfNotFound: true);
        keypadEnterAction = inputActionAsset.FindAction("Player Controls/KeypadEnter", throwIfNotFound: true);
    }

    void OnEnable()
    {
        enterAction.Enable();
        keypadEnterAction.Enable();
    }

    void OnDisable()
    {
        enterAction.Disable();
        keypadEnterAction.Disable();
    }

    void Update()
    {
        // Check if the respective keys are pressed
        if (enterAction.triggered)
        {
            Debug.Log("Standard Enter key pressed.");
        }

        if (keypadEnterAction.triggered)
        {
            Debug.Log("Keypad Enter key pressed.");
        }
    }
}
