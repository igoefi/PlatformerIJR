using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputSystem_Actions _input;

    public event Action AttackPressed;
    public event Action VampirizmPressed;
    public event Action JumpPressed;
    public event Action JumpUnpress;
    public event Action<Vector2> MovementPressed;
    
    private void Awake()
    {
        _input = new();
        _input.Enable();    
    }
    
    private void OnEnable()
    {
        _input.Player.Jump.performed += PressJump;
        _input.Player.Jump.canceled += UnpressJump;
        _input.Player.Move.performed += PressMovement;
        _input.Player.Move.canceled += PressMovement;
        _input.Player.Attack.performed += PressAttack;
        _input.Player.Vampirizm.performed += PressVampirizm;
    }

    private void OnDisable()
    {
        _input.Player.Jump.performed -= PressJump;
        _input.Player.Jump.canceled -= UnpressJump;
        _input.Player.Move.performed -= PressMovement;
        _input.Player.Move.canceled -= PressMovement;
        _input.Player.Attack.performed -= PressAttack;
        _input.Player.Vampirizm.performed -= PressVampirizm;
    }
    
    private void PressJump(InputAction.CallbackContext _) =>
        JumpPressed?.Invoke();
    
    private void PressVampirizm(InputAction.CallbackContext _) =>
        VampirizmPressed?.Invoke();

    private void UnpressJump(InputAction.CallbackContext _) =>
        JumpUnpress?.Invoke();
    
    private void PressMovement(InputAction.CallbackContext context) =>
        MovementPressed?.Invoke(context.ReadValue<Vector2>());
    
    private void PressAttack(InputAction.CallbackContext _) =>
        AttackPressed?.Invoke();
}
