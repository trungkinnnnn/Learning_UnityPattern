
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public float moveSpeed;
    public float jumpForce;
    public float dashForce;
    public float attackColdDown;
}
