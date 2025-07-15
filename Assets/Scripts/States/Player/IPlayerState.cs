using UnityEngine;

public interface IPlayerState
{
    void Enter(PlayerController player);
    void Update();
    void Exit();
}
