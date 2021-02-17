public abstract class Command 
{
    //A protected member is accessible within its class and by derived class instances.
    protected IEntity _entity;
    protected float _time;

    public Command(IEntity entity, float time)
    {
        _entity = entity;
        _time = time;
    }

    public abstract void Execute();
    public abstract void Undo();

    public float GetTime()
    {
        return _time;
    }
}

