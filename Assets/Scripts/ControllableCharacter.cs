using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableCharacter : MonoBehaviour
{
    /// <summary>
    /// Move the character to a new position.
    /// </summary>
    /// <param name="x">The x coordinate to move to.</param>
    /// <param name="y">The y coordinate to move to.</param>
    public void Move(int x, int y)
    {
        // In a real game we would probably have more specific rules about how the character moves.
        // For example, speed, collision, etc. This is meant to be a simple example!
        Vector3 newPosition = new Vector3(x, y, transform.position.z);
        transform.position = newPosition;
    }	
}
