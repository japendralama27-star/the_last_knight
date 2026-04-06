using UnityEngine;

public class Player_JumpState : Player_AiredState
{
    public Player_JumpState(Player player, StateMachine stateMachine, string animboolName) : base(player, stateMachine, animboolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(rb.linearVelocity.x, player.jumpforce);
    }
    public override void Update()
    {
        base.Update();

        //we need to be sure we are npt in jump attack state while we enter to fall state
        if (rb.linearVelocity.y < 0 && stateMachine.CurrentState != player.JumpAttackState)
        {

            audiomanager.PlaySFX(audiomanager.fall);
            stateMachine.ChangeState(player.fallState);
        }
    }
}
