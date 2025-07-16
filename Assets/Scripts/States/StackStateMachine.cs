
using System;
using System.Collections.Generic;

public class StackStateMachine<T>
{
    private readonly T context;
    private readonly List<Transition<T>> transitions = new();
    private readonly Stack<IState<T>> stateStack = new();

    public StackStateMachine(T context)
    {
        this.context = context;
    }

    public void PushState(IState<T> newState)
    {
        var currentState = stateStack.Count > 0 ? stateStack.Peek() : default;
        currentState?.Pause(context);

        stateStack.Push(newState);
        newState.Enter(context);
    }

    public void PopState()
    {
        if (stateStack.Count == 0) return;
        
        var popped = stateStack.Pop();
        popped.Exit(context);

        if(stateStack.Count > 0)
        {
            var resumed = stateStack.Peek();
            resumed.Resume(context);
        }    
    }

    public void AddTransition(Transition<T> transition)
    {
        transitions.Add(transition);
    }


    public void Update()
    {
        if(stateStack.Count == 0) return ;

        var currentState = stateStack.Peek();

        ITransitionBlocker<T> blocker = currentState as ITransitionBlocker<T>;

        if(blocker != null && blocker.BlockAllTransitions)
        {
            currentState.Update(context);
            return ;
        }

        foreach(var transition in transitions)
        {
            if(transition.Condition(context))
            {
                if (blocker != null && blocker.ShouldBlockTransition(transition.TargetState))
                    continue ;

                PushState(transition.TargetState);
                return ;
            }
        }

        currentState.Update(context);
    }

}
