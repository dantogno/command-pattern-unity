using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private ControllableCharacter characterToControl;
	
	// Update is called once per frame
	void Update ()
    {
        ControlCharacter();
    }

    private void ControlCharacter()
    {
        Command command = HandleInput();

        if (command != null)
            command.Execute(characterToControl);
    }

    /// <summary>
    /// Read input and create commands based on it.
    /// In some games you might need to execute multiple commands, 
    /// for example, running and jumping.
    /// You could make HandleInput return a list of commands and then execute them all 
    /// in ControlCharacter.
    /// </summary>
    /// <returns></returns>
    private Command HandleInput()
    {
        // Unity has a built-in implementation of the Command pattern in it's Input Manager.
        // You should use it and thus GetButtonDown rather than GetKey!
        // But I want this example to work without configuring the Input Manager
        // as a requirement.

        // The input and MoveCommand should essentially tell the character what direction to move,
        // or the target destination.
        // The character itself should contain logic for determining how to interpet that
        // and check for a valid move based on the character's movement rules,
        // collision, etc.

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            return new MoveCommand((int)characterToControl.transform.position.x - 1, 
                (int)characterToControl.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            return new MoveCommand((int)characterToControl.transform.position.x + 1,
                (int)characterToControl.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            return new MoveCommand((int)characterToControl.transform.position.x,
                (int)characterToControl.transform.position.y - 1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            return new MoveCommand((int)characterToControl.transform.position.x,
                (int)characterToControl.transform.position.y + 1);
        }
        return null;
    }
}
