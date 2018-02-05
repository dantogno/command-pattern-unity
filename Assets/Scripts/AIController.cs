using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{ 
    [SerializeField]
    private ControllableCharacter characterToControl;

    [SerializeField]
    private Transform target;

    private Vector3 targetPreviousPosition;

    private void Start()
    {
        targetPreviousPosition = target.position;
    }

    // Update is called once per frame
    void Update ()
    {
        bool targetMoved = CheckIfTargetMoved();

        Debug.Log("Target moved: " + targetMoved);

        if (targetMoved)
            MoveTowardTarget();
	}

    /// <summary>
    /// Return true if target moved.
    /// We only want to move the AI character
    /// if the player character has moved,
    /// to simulate "turns."
    /// </summary>
    /// <returns></returns>
    bool CheckIfTargetMoved()
    {
       return target.position != targetPreviousPosition;
    }

    /// <summary>
    /// Move the AI character toward the target character.
    /// </summary>
    private void MoveTowardTarget()
    {
        Vector2 distanceToTarget = target.position - characterToControl.transform.position;

        // If the X distance is greater than the Y distance, we will move on X,
        // otherwise, we move on Y.
        bool shouldMoveOnX = Mathf.Abs(distanceToTarget.x) > Mathf.Abs(distanceToTarget.y);

        int newPositionX = (int)characterToControl.transform.position.x; 
        int newPositionY = (int)characterToControl.transform.position.y;

        if (shouldMoveOnX)
        {
            if (distanceToTarget.x > 0)
                newPositionX = newPositionX + 1;
            else
                newPositionX = newPositionX - 1;
        }
        else
        {
            if (distanceToTarget.y > 0)
                newPositionY = newPositionY + 1;
            else
                newPositionY = newPositionY - 1;
        }

        var command = new MoveCommand(newPositionX, newPositionY);
        command.Execute(characterToControl);

        targetPreviousPosition = target.position;
    }
}
