
using System;

public class Transition<T>
{
    public IState<T> TargetState { get; }
    public Func<T, bool> Condition { get; }

    public Transition(IState<T> targetState, Func<T, bool> condition)
    {
        TargetState = targetState;
        Condition = condition;
    }
}
