using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    PlayerControls inputActions;

    Vector2 moveInput;
    Vector2 cameraInput;

    private void OnEnable() 
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();

            inputActions.Player.Movement.performed += inputActions => moveInput = inputActions.ReadValue<Vector2>();
            inputActions.Player.Camera.performed += i => cameraInput= i.ReadValue<Vector2>();
        }

        inputActions .Enable();
    }

    private void OnDisable() 
    {
        inputActions.Disable();
    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
    }

    private void MoveInput(float delta)
    {
        horizontal = moveInput.x;
        vertical = moveInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }
}
