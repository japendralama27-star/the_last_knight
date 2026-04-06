using UnityEngine;

public class Player_DeathState : PlayerState
{
    public Player_DeathState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        input.Disable();//disable input on death
        rb.simulated = false;//disable physics on death
    }
}
