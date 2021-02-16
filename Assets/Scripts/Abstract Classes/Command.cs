public abstract class Command 
{
    //A protected member is accessible within its class and by derived class instances.
    protected IEntity _entity;

    public Command(IEntity entity)
    {
        _entity = entity;
    }

    public abstract void Execute();
    public abstract void Undo();
}
