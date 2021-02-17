using UnityEngine;

public class MoveCommand : Command
{

    private Vector3 _direction;
    private float _distance;

    public MoveCommand(IEntity entity, float time, Vector3 direction, float distance) : base(entity, time)
    {
        _direction = direction;
        _distance = distance;
        _time = time;
    }

    public override void Execute()
    {
        _entity.transform.Translate(_distance * _direction);
    }

    public override void Undo()
    {
        _entity.transform.Translate(-1f * _distance * _direction);
    }
}
