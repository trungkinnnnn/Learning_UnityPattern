
public interface IState<T>
{
    void Enter(T context);
    void Update(T context);    
    void Exit(T context);

    void Pause(T context) { }
    void Resume(T context) {  }
}
