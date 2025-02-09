using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private CarController _carController;

    private void Start()
    {
        _carController = GetComponent<CarController>();
    }

    private void Update()
    {
        _carController.MoveInput = Input.GetAxis("Vertical");
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        _carController.MoveInput = context.ReadValue<float>();
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        _carController.SteerInput = context.ReadValue<float>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Vector2 lookInput = context.ReadValue<Vector2>();
        // _carController.LookInput = lookInput;
    }
}
