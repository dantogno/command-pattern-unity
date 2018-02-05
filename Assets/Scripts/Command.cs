public abstract class Command
{
    abstract public void Execute(ControllableCharacter character);
    abstract public void Undo(ControllableCharacter character);
}

