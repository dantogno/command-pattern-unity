using UnityEngine;

public class MoveCommand : Command
{
    private int x, y;
    private Vector2 previousPosition;

    /// <summary>
    /// Command for moving the character.
    /// </summary>
    /// <param name="x">X coordinate to move to.</param>
    /// <param name="y">Y coordinate to move to.</param>
    public MoveCommand(int  x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override void Execute(ControllableCharacter character)
    {
        previousPosition = character.transform.position;
        character.Move(x, y);
    }

    public override void Undo(ControllableCharacter character)
    {
        if(previousPosition != null)
            character.Move((int)previousPosition.x, (int)previousPosition.y);
    }
}
