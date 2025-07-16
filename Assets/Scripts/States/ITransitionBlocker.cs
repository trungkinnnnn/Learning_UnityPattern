
public interface ITransitionBlocker<T>
{
    bool BlockAllTransitions {  get; }
    bool ShouldBlockTransition(IState<T> targetState);
}
