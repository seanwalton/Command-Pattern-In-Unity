using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CommandProcessor))]
public class PlayerBehaviour : MonoBehaviour, IEntity
{

    [SerializeField] float speed;

    private CommandProcessor _commandProcessor;
    private Vector2 playerInput;
    private bool undoActive;
    private bool playerMoving;

    private void Awake()
    {
        _commandProcessor = GetComponent<CommandProcessor>();
    }

    private void Start()
    {
        playerInput = Vector2.zero;
        undoActive = false;
        playerMoving = false;
    }

    private void Update()
    {
        if (undoActive)
        {
            _commandProcessor.Undo();
        }
        else if (playerMoving)
        {
            _commandProcessor.ExecuteCommand(new MoveCommand(this, playerInput, speed * Time.deltaTime));
        }
        
    }


    public void OnPlayerUndo(InputAction.CallbackContext input)
    {
        if (input.started) undoActive = true;
        if (input.canceled) undoActive = false;
    }

    public void OnPlayerMoveChange(InputAction.CallbackContext input)
    {
        playerInput = input.ReadValue<Vector2>();
        if (input.started) playerMoving = true;
        if (input.canceled)
        {
            playerInput = Vector2.zero;
            playerMoving = false;
        }
    }
}
